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
    public class FluentValidationFilter<TRequestDto, TOut> : ExecutionPipelineFilter<TRequestDto, TOut>
    {
        private readonly ILog _log;

        public FluentValidationFilter(ILifetimeScope scope, ILog log)
            : base(scope)
        {
            _log = log;
        }

        public override IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
        {
            var handler = Scope.Resolve<IHandler<TRequestDto, IValidationContext<TOut>>>();
            _log.Debug($"{Scope.Tag} - {handler.GetType().Name} - {requestDto.GetType().Name} - start");
            handler.Handle(requestDto);
            _log.Debug($"{Scope.Tag} - {handler.GetType().Name} - {requestDto.GetType().Name} - end");

            return this;
        }
    }
}