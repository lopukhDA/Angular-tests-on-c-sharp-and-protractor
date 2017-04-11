using NUnit.Framework;
using System.Configuration;

namespace AngularJS_site_test.Tests
{
    public abstract class BaseTastClass
    {
        protected WebDriver webDriver;
        protected LoggerClass log;

        [OneTimeSetUp]
        public void StartReport()
        {
            log = new LoggerClass();
        }


        [OneTimeTearDown]
        public void EndReport()
        {
            log.OneTearDown();
        }

        [SetUp]
        public void Setup()
        {
            log.StartTest(TestContext.CurrentContext.Test.Name);
            webDriver = new WebDriver(log);
        }

        [TearDown]
        public void TearDown()
        {
            log.TearDown(webDriver.Driver);
            webDriver.Quit();
        }

    }
}
