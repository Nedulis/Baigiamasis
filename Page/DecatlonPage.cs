using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace autotests.Page
{
    public class DecatlonPage : BasePage
    {
        private const string AddressUrl = "https://www.decathlon.lt/lt/";
        private IWebElement acceptCookies => Driver.FindElement(By.Id("lgcookieslaw_accept"));
        private IWebElement searchField => Driver.FindElement(By.Id("aa-search-input"));
        private IWebElement accountIcon => Driver.FindElement(By.CssSelector(".icon-account"));
        private IWebElement loginButton => Driver.FindElement(By.CssSelector(".btn.btn--color-primary.mb2.full"));
        private SelectElement orderDropdown => new SelectElement(Driver.FindElement(By.CssSelector("#sort-by > select")));
        private string firstItemPrice => Driver.FindElement(By.CssSelector("#hits > div > div > ol > li:nth-child(1) > div > div > div > div > div:nth-child(4) > div > div > span.price")).Text;
        public DecatlonPage(IWebDriver webdriver) : base(webdriver) { }
        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        public void AcceptCookies()
        {
            acceptCookies.Click();
        }
        public void SearchForItemByText(string item)
        {
            searchField.Clear();
            searchField.Click();
            searchField.SendKeys(item);
        }
        public void OpenLoginWindow()
        {
            accountIcon.Click();
            loginButton.Click();
        }
        public void SelectValueFromOrderDropdown(string value)
        { 
            orderDropdown.SelectByValue(value);
        }
        public void VerifyMostExpencivePriceResult(string price)
        {
            Assert.IsTrue(firstItemPrice == price, "False, price is not correct");
        }
    }
}
