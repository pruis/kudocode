using Autofac;
using log4net;
using System.Collections.Generic;

namespace KudoCode.Contracts.Api
{
	public class WorkerFilter<TRequestDto, TOut> : ExecutionPipelineFilter<TRequestDto, TOut>
    {
        private readonly ILog _log;

        public WorkerFilter(ILifetimeScope scope, ILog log) : base(scope)
        {
            _log = log;
        }

        public override IExecutionPipelineFilter<TRequestDto, TOut>
            Participate(TRequestDto requestDto)
        {
            var handlers = Scope.Resolve<IEnumerable<IHandler<TRequestDto, IWorkerContext<TOut>>>>();
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