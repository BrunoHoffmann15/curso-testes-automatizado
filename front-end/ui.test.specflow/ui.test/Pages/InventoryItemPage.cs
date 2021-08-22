using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ui.test.Drivers;

namespace ui.test.Pages
{
    public class InventoryItemPage : Browser
    {
        public void AddToCart(string produto) 
        {
            string produtoIdFormmat = produto.Replace(" ", "-").ToLower();

            driver.FindElement(By.XPath($"//*[@id=\"add-to-cart-{produtoIdFormmat}\"]")).Click();
        } 
    }
}
