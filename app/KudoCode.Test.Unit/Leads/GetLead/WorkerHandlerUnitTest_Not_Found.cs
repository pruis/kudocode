﻿using System.Linq;
using Autofac;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers.Interfaces;
using KudoCode.Test.Unit.InMemoryDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KudoCode.Test.Unit.Leads.GetLead
{
    [TestClass]
    public class WorkerHandlerUnitTest_Not_Found : UnitTestBase
    {
        private int _leadId;
        private GetLeadRequest _getLeadRequest;
        private IWorkerContext<GetLeadResponse> _getResponse;

        public WorkerHandlerUnitTest_Not_Found()
        {
        }

        [TestMethod]
        public void GetLead()
        {
            base.Run(
                "GetLeadDto WorkerHandler - Not Found",
                "Given a non existent lead id",
                "When I call the GetLeadDtoWorkerHandler with GetLeadDto",
                "Then i receive an error messages");
        }

        protected override void Seed()
        {
            SeedDataBase.InitializeDataBase();
            _leadId = -1;
        }

        protected override void Given()
        {
            _getLeadRequest = new GetLeadRequest() {Id = _leadId};
        }

        protected override void When()
        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope(ScopeKey))
            {
                _getResponse = scope
                    .Resolve<IHandler<GetLeadRequest, IWorkerContext<GetLeadResponse>>>()
                    .Handle(_getLeadRequest);
            }
        }

        protected override void Then()
        {
            Assert.IsTrue(_getResponse.Messages.Any(a =>
                a.Type == MessageDtoType.Error));
            Assert.IsTrue(_getResponse.Messages.Any(a => a.Key == "E4"));
        }
    }
}