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
    class TheBasicComponentTests : BaseTastClass
    {
        private string _url = "https://angularjs.org/";

        [Test]
        public void InputYourNameTest()
        {
            TheBasicComponent basicComponent = new TheBasicComponent(webDriver);
            basicComponent.Open(_url);
            string result = basicComponent.SendYourNameAndReturnResult("Dima");
            Assert.AreEqual(result, "Hello Dima!", "Error! The entered name does not match the one received. ");
        }

    }
}
