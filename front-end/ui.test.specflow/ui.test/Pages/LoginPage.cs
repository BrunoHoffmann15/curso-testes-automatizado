using OpenQA.Selenium;
using ui.test.Drivers;

namespace ui.test.Pages
{
    public class LoginPage : Browser
    {
        private IWebElement BotImg => driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div[1]/div[2]"));
        private IWebElement UsernameTxt => driver.FindElement(By.XPath("//*[@id=\"user-name\"]"));
        private IWebElement PasswordTxt => driver.FindElement(By.XPath("//*[@id=\"password\"]"));
        private IWebElement LoginBtn => driver.FindElement(By.XPath("//*[@id=\"login-button\"]"));
        private IWebElement ErrorMsg => driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]"));

        public bool IsBotImgExist() => BotImg.Displayed;

        public void LoginSendKeys(string username, string password) 
        {
            UsernameTxt.SendKeys(username);
            PasswordTxt.SendKeys(password);
        }

        public void LoginClick() => LoginBtn.Click();

        public string GetErrorMessage() => ErrorMsg.Text;
    }
}