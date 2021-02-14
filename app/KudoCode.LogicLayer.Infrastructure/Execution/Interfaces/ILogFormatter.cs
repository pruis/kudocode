namespace KudoCode.LogicLayer.Infrastructure.Execution.Interfaces
{
	public interface ILogFormatter
    {
        void Debug(string handlerName, string requestDtoName, string message);
        void Fatal(string handlerName, string requestDtoName, string message);
    }

}