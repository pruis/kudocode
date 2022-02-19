using KudoCode.Contracts;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.Web.Api.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;

namespace KudoCode.Test.Acceptance.Leads
{
	public class GetLeadsBddfy
    {
        private Connector _connector;
        private IApiResponseContextDto<List<GetLeadResponse>> _searchByEmailResponseDto;

        public void Get(Connector connector)
        {
            _connector = connector;
            this.Given(_ => GivenSavedLeads())
                .When(_ => WhenIFetchLeadsUsingEmail())
                .Then(_ => ThenTheResponseOnFetchIsSuccessful())
                .BDDfy();
        }

        public void GivenSavedLeads()
        {
            for (int i = 0; i < 3; i++)
            {
                var name = TestHelpers.UniqueName();
                new LeadCreateBddfy().Params(name, $"{name}@gmail.com").Create(_connector);
            }
        }

        public void WhenIFetchLeadsUsingEmail()
        {
            _searchByEmailResponseDto = _connector.Lead.GetList(new GetListLeadRequest() { });
        }

        public void ThenTheResponseOnFetchIsSuccessful()
        {
            Assert.IsTrue(_searchByEmailResponseDto.Result.Any());
        }
    }
}