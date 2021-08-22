using OpenQA.Selenium;
using ui.test.Drivers;

namespace ui.test.Pages
{
    public class InventoryPage : Browser
    {
        private IWebElement MenuBtn => driver.FindElement(By.XPath("//*[@id=\"react-burger-menu-btn\"]"));
        private IWebElement MenuWindow => driver.FindElement(By.XPath("//*[@id=\"menu_button_container\"]/div/div[2]/div[1]"));
        private IWebElement MenuLogoutLnk => driver.FindElement(By.XPath("//*[@id=\"logout_sidebar_link\"]"));



        public void MenuClick() => MenuBtn.Click();

        public bool IsMenuWindowVisible => MenuWindow.Displayed;

        public bool IsMenuLnkVisible => MenuLogoutLnk.Displayed;

        public void SelectProduto(string produto) => driver.FindElement(By.XPath($"//*[text()=\"{produto}\"]")).Click();
    }
}