﻿using Autofac;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Domain.Logic.Lookups.Entities;
using KudoCode.LogicLayer.Domain.Logic.Portfolios.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioShares.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactions.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsSummaries.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsTypes.Entities;
using KudoCode.Contracts.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using KudoCode.Abstract.Application;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace KudoCode.Web.Api
{
	public static class MockDataBase
	{
		internal static void InitializeDataBase()
		{
			using (var scope = ApplicationContext.Container.BeginLifetimeScope("ExecutionPipeline"))
			{
				using (var context = scope.Resolve<DbContext>())
				{

					if ((context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
					{
						//context.Database.Migrate();
						return;
					}

					context.Database.EnsureDeleted();
					context.Database.EnsureCreated();

					var organization = new EntityOrganization()
					{ Name = "Default", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now };

					var adminRole = new AuthorizationRole() { Id = 1, Name = "Administrator", EntityOrganization = organization };
					var agentRole = new AuthorizationRole() { Id = 2, Name = "Agent", EntityOrganization = organization };
					var advisoryRole = new AuthorizationRole() { Id = 3, Name = "Advisor", EntityOrganization = organization };
					var workflowRole = new AuthorizationRole() { Id = 4, Name = "Workflow", EntityOrganization = organization };

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
						ModifiedDate = DateTime.Now
					};
					var schedulerFlowUser = new ApplicationUser()
					{
						Name = "Scheduler",
						Email = "scheduler@flow.com",
						Password = "\u001f\r?????\u001e\u0016kt??#?\u0014?F??\u0014\u0018S?Ar??36??",
						CreatedDate = DateTime.Now,
						ModifiedDate = DateTime.Now
					};

					var currentAdviser = new CurrentAdvisor()
					{ Id = 1, Description = "Advisor A", EntityOrganization = organization };
					var genderA = new Gender() { Id = 1, Description = "Male", EntityOrganization = organization };
					var genderB = new Gender() { Id = 2, Description = "Female", EntityOrganization = organization };
					var occupation = new Occupation()
					{ Id = 1, Description = "Unemployed", EntityOrganization = organization };
					var addressType = new AddressType()
					{ Id = 1, Description = "Complex", EntityOrganization = organization };
					var phoneCallActivityType = new LeadScheduledActivityType()
					{ Id = 1, Description = "Phone Call", EntityOrganization = organization };
					var meetingActivityType = new LeadScheduledActivityType()
					{ Id = 2, Description = "Meeting", EntityOrganization = organization };

					var authorizationGroupA = new AuthorizationGroup()
					{ Id = 1, Name = "Group A", EntityOrganization = organization };
					var authorizationGroupB = new AuthorizationGroup()
					{ Id = 2, Name = "Group B", EntityOrganization = organization };


					var portfolioTransactionTypeOpen = new PortfolioTransactionType()
					{
						Id = 1,
						Description = "Open",
					};

					var portfolioTransactionTypeClose = new PortfolioTransactionType()
					{
						Id = 2,
						Description = "Close",
					};

					var portfolioShareA = new PortfolioShare()
					{
						Description = "ABC short",
						Code = "ABC"
					};
					var portfolioShareB = new PortfolioShare()
					{
						Description = "XYZ short",
						Code = "XXZ"
					};


					context.Add(portfolioTransactionTypeClose);
					context.Add(portfolioTransactionTypeOpen);

					var portfolios = new List<Portfolio>()
					{
						new Portfolio() {OpenDate = DateTime.Now, Name = "Test A"},
						new Portfolio() {OpenDate = DateTime.Now, Name = "Test B"},
						new Portfolio() {OpenDate = DateTime.Now, Name = "Test C"},
						new Portfolio() {OpenDate = DateTime.Now, Name = "Test D"},
					};

					foreach (var portfolio in portfolios)
					{
						var summaryDate = DateTime.Now;
						for (int i = 0; i < 10; i++)
						{
							var summary = new PortfolioTransactionsSummary()
							{
								CloseAmount = (decimal)new Random(i).NextDouble() *
											  ((decimal)new Random(i).NextDouble() * 10),
								OpenAmount =
									(decimal)new Random(i).NextDouble() * ((decimal)new Random(i).NextDouble() * 10),
								CloseDate = summaryDate,
								OpenDate = summaryDate.AddDays(-30),
								Portfolio = portfolio
							};

							context.Add(summary);
							summaryDate = summaryDate.AddDays(-30);
						}

						var transactionDate = DateTime.Now;
						for (int i = 0; i < 10; i++)
						{
							var transaction = new PortfolioTransaction()
							{
								Total = (decimal)new Random(i).NextDouble() * 10,
								Price = (decimal)new Random(i).NextDouble() *
										((decimal)new Random(i).NextDouble() * 10),
								Quantity = Math.Abs(new Random(i).Next()),
								Date = transactionDate,
								Portfolio = portfolio,
								PortfolioShare = portfolioShareA,
								PortfolioTransactionType = portfolioTransactionTypeClose
							};

							context.Add(transaction);
							transactionDate = transactionDate.AddDays(-1);
						}

						context.Add(portfolio);
					}

					applicationUser.AddEntityOrganization(organization);
					applicationUser.ActiveEntityOrganizationId = 1;
					applicationUser.AddAuthorizationGroup(authorizationGroupA);
					applicationUser.AuthorizationRole = adminRole;

					context.Add(organization);
					context.Add(adminRole);
					context.Add(advisoryRole);
					context.Add(agentRole);
					context.Add(workflowRole);
					context.Add(applicationUser);
					context.Add(workflowUser);
					context.Add(schedulerFlowUser);
					context.Add(currentAdviser);
					context.Add(genderA);
					context.Add(genderB);
					context.Add(occupation);
					context.Add(addressType);
					context.Add(phoneCallActivityType);
					context.Add(meetingActivityType);
					context.Add(authorizationGroupA);
					//context.Add(authorizationGroupB);

					for (int i = 0; i < 1000; i++)
					{
						var user = new ApplicationUser()
						{
							Name = "Default",
							Email = $"testB@test{i}.com",
							Password = "\u001f\r?????\u001e\u0016kt??#?\u0014?F??\u0014\u0018S?Ar??36??",
							CreatedDate = DateTime.Now,
							ModifiedDate = DateTime.Now
						};
						user.AddEntityOrganization(organization);
						user.ActiveEntityOrganizationId = 1;
						user.AddAuthorizationGroup(authorizationGroupA);
						user.AuthorizationRole = adminRole;
						context.Add(user);
					}


					context.Add(new Company() { Name = "database 1", Address = "Address 1", LastName = "Last Name 1" });
					context.Add(new Company() { Name = "database 2", Address = "Address 2", LastName = "Last Name 2" });
					context.Add(new Company() { Name = "database 3", Address = "Address 3", LastName = "Last Name 3" });
					context.Add(new Company() { Name = "database 4", Address = "Address 4", LastName = "Last Name 4" });

					context.Add(new Lead() { AgentId = 1 });


					var tc = new TableConfig() { Name = "TableA", GetInterceptorKey = "GetTableA", SaveInterceptorKey = "SaveTableA", ListInterceptorKey = "ListTableA" };
					context.Add(tc);

					context.Add(new PropertyConfig() { Name = "Id", Type = "int", TableConfig = tc });
					context.Add(new PropertyConfig() { Name = "Name", Type = "string", TableConfig = tc });
					context.Add(new PropertyConfig() { Name = "DOB", Type = "datetime", TableConfig = tc });
					context.Add(new PropertyConfig() { Name = "Gender", Type = "dropdown",Source = "Gender",CacheOnFirstLoad = true, TableConfig = tc });

					context.SaveChanges();
				}
			}
		}
	}
}