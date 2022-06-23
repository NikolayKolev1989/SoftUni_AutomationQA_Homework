using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace WebDriverTests
{
    public class TaskBoard_WebDriverTests
    {

        private const string url = "https://taskboard.nakov.repl.co";
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_GetAllTasks_CheckFirstTask()
        {
            driver.Navigate().GoToUrl(url);
            var taskBoardLink = driver.FindElement(By.LinkText("Task Board"));
            taskBoardLink.Click();

            var boardName = driver.FindElement(By.CssSelector("div.task:nth-child(3) > h1:nth-child(1)")).Text;
            var taskName = driver.FindElement(By.CssSelector("#task1 > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(2)")).Text;

            Assert.That(boardName, Is.EqualTo("Done"));
            Assert.That(taskName, Is.EqualTo("Project skeleton"));

        }

        [Test]
        public void Test_SearchTasks_CheckFirstTask()
        {
            driver.Navigate().GoToUrl(url);
            var searchLink = driver.FindElement(By.LinkText("Search"));
            searchLink.Click();
            var searchField = driver.FindElement(By.Id("keyword"));
            searchField.SendKeys("home");
            searchField.SendKeys(Keys.Enter);

            var title = driver.FindElement(By.CssSelector("#task2 > tbody > tr.title > td")).Text;
            var description = driver.FindElement(By.CssSelector("div.description")).Text;

            Assert.That(title, Is.EqualTo("Home page"));
            Assert.That(description, Is.EqualTo("Create the [Home] page and list tasks count by board"));

        }

        [Test]
        public void Test_SearchTasks_EmptyResult()
        {
            driver.Navigate().GoToUrl(url);
            var searchLink = driver.FindElement(By.LinkText("Search"));
            searchLink.Click();

            var searchField = driver.FindElement(By.Id("keyword"));
            searchField.SendKeys("missing 123789456");
            searchField.SendKeys(Keys.Enter);

            var message = driver.FindElement(By.Id("searchResult")).Text;

            Assert.That(message, Is.EqualTo("No tasks found."));

        }

        [Test]
        public void Test_CreateTask_InvalidData()
        {
            driver.Navigate().GoToUrl(url);
            var createLink = driver.FindElement(By.LinkText("Create"));
            createLink.Click();

            var createButton = driver.FindElement(By.Id("create"));
            createButton.Click();

            var errorMessage = driver.FindElement(By.CssSelector("body > main > div")).Text;
            Assert.That(errorMessage, Is.EqualTo("Error: Title cannot be empty!"));

        }

        [Test]
        public void Test_CreateTask_validData()
        {
            driver.Navigate().GoToUrl(url);
            string title = "Shano Title";
            string description = "Shano Description";

            var createLink = driver.FindElement(By.LinkText("Create"));
            createLink.Click();

            var titleTextField = driver.FindElement(By.Id("title"));
            titleTextField.Click();
            titleTextField.SendKeys(title);

            var descriptionTextField = driver.FindElement(By.Id("description"));
            descriptionTextField.Click();
            descriptionTextField.SendKeys(description);

            var boardName = driver.FindElement(By.Id("boardName"));
            boardName.Click();
            var boardNameSelector = driver.FindElement(By.CssSelector("#boardName > option:nth-child(3)"));
            boardNameSelector.Click();

            var createButton = driver.FindElement(By.Id("create"));
            createButton.Click();

            var allTasks = driver.FindElements(By.CssSelector("table.task-entry"));
            var task = allTasks.Last();

            var titleLabel = task.FindElement(By.CssSelector("tr.title > td")).Text;
            var DescriptionLabel = task.FindElement(By.CssSelector("tr.description > td")).Text;

            Assert.That(titleLabel, Is.EqualTo(title));
            Assert.That(DescriptionLabel, Is.EqualTo(description));

        }
    }
}