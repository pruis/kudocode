using KudoCode.Web.Infrastructure.Domain.Execution;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Application.Models.Portfolios;

using KudoCode.Web.Application.Models.PortfolioTransactionsSummary;

namespace KudoCode.Web.Application.Handlers.PortfolioTransactionsSummary
{
    public class GetPortfolioTransactionsSummaryWebHandler : IWebHandler<GetPortfolioTransactionsSummaryRequest,
        GetPortfolioTransactionsSummaryViewModel>
    {
        private readonly Connector _connector;
        private readonly IMapper _mapper;

        public GetPortfolioTransactionsSummaryWebHandler(Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<GetPortfolioTransactionsSummaryViewModel> Handle(
            GetPortfolioTransactionsSummaryRequest request,
            IWebResponseDto<GetPortfolioTransactionsSummaryViewModel> webResponseDto)
        {
            var apiResponseDto =
                _connector.EndPoint
                    .Request<GetPortfolioTransactionsSummaryRequest, GetPortfolioTransactionsSummaryResponse>(request);
            _mapper.Map(apiResponseDto, webResponseDto);

            return webResponseDto;
        }
    }
}