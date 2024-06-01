using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
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