using System.Linq;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Plugin.Interfaces;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Audit
{
    public class LeadAuditDefinition : IAuditDefinition<Lead>
    {
        public object GetAudit(Lead entity)
        {
            return new
            {
                LeadPersonalInformation = new
                {
                    entity.LeadPersonalInformation?.FirstName,
                    entity.LeadPersonalInformation?.Email,
                    entity.LeadPersonalInformation?.Age,
                    entity.LeadPersonalInformation?.Cellphone,
                    entity.LeadPersonalInformation?.CurrentAdvisorId,
                    entity.LeadPersonalInformation?.OccupationId,
                },
                entity.AgentId,
                AuthorizationGroups = new
                {
                    AuthorizationGroupIds = entity.AuthorizationGroups
                        ?.Select(a => new {AuthorizationGroupId = a.AuthorizationGroupId})
                        .ToList()
                }
            };
        }
    }
}