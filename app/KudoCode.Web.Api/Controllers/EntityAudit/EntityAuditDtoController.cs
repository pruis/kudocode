using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KudoCode.Web.Api.Controllers.EntityAudit
{
	[Produces("application/json")]
    [Route("api/[controller]")]
    public class EntityAuditController : Controller
    {
        private readonly IExecutionPipeline _executionPipeline;

        public EntityAuditController(IExecutionPipeline executionPipeline)
        {
            _executionPipeline = executionPipeline;
        }

        [HttpPost]
        [Route("[action]")]
        public IApiResponseContextDto<int> Create([FromBody] CreateEntityAuditDto createEntityAuditDto)
        {
            return _executionPipeline.Execute<ICreateEntityAuditDto, int>(createEntityAuditDto);
        }
    }
}