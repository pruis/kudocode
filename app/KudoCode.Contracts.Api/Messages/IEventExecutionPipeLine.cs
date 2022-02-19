namespace KudoCode.Contracts.Api
{
	public interface IEventExecutionPipeLine
    {
        void Execute(object requestDto);
    }
}