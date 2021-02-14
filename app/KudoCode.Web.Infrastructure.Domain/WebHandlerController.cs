using System;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.Web.Infrastructure.Domain.Execution;
using Microsoft.Extensions.Configuration;

namespace KudoCode.Web.Infrastructure.Domain
{
    public class WebHandlerController
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly IApplicationContextHandler _applicationContextHandler;
        private readonly IKudoCodeNavigation _navigation;

        public WebHandlerController(
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IApplicationContextHandler applicationContextHandler,
            IKudoCodeNavigation navigation
        )
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _applicationContextHandler = applicationContextHandler;
            _navigation = navigation;
        }

        public WebExecutionPipelineChained<TRequestDto, TResponseDto> Create<TRequestDto, TResponseDto>()
            where TResponseDto : new()
            where TRequestDto : IApiRequestDto
        {
            _applicationContextHandler.FetchContext();
            return new WebExecutionPipelineChained<TRequestDto, TResponseDto>(_serviceProvider,
                _navigation);
        }
    }
}