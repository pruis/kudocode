using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Participants.Interfaces;
using KudoCode.Messaging.Infrastructure.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Participants
{
    public class AggregateFilter<TRequestDto, TOut> : ExecutionPipelineFilter<TRequestDto, TOut>
    {
        private IExecutionPipelineContext<TOut> _context;
        private readonly IApplicationUserContext _applicationUserContext;

        public AggregateFilter(IExecutionPipelineContext<TOut> context, ILifetimeScope scope, IApplicationUserContext applicationUserContext) : base(scope)
        {
            _context = context;
            _applicationUserContext = applicationUserContext;
        }

        public override IExecutionPipelineFilter<TRequestDto, TOut> Participate(TRequestDto requestDto)
        {
            if (!_context.Aggregates.ToArray().Any())
                return this;

            var authToken = _applicationUserContext.Token.Value;

            foreach (var @event in _context.Aggregates)
            {
                var e = @event as IEventRequestDto<IApiControllerRequestDto>;

                e.MetaData.AuthenticationToken = authToken;
                foreach (var queue in e.MetaData.Destination)
                    Scope.ResolveNamed<IEventManager>(queue).Send(@event);
            }

            return this;
        }
    }
}