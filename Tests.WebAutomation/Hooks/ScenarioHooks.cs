using BoDi;
using WebAutomation.Constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace WebAutomation.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        protected IWebDriver _driver;

        public ScenarioHooks(IWebDriver driver)
        {
            _driver = driver;
        }

        [BeforeScenario]
        public static void RestClientSettings()
        {
         
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // dispose of webdriver
            if (_driver != null)
            {
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
