using Autofac;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos;
using KudoCode.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using KudoCode.Contracts.Api;

namespace PublishEvent.Service
{
	class Program
    {
        static void Main(string[] args)
        {
            var events = new ArrayList();

            var eventRequestDto = new EventRequestDto<CreateEntityAuditEventMessage>();
            eventRequestDto.Queues.Add(KudoCode.LogicLayer.Dtos.Constants.EventQueues.InternalEventsQueue);

            eventRequestDto.MetaData = new CreateEntityAuditEventMessage()
            {
                Entity = "Lead",
                PropertyInformation = new List<PropertyInformationDto>()
                {
                    new PropertyInformationDto()
                        {Name = "test", Value = DateTime.Now.ToString()}
                }
            };
            events.Add(eventRequestDto);

            //eventRequestDto.MetaData = new CreatePortfolioImportXslEventMessage();
            //eventRequestDto.RequestUser.Id = 1;
            //events.Add(eventRequestDto);

            ApplicationContext.Container = ContainerInstaller.BuildContainer();

            foreach (var @event in events)
            foreach (var source in (@event as IEventRequestSources).Queues)
                ApplicationContext.Container.ResolveNamed<IEventManager>(source).Send(@event);
        }
    }
}