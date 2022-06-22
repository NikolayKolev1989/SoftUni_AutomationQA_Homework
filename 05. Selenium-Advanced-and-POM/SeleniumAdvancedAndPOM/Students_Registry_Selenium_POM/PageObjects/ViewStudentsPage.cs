using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM.PageObjects
{
    internal class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
           "https://mvc-app-node-express.nakov.repl.co/students";

        public IReadOnlyCollection<IWebElement> ListStudents =>
            driver.FindElements(By.CssSelector("body > ul:nth-child(7)"));

        public string[] GetRegisteredStudents()
        {
            var elementsStudents = this.ListStudents
                .Select(s => s.Text)
                .ToArray();
            return elementsStudents;
        }

    }
}
