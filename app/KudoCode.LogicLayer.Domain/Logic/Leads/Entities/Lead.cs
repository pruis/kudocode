using KudoCode.Contracts.Api;
using System;
using System.Collections.Generic;


namespace KudoCode.LogicLayer.Domain.Logic.Leads.Entities
{
	public class Lead : IEntity,
            IEntityBasicAudit//,
           //IBelongToAuthorizationGroups<LeadAuthorizationGroupMap>, ILookup
        //,IBelongToApplicationUser
    {
        public Lead()
        {
            LeadScheduledActivities = new List<LeadScheduledActivity>();
            AuthorizationGroups = new List<LeadAuthorizationGroupMap>();
        }

        public int Id { get; set; }

        // Map from LeadPersonalInformation in AutoMapper
        public string Email { get; set; }
        public string Name { get; set; }

        public LeadPersonalInformation LeadPersonalInformation { get; set; }
        public List<LeadScheduledActivity> LeadScheduledActivities { get; set; }

        public int AgentId { get; set; }
        public ApplicationUser Agent { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public List<LeadAuthorizationGroupMap> AuthorizationGroups { get; set; }
    }
}