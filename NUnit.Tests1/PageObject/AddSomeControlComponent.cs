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

        public By InputToDo { get; set; } = NgBy.Model("todoList.todoText");
        public By AllItemTodo { get; set; } = NgBy.Repeater("todo in todoList.todos");
        public By ButtonAddTask { get; set; } = By.CssSelector("input[value=add]");

        public void InputNewTask(string text)
        {
            _driver.SendKeys(InputToDo, text);
            _driver.Click(ButtonAddTask);
        }

        public int GetCountTask()
        {
            return _driver.FindAllElements(AllItemTodo).Count;
        }

        public string GetLastTask()
        {
            IWebElement lastTaskElement = _driver.FindAllElements(AllItemTodo).Last<NgWebElement>();
            string taskText = _driver.GetText(lastTaskElement);
            return taskText;
        }


    }
}
