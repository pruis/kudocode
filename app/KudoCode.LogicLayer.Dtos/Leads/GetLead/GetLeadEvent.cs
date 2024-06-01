using System.Collections.Generic;
using KudoCode.Contracts;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Dtos.Leads.GetLead
{
    public class GetLeadEventMessage : IEventMetaData
    {
        public GetLeadEventMessage()
        {
        }

        public int LeadId { get; set; }
        public string Message { get; set; }
    }

    public class TestEventMessage : IEventMetaData
    {
        public int LeadId { get; set; }
        public string Message { get; set; }
    }
}