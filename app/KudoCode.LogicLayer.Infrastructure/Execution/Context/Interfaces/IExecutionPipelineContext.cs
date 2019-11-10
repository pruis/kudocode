using System.Collections;
using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces
{
    public interface IExecutionPipelineContext<TOut> :
        ICustomValidationContext<TOut>,
        IValidationContext<TOut>,
        IAuthorizationContext<TOut>,
        IAuthenticationContext<TOut>,
        IWorkerContext<TOut>
    {
        List<MessageDto> Messages { get; set; }
        ArrayList Events { get; set; }
        ArrayList Aggregates { get; set; }
        void AddMessage(string key, string[] values = null);
        void RaiseEvent<T>(T @event, params string[] queues) where T : IEventMetaData;

        void RaiseAggregate<TAggRequest, TAggResponse>(TAggRequest dto, params string[] queues)
            where TAggRequest : IApiRequestDto;

        bool HasErrors();
    }
}