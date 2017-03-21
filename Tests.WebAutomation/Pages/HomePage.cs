using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace WebAutomation.Goldmine.Pages
{
    public class HomePage : Page
    {
        private const string PageUrl = @"";

        public HomePage(IWebDriver driver) : base(driver)
        { 
        }

        public static HomePage NavigateTo(IWebDriver driver)
        {
            var homePage = new HomePage(driver);
            homePage.NavigateTo(PageUrl);
            return homePage;
        }
    }
}
