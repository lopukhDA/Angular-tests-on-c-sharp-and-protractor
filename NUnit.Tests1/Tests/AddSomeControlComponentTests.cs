using AngularJS_site_test.PageObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS_site_test.Tests
{
    [TestFixture]
    [Parallelizable]
    class AddSomeControlComponentTests : BaseTastClass
    {
        private string _url = "https://angularjs.org/";

        [Test]
        public void LastTaskTest()
        {
            AddSomeControlComponent addSomeControlComponent = new AddSomeControlComponent(webDriver);
            addSomeControlComponent.Open(_url);
            addSomeControlComponent.InputNewTask("New task");
            string lastTask = addSomeControlComponent.GetLastTask();
            Assert.AreEqual(lastTask, "New task", "Error! The entered task does not match the one received. ");
        }

        [Test]
        public void CountTaskTest()
        {
            AddSomeControlComponent addSomeControlComponent = new AddSomeControlComponent(webDriver);
            addSomeControlComponent.Open(_url);
            int countTaskBefore = addSomeControlComponent.GetCountTask();
            addSomeControlComponent.InputNewTask("New task");
            int countTaskAfter = addSomeControlComponent.GetCountTask();
            Assert.AreEqual(countTaskBefore + 1, countTaskAfter, "Error! The number of tasks does not match. ");
        }

        [Test]
        public void AddedTaskNotExecutedTest()
        {
            AddSomeControlComponent addSomeControlComponent = new AddSomeControlComponent(webDriver);
            addSomeControlComponent.Open(_url);
            addSomeControlComponent.InputNewTask("New task");
            int countTask = addSomeControlComponent.GetCountTask();
            bool execution = addSomeControlComponent.CheckForExecution(countTask - 1);
            Assert.IsFalse(execution, "Error! The number of tasks does not match. ");
        }

        [Test]
        public void CompletedTaskCrossedOutTest()
        {
            AddSomeControlComponent addSomeControlComponent = new AddSomeControlComponent(webDriver);
            addSomeControlComponent.Open(_url);
            addSomeControlComponent.InputNewTask("New task");
            int countTask = addSomeControlComponent.GetCountTask();
            addSomeControlComponent.CompletedTask(countTask - 1);
            bool execution = addSomeControlComponent.CheckForExecution(countTask - 1);
            Assert.IsTrue(execution, "Error! The number of tasks does not match. ");
        }
    }
}
