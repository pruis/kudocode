using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KudoCode.Web.Api.Controllers.Leads
{
	[TokenAuthentication]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LeadScheduledActivityController : Controller
    {
        private readonly ExecutionPipeline _executionPlan;

        public LeadScheduledActivityController(ExecutionPipeline executionPlan)
        {
            _executionPlan = executionPlan;
        }

        [HttpPost]
        [Route("[action]")]
        public IApiResponseContextDto<int> Create([FromBody] CreateGetLeadScheduledActivityRequest request)
        {
            var result = _executionPlan.Execute<CreateGetLeadScheduledActivityRequest, int>(request);
            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public IApiResponseContextDto<int> Update([FromBody] UpdateGetLeadScheduledActivityRequest request)
        {
            var result = _executionPlan.Execute<UpdateGetLeadScheduledActivityRequest, int>(request);
            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public IApiResponseContextDto<GetLeadScheduledActivityResponse> GetOne(
            [FromBody] GetLeadScheduledActivityRequest request)
        {
            var result =
                _executionPlan.Execute<GetLeadScheduledActivityRequest, GetLeadScheduledActivityResponse>(request);
            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public IApiResponseContextDto<List<GetLeadScheduledActivityResponse>> GetList(
            [FromBody] GetListLeadScheduledActivityRequest dto)
        {
            var result = _executionPlan
                .Execute<GetListLeadScheduledActivityRequest, List<GetLeadScheduledActivityResponse>>(dto);
            return result;
        }
    }
}