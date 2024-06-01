using KudoCode.Contracts;
using System;
using System.Net.Http;

namespace KudoCode.Contracts.Web
{
	public class ConnectorClient
    {
        public string BaseUrl = "https://localhost:63219/Api/";
        public ITokenDto Token;
        public HttpClient HttpClient;

        public void NewClient(string url)
        {
            BaseUrl = url;
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(BaseUrl);
        }

        public void SetToken(ITokenDto dto)
        {
            if (dto?.Value == null)
                return;
            Token = dto;
            HttpClient.DefaultRequestHeaders.Remove("Authorization");
            HttpClient.DefaultRequestHeaders.Add("Authorization", Token.Value);
        }
    }


}