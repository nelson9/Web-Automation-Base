using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace WebAutomation.Goldmine.Support
{
    /// <summary>
    /// This class helps us share the instance of the Selenium WebDriver via IoC
    /// </summary>
    [Binding]
    public class WebDriverSupport
    {
        private readonly IObjectContainer _objectContainer;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            // to make tests run faster we can switch this to a headless browser e.g. phantomjs once we've got things working, 
            // or we can do different browser testing
            var driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        private IWebDriver FireFoxDriver()
        {            
            var profile = new FirefoxProfile();
            profile.AcceptUntrustedCertificates = true;
            return  new FirefoxDriver(profile);
        }

        private IWebDriver PhantomDriver()
        {
            var service = PhantomJSDriverService.CreateDefaultService();
            service.IgnoreSslErrors = true;
            return new PhantomJSDriver(service);
        }
    }
}
