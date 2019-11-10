namespace KudoCode.Messaging.Infrastructure.Interfaces
{
	public interface IEventManager
	{
		void Dispose();
		IEventManager Listen();
		void Send<T>(T request);
	}
}