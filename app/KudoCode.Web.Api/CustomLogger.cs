using System;
using System.Collections.Generic;
using KudoCode.Helpers;
using KudoCode.Contracts;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KudoCode.Web.Api
{
	public class CustomLogger : ILog
	{
		//private TelemetryClient _telemetryClient;
		private IConfiguration _confg;
		private readonly IApplicationUserContext _applicationUserContext;

		public CustomLogger(IConfiguration config,
			IApplicationUserContext applicationUserContext
			//, TelemetryClient telemetryClient
			)
		{
			//telemetryClient.InstrumentationKey = config["ApplicationInsightsInstrumentionKey"];

			_confg = config;
			_applicationUserContext = applicationUserContext;
			//_telemetryClient = telemetryClient;

		}

		public bool IsDebugEnabled => throw new NotImplementedException();

		public bool IsInfoEnabled => throw new NotImplementedException();

		public bool IsWarnEnabled => throw new NotImplementedException();

		public bool IsErrorEnabled => throw new NotImplementedException();

		public bool IsFatalEnabled => throw new NotImplementedException();

		public ILogger Logger => throw new NotImplementedException();

		log4net.Core.ILogger log4net.Core.ILoggerWrapper.Logger => throw new NotImplementedException();

		public void Debug(object message)
		{
			///message.ToDictionary()
			var data = message.ToDictionary();
			data.Add("UserId", _applicationUserContext?.Id.ToString());
			//data.Add("UserName", _applicationUserContext?.Email);

			//_telemetryClient.TrackEvent("WebApi", data);
			//_logger.Log.Debug(message);
		}

		public void Debug(object message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(string format, object arg0)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(string format, object arg0, object arg1)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(string format, object arg0, object arg1, object arg2)
		{
			throw new NotImplementedException();
		}

		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void Error(object message)
		{
			throw new NotImplementedException();
		}

		public void Error(object message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(string format, object arg0)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(string format, object arg0, object arg1)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(string format, object arg0, object arg1, object arg2)
		{
			throw new NotImplementedException();
		}

		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void Fatal(object message)
		{
			var data = message.ToDictionary();
			data.Add("UserId", _applicationUserContext?.Id.ToString());
			//data.Add("UserName", _applicationUserContext?.LoginName);

			//_telemetryClient.TrackEvent("WebApi", data);

			//throw new NotImplementedException();
		}

		public void Fatal(object message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(string format, object arg0)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(string format, object arg0, object arg1)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(string format, object arg0, object arg1, object arg2)
		{
			throw new NotImplementedException();
		}

		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void Info(object message)
		{
			throw new NotImplementedException();
		}

		public void Info(object message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(string format, object arg0)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(string format, object arg0, object arg1)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(string format, object arg0, object arg1, object arg2)
		{
			throw new NotImplementedException();
		}

		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void Warn(object message)
		{
			//_telemetryClient.TrackEvent("WebApi", new Dictionary<string, string>() { { "data", message.ToString() } });
			//throw new NotImplementedException();
		}

		public void Warn(object message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(string format, params object[] args)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(string format, object arg0)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(string format, object arg0, object arg1)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(string format, object arg0, object arg1, object arg2)
		{
			throw new NotImplementedException();
		}

		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			throw new NotImplementedException();
		}
	}

}