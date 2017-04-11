using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using Protractor;
using System.Drawing.Imaging;

namespace AngularJS_site_test
{
    public class WebDriver
    {
        public IWebDriver Driver { get; }
        private IWait<IWebDriver> _wait;
        private LoggerClass _log;
        private const int _waitTimeout = 15;
        private NgWebDriver _ngDriver;

        public WebDriver(LoggerClass log)
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            _ngDriver = new NgWebDriver(Driver);
            
            //_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_waitTimeout));
            _log = log;
        }

        public void Quit()
        {
            _log.Log("Test Quit");
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Quit();
        }

        public void Navigate(string url)
        {
            _log.Log($"Navigating is {url}");
            _ngDriver.Url = url;
            //_driver.Manage().Window.Maximize();
        }

        public void SendKeys(By locator, string text)
        {
            _log.Log($"Text '{text}' entered in the locator {locator}");
            var element = GetElement(locator);
            element.SendKeys(text);
        }

        public string GetText(By locator)
        {
            //string text = FindElementWithWaiting(locator).Text;
            var text = GetElement(locator).Text;
            _log.Log($"Get text locator {locator} ({text})");
            return text;
        }

        public string GetText(IWebElement element)
        {
            _log.Log($"Get text locator {element.TagName} ({element.Text})");
            return element.Text;
        }

        public void Click(By locator)
        {
            _log.Log($"Click to locator {locator}");
            var element = GetElement(locator);
            element.Click();
        }

        public NgWebElement GetElement(By locator)
        {
            var el = _ngDriver.FindElement(locator);
            return el;
        }

        public IList<NgWebElement> FindAllElements(By locator)
        {
            _log.Log($"Getting the list of elements by locator {locator} ");
            IList<NgWebElement> allElements = _ngDriver.FindElements(locator);
            return allElements;
        }

        //public Collection GetElements(By locator)
        //{
        //    var el = _ngDriver.FindElements(locator);
        //    return el;
        //}
    }
}
