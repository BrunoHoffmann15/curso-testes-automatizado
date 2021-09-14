using Cwi.Treinamento.TesteAutomatizado.Tests.Controllers;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.Treinamento.TesteAutomatizado.Tests.Steps.Employee
{
    [Binding]
    public class CreateEmployeeSteps
    {
        private readonly HttpRequestController _httpRequestController;

        public CreateEmployeeSteps(HttpRequestController httpRequestController)
        {
            _httpRequestController = httpRequestController;
        }

        [Given(@"que o usuário não esteja autenticado")]
        public void DadoQueOUsuarioNaoEstejaAutenticado()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"que seja solicitado a criação de um novo usuário")]
        public async Task DadoQueSejaSolicitadoACriacaoDeUmNovoUsuario()
        {
            await _httpRequestController.SendAsync("v1/employees", "POST");
        }

        [Then(@"o funcionário não será cadastrado")]
        public void EntaoOFuncionarioNaoSeraCadastrado()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"será retornado uma mensagem de erro de autenticação")]
        public void EntaoSeraRetornadoUmaMensagemDeErroDeAutenticacao()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
