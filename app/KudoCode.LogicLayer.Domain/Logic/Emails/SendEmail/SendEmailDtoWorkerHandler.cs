using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Dtos.Emails;
using System;

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
                Context.Result = new SendEmailResponse() { Address = "XXXXXXXXXXXXXXXXXXX", Date= DateTime.Now};
            Context.Result.Id = Request.LeadId;
        }
    }
}