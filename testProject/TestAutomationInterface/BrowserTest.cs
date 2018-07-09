using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace testProject.TestAutomationInterface
{
    //I created a test for the firefox to open the pages in the .xml file
    class BrowserTest
    {
        IWebDriver driver;
        [SetUp] //called before test
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }
        [Test]
        public void OpenTest()
        {
            //I wanted to get the project directory dynamically.
            //Unfortunately the methods didn't work as I expected so I wrote here the
            //full path of the .xml.
            XmlTextReader reader = new XmlTextReader(@"C:\Users\david\Documents\Visual Studio 2015\Projects\testProject\testProject\TestAutomationInterface\ObjectRepository.xml");
            while (reader.Read()) //read until the end of the file
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    driver.Url = reader.Value;
                }
            }
            
        }
        [TearDown] //called after test
        public void EndTest()
        {
            driver.Close();
        }
    }
}
