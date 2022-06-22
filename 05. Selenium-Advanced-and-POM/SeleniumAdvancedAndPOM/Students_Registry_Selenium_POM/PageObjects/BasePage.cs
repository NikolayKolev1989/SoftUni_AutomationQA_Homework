using OpenQA.Selenium;
using System;

namespace Students_Registry_Selenium_POM.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public virtual string PageUrl { get; }
        public IWebElement LinkHomePage => 
            driver.FindElement(By.CssSelector("body > a:nth-child(1)"));
        public IWebElement LinkViewStudentsPage =>
            driver.FindElement(By.CssSelector("body > a:nth-child(3)"));
        public IWebElement LinkAddStudentsPage => 
            driver.FindElement(By.CssSelector("body > a:nth-child(5)"));
        public IWebElement ElementPageHeading => 
            driver.FindElement(By.CssSelector("body > h1:nth-child(6)"));

        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingText()
        {
            return ElementPageHeading.Text;
        }
    }
}
