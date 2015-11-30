using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace SeleniumGridDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DesiredCapabilities capability = null;
            IWebDriver driver = null;
            for (int i = 1; i < 4; i++)
            {
                switch (i)
                {
                    case 1:
                        capability = DesiredCapabilities.Firefox();
                        capability.SetCapability("BrowserName", "firefox");
                        break;
                    case 2:
                        capability = DesiredCapabilities.Chrome();
                        capability.SetCapability("BrowserName", "chrome");
                        break;
                    case 3:
                        capability = DesiredCapabilities.InternetExplorer();
                        capability.SetCapability("BrowserName", "internet explorer");
                        break;
                    default:
                        return;
                }

                driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl("http://www.baidu.com");
                IWebElement searchBox = driver.FindElement(By.Id("kw"));
                IWebElement searchButton = driver.FindElement(By.Id("su"));
                searchBox.SendKeys("Shinetech");
                searchButton.Click();
                driver.Dispose();
            }
        }
    }
}
