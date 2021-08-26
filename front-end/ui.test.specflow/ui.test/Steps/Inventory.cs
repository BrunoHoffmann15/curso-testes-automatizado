using TechTalk.SpecFlow;
using ui.test.Drivers;

namespace ui.test.Steps
{
    [Binding]
    public class Inventory : Browser
    {

        [Then(@"tenho o produto (.*) com o valor (.*)")]
        public void EntaoTenhoOProdutoComOValor(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
