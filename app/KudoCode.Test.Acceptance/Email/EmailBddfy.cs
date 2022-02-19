using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.Web.Api.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace KudoCode.Test.Acceptance.Email
{
	public class EmailBddfy
    {
        private Connector _connector;
        private IApiResponseContextDto<SendEmailResponse> _emailResonse;
		private SendEmailRequest _request;

		public void Get(Connector connector)
        {
            _connector = connector;
            this.Given(_ => Given())
                .When(_ => When())
                .Then(_ => Then())
                .BDDfy();
        }

        public void Given()
        {
            _request = new SendEmailRequest() { LeadId = 10 };
        }

        public void When()
        {
            _emailResonse = _connector.EndPoint.Request<SendEmailRequest, SendEmailResponse>(_request);
        }

        public void Then()
        {
            Assert.IsTrue(_emailResonse.Result.Id.Equals(_request.LeadId));
        }
    }
}