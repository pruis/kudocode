using log4net;
using Microsoft.Extensions.Configuration;

namespace KudoCode.Contracts.Api
{
	public class LogFormatter : ILogFormatter
	{
		private IConfiguration _config;
		private ILog _log;
		[System.ThreadStatic]
		private string _traceId;

		public LogFormatter(ILog log, IConfiguration config)
		{
			_config = config;
			_log = log;
			if (string.IsNullOrWhiteSpace(_traceId))
			{
				_traceId = System.Guid.NewGuid().ToString();
			}
		}


		public void Debug(string handlerName, string requestDtoType, string message)
		{
			if (_config["EnableTracing"].ToLower().Equals("true"))
			{
				_log.Debug(new { traceId = _traceId, handlerName = handlerName, requestDtoType = requestDtoType, message = message });
			}
		}
		public void Fatal(string handlerName, string requestDtoType, string message)
		{
			_log.Fatal(new { traceId = _traceId, handlerName = handlerName, requestDtoType = requestDtoType, message = message });
		}
	}

}