using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KudoCode.Web.Infrastructure.Domain.HttpConnector
{
	public class HttpHandler
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IConfiguration _configuration;
		private readonly IApplicationUserContext _applicationUserContext;

		public HttpHandler(ReferenceConverter referenceConverter)
		{
		}

		public HttpHandler(IConfiguration configuration, IApplicationUserContext applicationUserContext, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_configuration = configuration;
			_applicationUserContext = applicationUserContext;
		}
		public async Task<IApiResponseContextDto<TResponseDto>> PostAsync<TRequestDto, TResponseDto>(TRequestDto dto, CancellationToken? cancellationToken = null)
				where TRequestDto : IApiRequestDto
		{

			if (_configuration["ApiBaseUrl"] == null)
				throw new Exception("FATAL: ApiBaseUrl CAN NOT BE NULL");

			var hostUrl = _configuration["ApiBaseUrl"];

			var request = new ApiControllerRequestDto()
			{
				Request = JsonConvert.SerializeObject(dto, Json.Serialization.Auto()),
				RequestType = typeof(TRequestDto).Name,
				ResponseType = typeof(TResponseDto).Name,
			};

			var jsonToSend = JsonConvert.SerializeObject(request, Json.Serialization.Auto());

			var httpClient = new HttpClient
			{
				BaseAddress = new Uri(hostUrl)
			};

			if (_applicationUserContext.Token?.Value != null)
			{
				httpClient.DefaultRequestHeaders.Add("Authorization", _applicationUserContext.Token?.Value);
			}

			var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
			var uri = hostUrl + $"{_configuration["ApiBaseUri"]}Generic/Post";
			var response = await httpClient.PostAsync(uri, content, cancellationToken ?? new CancellationTokenSource().Token);

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{  
				return new ApiResponseContextDto<TResponseDto>()
				{ Messages = new List<MessageDto>() { new MessageDto("E3", "please logout and re-login", MessageDtoType.Error) } };

			}

			var result = JsonConvert.DeserializeObject<ApiResponseContextDto<TResponseDto>>(response.Content.ReadAsStringAsync().Result);
			return result;
		}

		public IApiResponseContextDto<TResponseDto> Post<TRequestDto, TResponseDto>(TRequestDto dto, CancellationToken? cancellationToken = null)
			where TRequestDto : IApiRequestDto
		{
			if (_configuration["ApiBaseUrl"] == null)
				throw new Exception("FATAL: ApiBaseUrl CAN NOT BE NULL");

			var hostUrl = _configuration["ApiBaseUrl"];

			var request = new ApiControllerRequestDto()
			{
				Request = JsonConvert.SerializeObject(dto, Json.Serialization.Auto()),
				RequestType = typeof(TRequestDto).Name,
				ResponseType = typeof(TResponseDto).Name,
			};

			var jsonToSend = JsonConvert.SerializeObject(request, Json.Serialization.Auto());

			var httpClient = new HttpClient
			{
				BaseAddress = new Uri(hostUrl)
			};

			if (_applicationUserContext.Token?.Value != null)
			{
				httpClient.DefaultRequestHeaders.Add("Authorization", _applicationUserContext.Token?.Value);
			}

			var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
			var uri = hostUrl + "Generic/Post";
			var response = httpClient.PostAsync(uri, content, cancellationToken ?? new CancellationTokenSource(Convert.ToInt32(_configuration["RestApi.AsyncTimeOut"])).Token).Result;
			var result = JsonConvert.DeserializeObject<ApiResponseContextDto<TResponseDto>>(response.Content.ReadAsStringAsync().Result);
			return result;
		}
	}
}