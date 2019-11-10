using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KudoCode.Web.Infrastructure.Domain.HttpConnector
{
	public class HttpHandler
	{
		private readonly IApplicationContextHandler _applicationContextHandler;
		private readonly IConfiguration _configuration;
		private ReferenceConverter _referenceConverter;

		public HttpHandler(IApplicationContextHandler applicationContextHandler, IConfiguration configuration)
		{
			_applicationContextHandler = applicationContextHandler;
			_configuration = configuration;
		}

		public async Task<IApiResponseContextDto<TResponseDto>> Post<TRequestDto, TResponseDto>(TRequestDto dto)
			where TRequestDto : IApiRequestDto
		{
			_referenceConverter = new ReferenceConverter(typeof(IApiResponseContextDto<TResponseDto>));

			if (_configuration["ApiBaseUrl"] == null)
				throw new Exception("FATAL: ApiBaseUrl CAN NOT BE NULL");

			var httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);

			var request = new ApiControllerRequestDto()
			{
				Request = dto,
				ResponseType = typeof(TResponseDto).FullName,
				AuthenticationToken = _applicationContextHandler.FetchContext()?.Token?.Value
			};

			var jsonToSend = JsonConvert.SerializeObject(request, Json.Serialization.Auto());

			var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
			var uri = _configuration["ApiBaseUrl"] + "EndPoint/Request";
			var response = await httpClient.PostAsync(uri, content);
			var result = JsonConvert.DeserializeObject<ApiResponseContextDto<TResponseDto>>
				(response.Content.ReadAsStringAsync().Result);
			return result;
		}
	}
}