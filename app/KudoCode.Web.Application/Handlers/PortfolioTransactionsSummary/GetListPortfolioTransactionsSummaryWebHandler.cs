using KudoCode.Web.Infrastructure.Domain.Execution;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Application.Models.Portfolios;

using KudoCode.Web.Application.Models.PortfolioTransactionsSummary;

namespace KudoCode.Web.Application.Handlers.PortfolioTransactionsSummary
{
    public class GetListPortfolioTransactionsSummaryWebHandler : IWebHandler<GetListPortfolioTransactionsSummaryRequest,
        GetListPortfolioTransactionsSummaryViewModel>
    {
        private readonly Connector _connector;
        private readonly IMapper _mapper;

        public GetListPortfolioTransactionsSummaryWebHandler(Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<GetListPortfolioTransactionsSummaryViewModel> Handle(
            GetListPortfolioTransactionsSummaryRequest request,
            IWebResponseDto<GetListPortfolioTransactionsSummaryViewModel> webResponseDto)
        {
            var apiResponseDto = _connector.EndPoint
                .Request<GetListPortfolioTransactionsSummaryRequest,
                    GetListPortfolioTransactionsSummaryResponse>(request);
            _mapper.Map(apiResponseDto, webResponseDto);

            return webResponseDto;
        }
    }
}