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
    }
}
