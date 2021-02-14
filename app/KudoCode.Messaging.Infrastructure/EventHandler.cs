using System;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;
using KudoCode.Messaging.Infrastructure.Interfaces;

namespace KudoCode.Messaging.Infrastructure
{
    public abstract class EventHandler<T> : IEventHandler<T>
        where T : IEventMetaData
    {
        public EventRequestDto<T> Event { get; set; }

        public abstract void Execute();

        public void Handle(EventRequestDto<T> @event)
        {
            Event = @event;
            Execute();
        }
    }
}