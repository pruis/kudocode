using System;
using System.Collections.Generic;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;

namespace KudoCode.Web.Infrastructure.Domain.Execution
{
    public class ApplicationContextHandler : IApplicationContextHandler
    {
        private readonly IStorage _storage;
        private readonly IApplicationUserContext _applicationUserContext;
        private readonly ITokenCache _tokenCache;
        private IMapper _mapper;

        public ApplicationContextHandler(
            IStorage storage,
            IApplicationUserContext applicationUserContext,
            IMapper mapper, ITokenCache tokenCache)
        {
            _storage = storage;
            _applicationUserContext = applicationUserContext;
            _mapper = mapper;
            _tokenCache = tokenCache;
        }

        /// <summary>
        /// Fetch from storage and populate IOC instance of IApplicationUserContext
        /// </summary>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public IApplicationUserContext FetchContext()
        {
            return !string.IsNullOrWhiteSpace(_applicationUserContext.Email)
                ? _applicationUserContext
                : FetchFromStorage();
        }

        /// <summary>
        /// Refreshes the Application User Context and Checks if a user context is available
        /// </summary>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public bool IsLoggedIn()
        {
            FetchContext();
            return !string.IsNullOrWhiteSpace(_applicationUserContext.Email);
        }

        private IApplicationUserContext FetchFromStorage()
        {
            var key = _tokenCache.Get();

            if (key == null)
                throw new KeyNotFoundException("user cookie key not found");

            var appUser = _storage.Get<ApplicationUserContext>(key) ?? new ApplicationUserContext();

            _mapper.Map(appUser, _applicationUserContext);
            return _applicationUserContext;
        }

        /// <summary>
        /// Set new IApplicationUserContext to storage and IOC for new login
        /// </summary>
        /// <param name="applicationUserContext"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public IApplicationUserContext SetContext(IApplicationUserContext applicationUserContext)
        {
            _mapper.Map(applicationUserContext, _applicationUserContext);
            var key = _tokenCache.Get();
            if (key == null)
                throw new KeyNotFoundException("user cookie key not found");
            _storage.Set(key, _applicationUserContext);
            return _applicationUserContext;
        }

        /// <summary>
        /// Removes IApplicationUserContext From Storage and IOC for logout
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        public void Destroy()
        {
            var key = _tokenCache.Get();
            if (key == null)
                throw new KeyNotFoundException("user cookie key not found");
            _storage.Remove(key);
            _mapper.Map(new ApplicationUserContext(), _applicationUserContext);
        }
    }
}