using autotests.Drivers;
using autotests.Page;
using autotests.ReportingLibrary;
using autotests.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
namespace autotests.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        protected static ExtentReportsHelper extent;
        public static DecatlonPage decatlonPage;
        public static DecatlonLoginPage decatlonLoginPage;
        public static DecatlonSearchFilterPage decatlonSearchFilter;
        public static DecatlonItemPage decatlonItemPage;
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChromeWithSpecOptions();
            extent = new ExtentReportsHelper();
            decatlonPage = new DecatlonPage(driver);
            decatlonLoginPage = new DecatlonLoginPage(driver);
            decatlonSearchFilter = new DecatlonSearchFilterPage(driver);
            decatlonItemPage = new DecatlonItemPage(driver);
        }
        [SetUp]
        public static void SetUp()
        {
            extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
            MyReport.GenerateReport(driver, extent);
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            extent.Close();
            driver.Quit();
        }
    }
}