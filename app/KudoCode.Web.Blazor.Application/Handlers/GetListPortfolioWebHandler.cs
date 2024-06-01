using AutoMapper;
using KudoCode.Contracts.Web;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Web.Blazor.Application.ViewModels;

namespace KudoCode.Web.Blazor.Application.Handlers
{
	public class GetListPortfolioWebHandler : IWebHandler<GetListPortfolioRequest, GetListPortfolioViewModel>
    {
        private readonly ApiPostController _apiPostController;
        private readonly IMapper _mapper;

        public GetListPortfolioWebHandler(ApiPostController apiPostController, IMapper mapper)
        {
            _apiPostController = apiPostController;
            _mapper = mapper;
        }

        public IWebResponseDto<GetListPortfolioViewModel> Handle(GetListPortfolioRequest request,
            IWebResponseDto<GetListPortfolioViewModel> webResponseDto)
        {
            var apiResponseDto =
                _apiPostController
                    .Create<GetListPortfolioRequest, GetListPortfolioResponse>()
                    .Post(request);

            _mapper.Map(apiResponseDto, webResponseDto);

            return webResponseDto;
        }
    }
}