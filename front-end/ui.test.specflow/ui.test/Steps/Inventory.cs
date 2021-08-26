using NUnit.Framework;
using TechTalk.SpecFlow;
using ui.test.Drivers;
using ui.test.Pages;

namespace ui.test.Steps
{
    [Binding]
    public class Inventory : Browser
    {
        private readonly InventoryPage _inventoryPage;
        private readonly InventoryItemPage _inventoryItemPage;

        public Inventory(
            InventoryPage inventoryPage,
            InventoryItemPage inventoryItemPage)
        {
            _inventoryPage = inventoryPage;
            _inventoryItemPage = inventoryItemPage;
        }

        [Then(@"tenho o produto (.*) com o valor (.*)")]
        public void EntaoTenhoOProdutoComOValor(string nomeProduto, string valorProduto)
        {
            _inventoryPage.SelectProduto(nomeProduto);
            string valor = _inventoryItemPage.GetValorProduto();

            Assert.AreEqual(valorProduto, valor);
        }

    }
}
