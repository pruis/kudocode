using System;
using System.Collections.Generic;
using KudoCode.Web.Api.Connector;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace KudoCode.Test.Acceptance.Leads
{
	public class LeadsSearchBddfy
	{
		private Connector _connector;
		private IApiResponseContextDto<List<GetLeadResponse>> _searchByEmailResponseDto;
		private string _emailA = TestHelpers.UniqueName() + "@gmail.com";
		private string _emailB = TestHelpers.UniqueName() + "@hotmail.com";

		private string _firstName = $" {DateTime.Now.ToLongTimeString()}{DateTime.Now.Second}{DateTime.Now.Millisecond}Name".Replace(".","").Replace(":","").Replace(" ","");
		private IApiResponseContextDto<List<GetLeadResponse>> _searchByNameResponseDto;


		public void Search(Connector connector)
		{
			_connector = connector;
			this.Given(_ => GivenSavedLeads())
				.When(_ => WhenIFetchLeadsUsingEmail())
				.And(_ => WhenIFetchLeadsUsingName())
				.Then(_ => ThenTheResponseOnFetchIsSuccessful())
				.BDDfy();
		}

		public void GivenSavedLeads()
		{
			new LeadCreateBddfy().Params(_firstName, _emailA).Create(_connector);
			new LeadCreateBddfy().Params(_firstName,_emailB).Create(_connector);
		}
		
		public void WhenIFetchLeadsUsingEmail()
		{
			_searchByEmailResponseDto = _connector.Lead.GetList(new GetListLeadRequest() { Email = _emailA });
		}
		public void WhenIFetchLeadsUsingName()
		{
			_searchByNameResponseDto = _connector.Lead.GetList(new GetListLeadRequest() { Name = _firstName });
		}

		public void ThenTheResponseOnFetchIsSuccessful()
		{
			Assert.IsTrue(_searchByEmailResponseDto.Result.Count == 1);
			Assert.IsTrue(_searchByEmailResponseDto.Result[0].Email.Equals(_emailA));

			Assert.IsTrue(_searchByNameResponseDto.Result.Count == 2);
			Assert.IsTrue(_searchByNameResponseDto.Result[0].Name.Contains(_firstName));
			Assert.IsTrue(_searchByNameResponseDto.Result[1].Name.Contains(_firstName));
		}

	
	}
}