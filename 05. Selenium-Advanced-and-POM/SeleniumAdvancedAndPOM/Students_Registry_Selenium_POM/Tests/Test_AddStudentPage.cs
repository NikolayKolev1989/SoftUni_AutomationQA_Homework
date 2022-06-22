using NUnit.Framework;
using Students_Registry_Selenium_POM.PageObjects;
using System;

namespace Students_Registry_Selenium_POM.Tests
{
    public class Test_AddStudentPage:BaseTest
    {
        [Test]
        public void Test_AddStudentPage_Links()
        {
            var page = new AddStudentPage(driver);
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
        public void Test_AddStudentPage_Content()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            Assert.That(page.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(page.GetPageHeadingText(), Is.EqualTo("Register New Student"));
            Assert.That(page.FieldStudentName.Text, Is.EqualTo(""));
            Assert.That(page.FieldStudentEmail.Text, Is.EqualTo(""));
            Assert.That(page.AddStudentButton.Text, Is.EqualTo("Add"));
        }

        [Test]
        public void Test_AddStudentPage_AddValidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            string name = "New Test Student" + DateTime.Now.Ticks;
            string email = name + "@email.com";
            page.AddStudent(name, email);

            var viewPage = new ViewStudentsPage(driver);
            viewPage.Open();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
            var students = viewPage.GetRegisteredStudents();

            Assert.That(students, Contains.Item(name + " " + email));
           
        }

    }
}