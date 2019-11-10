using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Infrastructure.Dtos.Requests
{
    public interface IApiControllerRequestDto : IEventMetaData
    {
        IApiRequestDto Request { get; set; }
        string ResponseType { get; set; }
        string AuthenticationToken { get; set; }
        List<string> Destination { get; set; }
    }

    public class ApiControllerRequestDto : IApiControllerRequestDto
    {
        public IApiRequestDto Request { get; set; }
        public string ResponseType { get; set; }
        public string AuthenticationToken { get; set; }
        public List<string> Destination { get; set; }
    }
}