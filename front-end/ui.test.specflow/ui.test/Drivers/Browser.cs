using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace ui.test.Drivers
{
    public class Browser
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;

        public static IWebDriver GetCurrentDriver() 
        { 
            if (driver == null)
            {
                try 
                {
                    ChromeOptions options = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
                    driver.Manage().Window.Minimize();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                }
                catch (Exception ex) 
                {
                    throw ex;
                }
            }

            return driver;
        }

        public static void LoadPage(String url) 
        {
            GetCurrentDriver().Url = url;
        }

        public static void CloseDriver() 
        {
            try
            {
                GetCurrentDriver().Close();
                driver = null;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
