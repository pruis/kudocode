using KudoCode.Web.Infrastructure.Domain.Execution;
using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.Web.Api.Connector;


namespace KudoCode.Web.Application.Handlers.Portfolios
{
    public class
        SavePortfolioTransactionsSummaryWebHandler : IWebHandler<SavePortfolioTransactionsSummaryRequest,
            int>
    {
        private readonly Connector _connector;
        private readonly IMapper _mapper;

        public SavePortfolioTransactionsSummaryWebHandler(Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<int> Handle(SavePortfolioTransactionsSummaryRequest vm,
            IWebResponseDto<int> responseDto)
        {
            var result = _connector.EndPoint
                .Request<SavePortfolioTransactionsSummaryRequest, int>(vm);

            _mapper.Map(result, responseDto);

            if (!responseDto.HasErrors())
                responseDto.Messages.Add(new MessageDto("M1", "Success", 0));
            return responseDto;
        }
    }
}