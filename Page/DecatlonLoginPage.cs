using NUnit.Framework;
using OpenQA.Selenium;
namespace autotests.Page
{
    public class DecatlonLoginPage : BasePage
    {
        private IWebElement emailInputField => Driver.FindElement(By.CssSelector("#input-email"));
        private IWebElement emailClickButtonNext => Driver.FindElement(By.CssSelector("#lookup-btn"));
        private IWebElement resultElement => Driver.FindElement(By.CssSelector("#form-sign-in > div:nth-child(1) > div > div.textfield-error > p"));
        public DecatlonLoginPage(IWebDriver webdriver) : base(webdriver) { }
        public void EmailInput(string text)
        {
            GetWait().Until(d => Driver.FindElement(By.CssSelector("#input-email")).Displayed);
            emailInputField.Click();
            emailInputField.SendKeys(text);
            emailClickButtonNext.Click();
        }
        public void VerifyResult(string message)
        {
            Assert.IsTrue(resultElement.Text.Contains(message), "Result is wrong");
        }
    }
}