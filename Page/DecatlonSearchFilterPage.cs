using OpenQA.Selenium;
namespace autotests.Page
{
    public class DecatlonSearchFilterPage : BasePage
    {

        private IWebElement selectCheckbox1 => Driver.FindElement(By.CssSelector("#available > div > div.ais-Panel-body.open > div > ul > li > a > label > span.ais-RefinementList-labelText"));
        private IWebElement clickMoreBrandResults => Driver.FindElement(By.CssSelector("#brands > div > div.ais-Panel-body.open > div > div > button"));
        private IWebElement selectItemBrand => Driver.FindElement(By.CssSelector("#brands > div > div.ais-Panel-body.open > div > div > ul > li:nth-child(14) > div > label > span.ais-RefinementList-labelText"));
        private IWebElement selectJacket => Driver.FindElement(By.CssSelector("#hits > div > div > ol > li:nth-child(1)"));
        public DecatlonSearchFilterPage(IWebDriver webdriver) : base(webdriver) { }
        public void ClickFirstCheckbox()
        {
            selectCheckbox1.Click();
        }
         public void ClickOnJacket()
        {
            selectJacket.Click();
            selectJacket.Click();
        }
        public void SelectBrand()
        {
            clickMoreBrandResults.Click();
            selectItemBrand.Click();
        }
    }
}
