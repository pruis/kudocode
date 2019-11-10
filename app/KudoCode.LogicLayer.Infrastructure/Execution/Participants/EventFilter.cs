using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.Messaging.Infrastructure.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Participants.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Participants
{
	public class EventFilter<TRequestDto, TOut> : ExecutionPipelineFilter<TRequestDto, TOut>
	{
		private IExecutionPipelineContext<TOut> _context;

		public EventFilter(IExecutionPipelineContext<TOut> context,ILifetimeScope scope) : base(scope)
		{
			_context = context;
		}

		public override IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
		{
			if (!_context.Events.ToArray().Any())
				return this;

			foreach (var @event in _context.Events)
				foreach (var source in (@event as IEventRequestSources).Queues)
					Scope.ResolveNamed<IEventManager>(source).Send(@event);

			return this;
		}
	}
}
