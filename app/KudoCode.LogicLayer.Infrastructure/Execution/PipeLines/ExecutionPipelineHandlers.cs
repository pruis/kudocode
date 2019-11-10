using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using log4net;

namespace KudoCode.LogicLayer.Infrastructure.Execution.PipeLines
{
    public class ExecutionPipelineHandlers : IExecutionPipelineHandlers
    {
        private readonly ILog _logger;
        private readonly List<Type> _types;

        public ExecutionPipelineHandlers(ILog logger, List<Type> types)
        {
            _logger = logger;
            _types = types;
        }

        public IApiResponseContextDto<TOut> Execute<TRequestDto, TOut>(TRequestDto requestDto, string token = "")
            where TRequestDto : IApiRequestDto

        {
            using (var scope = ApplicationContext.Container.BeginLifetimeScope("ExecutionPipeline"))
            {
                var mapper = scope.Resolve<IMapper>();
                var context = scope.Resolve<IExecutionPipelineContext<TOut>>();
                if (!string.IsNullOrWhiteSpace(token))
                    scope.Resolve<ITokenCache>().Set(token);
                try
                {
                    foreach (var type in _types)
                    {
                        var handler = scope.Resolve(type);

                        handler.GetType()
                            .GetMethod("Handle")
                            .Invoke(handler, new[] {(object) requestDto});

                        if (context.HasErrors())
                            return mapper.Map<IApiResponseContextDto<TOut>>(context);
                    }

                    return mapper.Map<IApiResponseContextDto<TOut>>(context);
                }
                catch (Exception e)
                {
                    _logger.Fatal(e);
                    context.AddMessage("E2");
                    return mapper.Map<IApiResponseContextDto<TOut>>(context);
                }
                finally
                {
                }
            }
        }
    }
}