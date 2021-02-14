using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events;
using KudoCode.LogicLayer.Infrastructure.Dtos.Events.Interfaces;

namespace KudoCode.Messaging.Infrastructure.Interfaces
{
	public interface IEventHandler<T>
		where T : IEventMetaData
	{
		EventRequestDto<T> Event { get; set; }
		void Handle(EventRequestDto<T> @event);
		void Execute();
	}
}