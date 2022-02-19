using KudoCode.Contracts;

namespace KudoCode.Contracts.Api
{
	public interface IEventHandler<T>
		where T : IEventMetaData
	{
		EventRequestDto<T> Event { get; set; }
		void Handle(EventRequestDto<T> @event);
		void Execute();
	}
}