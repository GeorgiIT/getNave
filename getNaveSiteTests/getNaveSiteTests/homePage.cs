namespace getNaveSiteTests;


using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


public class Tests
{
    IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.BinaryLocation = "/Users/georgi/Desktop/Google Chrome.app/Contents/MacOS/Google Chrome";
        driver = new ChromeDriver(options);
    }

    [Test]
    public void TestHomePageLoading()
    {
        driver.Url = "https://getnave.com/";

        Assert.AreEqual(driver.Url, "https://getnave.com/");

        string headingText = driver.FindElement(By.CssSelector("body > section.section-first.section-first-home > div > h1")).Text;

        Assert.AreEqual(headingText, "Kanban Dashboards");
    }

    [Test]
    public void TestingNavBarLinks()
    {
        driver.Url = "https://getnave.com/";

        //Pricing navigation bar button
        driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(4) > a")).Click();

        string actualUrl = driver.Url;
        string expectedUrl = "https://getnave.com/pricing";

        Assert.AreEqual(expectedUrl, actualUrl, $"Expected URL: {expectedUrl}\nActual URL: {actualUrl}");

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(2));

        //Digital Course navigation bar button
        driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(5) > a")).Click();

        actualUrl = driver.Url;
        expectedUrl = "https://getnave.com/enroll";

        Assert.AreEqual(expectedUrl, actualUrl, $"Expected URL: {expectedUrl}\nActual URL: {actualUrl}");

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(2));

        //"Explore your dashboard" navigation bar button
        driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > div > a")).Click();

        actualUrl = driver.Url;
        expectedUrl = "https://getnave.com/select-platform";

        Assert.AreEqual(expectedUrl, actualUrl, $"Expected URL: {expectedUrl}\nActual URL: {actualUrl}");

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(2));


        //"See a dashboard with your data" button
        driver.FindElement(By.CssSelector("body > section.section-first.section-first-home > div > a")).Click();

        actualUrl = driver.Url;
        expectedUrl = "https://getnave.com/select-platform";

        Assert.AreEqual(expectedUrl, actualUrl, $"Expected URL: {expectedUrl}\nActual URL: {actualUrl}");

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(2));

        //Home buton "Nave logo" 
        driver.FindElement(By.CssSelector("#nav_bar > nav > div > div.logo > a")).Click();

        actualUrl = driver.Url;
        expectedUrl = "https://getnave.com/";

        Assert.AreEqual(expectedUrl, actualUrl, $"Expected URL: {expectedUrl}\nActual URL: {actualUrl}");

        Thread.Sleep(TimeSpan.FromSeconds(2));

        //Blog navigation bar button
        IWebElement blogButton = driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(6) > a"));
        string blogButtonUrl = blogButton.GetAttribute("href");
        ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");  // Open a new tab
        driver.SwitchTo().Window(driver.WindowHandles.Last());  // Switch to the new tab
        driver.Navigate().GoToUrl(blogButtonUrl);

        Assert.AreEqual("https://getnave.com/blog/", driver.Url);
        
    }



    [Test]
    public void CheckingDashboardsHyperLinks()
    {
        // Home page
        driver.Url = "https://getnave.com/";

        // Test for Jira hyperLink

        driver.FindElement(By.CssSelector("body > section.section-list-kanban-progress.section-platforms.section-gray-bg > div > div > " +
            "div.col-12.col-sm-6.col-md-3.col-md-offset-1 > div > div > a")).Click();

        string actiualTitle = driver.FindElement(By.CssSelector("body > section.section-first.section-dashboard-bg > div > h1")).Text;

        string expectedTitle = "Dashboard for Jira";

        Assert.AreEqual(actiualTitle, expectedTitle);

        driver.Navigate().Back();

        Thread.Sleep(TimeSpan.FromSeconds(3));


        // Test for Trello hyperLink
        driver.FindElement(By.CssSelector("body > section.section-list-kanban-progress.section-platforms.section-gray-bg > " +
            "div > div > div:nth-child(2) > div > div > a")).Click();

        actiualTitle = driver.FindElement(By.CssSelector("body > section.section-first.section-dashboard-bg > div > h1")).Text;

        expectedTitle = "Dashboard for Trello";

        Assert.AreEqual(actiualTitle, expectedTitle);

        driver.Navigate().Back();

        Thread.Sleep(TimeSpan.FromSeconds(3));

        // Test for Azure DevOps hyperLink

        driver.FindElement(By.CssSelector("body > section.section-list-kanban-progress.section-platforms.section-gray-bg > div > div > div:nth-child(3) > div > div > a")).Click();

        actiualTitle = driver.FindElement(By.CssSelector("body > section.section-first.section-dashboard-bg > div > h1")).Text;

        expectedTitle = "Dashboard for Azure DevOps";

        Assert.AreEqual(actiualTitle, expectedTitle);

        driver.Navigate().Back();

        Thread.Sleep(TimeSpan.FromSeconds(3));


        // Test for Asana hyperLink

        driver.FindElement(By.CssSelector("body > section.section-list-kanban-progress.section-platforms.section-gray-bg > div > div > div.col-12.col-sm-6.col-md-3.col-md-offset-3 > div > div > a")).Click();

        actiualTitle = driver.FindElement(By.CssSelector("body > section.section-first.section-dashboard-bg > div > h1")).Text;

        expectedTitle = "Dashboard for Asana";

        Assert.AreEqual(actiualTitle, expectedTitle);

        driver.Navigate().Back();

        Thread.Sleep(TimeSpan.FromSeconds(3));

        // Test for ZenHub hyperLink

        driver.FindElement(By.CssSelector("body > section.section-list-kanban-progress.section-platforms.section-gray-bg > div > div > div:nth-child(5) > div > div > a")).Click();

        actiualTitle = driver.FindElement(By.CssSelector("body > section.section-first.section-dashboard-bg > div > h1")).Text;

        expectedTitle = "Dashboard for ZenHub";

        Assert.AreEqual(actiualTitle, expectedTitle);

    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
