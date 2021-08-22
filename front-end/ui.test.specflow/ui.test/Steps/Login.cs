using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ui.test.Drivers;
using ui.test.Pages;

namespace ui.test.Steps
{
    [Binding]
    public sealed class Login : Browser
    {
        private readonly LoginPage _loginPage;
        private readonly InventoryPage _inventoryPage;

        public Login()
        {
            _loginPage = new LoginPage();
            _inventoryPage = new InventoryPage();
        }

        [Given(@"que acesso o site")]
        public void DadoQueAcessoOSite()
        {
            Browser.LoadPage("https://www.saucedemo.com/");
        }

        [Then(@"vejo que estou na login page")]
        public void EntaoVejoQueEstouNaLoginPage()
        {
            Assert.IsTrue(_loginPage.IsBotImgExist());
        }

        [When(@"informo as seguintes credenciais")]
        public void QuandoInformoAsSeguintesCredencias(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _loginPage.LoginSendKeys((string) data.Username, (string) data.Password);
        }

        [When(@"me autentico no sistema")]
        public void QuandoMeAutenticoNoSistema()
        {
            _loginPage.LoginClick();
        }

        [Then(@"o menu do usuário está visível")]
        public void EntaoOMenuDoUsuarioEstaVisivel()
        {
            _inventoryPage.MenuClick();

            Assert.IsTrue(_inventoryPage.IsMenuWindowVisible);
        }

        [Then(@"o usuário aparece logado")]
        public void EntaoOUsuarioApareceLogado()
        {
            Thread.Sleep(1000);

            Assert.IsTrue(_inventoryPage.IsMenuLnkVisible);
        }

        [Then(@"um erro aparece informando que o usuário está bloqueado")]
        public void EntaoUmErroApareceInformandoQueOUsuarioEstaBloqueado()
        {
            Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", _loginPage.GetErrorMessage());
        }

    }
}
