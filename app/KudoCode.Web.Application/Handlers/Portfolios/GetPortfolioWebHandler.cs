using KudoCode.Contracts.Web;
using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Dtos;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Web.Api.Connector;

using KudoCode.Web.Application.Models.Portfolios;

namespace KudoCode.Web.Application.Handlers.Portfolios
{
    public class GetPortfolioWebHandler : IWebHandler<GetPortfolioRequest, GetPortfolioViewModel>
    {
        private readonly Api.Connector.Connector _connector;
        private readonly IMapper _mapper;

        public GetPortfolioWebHandler(Api.Connector.Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<GetPortfolioViewModel> Handle(GetPortfolioRequest request,
            IWebResponseDto<GetPortfolioViewModel> webResponseDto)
        {

            if (request.Id == 0)
                return webResponseDto;

            var apiResponseDto = _connector.EndPoint.Request<GetPortfolioRequest,GetPortfolioResponse>(request);
            _mapper.Map(apiResponseDto, webResponseDto);

            return webResponseDto;
        }
    }
}