using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using System.Collections.Generic;
using System.Linq;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.GetList
{
	public class GetListPortfolioWorkerHandler : QueryHandler<GetListPortfolioRequest,
        List<Portfolio>, GetListPortfolioResponse>
    {
        public GetListPortfolioWorkerHandler(
            IMapper mapper,
            IReadOnlyRepository repository,
            ILifetimeScope scope,
            IWorkerContext<GetListPortfolioResponse> context)
            : base(mapper, repository, scope, context)
        {
        }

        protected override void GetEntity()
        {
            Entity = Repository.GetAll<Portfolio>().ToList();
        }

        protected override void ValidateEntity()
        {
        }

        protected override void Execute()
        {
            Context.Result = new GetListPortfolioResponse()
            {
                Portfolios = Mapper.Map<List<PortfolioResponse>>(Entity)
            };
        }
    }
}