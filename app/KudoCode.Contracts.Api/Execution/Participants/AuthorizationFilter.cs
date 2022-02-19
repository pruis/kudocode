using Autofac;
using log4net;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts.Api
{
	public class AuthorizationFilter<TRequestDto, TOut> : ExecutionPipelineFilter<TRequestDto, TOut>,
		IAuthorizationParticipant
	{
		private readonly ILog _log;
		private readonly ILifetimeScope _scope;

		public AuthorizationFilter(ILifetimeScope scope,
			ILog log) :
			base(scope)
		{
			_log = log;
			_scope = scope;
		}

		public override IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
		{
			var IsLoggedOnHandler = Scope.Resolve<IEnumerable<IHandler<TRequestDto, IAuthorizationContext<TOut>>>>()
				.First(a => a.GetType().Name.Contains("IsLoggedOn"));

			_log.Debug($"{_scope.Tag} - {this.GetType().Name} - {requestDto.GetType().Name} - start");
			IsLoggedOnHandler.Handle(requestDto);
			_log.Debug($"{_scope.Tag} - {this.GetType().Name} - {requestDto.GetType().Name} - start");

			return this;
		}
	}
}