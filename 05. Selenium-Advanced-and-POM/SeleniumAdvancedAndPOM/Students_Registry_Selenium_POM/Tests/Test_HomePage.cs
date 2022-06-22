using NUnit.Framework;
using Students_Registry_Selenium_POM.PageObjects;
using System;

namespace Students_Registry_Selenium_POM.Tests
{
    public class Test_HomePage:BaseTest
    {
        [Test]
        public void Test_HomePage_Link()
        {
            var page = new HomePage(driver);
            page.Open();
            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
            page.Open();
            page.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
            page.Open();
            page.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();
            Assert.That(page.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(page.GetPageHeadingText(), Is.EqualTo("Students Registry"));

        }

        
    }
}