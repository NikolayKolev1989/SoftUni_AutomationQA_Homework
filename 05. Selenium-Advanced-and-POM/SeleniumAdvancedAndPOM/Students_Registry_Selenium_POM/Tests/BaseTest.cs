using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Students_Registry_Selenium_POM.Tests
{
    public class BaseTest
    {

        protected IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}