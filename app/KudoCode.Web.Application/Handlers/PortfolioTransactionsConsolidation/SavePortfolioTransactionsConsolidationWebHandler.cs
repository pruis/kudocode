using KudoCode.Web.Infrastructure.Domain.Execution;
using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsConsolidations.Inbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Application.Models.Portfolios;

using KudoCode.Web.Application.Models.PortfolioTransactionsConsolidation;

namespace KudoCode.Web.Application.Handlers.PortfolioTransactionsConsolidation
{
    public class
        SavePortfolioTransactionsConsolidationWebHandler : IWebHandler<SavePortfolioTransactionsConsolidationViewModel,
            int>
    {
        private readonly Connector _connector;
        private readonly IMapper _mapper;

        public SavePortfolioTransactionsConsolidationWebHandler(Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<int> Handle(SavePortfolioTransactionsConsolidationViewModel vm,
            IWebResponseDto<int> responseDto)
        {
            var result = _connector.EndPoint
                .Request<SavePortfolioTransactionsConsolidationDto, int>(
                    _mapper.Map<SavePortfolioTransactionsConsolidationDto>(vm));

            _mapper.Map(result, responseDto);

            if (!responseDto.HasErrors())
                responseDto.Messages.Add(new MessageDto("M1", "Success", 0));
            return responseDto;
        }
    }
}