using Autofac;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Domain.Logic.Lookups.Entities;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioShares.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsConsolidations.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsTypes.Entities;
using KudoCode.Contracts.Api;
using Microsoft.EntityFrameworkCore;
using System;

namespace KudoCode.Test.Unit.InMemoryDataBase
{
    public static class SeedDataBase
    {
        public static int CreateLead(string email)
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            {
                using (var context = scope.Resolve<DbContext>())
                {
                    var lead = new Lead()
                    {
                        AgentId = 1,
                        Email = email,
                        Name = "test test",
                        LeadPersonalInformation = new LeadPersonalInformation
                        {
                            FirstName = "test",
                            Surname = "test",
                            Email = email,
                            CurrentAdvisorId = 1,
                            GenderId = 1,
                            OccupationId = 1
                        }
                    };

                    context.Add(lead);
                    context.SaveChanges();
                    return lead.Id;
                }
            }
        }

        public static int CreatePortfolio(string name, DateTime openDate)
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            {
                using (var context = scope.Resolve<DbContext>())
                {
                    var entity = new Portfolio()
                    {
                        Name = name,
                        OpenDate = openDate
                    };

                    context.Add(entity);
                    context.SaveChanges();
                    return entity.Id;
                }
            }
        }

        public static int CreatePortfolioShare(string description)
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            {
                using (var context = scope.Resolve<DbContext>())
                {
                    var entity = new PortfolioShare()
                    {
                        Description = description,
                    };

                    context.Add(entity);
                    context.SaveChanges();
                    return entity.Id;
                }
            }
        }

        public static int CreatePortfolioTransactionType(string description)
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            {
                using (var context = scope.Resolve<DbContext>())
                {
                    var entity = new PortfolioTransactionType()
                    {
                        Description = description,
                        Id = 1
                    };

                    context.Add(entity);
                    context.SaveChanges();
                    return entity.Id;
                }
            }
        }

        public static int CreatePortfolioTransactionSummary(int portfolioId)
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            {
                using (var context = scope.Resolve<DbContext>())
                {
                    var entity = new PortfolioTransactionsSummary()
                    {
                        PortfolioId = portfolioId,
                        CloseAmount = 10,
                        OpenAmount = 11,
                        CloseDate = DateTime.Now,
                        OpenDate = DateTime.Now.AddDays(-21),
                    };

                    context.Add(entity);
                    context.SaveChanges();
                    return entity.Id;
                }
            }
        }

        public static int GetPortfolioTransaction(int portfolioId)
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            {
                using (var context = scope.Resolve<DbContext>())
                {
                    var entity = new PortfolioTransaction()
                    {
                        PortfolioId = portfolioId,
                        Date = DateTime.Now,
                        Price = 11.4m,
                        Quantity = 2342,
                        PortfolioShareId = 1,
                        PortfolioTransactionTypeId = 1,
                        Total = 434,
                        ModifiedDate = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = "",
                        CreatedBy = "",
                    };

                    context.Add(entity);
                    context.SaveChanges();
                    return entity.Id;
                }
            }
        }

        public static int CreatePortfolioTransactionsConsolidation(int summaryId)
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            {
                using (var context = scope.Resolve<DbContext>())
                {
                    var entity = new PortfolioTransactionsConsolidation()
                    {
                        PortfolioTransactionsSummaryId = summaryId,
                    };

                    context.Add(entity);
                    context.SaveChanges();
                    return entity.Id;
                }
            }
        }


        public static void DropAndCreate()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            using (var context = scope.Resolve<DbContext>())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        public static void Drop()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            using (var context = scope.Resolve<DbContext>())
                context.Database.EnsureCreated();
        }

        public static void InitializeDataBase()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope())
            {
                using (var context = scope.Resolve<DbContext>())
                {
                    //if ((context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    //	return;

                    //context.Database.EnsureDeleted();
                    //context.Database.EnsureCreated();

                    var organization = new EntityOrganization()
                    { Name = "Default", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };

                    var adminRole = new AuthorizationRole() { Id = 1, Name = "Administrator", EntityOrganization = organization };
                    var agentRole = new AuthorizationRole() { Id = 2, Name = "Agent", EntityOrganization = organization };
                    var advisorRole = new AuthorizationRole() { Id = 3, Name = "Advisor", EntityOrganization = organization };
                    var workflowRole = new AuthorizationRole() { Id = 4, Name = "Workflow", EntityOrganization = organization };

                    var authorizationGroupA = new AuthorizationGroup()
                    { Id = 1, Name = "Group A", EntityOrganization = organization };
                    var authorizationGroupB = new AuthorizationGroup()
                    { Id = 2, Name = "Group B", EntityOrganization = organization };

                    var applicationUser = new ApplicationUser()
                    {
                        Name = "Default",
                        Email = "testB@testC.com",
                        Password = "\u001f\r?????\u001e\u0016kt??#?\u0014?F??\u0014\u0018S?Ar??36??",
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };
                    var workflowUser = new ApplicationUser()
                    {
                        Name = "Workflow",
                        Email = "work@flow.com",
                        Password = "\u001f\r?????\u001e\u0016kt??#?\u0014?F??\u0014\u0018S?Ar??36??",
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ActiveEntityOrganization = organization,
                    };

                    var currentAdvisor = new CurrentAdvisor()
                    { Id = 1, Description = "Advisor A", EntityOrganization = organization };
                    var gender = new Gender() { Id = 1, Description = "Male", EntityOrganization = organization };
                    var occupation = new Occupation()
                    { Id = 1, Description = "Unemployed", EntityOrganization = organization };
                    var addressType = new AddressType()
                    { Id = 1, Description = "Complex", EntityOrganization = organization };
                    var phonecallActivityType = new LeadScheduledActivityType()
                    { Id = 1, Description = "Phone Call", EntityOrganization = organization };
                    var meetingActivityType = new LeadScheduledActivityType()
                    { Id = 2, Description = "Meeting", EntityOrganization = organization };




                    applicationUser.AddEntityOrganization(organization);
                    applicationUser.ActiveEntityOrganization = organization;
                    applicationUser.AddAuthorizationGroup(authorizationGroupA);
                    applicationUser.AuthorizationRole = adminRole;
                    context.Add(applicationUser);
                    context.Add(workflowUser);
                    context.Add(currentAdvisor);
                    context.Add(gender);
                    context.Add(occupation);
                    context.Add(addressType);
                    context.Add(phonecallActivityType);
                    context.Add(meetingActivityType);
                    context.Add(authorizationGroupA);
                    context.Add(authorizationGroupB);

                    context.Add(agentRole);
                    context.Add(advisorRole);
                    context.Add(workflowRole);

                    context.SaveChanges();
                }
            }
        }
    }
}