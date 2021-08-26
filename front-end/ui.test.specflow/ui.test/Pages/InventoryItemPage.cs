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
        
        public string GetValorProduto() 
        {
            string valor = driver.FindElement(By.XPath("//*[@id=\"inventory_item_container\"]/div/div/div[2]/div[3]")).Text;

            return valor.Replace("$", "");
        }
    }
}
