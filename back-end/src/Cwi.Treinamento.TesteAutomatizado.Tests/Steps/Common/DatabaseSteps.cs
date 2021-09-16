using Cwi.Treinamento.TesteAutomatizado.Tests.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Cwi.Treinamento.TesteAutomatizado.Tests.Steps.Common
{
    [Binding]
    public class DatabaseSteps
    {
        private readonly PostgreDatabaseController _postgreDatabaseController;

        public DatabaseSteps(PostgreDatabaseController postgreDatabaseController)
        {
            _postgreDatabaseController = postgreDatabaseController;
        }

        [Given(@"que a base de dados esteja limpa")]
        public async Task DadoQueABaseDeDadosEstejaLimpa()
        {
            await _postgreDatabaseController.ClearDatabase();
        }

        [Then(@"o registro estará disponível na tabela '(.*)' da base de dados")]
        public async Task EntaoORegistroEstaraDisponivelNaTabelaDaBaseDeDados(string tableName, Table table)
        {
            var currenteItens = await _postgreDatabaseController.SelectFrom(tableName, table);

            Assert.NotZero(currenteItens.Count(), $"Não foram encontrados registros na tabela {tableName}.");

            var actualJsonResponse = JsonConvert.SerializeObject(currenteItens);
            var expectedJsonResponse = JsonConvert.SerializeObject(table.CreateDynamicSet()).Replace("'", "");

            Assert.IsTrue(JToken.DeepEquals(JToken.Parse(actualJsonResponse), JToken.Parse(expectedJsonResponse)), $"Conteúdo atual do retorno \n {actualJsonResponse} \n diferente do esperado: \n {expectedJsonResponse}.");
        }

    }
}
