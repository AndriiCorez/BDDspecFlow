using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BDDexample.Steps
{
    [Binding]
    public class GoogleSearchSteps
    {
        IWebDriver _driver;

        public GoogleSearchSteps()
        {
            _driver = Browser.Current;
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [Given(@"I have navigated to Google page")]
        public void GivenIHaveNavigatedToGooglePage()
        {
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
        }
        
        [Given(@"I see the Google page fully loaded")]
        public void GivenISeeTheGooglePageFullyLoaded()
        {
            if (_driver.FindElement(By.Name("q")).Displayed == true)
                Console.WriteLine("Loaded");
            else
                Console.WriteLine("Failed to load");
        }
        
        [When(@"I type search keyword as")]
        public void WhenITypeSearchKeywordAs(Table table)
        {
            dynamic tableDetails = table.CreateDynamicInstance();
            _driver.FindElement(By.Name("q")).SendKeys(tableDetails.Keyword);
        }
        
        [Then(@"is hould see the result for keyword")]
        public void ThenIsHouldSeeTheResultForKeyword(Table table)
        {
            dynamic tableDetails = table.CreateDynamicInstance();
            string value = tableDetails.Keyword;
            if (_driver.FindElement(By.PartialLinkText(value)).Displayed == false)
                Assert.Fail(value + " control not found");
        }
    }
}
