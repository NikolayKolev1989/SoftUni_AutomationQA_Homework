using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Registry_Selenium_POM.PageObjects
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl =>
            "https://mvc-app-node-express.nakov.repl.co/";

        public IWebElement ElementStudentsCount =>
            driver.FindElement(By.CssSelector("body > p:nth-child(7) > b:nth-child(1)"));

        public int GetStudentCount()
        {
            int count = int.Parse(ElementStudentsCount.Text);
            return count;
        }
    }
}
