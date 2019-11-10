using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Dtos.Emails;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit.Dtos;
using KudoCode.Web.Api.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace KudoCode.Test.Acceptance.AuditEntity
{
    public class AuditEntityBddfy
    {
        private Connector _connector;
        private IApiResponseContextDto<int> _resonse;

        public void Get(Connector connector)
        {
            _connector = connector;
            this.Given(_ => Given())
                .When(_ => When())
                .Then(_ => Then())
                .BDDfy();
        }

        public void Given()
        {
        }

        public void When()
        {
            _resonse = _connector.EntityAudit.Create(new CreateEntityAuditDto()
            {
                Entity = "Asset",
                EntityId = 1,
                CreatedBy = "test",
                CreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ApplicationUserId = 1,
                PropertyInformation = new List<PropertyInformationDto>()
                {
                    new PropertyInformationDto()
                    {
                        Name = "test",
                        Value = "test"
                    },
                    new PropertyInformationDto()
                    {
                        Name = "testA",
                        Value = "testA"
                    }
                }
            });
        }

        public void Then()
        {
            Assert.IsTrue(_resonse.Result > 0);
        }
    }
}