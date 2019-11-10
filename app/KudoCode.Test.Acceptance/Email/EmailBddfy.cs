using KudoCode.Web.Api.Connector;
using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace KudoCode.Test.Acceptance.Email
{
    public class EmailBddfy
    {
        private Connector _connector;
        private IApiResponseContextDto<SendEmailResponse> _emailResonse;

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
        }

        public void When()
        {
            _emailResonse = _connector.EndPoint.Request<SendEmailRequest, SendEmailResponse>(new SendEmailRequest());
        }

        public void Then()
        {
            Assert.IsTrue(_emailResonse.Result.Id.Equals(1));
        }
    }
}