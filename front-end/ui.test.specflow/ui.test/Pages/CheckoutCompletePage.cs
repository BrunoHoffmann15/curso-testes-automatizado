using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ui.test.Drivers;

namespace ui.test.Pages
{
    public class CheckoutCompletePage : Browser
    {
        public IWebElement ThankYouForYourOrderTxt => driver.FindElement(By.XPath("//*[@id=\"checkout_complete_container\"]/h2"));

        public string GetThankYouForOrderText() => ThankYouForYourOrderTxt.Text;
    }
}
