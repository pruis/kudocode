using AutoMapper;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Blazor.Application.ViewModels;
using KudoCode.Web.Infrastructure.Domain.Execution;
using KudoCode.Web.Infrastructure.Domain.HttpConnector;

namespace KudoCode.Web.Blazor.Application.Handlers
{
    public class GetPortfolioWebHandler : IWebHandler<GetPortfolioRequest, GetPortfolioViewModel>
    {
        private readonly ApiPostController _apiPostController;
        private readonly IMapper _mapper;

        public GetPortfolioWebHandler(ApiPostController apiPostController, IMapper mapper)
        {
            _apiPostController = apiPostController;
            _mapper = mapper;
        }

        public IWebResponseDto<GetPortfolioViewModel> Handle(GetPortfolioRequest request,
            IWebResponseDto<GetPortfolioViewModel> webResponseDto)
        {
            if (request.Id == 0)
                return webResponseDto;

            _apiPostController
                .Create<GetPortfolioRequest, GetPortfolioResponse>()
                .SetOnComplete((apiResponseDto) => { _mapper.Map(apiResponseDto, webResponseDto); })
                .Post(request);

            ;

            return webResponseDto;
        }
    }
}