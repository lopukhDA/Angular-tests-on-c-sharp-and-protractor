//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Interactions;
//using Protractor;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace AngularJS_site_test
//{
//    [TestFixture]
//    public class TestClass
//    {
//        const string URL = "http://juliemr.github.io/protractor-demo/";

//        IWebDriver driver;
//        SuperCalculatorPage page;

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
//            page = new SuperCalculatorPage(driver, URL);
//        }

//        [TearDown]
//        public void Teardown()
//        {
//            driver.Quit();
//        }

//        [Test]
//        public void Should_have_a_history()
//        {
//            page.Add("1", "2");
//            page.Subtract("3", "4");
//            Assert.AreEqual(page.HistoryCount(), 2);

//            page.Divide("5", "6");
//            Assert.AreEqual(page.HistoryCount(), 3);
//        }

//        [Test]
//        public void PageObject_ThreeSubtractOne_ShouldBeTwo()
//        {
//            page.Subtract("1", "2");
//            Assert.AreEqual(page.LatestResultText, "-1");
//        }

//    }
//}
