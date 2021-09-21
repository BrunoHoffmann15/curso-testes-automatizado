using Cwi.Treinamento.TesteAutomatizado.Tests.Controllers;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.Treinamento.TesteAutomatizado.Tests.Steps.Common
{
    [Binding]
    public class HttpRequestSteps
    {
        private readonly HttpRequestController _httpRequestController;

        public HttpRequestSteps(HttpRequestController httpRequestController) 
        {
            _httpRequestController = httpRequestController;
        }

        [Given(@"que seja feita uma chamada do tipo '(.*)' para o endpoint '(.*)' com o corpo da requisição")]
        public async Task DadoQueSejaFeitaUmaChamadaDoTipoParaOEndpointComOCorpoDaRequisicao(string httpMethodName, string endpoint, string requestBody)
        {
            _httpRequestController.AddRequestJsonBody(requestBody);

            await _httpRequestController.SendAsync(endpoint, httpMethodName);
        }

        [Given(@"que seja feita uma chamada do tipo '(.*)' para o endpoint '(.*)'")]
        public async Task DadoQueSejaFeitaUmaChamadaDoTipoParaOEndpoint(string httpMethodName, string endpoint)
        {
            await _httpRequestController.SendAsync(endpoint, httpMethodName);
        }


        [Then(@"o código de retorno será '(.*)'")]
        public void EntaoOCodigoDeRetornoSera(int httpStatusCode)
        {
            Assert.AreEqual(httpStatusCode, (int) _httpRequestController.GetResponseMessageHttpStatusCode());
        }

        [Then(@"o conteúdo retornado será")]
        public async Task EntaoOConteudoRetornadoSera(string responseExpected)
        {
            string jsonResult = await _httpRequestController.GetResponseBodyContent();

            var expectedObject = JsonConvert.DeserializeObject<object>(responseExpected);
            var resultObject = JsonConvert.DeserializeObject<object>(jsonResult);

            Assert.AreEqual(JsonConvert.SerializeObject(expectedObject), JsonConvert.SerializeObject(resultObject));
        }

    }
}
