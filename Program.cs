using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestDemoApp
{
    class Program
    {
        public static void SearchTest()
        {
            Console.WriteLine("Test Started");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();//maximize the browser window
            Thread.Sleep(1500);
            driver.FindElement(By.Name("q")).SendKeys("C# Tutorial");
            Thread.Sleep(2500);
            driver.FindElement(By.Name("btnK")).Click();
            Thread.Sleep(2500);
            Console.WriteLine("Test Ended");
            driver.Close();
        }
        public static void browserCommands()
        {
            Console.WriteLine("Test Started");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            Console.WriteLine(driver.Url);
            driver.Manage().Window.Maximize();//maximize the browser window
            Thread.Sleep(1500);
            driver.Url = "http://www.calculator.net";
            Thread.Sleep(1500);
            Console.WriteLine(driver.Url);
            driver.Navigate().Back();
            Thread.Sleep(1500);
            Console.WriteLine(driver.Url);
            driver.Navigate().Forward();
            Thread.Sleep(1500);
            Console.WriteLine(driver.Url);



        }
        static void Main(string[] args)
        {
            //SearchTest();
            browserCommands();
        }
    }
}
