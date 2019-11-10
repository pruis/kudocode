using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;

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