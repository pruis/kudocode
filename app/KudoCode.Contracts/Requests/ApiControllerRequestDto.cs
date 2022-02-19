using System.Collections.Generic;

namespace KudoCode.Contracts
{
	public interface IApiControllerRequestDto : IEventMetaData
    {
        string Request { get; set; }
        string ResponseType { get; set; }
        public string RequestType { get; set; }
        string AuthenticationToken { get; set; }
        List<string> Destination { get; set; }
    }

    public class ApiControllerRequestDto : IApiControllerRequestDto
    {
        public string Request { get; set; }
        public string ResponseType { get; set; }
        public string RequestType { get; set; }
        public string AuthenticationToken { get; set; }
        public List<string> Destination { get; set; }
    }

    public class UiControllerRequestDto 
    {
        public object Request { get; set; } = new { };
        public string ResponseType { get; set; }
        public string RequestType { get; set; }
    }

}