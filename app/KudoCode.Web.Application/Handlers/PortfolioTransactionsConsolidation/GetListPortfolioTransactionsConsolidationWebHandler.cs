using KudoCode.Web.Infrastructure.Domain.Execution;
using System.Collections.Generic;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Outbound;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Application.Models.Portfolios;

using KudoCode.Web.Application.Models.PortfolioTransactionsConsolidation;

namespace KudoCode.Web.Application.Handlers.PortfolioTransactionsConsolidation
{
    public class GetListPortfolioTransactionsConsolidationWebHandler : IWebHandler<
        GetListPortfolioTransactionsConsolidationDto, GetListPortfolioTransactionsConsolidationViewModel>
    {
        private readonly Connector _connector;
        private readonly IMapper _mapper;

        public GetListPortfolioTransactionsConsolidationWebHandler(Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<GetListPortfolioTransactionsConsolidationViewModel> Handle(
            GetListPortfolioTransactionsConsolidationDto dto,
            IWebResponseDto<GetListPortfolioTransactionsConsolidationViewModel> webResponseDto)
        {
            if (dto.PortfolioTransactionsSummaryId == 0)
                return webResponseDto;

            var apiResponseDto = _connector.EndPoint
                .Request<GetListPortfolioTransactionsConsolidationDto, List<PortfolioTransactionsConsolidationDto>>
                    (dto);
            _mapper.Map(apiResponseDto, webResponseDto);

            return webResponseDto;
        }
    }
}