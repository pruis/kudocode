﻿using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KudoCode.Web.Api.Controllers.Leads
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[TokenAuthentication]
	public class LeadController : Controller
	{
		private readonly IExecutionPipeline _executionPipeline;

		public LeadController(IExecutionPipeline executionPipeline)
			=> _executionPipeline = executionPipeline;

		[HttpPost]
		[Route("[action]")]
		public async Task<IApiResponseContextDto<int>> Create([FromBody] CreateLeadRequest request)
			=> await Task.Run(()=> _executionPipeline.Execute<CreateLeadRequest, int>(request));

		[HttpPost]
		[Route("[action]")]
		public async Task<IApiResponseContextDto<int>> Update([FromBody] UpdateLeadRequest request)
			=> _executionPipeline.Execute<UpdateLeadRequest, int>(request);

		[HttpPost]
		[Route("[action]")]
		public async Task<IApiResponseContextDto<GetLeadResponse>> GetSingle([FromBody] GetLeadRequest request)
			=> _executionPipeline.Execute<GetLeadRequest, GetLeadResponse>(request);

		[HttpPost]
		[Route("[action]")]
		public async Task<IApiResponseContextDto<List<GetLeadResponse>>> GetList([FromBody] GetListLeadRequest dto)
			=> _executionPipeline.Execute<GetListLeadRequest, List<GetLeadResponse>>(dto);
	}

}