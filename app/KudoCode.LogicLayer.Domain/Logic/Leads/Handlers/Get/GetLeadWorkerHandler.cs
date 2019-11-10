using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Dtos;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Plugin.Redis.Infrastructure;

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
            _redisLoaded = _redisContext.Keys.Contains(RedisKey());

            if (!_redisLoaded)
                Entity = Repository.GetOne<Lead>
                (a => a.Id == Request.Id, "LeadPersonalInformation," +
                                          "Agent," +
                                          "LeadScheduledActivities" +
                                          ",LeadScheduledActivities.Address" +
                                          ",LeadScheduledActivities.LeadScheduledActivityType"
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