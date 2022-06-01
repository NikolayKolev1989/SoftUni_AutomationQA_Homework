using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace NUnitSeleniumTestsProject
{
    public class WikipediaSeleniumTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new FirefoxDriver();
            this.driver.Url = "https://www.wikipedia.org/";
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_QAPage_Wikipedia()
        {
            var expextedTitle = "QA - Wikipedia";
            var expecetedUrl = "https://en.wikipedia.org/wiki/QA";

            driver.FindElement(By.CssSelector("#searchInput")).SendKeys("QA");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#searchInput")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            Assert.That(driver.Url, Is.EqualTo(expecetedUrl));
            Assert.That(driver.Title, Is.EqualTo(expextedTitle));
        }
    }
}