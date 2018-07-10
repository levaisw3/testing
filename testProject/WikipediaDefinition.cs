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

        //The first three step is preconditions
        //I navigate to a page which I can validate
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
            //After I navigate to a web page, I check the result.
        }

        [Given(@"I choose the English language")]
        public void GivenIChooseTheEnglishLanguage()
        {
            driver.FindElement(By.Id("js-link-box-en")).Click();
            Assert.AreEqual("Wikipedia, the free encyclopedia", driver.Title);
        }
        //I search for a page that contains a specific text and a picture
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
            //I am looking for the 'Unit testing' text in every type of element
            //Finding the first one means the page contains it and the test will pass
            driver.FindElement(By.XPath("//*[contains(text(),'Unit testing')]"));
            
        }

        [Then(@"""(.*)"" picture exists")]
        public void ThenPictureExists(string p0)
        {
            //I am looking for an image, and Test_Automation_Interface in the src
            driver.FindElement(By.XPath("//img[contains(@src,'Test_Automation_Interface')]"));
            
            
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
