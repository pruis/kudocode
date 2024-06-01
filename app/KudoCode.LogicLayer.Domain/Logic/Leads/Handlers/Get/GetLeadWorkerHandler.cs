using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos;
using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Get
{
	public class GetLeadWorkerHandler
        : QueryHandler<GetLeadRequest, Lead, GetLeadResponse>, IRedisCacheQueryHandler
    {
        private readonly IApplicationUserContext _applicationUserContext;
        private readonly IDelegateContext _redisContext;
        private bool _redisLoaded;

        public GetLeadWorkerHandler(IMapper mapper,
            IApplicationUserContext applicationUserContext,
            IReadOnlyRepository repository,
            IWorkerContext<GetLeadResponse> context,
            IDelegateContext redisContext,
            ILifetimeScope scope
        )
            : base(mapper, repository, scope, context)
        {
            _applicationUserContext = applicationUserContext;
            _redisContext = redisContext;
        }

        protected override void GetEntity()
        {
           //Thread.Sleep(5000);

            _redisLoaded = _redisContext.Keys.Contains(RedisKey());

            if (!_redisLoaded)
                Entity = Repository.GetOne<Lead>
                (a => a.Id == Request.Id,
                 src => src
                     .Include(a => a.LeadPersonalInformation)
                     .Include(a => a.Agent)
                     .Include(a => a.LeadScheduledActivities)
                         .ThenInclude(x => x.Address)
                     .Include(a => a.LeadScheduledActivities)
                         .ThenInclude(x => x.LeadScheduledActivityType)
                );
        }

        protected override void ValidateEntity()
        {
            if (!_redisLoaded && Entity == null)
                Context.AddMessage("E4");
        }

        protected override void Execute()
        {
            if (!_redisLoaded)
            {
                Context.Result = Mapper.Map<GetLeadResponse>(Entity);
                Context.Result.ApplicationUserEmail = _applicationUserContext.Email;
            }

            Context.RaiseAggregate<SendEmailRequest,SendEmailResponse>(
                new SendEmailRequest()
                {
                    LeadId = Context.Result.Id,
                    ApplicationUserId = _applicationUserContext.Id
                },
                Constants.EventQueues.AggregateEventsQueue
            );
        }


        public string RedisKey() => $"{GetType().Name}_{typeof(Lead).Name}_{Entity?.Id.ToString()}";
    }
}