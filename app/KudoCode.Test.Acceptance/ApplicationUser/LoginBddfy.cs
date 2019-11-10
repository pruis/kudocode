using System;
using System.Threading;
using KudoCode.Web.Api.Connector;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace KudoCode.Test.Acceptance.ApplicationUser
{
	public class LoginBddfy
	{
		private string _email;
		private int _leadId;
		private Connector _connector;
		private IApiResponseContextDto<ApplicationUserContext> _loginResponse;
		private IApiResponseContextDto<GetLeadResponse> _leadResponse;

		public void Get(Connector connector, string email, int leadId)
		{
			_email = email;
			_leadId = leadId;
			_connector = connector;
			this.Given(_ => Given())
				.When(_ => When())
				.Then(_ => Then())
				.BDDfy();
		}

		public void Given()
		{
			_loginResponse = _connector.Authentication.GetToken(new GetTokenRequest() { Email = _email, Password = "1234" });
			Assert.IsNotNull(_loginResponse.Result);
		}

		public void When()
		{

			_leadResponse = _connector.Lead.GetSingle(new GetLeadRequest() { Id = _leadId });
		}

		public void Then()
		{
			Assert.IsTrue(_loginResponse.Result.Email.Equals(_email));
			Assert.IsTrue(_leadResponse.Result.ApplicationUserEmail.Equals(_email));
		}
	}
}