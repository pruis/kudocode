namespace KudoCode.Contracts.Api
{
	public interface IEventManager
	{
		void Dispose();
		IEventManager Listen();
		void Send<T>(T request);
	}
}