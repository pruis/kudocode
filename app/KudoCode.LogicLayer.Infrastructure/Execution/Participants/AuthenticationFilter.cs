using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Participants.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using log4net;
using System.Collections.Generic;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Participants
{
	public class AuthenticationFilter<TRequestDto, TOut> : ExecutionPipelineFilter<TRequestDto, TOut>,
		IAuthenticationParticipant
	{
		private readonly ILog _log;

		public AuthenticationFilter(ILifetimeScope scope, ILog log)
			: base(scope)
		{
			_log = log;
		}

		public override IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
		{
			var handlers = Scope.Resolve<IEnumerable<IHandler<TRequestDto, IAuthenticationContext<TOut>>>>();
			foreach (var handler in handlers)
			{
				_log.Debug($"{Scope.Tag} - {handler.GetType().Name} - {requestDto.GetType().Name} - start");
				handler.Handle(requestDto);
				_log.Debug($"{Scope.Tag} - {handler.GetType().Name} - {requestDto.GetType().Name} - end");
			}

			return this;
		}
	}
}