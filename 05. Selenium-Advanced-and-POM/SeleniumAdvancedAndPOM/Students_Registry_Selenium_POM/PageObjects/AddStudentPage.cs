using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM.PageObjects
{
    internal class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement FieldStudentName =>
            driver.FindElement(By.CssSelector("#name"));

        public IWebElement FieldStudentEmail =>
            driver.FindElement(By.CssSelector("#email"));
        public IWebElement AddStudentButton =>
            driver.FindElement(By.XPath("/html/body/form/button"));

        public string ElementErrorMessage =>
            driver.FindElement(By.CssSelector("body > div:nth-child(6)")).Text;

        public void AddStudent(string name, string email)
        {
            this.FieldStudentName.SendKeys(name);
            this.FieldStudentEmail.SendKeys(email);
            Thread.Sleep(1000);
            this.AddStudentButton.Click();
        }

        public string GetErrorMessage()
        {
            return ElementErrorMessage;
        }

    }
}
