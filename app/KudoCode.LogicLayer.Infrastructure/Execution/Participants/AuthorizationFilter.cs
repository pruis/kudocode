using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Participants.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using log4net;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Participants
{
    public class AuthorizationFilter<TRequestDto, TOut> : ExecutionPipelineFilter<TRequestDto, TOut>,
        IAuthorizationParticipant
    {
        private readonly ILog _log;

        public AuthorizationFilter(ILifetimeScope scope,
            ILog log) :
            base(scope)
        {
            _log = log;
        }

        public override IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
        {
            var handler = Scope.Resolve<IHandler<TRequestDto, IAuthorizationContext<TOut>>>();
            if (handler == null)
                throw new System.NotImplementedException(
                    $"Authorization Handler not implemented for: {typeof(TRequestDto)}, {typeof(TOut)}");

            _log.Debug($"{Scope.Tag} - {handler.GetType().Name} - {requestDto.GetType().Name} - start");
            handler.Handle(requestDto);
            _log.Debug($"{Scope.Tag} - {handler.GetType().Name} - {requestDto.GetType().Name} - end");

            return this;
        }
    }
}