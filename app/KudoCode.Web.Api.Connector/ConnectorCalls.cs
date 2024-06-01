using KudoCode.Contracts;
using KudoCode.Helpers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace KudoCode.Web.Api.Connector
{
	public static class ConnectorCalls
    {
        public static IApiResponseContextDto<TResponse> Get<TResponse>(ConnectorClient connectorClient, string url)
        {
            var response = connectorClient.HttpClient.GetAsync(connectorClient.BaseUrl + url);
            response.Wait();

            var result =
                JsonConvert.DeserializeObject<ApiResponseContextDto<TResponse>>(response.Result.Content
                    .ReadAsStringAsync().Result);
            return result;
        }

        public static IApiResponseContextDto<TResponse> Post<TRequestDto, TResponse>(ConnectorClient connectorClient,
            TRequestDto dto, string url)
        {
            string jsonToSend = JsonConvert.SerializeObject(dto, Json.Serialization.Auto());

            var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
            var uri = connectorClient.BaseUrl + url;
            var response = connectorClient.HttpClient.PostAsync(uri, content);
            response.Wait();

            var result = JsonConvert.DeserializeObject<ApiResponseContextDto<TResponse>>
                (response.Result.Content.ReadAsStringAsync().Result, Json.Serialization.Auto());
            return result;
        }

        public static IApiResponseContextDto<TResponseDto> EndPoint<TRequestDto, TResponseDto>(
            ConnectorClient connectorClient, TRequestDto dto)
            where TRequestDto : IApiRequestDto
        {
            var request = new ApiControllerRequestDto()
            {
                Request = JsonConvert.SerializeObject(dto, Json.Serialization.Auto()),
                RequestType = typeof(TRequestDto).Name,
                ResponseType = typeof(TResponseDto).Name
            };

            var jsonToSend = JsonConvert.SerializeObject(request, Json.Serialization.Auto());

            var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
            var uri = connectorClient.BaseUrl + "Generic/Post";
            var response = connectorClient.HttpClient.PostAsync(uri, content);
            response.Wait();

            var result = JsonConvert.DeserializeObject<ApiResponseContextDto<TResponseDto>>
                (response.Result.Content.ReadAsStringAsync().Result, Json.Serialization.Auto());
            return result;
        }
    }
}