using Cwi.Treinamento.TesteAutomatizado.Tests.Controllers;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.Treinamento.TesteAutomatizado.Tests.Steps.Employee
{
    [Binding]
    [Scope(Tag = "CreateEmployee")]
    public class CreateEmployeeSteps
    {
        private readonly HttpRequestController _httpRequestController;

        public CreateEmployeeSteps(HttpRequestController httpRequestController)
        {
            _httpRequestController = httpRequestController;
        }

        [Given(@"que seja solicitado a criação de um novo usuário")]
        public async Task DadoQueSejaSolicitadoACriacaoDeUmNovoUsuario()
        {
            _httpRequestController.AddRequestJsonBody(new { Name = "Funcionario Teste", Email = "funcionario1@email.com" });

            await _httpRequestController.SendAsync("v1/employees", "POST");
        }

        [Given(@"que seja solicitado a criação de um novo usuário sem o preenchimento dos campos obrigatórios")]
        public async Task DadoQueSejaSolicitadoACriacaoDeUmNovoUsuarioSemOPreenchimentoDosCamposObrigatorios()
        {
            _httpRequestController.AddRequestJsonBody(new { });

            await _httpRequestController.SendAsync("v1/employees", "POST");
        }


        [Then(@"o funcionário não será cadastrado")]
        public void EntaoOFuncionarioNaoSeraCadastrado()
        {
            Assert.AreNotEqual(HttpStatusCode.Created, _httpRequestController.GetResponseMessageHttpStatusCode());
        }

        [Then(@"o funcionário será cadastrado")]
        public void EntaoOFuncionarioSeraCadastrado()
        {
            Assert.AreEqual(HttpStatusCode.Created, _httpRequestController.GetResponseMessageHttpStatusCode());
        }


        [Then(@"será retornado uma mensagem de erro de autenticação")]
        public void EntaoSeraRetornadoUmaMensagemDeErroDeAutenticacao()
        {
            Assert.AreEqual(HttpStatusCode.Unauthorized, _httpRequestController.GetResponseMessageHttpStatusCode());
        }

        [Then(@"será retornado uma mensagem de falha de preenchimento de campos obrigatórios")]
        public void EntaoSeraRetornadoUmaMensagemDeFalhaDePreenchimentoDeCamposObrigatorios()
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, _httpRequestController.GetResponseMessageHttpStatusCode());
        }
    }
}
