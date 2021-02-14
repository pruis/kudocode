using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

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
            IsLoggedIn();
        }
    }
}