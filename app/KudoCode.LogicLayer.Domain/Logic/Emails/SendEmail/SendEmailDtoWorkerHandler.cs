using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Emails.SendEmail
{
    public class SendEmailDtoWorkerHandler : WorkerHandler<SendEmailRequest, SendEmailResponse>
    {
        public SendEmailDtoWorkerHandler(IMapper mapper,
            IComponentContext scope,
            IWorkerContext<SendEmailResponse> context)
            : base(mapper, scope, context)
        {
        }

        protected override void Execute()
        {
            if (Context.Result == null)
                Context.Result = new SendEmailResponse();
            Context.Result.Id = 1;
        }
    }
}