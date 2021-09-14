using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cwi.Treinamento.TesteAutomatizado.Tests.Controllers
{
    public class HttpRequestController
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Uri _baseUrl;
        private HttpRequestMessage HttpRequestMessage;
        private HttpResponseMessage HttpResponseMessage;

        public HttpRequestController(IHttpClientFactory httpClientFactory, string baseUrl)
        {
            _httpClientFactory = httpClientFactory;
            _baseUrl = new Uri(baseUrl);
        }

        private HttpRequestMessage GetHttpRequestMessage() 
        {
            if (HttpRequestMessage == null)
                HttpRequestMessage = new HttpRequestMessage();

            return HttpRequestMessage;
        }

        public async Task SendAsync(string endpoint, string httpMethodName) 
        {
            var request = GetHttpRequestMessage();

            request.RequestUri = new Uri(_baseUrl, endpoint);

            request.Method = GetMethodFromName(httpMethodName);

            HttpResponseMessage = await _httpClientFactory.CreateClient().SendAsync(request);

            return 
        } 

        private HttpMethod GetMethodFromName(string methodName) 
        {
            switch (methodName.ToLower()) 
            {
                case "get":
                    return HttpMethod.Get;
                case "post":
                    return HttpMethod.Post;
                case "patch":
                    return HttpMethod.Patch;
                case "put":
                    return HttpMethod.Put;
                case "delete":
                    return HttpMethod.Delete;
                case "options":
                    return HttpMethod.Options;
                case "head":
                    return HttpMethod.Head;
                default:
                    return HttpMethod.Get;
            }            
        }
    }
}
