using AutoMapper;
using KudoCode.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace KudoCode.Contracts.Api
{
	public class ValidateTokenAuthenticationHandler : IHandler<ValidateTokenRequest, IAuthenticationContext<ValidateTokenResponse>>,
			IAbstractHandler<ValidateTokenRequest, ValidateTokenResponse>
	{
		private readonly ISecondaryExecutionPipeline _executionPipeline;
		private readonly IApplicationUserContext _applicationUserContext;
		private readonly IMapper _mapper;
		private readonly ITokenCache _tokenCache;
		private IAuthenticationContext<ValidateTokenResponse> Context;

		public ValidateTokenAuthenticationHandler(IAuthenticationContext<ValidateTokenResponse> context,
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

		public ValidateTokenRequest Request { get; set; }

		IWorkerContext<ValidateTokenResponse> IAbstractHandler<ValidateTokenRequest, ValidateTokenResponse>.Context => throw new System.NotImplementedException();

		public IAuthenticationContext<ValidateTokenResponse> Handle(ValidateTokenRequest request)
		{
			var token = _tokenCache.Get();

			if (string.IsNullOrEmpty(token))
			{
				Context.AddMessage("W3");
				_applicationUserContext.Token.IsValidTokenProvided = false;
				return Context;
			}

			var validationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = "Fiver.Security.Bearer",
				ValidAudience = "Fiver.Security.Bearer",
				IssuerSigningKey = JwtSecurityKey.Create("fiver-secret-key")
			};

			System.Security.Claims.ClaimsPrincipal principal = null;
			SecurityToken validatedToken = null;

			try
			{
				principal = new JwtSecurityTokenHandler()
								.ValidateToken(token, validationParameters, out validatedToken);
			}
			catch (SecurityTokenValidationException)
			{
				Context.AddMessage("E3", "Invalid Token");
				return Context;
			}

			var email = principal.Claims.ToList()[0].Value;
			_applicationUserContext.Token = new TokenDto(token, validatedToken.ValidTo);
			_applicationUserContext.Email = email;
			_applicationUserContext.Token.IsValidTokenProvided = true;

			return Context;
		}
	}
}