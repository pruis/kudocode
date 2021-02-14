using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Autofac;
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
	public class GetApplicationUserContextAuthenticationHandler<TRequestDto, TOut> : IHandler<TRequestDto, IAuthenticationContext<TOut>>
	{
		private readonly ISecondaryExecutionPipeline _executionPipeline;
		private readonly IApplicationUserContext _applicationUserContext;
		private readonly IMapper _mapper;
		private readonly ITokenCache _tokenCache;
		private readonly ILifetimeScope _scope;
		private IAuthenticationContext<TOut> Context;

		public GetApplicationUserContextAuthenticationHandler(IAuthenticationContext<TOut> context,
			ISecondaryExecutionPipeline executionPipeline,
			IApplicationUserContext applicationUserContext,
			IMapper mapper,
			ITokenCache tokenCache, ILifetimeScope scope)
		{
			Context = context;
			_executionPipeline = executionPipeline;
			_applicationUserContext = applicationUserContext;
			_mapper = mapper;
			_tokenCache = tokenCache;
			_scope = scope;
		}

		public IAuthenticationContext<TOut> Handle(TRequestDto request)
		{

			_scope.ResolveKeyed<IExecutionPipeline>("ValidateToken")
				.Execute<ValidateTokenRequest, ValidateTokenResponse>(new ValidateTokenRequest());
			
			if (_applicationUserContext.Token.IsValidTokenProvided == false)
			{
				return Context;
			}

			var response = _executionPipeline.Execute<GetApplicationUserDto, ApplicationUserDto>(
				new GetApplicationUserDto(_applicationUserContext.Email)).AttachResult(Context);

			_mapper.Map(response.Result, _applicationUserContext);

			return Context;
		}
	}
}