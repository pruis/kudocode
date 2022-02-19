using Autofac;
using AutoMapper;
using KudoCode.Contracts;
using KudoCode.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KudoCode.Contracts.Api
{
	public class ExecutionPipeline : ISecondaryExecutionPipeline
	{
		private readonly ILogFormatter _log;
		private readonly List<Type> _types;
		private readonly ILifetimeScope _scope;

		public ExecutionPipeline(List<Type> types, ILifetimeScope scope, ILogFormatter log)
		{
			_log = log;
			_types = types;
			_scope = scope;
		}

		public IApiResponseContextDto<TOut> Execute<TRequestDto, TOut>(TRequestDto requestDto, string scopeName = "", string token = "")
			where TRequestDto : IApiRequestDto
		{

			if (!string.IsNullOrWhiteSpace(scopeName))
				using (var scope = ApplicationContext.Container.BeginLifetimeScope(scopeName))
					return ScopeWrap<TRequestDto, TOut>(requestDto, scope, token);

			if (_scope.Tag.Equals("ExecutionPipeline"))
				return ScopeWrap<TRequestDto, TOut>(requestDto, _scope, token);
			using (var scope = ApplicationContext.Container.BeginLifetimeScope("ExecutionPipeline"))
				return ScopeWrap<TRequestDto, TOut>(requestDto, scope, token);
		}

		private IApiResponseContextDto<TOut> ScopeWrap<TRequestDto, TOut>(TRequestDto requestDto, ILifetimeScope scope, string token)
			where TRequestDto : IApiRequestDto
		{
			_log.Debug(this.GetType().Name, requestDto.GetType().Name, "START");
			var context = scope.Resolve<IExecutionPipelineContext<TOut>>();
			if (!string.IsNullOrWhiteSpace(token))
				scope.Resolve<ITokenCache>().Set(token);

			try
			{
				foreach (var type in _types)
				{
					((IExecutionPipelineFilter<TRequestDto, TOut>)
							scope.Resolve(type.MakeGenericType
								(typeof(TRequestDto), typeof(TOut))))
						.Participate(requestDto);

					if (context.Messages.Any(a => a.Type == MessageDtoType.Error))
						return scope.Resolve<IMapper>().Map<IApiResponseContextDto<TOut>>(context);
				}

				return scope.Resolve<IMapper>().Map<IApiResponseContextDto<TOut>>(context);
			}
			catch (Exception e)
			{
				Debugger.Break();
				var errorGuid = $"{DateTime.Now:MMddyyyyHHmmss}" +
								$"_{scope.Resolve<IApplicationUserContext>()?.Id}";
				//_log.Fatal(errorGuid, e);
				_log.Fatal(this.GetType().Name, requestDto.GetType().Name, $"{errorGuid} -- ERROR MESSAGE: {e.Message} INNER EXCEPTION: {e.InnerException} STACKTRACE: {e.StackTrace}");
				context.AddMessage("E2", errorGuid);
				return scope.Resolve<IMapper>().Map<IApiResponseContextDto<TOut>>(context);
			}
			finally
			{
				_log.Debug(this.GetType().Name, requestDto.GetType().Name, "END");
				LogMessages(requestDto, context);
				//scope.Dispose();
			}
		}

		private void LogMessages<TRequestDto, TOut>(TRequestDto requestDto, IExecutionPipelineContext<TOut> context)
		{
			var errorList = context.Messages.Where(a => a.Key != "E3");
			if (context.HasErrors() && errorList.Any())
			{
				var req = ((object)requestDto).ToDictionary();
				var message = string.Empty;
				foreach (var item in errorList)
				{
					message += $"{item.Key} - {item.Message} {Environment.NewLine}";
				}

				req.Add($"errorMessageCollection", message);

				_log.Fatal(this.GetType().Name, requestDto.GetType().Name, req.DictionaryToString());
			}
		}

	}
}