using BoDi;
using Cwi.Treinamento.TesteAutomatizado.Tests.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.IO;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace Cwi.Treinamento.TesteAutomatizado.Tests
{
    [Binding]
    public class Startup
    {
        private readonly IObjectContainer _objectContainer;

        public Startup(IObjectContainer objectContainer) 
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void DependencyInjection()
        {
            var configuration = GetConfiguration();
            var httpRequestController = new HttpRequestController(GetHttpClientFactory(), configuration["ExampleApi"]);
            var postgreDatabaseController = new PostgreDatabaseController(new NpgsqlConnection(configuration["ConnectionStrings:ExemploDb"]));

            _objectContainer.RegisterInstanceAs<HttpRequestController>(httpRequestController);
            _objectContainer.RegisterInstanceAs<IConfiguration>(configuration);
            _objectContainer.RegisterInstanceAs<PostgreDatabaseController>(postgreDatabaseController);
        }

        private IConfiguration GetConfiguration() 
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT");

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{envName}.json", optional: true)
                .Build();
        }

        private IHttpClientFactory GetHttpClientFactory() 
        {
            return new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider()
                .GetRequiredService<IHttpClientFactory>();
        }
    }
}
