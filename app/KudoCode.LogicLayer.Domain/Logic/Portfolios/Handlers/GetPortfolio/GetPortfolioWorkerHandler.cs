using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.LogicLayer.Domain.Logic.Portfolios.Handlers.GetPortfolio
{
	public class GetPortfolioWorkerHandler : QueryHandler<GetPortfolioRequest,
		Portfolio, GetPortfolioResponse>
	{
		public GetPortfolioWorkerHandler(
			IMapper mapper,
			IReadOnlyRepository repository,
			ILifetimeScope scope,
			IWorkerContext<GetPortfolioResponse> context)
			: base(mapper, repository, scope, context)
		{
		}

		protected override void GetEntity()
		{
			Entity = Request.Id > 0
				? Repository.GetOne<Portfolio>(a => a.Id == Request.Id,
				src => src
				.Include(a => a.Accounts)
				.Include(a => a.TransactionsSummaries)
				.Include(a => a.Transactions)
					.ThenInclude(a => a.PortfolioTransactionType)
				.Include(a => a.Transactions)
					.ThenInclude(a => a.PortfolioShare)
					)
				: new Portfolio();
		}

		protected override void ValidateEntity()
		{
			if (Entity == null)
				Context.AddMessage("E4", $"Portfolio with id {Request.Id}");
		}

		protected override void Execute()
		{
			Context.Result = Mapper.Map<GetPortfolioResponse>(Entity);
		}
	}
}