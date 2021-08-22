using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ui.test.Drivers;

namespace ui.test.Pages
{
    public class CheckoutStepTwoPage : Browser
    {
        private IWebElement CheckoutOverviewBtn => driver.FindElement(By.XPath("//*[@id=\"finish\"]"));

        public void CheckoutOverviewClick() => CheckoutOverviewBtn.Click();
    }
}
