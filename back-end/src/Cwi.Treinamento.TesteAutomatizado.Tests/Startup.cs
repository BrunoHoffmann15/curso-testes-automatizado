using BoDi;
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
        
        }
    }
}
