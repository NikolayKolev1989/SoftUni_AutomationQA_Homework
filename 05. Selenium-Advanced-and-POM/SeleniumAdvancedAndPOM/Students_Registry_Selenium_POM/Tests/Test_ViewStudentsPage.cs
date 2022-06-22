using NUnit.Framework;
using Students_Registry_Selenium_POM.PageObjects;

namespace Students_Registry_Selenium_POM.Tests
{
    public class Test_ViewStudentsPage:BaseTest
    {
       
        [Test]
        public void Test_HomePage_Links()
        {
            var page = new ViewStudentsPage(driver);
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
        public void Test_ViewStudentsPageContent()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();
            Assert.That(page.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(page.GetPageHeadingText(), Is.EqualTo("Registered Students"));

            var students = page.GetRegisteredStudents();
            foreach (var student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.IndexOf(")") == students.Length-1);
            }
        }

        
    }
}