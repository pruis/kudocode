namespace KudoCode.Messaging.Infrastructure.Interfaces
{
	public interface IEventExecutionPipeLine
    {
        void Execute(object requestDto);
    }
}