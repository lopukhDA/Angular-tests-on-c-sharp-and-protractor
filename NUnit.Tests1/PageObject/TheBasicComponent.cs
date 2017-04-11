using OpenQA.Selenium;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS_site_test.PageObject
{
    class TheBasicComponent
    {

        private WebDriver _driver;

        public TheBasicComponent(WebDriver driver)
        {
            _driver = driver;
        }

        public void Open(string url)
        {
            _driver.Navigate(url);
        }

        public By InputYourName { get; set; } = NgBy.Model("yourName");
        public By TextYourName { get; set; } = NgBy.Binding("yourName");
        

        public string SendYourNameAndReturnResult(string text)
        {
            _driver.SendKeys(InputYourName, text);
            return _driver.GetText(TextYourName);
        }
    }
}
