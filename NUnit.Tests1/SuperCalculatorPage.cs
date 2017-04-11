using OpenQA.Selenium;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace AngularJS_site_test
{
    public class SuperCalculatorPage
    {
        private NgWebDriver _ngDriver;

        public By FirstNumber { get; set; } = NgBy.Model("first");
        public By SecondNumber { get; set; } = NgBy.Model("second");
        public By GoButton { get; set; } = By.Id("gobutton");
        public By LatestResult { get; set; } = NgBy.Binding("latest");
        public By History { get; set; } = NgBy.Repeater("result in memory");
        public By Operators { get; set; } = NgBy.Model("operator");

        public SuperCalculatorPage(IWebDriver driver, string url)
        {
            _ngDriver = new NgWebDriver(driver);
            _ngDriver.Url = url;
        }

        public string LatestResultText
        {
            get { return _ngDriver.FindElement(LatestResult).Text; }
        }

        public void Add(string first, string second)
        {
            DoMath(first, second, "+");
        }

        public void Subtract(string first, string second)
        {
            DoMath(first, second, "-");
        }

        public void Multiply(string first, string second)
        {
            DoMath(first, second, "*");
        }

        public void Divide(string first, string second)
        {
            DoMath(first, second, "/");
        }

        private void DoMath(string first, string second, string op)
        {
            SetFirst(first);
            SetSecond(second);
            SetOperator(op);
            ClickGo();
        }

        private void SetFirst(string number)
        {
            var first = _ngDriver.FindElement(FirstNumber);
            first.Clear();
            first.SendKeys(number);
        }

        private void SetSecond(string number)
        {
            var second = _ngDriver.FindElement(SecondNumber);
            second.Clear();
            second.SendKeys(number);
        }

        private void SetOperator(string op)
        {
            IWebElement operatorSelect = _ngDriver.FindElement(Operators);
            SelectElement selectList = new SelectElement(operatorSelect);
            selectList.SelectByText(op);
        }

        public int HistoryCount()
        {
            return _ngDriver.FindElements(History).Count;
        }

        public string HistoryFirst()
        {
            return _ngDriver.FindElements(History).Last<NgWebElement>().Text;
        }


        private void ClickGo()
        {
            _ngDriver.FindElement(GoButton).Click();
        }
    }
}
