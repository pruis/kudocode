using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace KudoCode.LogicLayer.Infrastructure
{
    public class AuthenticationHandler<TRequestDto, TOut> : IHandler<TRequestDto, IAuthenticationContext<TOut>>
    {
        private readonly ISecondaryExecutionPipeline _executionPipeline;
        private readonly IApplicationUserContext _applicationUserContext;
        private readonly IMapper _mapper;
        private readonly ITokenCache _tokenCache;
        private IAuthenticationContext<TOut> Context;

        public AuthenticationHandler(IAuthenticationContext<TOut> context,
            ISecondaryExecutionPipeline executionPipeline,
            IApplicationUserContext applicationUserContext,
            IMapper mapper,
            ITokenCache tokenCache)
        {
            Context = context;
            _executionPipeline = executionPipeline;
            _applicationUserContext = applicationUserContext;
            _mapper = mapper;
            _tokenCache = tokenCache;
        }

        public IAuthenticationContext<TOut> Handle(TRequestDto request)
        {
            var token = _tokenCache.Get();

            if (string.IsNullOrEmpty(token))
            {
                Context.AddMessage("W3");
                Context.IsValidTokenProvided = false;
                return Context;
            }

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, ValidateAudience = true, ValidateLifetime = true, ValidateIssuerSigningKey = true, ValidIssuer = "Fiver.Security.Bearer", ValidAudience = "Fiver.Security.Bearer", IssuerSigningKey = JwtSecurityKey.Create("fiver-secret-key")
            };

            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token, validationParameters, out var validatedToken);

            var email = principal.Claims.ToList()[0].Value;
            _applicationUserContext.Token = new TokenDto(token, validatedToken.ValidTo);
            _applicationUserContext.Email = email;

            var response = _executionPipeline.Execute<GetApplicationUserDto, ApplicationUserDto>(
                new GetApplicationUserDto(email));

            _mapper.Map(response.Result, _applicationUserContext);

            Context.IsValidTokenProvided = true;
            return Context;
        }
    }
}