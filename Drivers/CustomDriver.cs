using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace autotests.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChrome()
        {
            return GetDriver(Browsers.Chrome);
        }
        public static IWebDriver GetChromeWithSpecOptions()
        {
            return GetDriver(Browsers.ChromeWithOptions);
        }
        private static IWebDriver GetDriver(Browsers webDriver)
        {
            IWebDriver driver = null;
            switch (webDriver)
            {
                case Browsers.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browsers.IncognitoChrome:
                    driver = GetChromeWithIncognitoOptions();
                    break;
                case Browsers.ChromeWithOptions:
                    driver = GetChromeWithOptions();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
        private static IWebDriver GetChromeWithIncognitoOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            return new ChromeDriver(options);
        }
        private static IWebDriver GetChromeWithOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            return new ChromeDriver(options);
        }
    }
}