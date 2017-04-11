using OpenQA.Selenium;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS_site_test.PageObject
{
    class AddSomeControlComponent
    {
        private WebDriver _driver;

        public AddSomeControlComponent(WebDriver driver)
        {
            _driver = driver;
        }

        public void Open(string url)
        {
            _driver.Navigate(url);
        }

        public By InputTask { get; set; } = NgBy.Model("todoList.todoText");
        public By AllItemTask { get; set; } = NgBy.Repeater("todo in todoList.todos");
        public By ButtonAddTask { get; set; } = By.CssSelector("input[value=add]");
        public By AllTextTask { get; set; } = By.CssSelector("ul.unstyled span");

        public void InputNewTask(string text)
        {
            _driver.SendKeys(InputTask, text);
            _driver.Click(ButtonAddTask);
        }

        public int GetCountTask()
        {
            return _driver.FindAllElements(AllItemTask).Count;
        }

        public string GetLastTask()
        {
            IWebElement lastTaskElement = _driver.FindAllElements(AllItemTask).Last<NgWebElement>();
            string taskText = _driver.GetText(lastTaskElement);
            return taskText;
        }

        public bool CheckForExecution(int number)
        {
            IList<NgWebElement> allElements = _driver.FindAllElements(AllTextTask);
            bool check = _driver.CheckClassForElement(allElements[number], "done-true");
            return check;
        }

        public void CompletedTask(int number)
        {
            IList<NgWebElement> allElements = _driver.FindAllElements(AllTextTask);
            _driver.Click(allElements[number]);
        }

    }
}
