using NUnit.Framework;
using OpenQA.Selenium;
namespace autotests.Page
{
    public class DecatlonItemPage : BasePage
    {
        private IWebElement inspectItemText => Driver.FindElement(By.CssSelector("#main > div.row.m0.js-equalizer > div.col-xs-12.col-lg-4.bloc__product-info > div > div > h1"));
        public DecatlonItemPage(IWebDriver webdriver) : base(webdriver) { }
        public void VerifyItemNameContainsSearchText(string item)
        {
            Assert.IsTrue(inspectItemText.Text.Contains(item), "Item name does not match search");
        }
    }
}

