using System.Collections.Generic;
using System.Linq;

namespace KudoCode.Contracts
{
    public class LookupResponse : ILookupDto
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int OranizationId { get; set; }
        public string Description { get; set; }
    }

    public interface IGetLookupResponse
    {
        List<LookupResponse> Lookups { get; set; }
    }

    public class GetLookupResponse : IGetLookupResponse
    {
        public GetLookupResponse()
        {
            Lookups = new List<LookupResponse>();
        }
        public List<LookupResponse> Lookups { get; set; }
   }


    public interface ILookupDto
    {
    }


    public class GetLookupRequest : IApiRequestDto
    {
        public GetLookupRequest(LookupRequest[] lookups)
        {
            Lookups = new List<LookupRequest>(lookups);
        }

        public List<LookupRequest> Lookups { get; set; }
    }

    public class LookupRequest
    {
        public LookupRequest()
        {
            Key = "Id";
            Value = "Description";
        }

        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Filter { get; set; }
    }
    public class LookupDto
    {
        public LookupDto()
        {
        }

        public int Id { get; set; }
        public string Value { get; set; }
    }
}