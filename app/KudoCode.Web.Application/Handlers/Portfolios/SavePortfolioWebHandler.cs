using KudoCode.Web.Infrastructure.Domain.Execution;
using System.Linq;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.Web.Api.Connector;


namespace KudoCode.Web.Application.Handlers.Portfolios
{
    public class
        SavePortfolioWebHandler : IWebHandler<SavePortfolioRequest,
            int>
    {
        private readonly Connector _connector;
        private readonly IMapper _mapper;

        public SavePortfolioWebHandler(Connector connector, IMapper mapper)
        {
            _connector = connector;
            _mapper = mapper;
        }

        public IWebResponseDto<int> Handle(SavePortfolioRequest vm,
            IWebResponseDto<int> responseDto)
        {
            var result = _connector.EndPoint
                .Request<SavePortfolioRequest, int>(vm);

            _mapper.Map(result, responseDto);

            if (!responseDto.HasErrors())
                responseDto.Messages.Add(new MessageDto("M1", "Success", 0));
            return responseDto;
        }
    }
}