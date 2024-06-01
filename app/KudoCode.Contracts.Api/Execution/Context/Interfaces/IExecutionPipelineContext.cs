namespace KudoCode.Contracts.Api
{
	public interface IExecutionPipelineContext<TOut> :
        IValidationContext<TOut>,
        IAuthorizationContext<TOut>,
        IAuthenticationContext<TOut>,
        IWorkerContext<TOut>
    {
        //List<MessageDto> Messages { get; set; }
        //ArrayList Events { get; set; }
        //ArrayList Aggregates { get; set; }
        //void AddMessage(string key, string[] values = null);
        //void RaiseEvent<T>(T @event, params string[] queues) where T : IEventMetaData;

        //void RaiseAggregate<TAggRequest, TAggResponse>(TAggRequest dto, params string[] queues)
        //    where TAggRequest : IApiRequestDto;

        //bool HasErrors();
    }
}