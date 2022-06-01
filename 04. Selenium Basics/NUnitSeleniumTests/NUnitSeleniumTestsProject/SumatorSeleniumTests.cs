using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NUnitSeleniumTestsProject
{
    public class SumatorSeleniumTests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://sum-numbers.nakov.repl.co/";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        [TestCase ("2", "3", "Sum: 5")]
        [TestCase("12", "8", "Sum: 20")]
        [TestCase("-53", "28", "Sum: -25")]
        [TestCase("17", "-45", "Sum: -28")]
        [TestCase("15789", "548723", "Sum: 564512")]
        public void Test_Calculator(string num1, string num2, string expectedResult)
        {
            driver.FindElement(By.Id("number1")).SendKeys(num1);
            driver.FindElement(By.Id("number2")).SendKeys(num2);
            driver.FindElement(By.Id("calcButton")).Click();
            var result = driver.FindElement(By.Id("result")).Text;

            Assert.That(result, Is.EqualTo(expectedResult));
            driver.FindElement(By.Id("resetButton")).Click();
        }
    }
}