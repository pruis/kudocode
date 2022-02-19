using KudoCode.Contracts;
using KudoCode.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KudoCode.Contracts.Web
{
	public class HttpHandler
	{
		private readonly IConfiguration _configuration;
		private readonly IApplicationUserContext _applicationUserContext;

		public HttpHandler()
		{
		}

		public HttpHandler(IConfiguration configuration, IApplicationUserContext applicationUserContext)
		{
			_configuration = configuration;
			_applicationUserContext = applicationUserContext;
		}
		public async Task<IApiResponseContextDto<TResponseDto>> PostAsync<TRequestDto, TResponseDto>(TRequestDto dto, string serviceDestination = "", CancellationToken? cancellationToken = null)
		//where TRequestDto : IApiRequestDto
		{

			var hostUrl = string.Empty;

			if (!string.IsNullOrEmpty(serviceDestination))
			{
				hostUrl = _configuration[$"ServiceRoutes:{serviceDestination}"];
				if (string.IsNullOrEmpty(hostUrl))
					throw new Exception($"FATAL: serviceDestination url not set {serviceDestination}");
			}
			else
			{
				if (_configuration["ApiBaseUrl"] == null)
					throw new Exception("FATAL: ApiBaseUrl CAN NOT BE NULL");
				hostUrl = _configuration["ApiBaseUrl"];
			}

			var httpClient = new HttpClient
			{
				BaseAddress = new Uri(hostUrl)
			};

			if (_applicationUserContext.Token?.Value != null)
			{
				httpClient.DefaultRequestHeaders.Add("Authorization", _applicationUserContext.Token?.Value);
			}


			var request = new ApiControllerRequestDto()
			{
				Request = JsonConvert.SerializeObject(dto, Json.Serialization.Auto()),
				RequestType = typeof(TRequestDto).Name,
				ResponseType = typeof(TResponseDto).Name,
				AuthenticationToken = _applicationUserContext.Token?.Value
			};

			var jsonToSend = JsonConvert.SerializeObject(request, Json.Serialization.Auto());


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

			var httpClient = new HttpClient
			{
				BaseAddress = new Uri(hostUrl)
			};

			if (_applicationUserContext.Token?.Value != null)
				httpClient.DefaultRequestHeaders.Add("Authorization", _applicationUserContext.Token?.Value);

			var request = new ApiControllerRequestDto()
			{
				Request = JsonConvert.SerializeObject(dto, Json.Serialization.Auto()),
				RequestType = typeof(TRequestDto).Name,
				ResponseType = typeof(TResponseDto).Name,
				AuthenticationToken = _applicationUserContext.Token?.Value
			};

			var jsonToSend = JsonConvert.SerializeObject(request, Json.Serialization.Auto());


			var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
			var uri = hostUrl + "Generic/Post";
			var response = httpClient.PostAsync(uri, content, cancellationToken ?? new CancellationTokenSource(Convert.ToInt32(_configuration["RestApi.AsyncTimeOut"])).Token).Result;
			var result = JsonConvert.DeserializeObject<ApiResponseContextDto<TResponseDto>>(response.Content.ReadAsStringAsync().Result);
			return result;
		}
	}
}