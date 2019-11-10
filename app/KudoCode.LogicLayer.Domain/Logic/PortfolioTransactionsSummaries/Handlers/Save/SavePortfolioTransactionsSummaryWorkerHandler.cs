using System;
using System.Globalization;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using Microsoft.Extensions.Configuration;

namespace KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Handlers.Save
{
    public class SavePortfolioTransactionsSummaryWorkerHandler : CommandHandler<SavePortfolioTransactionsSummaryRequest,
        PortfolioTransactionsSummary, int>
    {
        private readonly IConfiguration _configuration;

        public SavePortfolioTransactionsSummaryWorkerHandler(
            IMapper mapper,
            IRepository repository,
            ILifetimeScope scope,
            IConfiguration configuration,
            IWorkerContext<int> context)
            : base(mapper, repository, scope, context)
        {
            _configuration = configuration;
        }

        protected override void GetEntity()
        {
            Entity = Request.Id == 0
                ? new PortfolioTransactionsSummary()
                : Repository.GetOne<PortfolioTransactionsSummary>(a => a.Id == Request.Id);

            // if not resolved from the DB find parent the portfolio
            if (Entity.Id == 0)
                Entity.Portfolio = Request.PortfolioId == 0
                    ? Repository.GetOne<Portfolio>(a => a.Name.ToLower().Equals(Request.PortfolioName.ToLower()))
                    : Repository.GetOne<Portfolio>(a => a.Id == Request.PortfolioId);
            ;
        }

        protected override void ValidateEntity()
        {
            if (Entity.Id != 0) return;

            // Check if portfolio found
            if (Entity.Portfolio == null)
            {
                Context.AddMessage
                    ("E4", $"Portfolio not found {Request.PortfolioName}, {Request.PortfolioId}");
                return;
            }

            //check for duplicate details
            var any = Repository.GetIQueryable<PortfolioTransactionsSummary>();

            if (!string.IsNullOrWhiteSpace(Request.PortfolioName))
                any = any.Where(a => a.Portfolio.Name.ToLower().Equals(Request.PortfolioName.ToLower()));
            any = any.Where(a => a.OpenAmount == Request.OpenAmount);
            any = any.Where(a => a.CloseAmount == Request.CloseAmount);
            any = any.Where(a =>
                a.OpenDate == DateTime.Parse(Request.OpenDate,
                    CultureInfo.InvariantCulture));
            any = any.Where(a =>
                a.CloseDate == DateTime.Parse(Request.CloseDate,
                    CultureInfo.InvariantCulture));

            if (any.Any())
                Context.AddMessage("E6", "Duplicate PortfolioTransactionsSummary");
        }

        protected override void Execute()
        {
            Mapper.Map(Request, Entity);
            Repository.Save(Entity);
            Repository.SaveChanges();
            Context.Result = Entity.Id;
        }
    }
}