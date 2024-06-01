using KudoCode.Contracts.Web;
using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using KudoCode.Web.Api.Connector;


namespace KudoCode.Web.Application.Handlers.Portfolios
{
    public class
        SavePortfolioTransactionsSummaryWebHandler : IWebHandler<SavePortfolioTransactionsSummaryRequest,
            int>
    {
        private readonly Api.Connector.Connector _connector;
        private readonly IMapper _mapper;

        public SavePortfolioTransactionsSummaryWebHandler(Api.Connector.Connector connector, IMapper mapper)
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