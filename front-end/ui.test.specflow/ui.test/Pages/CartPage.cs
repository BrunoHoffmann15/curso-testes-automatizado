using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ui.test.Drivers;

namespace ui.test.Pages
{
    public class CartPage : Browser
    {
        private IWebElement CartLnk => driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a"));
        
        private IWebElement CheckoutCartBtn => driver.FindElement(By.XPath("//*[@id=\"checkout\"]"));

        public void CartClick() => CartLnk.Click();

        public void CheckoutCartClick() => CheckoutCartBtn.Click();

    }
}
