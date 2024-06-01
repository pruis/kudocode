using KudoCode.Contracts.Web;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.Web.Api.Connector;


namespace KudoCode.Web.Application.Handlers.PortfolioTransactions
{
    public class SavePortfolioTransactionWebHandler : IWebHandler<SavePortfolioTransactionRequest, int>
    {
        private readonly Api.Connector.Connector _connector;
        private readonly IMapper _mapper;

        public SavePortfolioTransactionWebHandler(Api.Connector.Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<int> Handle(SavePortfolioTransactionRequest request, IWebResponseDto<int> webResponseDto)
        {
            var apiResponseDto = _connector.EndPoint.Request<SavePortfolioTransactionRequest, int>(request);
            _mapper.Map(apiResponseDto, webResponseDto);

            return webResponseDto;
        }
    }
}