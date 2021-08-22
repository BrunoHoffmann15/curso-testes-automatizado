using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ui.test.Drivers;
using ui.test.Pages;

namespace ui.test.Steps
{
    [Binding]
    public class Checkout : Browser
    {
        private readonly CheckoutCompletePage _checkoutCompletePage;
        private readonly CheckoutStepOnePage _checkoutStepOnePage;
        private readonly CheckoutStepTwoPage _checkoutStepTwoPage;
        private readonly InventoryItemPage _inventoryItemPage;
        private readonly InventoryPage _inventoryPage;
        private readonly CartPage _cartPage;

        public Checkout()
        {
            _checkoutCompletePage = new CheckoutCompletePage();
            _checkoutStepOnePage = new CheckoutStepOnePage();
            _checkoutStepTwoPage = new CheckoutStepTwoPage();
            _inventoryItemPage = new InventoryItemPage();
            _inventoryPage = new InventoryPage();
            _cartPage = new CartPage();
        }


        [When(@"adiciono o produto (.*)")]
        public void QuandoAdicionoOProduto(string produto)
        {
            _inventoryPage.SelectProduto(produto);
            _inventoryItemPage.AddToCart(produto);
        }

        [When(@"visualizo o carrinho")]
        public void QuandoVisualizoOCarrinho()
        {
            _cartPage.CartClick();
        }

        [When(@"sigo para as informações do Checkout")]
        public void QuandoSigoParaAsInformacoesDoCheckout()
        {
            _cartPage.CheckoutCartClick();
        }

        [When(@"insiro os dados pessoais")]
        public void QuandoInsiroOsDadosPessoais(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _checkoutStepOnePage.YourInformationSendKeys((string) data.FirstName, 
                                                         (string) data.LastName, 
                                                         (string) data.ZipPostalCode);
        }

        [When(@"sigo para o Overview do Checkout")]
        public void QuandoSigoParaOOverviewDoCheckout()
        {
            _checkoutStepOnePage.CheckoutYourInformationClick();
        }

        [When(@"finalizo a compra")]
        public void QuandoFinalizoACompra()
        {
            _checkoutStepTwoPage.CheckoutOverviewClick();
        }

        [Then(@"a página de pedido completo é exibida contendo a mensagem (.+)")]
        public void EntaoAPaginaDePedidoCompletoEExibidaContendoAMensagem(string mensagem)
        {
            string textoFinalizacao = _checkoutCompletePage.GetThankYouForOrderText();

            Assert.AreEqual(mensagem, textoFinalizacao);
        }

    }
}
