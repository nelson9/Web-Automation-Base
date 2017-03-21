using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Drawing;

namespace WebAutomation.Goldmine.Pages
{
    public abstract class Page
    {
        private const int _maxWaitSeconds = 30;
        protected readonly IWebDriver _driver;

        public Page(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            this.WaitForPageLoad();
        }

        protected void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        protected void WaitAndClick(IWebElement element, int maxWaitSeconds = _maxWaitSeconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }

        protected string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public string GetTitle()
        {
            return _driver.Title;
        }
 
        protected void WaitForPageLoad()
        {
            Thread.Sleep(1000);
        }

        protected IWebElement WaitToFindElement(By by, int maxWaitSeconds = _maxWaitSeconds)
        {
            // wait until element can be found (to allow for loading delays)
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitSeconds));
            IWebElement element = wait.Until((d) =>
            {
                return d.FindElement(by);
            });

            return element;
        }

        protected IWebElement WaitForVisibility(By byCriterion, int maxWaitSeconds = _maxWaitSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitSeconds));
            return wait.Until(ExpectedConditions.ElementExists(byCriterion));
        }

        protected bool WaitForNotVisible(By byCriterion, int maxWaitSeconds = _maxWaitSeconds)
        {           
           var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxWaitSeconds));
           return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(byCriterion));
        }
    }
}
