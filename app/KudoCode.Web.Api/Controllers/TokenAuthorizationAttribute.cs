using Autofac;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace KudoCode.Web.Api.Controllers
{

	public class TokenAuthenticationAttribute : TypeFilterAttribute
	{
		public TokenAuthenticationAttribute() : base(typeof(TokenAuthenticationFilter))
		{
		}
	}

	public class TokenAuthenticationFilter : IAuthorizationFilter
	{
		
		public readonly IExecutionPipeline _executionPipeline;
		private readonly ILifetimeScope _scope;

		public TokenAuthenticationFilter(ILifetimeScope scope)
		{
			_scope = scope;
			///_executionPipeline = executionPipeline;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{

			var result = _scope
				.ResolveKeyed<IExecutionPipeline>("ValidateToken")
				.Execute<ValidateTokenRequest, ValidateTokenResponse>(new ValidateTokenRequest());


			//var result = _executionPipeline
			//	.Execute<ValidateTokenRequest, ValidateTokenResponse>(new ValidateTokenRequest());
			if (result.Messages.Any(a => a.Key.Equals("E3")))
			{
				context.Result = new JsonResult(new { Error = "Authorization failed." })
				{
					StatusCode = StatusCodes.Status401Unauthorized
				};
			}
		}
	}
}