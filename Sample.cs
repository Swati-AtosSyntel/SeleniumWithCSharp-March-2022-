using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumTestDemoApp
{
    class Sample
    {
        IWebDriver driver;
        [SetUp]
        public void StartTest()
        {
            //driver = new ChromeDriver();
            driver = new FirefoxDriver();

        }
        [Test]
        public void SearchTest()

        {
            Console.WriteLine("Test Case started");
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();//maximize the browser window
            Thread.Sleep(1500);
            driver.FindElement(By.Name("q")).SendKeys("C# Tutorial");
            Thread.Sleep(2500);
            driver.FindElement(By.Name("btnK")).Click();
            Thread.Sleep(2500);
            Console.WriteLine("Test Ended");


        }
        [Test]
        public void calculatorTest()
        {
            Console.WriteLine("Calculator test started");
            driver.Url = "https://www.calculator.net/";
            Thread.Sleep(1500);
            driver.FindElement(By.PartialLinkText("Loan")).Click();
            Thread.Sleep(2000);
            IWebElement amt = driver.FindElement(By.Id("cloanamount"));
            Thread.Sleep(2000);
            amt.Clear();
            amt.SendKeys("5000000");
            IWebElement term = driver.FindElement(By.Id("cloanterm"));
            Thread.Sleep(2000);
            term.Clear();
            term.SendKeys("15");
            IWebElement rate_of_interest = driver.FindElement(By.Id("cinterestrate"));
            Thread.Sleep(2000);
            rate_of_interest.Clear();
            rate_of_interest.SendKeys("7.3");
            IWebElement compound = driver.FindElement(By.Id("ccompound"));
            Thread.Sleep(2000);
            SelectElement oSelect = new SelectElement(compound);
            oSelect.SelectByIndex(3);
            IWebElement payBack = driver.FindElement(By.Id("cpayback"));
            Thread.Sleep(2000);
            SelectElement oSelect1 = new SelectElement(payBack);
            oSelect1.SelectByText("Every Quarter");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#calinputtable > tbody > tr:nth-child(7) > td > input[type=image]")).Click();
            Thread.Sleep(2500);
            IWebElement result = driver.FindElement(By.XPath("//*[@id='content']/table[1]/tbody/tr/td[3]/table"));
            Thread.Sleep(2000);
            string text = result.Text;
            Console.WriteLine(text);
        }
        [Test]
        public void RadioButtonExample()
        {
            driver.Navigate().GoToUrl("file:///D:/Swati/Campus%20Hire%20Induction/Manila/SeleniumTestDemoApp/SeleniumTestDemoApp/index.html");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1500);
            IList<IWebElement> genderList = driver.FindElements(By.Name("Gender"));
            Thread.Sleep(1500);
            genderList[0].Click();
            genderList.ElementAt(0).Click();
            if (genderList[0].Selected)
            {
                genderList[1].Click();
                Console.WriteLine(genderList[0].GetAttribute("Value"));
            }
            else
                Console.WriteLine(genderList[1].GetAttribute("Value"));
            
        }
        [Test]
        public void dropdown()
        {
            driver.Navigate().GoToUrl("file:///D:/Swati/Campus%20Hire%20Induction/Manila/SeleniumTestDemoApp/SeleniumTestDemoApp/index.html");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1500);
            IWebElement years = driver.FindElement(By.Id("Year"));
            SelectElement selectedElement = new SelectElement(years);
            selectedElement.SelectByText("2003");
            Console.WriteLine(selectedElement.SelectedOption.Text);
            IList<IWebElement> options = selectedElement.Options;
            int count = options.Count;
            for(int i = 0; i < count; i++)
            {
                string val = selectedElement.Options.ElementAt(i).Text;
                Console.WriteLine(val);
                selectedElement.SelectByIndex(i);

                Thread.Sleep(1500);

            }
            selectedElement.DeselectAll();
        }
        [Test]
        public void DynamicWebTables()
        {
            driver.Url = "https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites";
            Thread.Sleep(2000);
            // IWebElement table = driver.FindElement(By.XPath("//*[@id='mw - content - text']/div[1]/table[1]"));
            IWebElement table = driver.FindElement(By.CssSelector("#mw-content-text > div.mw-parser-output > table:nth-child(2)"));
            Thread.Sleep(2000);
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            Thread.Sleep(2000);
            string rowData = "";
            foreach(var r in rows)
            {
                IList<IWebElement> rowValues = r.FindElements(By.TagName("td"));
                Thread.Sleep(2000);
                foreach(var data in rowValues)
                {
                    rowData = rowData + data.Text+"\t";
                    Console.WriteLine(rowData);
                }
            }
        }
        [TearDown]
        public void EndTest()
        {
            Console.WriteLine("Test Case ended");
            driver.Close();//close current active browser window
            //driver.Quit();//close all browser windows opened by webdriver
        }
    }
}
