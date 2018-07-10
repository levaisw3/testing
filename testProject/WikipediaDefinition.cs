using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Collections;

namespace testProject
{
    [Binding]
    public sealed class WikipediaDefinition
    {
        IWebDriver driver;
        IWebElement BDD;
        [Given(@"I open my webbrowser")]
        public void GivenIOpenMyWebbrowser()
        {
            driver = new FirefoxDriver();
        }

        [Given(@"I navigate to the wikipedia site: ""(.*)""")]
        public void GivenINavigateToTheWikipediaSite(string p0)
        {
            driver.Url = @"http://www.wikipedia.org/";
            Assert.AreEqual("Wikipedia", driver.Title);
        }

        [Given(@"I choose the English language")]
        public void GivenIChooseTheEnglishLanguage()
        {
            driver.FindElement(By.Id("js-link-box-en")).Click();
            Assert.AreEqual("Wikipedia, the free encyclopedia", driver.Title);
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string p0)
        {
            driver.FindElement(By.Id("searchInput")).SendKeys("Test Automation");
            driver.FindElement(By.Id("searchButton")).Click();
            Assert.AreEqual("Test automation - Wikipedia", driver.Title);
        }

        [Then(@"""(.*)"" text exists in this page")]
        public void ThenTextExistsInThisPage(string p0)
        {
            driver.FindElement(By.XPath("//*[contains(text(),'Unit testing')]"));
            
        }

        [Then(@"""(.*)"" picture exists")]
        public void ThenPictureExists(string p0)
        {
            driver.FindElement(By.XPath("//img[contains(@src,'Test_Automation_Interface.png')]"));
            
            
        }

        [Then(@"I search for the link of Behavior driven development")]
        public void ThenISearchForTheLinkOfBehaviorDrivenDevelopment()
        {
            BDD = driver.FindElement(By.XPath("//a[@title='Behavior driven development']"));
            
        }

        [Then(@"I navigate to that page")]
        public void ThenINavigateToThatPage()
        {
            BDD.Click();
            Assert.AreEqual("Behavior-driven development - Wikipedia", driver.Title);
        }

    }
}
