using Autofac;
using KudoCode.Contracts;
using System.Linq;

namespace KudoCode.Contracts.Api
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
                var e = @event as IEventRequestDto<ApiControllerRequestDto>;

                e.MetaData.AuthenticationToken = authToken;
                foreach (var queue in e.MetaData.Destination)
                    Scope.ResolveNamed<IEventManager>(queue).Send(@event);
            }

            return this;
        }
    }
}