using Cwi.Treinamento.TesteAutomatizado.Tests.Controllers;
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


    }
}
