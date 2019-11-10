using System.Net.Http;
using System.Text;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses;
using KudoCode.LogicLayer.Infrastructure.Dtos.Responses.Interfaces;
using Newtonsoft.Json;

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
                Request = dto,
                ResponseType = typeof(TResponseDto).FullName
            };

            var jsonToSend = JsonConvert.SerializeObject(request, Json.Serialization.Auto());

            var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
            var uri = connectorClient.BaseUrl + "EndPoint/Request";
            var response = connectorClient.HttpClient.PostAsync(uri, content);
            response.Wait();

            var result = JsonConvert.DeserializeObject<ApiResponseContextDto<TResponseDto>>
                (response.Result.Content.ReadAsStringAsync().Result, Json.Serialization.Auto());
            return result;
        }
    }
}