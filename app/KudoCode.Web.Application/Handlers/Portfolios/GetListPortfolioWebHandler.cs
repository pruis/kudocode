using System;
using KudoCode.Web.Infrastructure.Domain.Execution;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Web.Api.Connector;
using KudoCode.Web.Application.Models.Portfolios;

namespace KudoCode.Web.Application.Handlers.Portfolios
{
	public class GetListPortfolioWebHandler : IWebHandler<GetListPortfolioRequest, GetListPortfolioViewModel>
	{
		private readonly Connector _connector;
		private readonly IMapper _mapper;

		public GetListPortfolioWebHandler(Connector connector, IMapper mapper)
		{
			_connector = connector;
			_mapper = mapper;
		}

		public IWebResponseDto<GetListPortfolioViewModel> Handle(GetListPortfolioRequest request,
			IWebResponseDto<GetListPortfolioViewModel> webResponseDto)
		{
			var apiResponseDto =
				_connector.EndPoint.Request<GetListPortfolioRequest, GetListPortfolioResponse>(request);
			_mapper.Map(apiResponseDto, webResponseDto);

			return webResponseDto;
		}
	}
}