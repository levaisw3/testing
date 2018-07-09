using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace testProject.SpecflowTest
{
    //Here I tested the "Google" to try out Specflow
    [Binding]
    public sealed class BrowserDefinition
    {
        IWebDriver driver;
        //Methods are generated from the .feature file
        [Given(@"I go to the page ""(.*)""")]
        public void GivenIGoToThePage(string p0)
        {
            driver = new FirefoxDriver();
            driver.Url= "http://www.google.com";
        }

        [Given(@"I see the page")]
        public void GivenISeeThePage()
        {
            Assert.AreEqual("Google", driver.Title);
        }

        [When(@"I enter keyword in the search text box")]
        public void WhenIEnterKeywordInTheSearchTextBox(Table table)
        {
            string st = table.Rows[0]["Keyword"].ToString();
            driver.FindElement(By.Name("q")).SendKeys(st);
        }

        [When(@"I click Search Button")]
        public void WhenIClickSearchButton()
        {
            driver.FindElement(By.Name("btnK")).Click();
            
        }

        [Then(@"I see the search result")]
        public void ThenISeeTheSearchResult()
        {
            Assert.AreEqual("wikipedia - Google-keresés", driver.Title);
            driver.Close();
        }
       
    }
}
