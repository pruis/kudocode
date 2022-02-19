using Autofac;
using KudoCode.Helpers;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts.Api
{
	public class ExecutionPipelineContext<TResponse> :
        IExecutionPipelineContext<TResponse>
    {
        public ExecutionPipelineContext(IApplicationUserContext applicationUserContext)
        {
            Messages = new List<MessageDto>();
            Events = new ArrayList();
            Aggregates = new ArrayList();
            _applicationUserContext = applicationUserContext;
        }

		private static int _id;
        private readonly IApplicationUserContext _applicationUserContext;

        public ArrayList Events { get; set; }
        public ArrayList Aggregates { get; set; }
        public TResponse Result { get; set; }
        public List<MessageDto> Messages { get; set; }

        public void AddMessage(string key, params string[] values)
        {
            var error = ApplicationContext.Container
                .Resolve<IMessageCollection>()
                .Messages
                .FirstOrDefault(a => a.Key == key);

            if (error == null)
                throw new KeyNotFoundException($"Missing KEY: {key}");

            if (values != null && values.Length > 0)
                error.Message = string.Format(error.Message, values);
            Messages.Add(error);
        }

        public bool HasErrors()
        {
            return Messages.Any(a => a.Type == MessageDtoType.Error);
        }

        public bool IsLoggedOn()
        {
            return !string.IsNullOrEmpty(_applicationUserContext.Email)
                   && _applicationUserContext.Token.IsValidTokenProvided
                   && !string.IsNullOrWhiteSpace(_applicationUserContext.Token?.Value);
        }


        public void RaiseEvent<T>(T @event, params string[] queues)
            where T : IEventMetaData
        {
            var eventRequestDto = ApplicationContext.Container.Resolve<IEventRequestDto<T>>();
            eventRequestDto.Queues = queues.ToList();
            eventRequestDto.MetaData = @event;
            Events.Add(eventRequestDto);
        }

        public void RaiseAggregate<TAggRequest,TAggResponse>(TAggRequest dto, params string[] queues)
            where TAggRequest : IApiRequestDto
        {
            var request = new ApiControllerRequestDto()
            {
                Request = JsonConvert.SerializeObject(dto, Json.Serialization.Auto()),
                RequestType = typeof(TAggRequest).Name,
                ResponseType = typeof(TAggResponse).Name,
                Destination = queues.ToList()
            };

            var eventRequestDto = ApplicationContext.Container.Resolve<IEventRequestDto<ApiControllerRequestDto>>();
            eventRequestDto.Queues = queues.ToList();
            eventRequestDto.MetaData = request;
            Events.Add(eventRequestDto);

            Aggregates.Add(eventRequestDto);
        }
    }
}