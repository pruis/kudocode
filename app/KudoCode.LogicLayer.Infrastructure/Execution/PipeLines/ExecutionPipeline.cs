using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Participants.Interfaces;
using log4net;
using Newtonsoft.Json;

namespace KudoCode.LogicLayer.Infrastructure.Execution.PipeLines
{
    public class ExecutionPipeline : IExecutionPipeline, ISecondaryExecutionPipeline
    {
        private readonly ILog _logger;
        private readonly List<Type> _types;
        private readonly ILifetimeScope _scope;

        public ExecutionPipeline(ILog logger,
            List<Type> types, ILifetimeScope scope)
        {
            _logger = logger;
            _types = types;
            _scope = scope;
        }

        public IApiResponseContextDto<TOut> Execute<TRequestDto, TOut>(TRequestDto requestDto, string token = "")
            where TRequestDto : IApiRequestDto
        {
            if (_scope.Tag.Equals("ExecutionPipeline")) return ScopeWrap<TRequestDto, TOut>(requestDto, _scope, token);
            using (var scope = ApplicationContext.Container.BeginLifetimeScope("ExecutionPipeline"))
                return ScopeWrap<TRequestDto, TOut>(requestDto, scope, token);
        }

        private IApiResponseContextDto<TOut> ScopeWrap<TRequestDto, TOut>(TRequestDto requestDto, ILifetimeScope scope, string token)
            where TRequestDto : IApiRequestDto
        {
            _logger.Debug($"{scope.Tag} - {this.GetType().Name} - {requestDto.GetType().Name} - START");
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
                var errorGuid = $"{DateTime.Now:MMddyyyyHHmmss}" +
                                $"_{scope.Resolve<IApplicationUserContext>()?.Id}";
                _logger.Fatal(scope.Tag);
                _logger.Fatal(errorGuid, e);
                context.AddMessage("E2", errorGuid);
                return scope.Resolve<IMapper>().Map<IApiResponseContextDto<TOut>>(context);
            }
            finally
            {
                _logger.Debug($"{scope.Tag} - {this.GetType().Name} - {requestDto.GetType().Name} - END");
                LogMessages(requestDto, context, scope.Tag);
                //scope.Dispose();
            }
        }

        private void LogMessages<TRequestDto, TOut>(TRequestDto requestDto, IExecutionPipelineContext<TOut> context,
            object scopeTag)
        {
            foreach (var message in context.Messages.Where(a => a.Key != "E2"))
                switch (message.Type)
                {
                    case MessageDtoType.Error:
                        _logger.Fatal(
                            $"{scopeTag} - {requestDto.GetType().Name} - {JsonConvert.SerializeObject(requestDto, Formatting.None)} " +
                            $": {message.Key} - {message.Message} ");
                        break;
                    case MessageDtoType.Warning:
                        _logger.Warn(
                            $"{scopeTag} - {requestDto.GetType().Name} - {JsonConvert.SerializeObject(requestDto, Formatting.None)} " +
                            $": {message.Key} - {message.Message} ");
                        break;
                    case MessageDtoType.Success:
                        break;
                }
        }
    }
}