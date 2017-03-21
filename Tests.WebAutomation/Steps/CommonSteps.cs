using WebAutomation.Constants;
using WebAutomation.Goldmine.Extensions;
using WebAutomation.Goldmine.Pages;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace WebAutomation.Goldmine.Steps
{
    [Binding]
    public class CommonSteps 
    {
        protected IWebDriver _driver;

        public CommonSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I Navigate to homepage")]
        public void GivenINavigateToHomepage()
        {
            var homePage = HomePage.NavigateTo(_driver);
            ScenarioContext.Current.SaveValue(homePage);
        }
    }
}
