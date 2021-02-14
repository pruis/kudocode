using System;
using System.Collections.Generic;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using Microsoft.Extensions.Configuration;

namespace KudoCode.Web.Infrastructure.Domain.Execution
{
    public class WebExecutionPipeline
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public WebExecutionPipeline(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public IWebResponseDto<TOut> Execute<TDto, TOut>(TDto dto) where TOut : new()
        {
            IWebResponseDto<TOut> T = new WebResponseDto<TOut>();
            T.Configuration = new Configuration()
            {
                DateFormat = _configuration["DateFormat"],
                DateTimeFormat = _configuration["DateTimeFormat"]
            };
            try
            {
                var handler = _serviceProvider.GetService(typeof(IWebHandler<TDto, TOut>));
                ((IWebHandler<TDto, TOut>) handler).Handle(dto, T);
                return T;
            }
            catch (Exception e)
            {
                T.AddError("EW1", new[] {e.Message});
                return T;
            }
        }
    }
}