using KudoCode.Contracts.Web;
using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Dtos;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.Contracts;
using KudoCode.Contracts;
using KudoCode.Web.Api.Connector;

using KudoCode.Web.Application.Models.PortfolioTransactions;

namespace KudoCode.Web.Application.Handlers.PortfolioTransactions
{
    public class
        GetPortfolioTransactionWebHandler : IWebHandler<GetPortfolioTransactionRequest, GetPortfolioTransactionViewModel
        >
    {
        private readonly Api.Connector.Connector _connector;
        private readonly IMapper _mapper;

        public GetPortfolioTransactionWebHandler(Api.Connector.Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<GetPortfolioTransactionViewModel> Handle(GetPortfolioTransactionRequest request,
            IWebResponseDto<GetPortfolioTransactionViewModel> webResponseDto)
        {
            var lookupResponse = _connector.EndPoint.Request<GetLookupRequest, GetLookupResponse>(
                dto: new GetLookupRequest(new[]
                {
                    new LookupRequest() {Type = "PortfolioTransactionType"},
                    new LookupRequest() {Type = "PortfolioShare"},
                }));
            webResponseDto.Messages.AddRange(lookupResponse.Messages);

            if (webResponseDto.Messages.Any(a => a.Type == MessageDtoType.Error))
                return webResponseDto;

            webResponseDto.Result.PortfolioTransactionType =
                Extensions.AssignLookupValues(lookupResponse.Result, "PortfolioTransactionType");
            webResponseDto.Result.PortfolioShare =
                Extensions.AssignLookupValues(lookupResponse.Result, "PortfolioShare");

            webResponseDto.Result.PortfolioId = request.PortfolioId;
            if (request.Id == 0)
                return webResponseDto;

            var apiResponseDto =
                _connector.EndPoint.Request<GetPortfolioTransactionRequest, GetPortfolioTransactionResponse>(request);
            _mapper.Map(apiResponseDto, webResponseDto);

            return webResponseDto;
        }
    }
}