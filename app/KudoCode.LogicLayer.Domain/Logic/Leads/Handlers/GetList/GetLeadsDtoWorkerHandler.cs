using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.GetList
{
    public class GetLeadsDtoWorkerHandler : QueryHandler<GetListLeadRequest, List<Lead>, List<GetLeadResponse>>
    {
        protected override void GetEntity()
        {
            var q = Repository.GetIQueryable<Lead>(null, "LeadPersonalInformation");

            if (!string.IsNullOrWhiteSpace(Request.Email))
                q = q.Where(a => a.Email.Contains(Request.Email));

            if (!string.IsNullOrWhiteSpace(Request.Name))
                q = q.Where(a => a.Name.Contains(Request.Name));

            Entity = q.ToList();
        }

        protected override void Execute()
        {
            Context.Result = Mapper.Map<List<GetLeadResponse>>(Entity);
        }

        protected override void ValidateEntity()
        {
        }

        public GetLeadsDtoWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            IComponentContext scope,
            IWorkerContext<List<GetLeadResponse>> context) : base(mapper, repository, scope, context)
        {
        }
    }
}