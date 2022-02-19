using KudoCode.Contracts;
using Microsoft.Extensions.Configuration;
using System;

namespace KudoCode.Contracts.Web
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