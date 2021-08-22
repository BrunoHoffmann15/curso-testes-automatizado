using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ui.test.Drivers;

namespace ui.test.Pages
{
    public class CheckoutStepOnePage : Browser
    {
        private IWebElement FirstNameTxt => driver.FindElement(By.XPath("//*[@id=\"first-name\"]"));
        private IWebElement LastNameTxt => driver.FindElement(By.XPath("//*[@id=\"last-name\"]"));
        private IWebElement ZipPostalCodeTxt => driver.FindElement(By.XPath("//*[@id=\"postal-code\"]"));
        private IWebElement CheckoutYourInformationBtn => driver.FindElement(By.XPath("//*[@id=\"continue\"]"));

        public void YourInformationSendKeys(string firstName, string lastName, string zipPostalCode)
        {
            FirstNameTxt.SendKeys(firstName);
            LastNameTxt.SendKeys(lastName);
            ZipPostalCodeTxt.SendKeys(zipPostalCode);
        }

        public void CheckoutYourInformationClick() => CheckoutYourInformationBtn.Click();
    }
}
