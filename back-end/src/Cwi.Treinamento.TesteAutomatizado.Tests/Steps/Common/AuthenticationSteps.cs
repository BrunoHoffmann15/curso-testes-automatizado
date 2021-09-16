using Cwi.Treinamento.TesteAutomatizado.Tests.Controllers;
using Cwi.Treinamento.TesteAutomatizado.Tests.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.Treinamento.TesteAutomatizado.Tests.Steps.Common
{
    [Binding]
    public class AuthenticationSteps
    {
        private readonly HttpRequestController _httpRequestController;
        private readonly IConfiguration _configuration;

        public AuthenticationSteps(HttpRequestController httpRequestController, IConfiguration configuration)
        {
            _httpRequestController = httpRequestController;
            _configuration = configuration;
        }

        [Given(@"que o usuário não esteja autenticado")]
        public void DadoQueOUsuarioNaoEstejaAutenticado()
        {
            _httpRequestController.RemoveHeader("Authorization");
        }

        [Given(@"que o usuário esteja autenticado")]
        public async Task DadoQueOUsuarioEstejaAutenticado()
        {
            _httpRequestController.AddRequestJsonBody(new { Username = _configuration["Authentication:Username"], Password = _configuration["Authentication:Password"] });

            await _httpRequestController.SendAsync("v1/public/auth", "POST");

            Assert.AreEqual(HttpStatusCode.OK, _httpRequestController.GetResponseMessageHttpStatusCode());

            var authenticationResponse = await _httpRequestController.GetTypedResponseBody<AuthenticationResponse>();

            _httpRequestController.AddHeader("Authorization", $"Bearer {authenticationResponse.AccessToken}");
        }
    }
}
