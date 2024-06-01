using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.Contracts;

namespace KudoCode.LogicLayer.Domain.Logic.Emails.SendEmail
{
	public class SendEmailDtoAuthorizationHandler
        : AbstractAuthorizationHandler<SendEmailRequest, SendEmailResponse>
    {
        public SendEmailDtoAuthorizationHandler(
            IApplicationUserContext applicationUserContext,
            IAuthorizationContext<SendEmailResponse> context
        )
            : base(applicationUserContext, context)
        {
            AllowAnonymous = true;
            //IsLoggedIn();
        }
    }
}