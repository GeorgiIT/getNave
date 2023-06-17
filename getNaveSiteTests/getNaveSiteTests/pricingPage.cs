namespace getNaveSiteTests;


using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;
using System.Net.Http;


public class PricingPageTests
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
    public void AnnualSubscriptionButtonsCheck()
    {
        driver.Url = "https://getnave.com/";

        driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(4) > a")).Click();

        //Testing "Jet Ski" button

        driver.FindElement(By.CssSelector("#annual-plan > div:nth-child(1) > a.btn.btn-lg.btn-border-orange")).Click();

        string currentUrl = driver.Url;

        Assert.AreEqual("https://getnave.com/select-platform", currentUrl);

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(2));

        //Testing "Speedboat" button

        driver.FindElement(By.CssSelector("#annual-plan > div:nth-child(2) > a.btn.btn-lg.btn-border-orange")).Click();

        currentUrl = driver.Url;

        Assert.AreEqual("https://getnave.com/select-platform", currentUrl);

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(2));

        //Testing "Yacht" button

        driver.FindElement(By.CssSelector("#annual-plan > div.active > a.btn.btn-lg.btn-orange")).Click();

        currentUrl = driver.Url;

        Assert.AreEqual("https://getnave.com/select-platform", currentUrl);

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(2));

        //Testing "Cruise Ship" button

        driver.FindElement(By.CssSelector("#annual-plan > div:nth-child(4) > a.btn.btn-lg.btn-border-orange")).Click();

        currentUrl = driver.Url;

        Assert.AreEqual("https://getnave.com/select-platform", currentUrl);

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(2));

    }

    [Test]
    public void mountlySubscriptionButtonsCheck()
    {
        driver.Url = "https://getnave.com/";

        driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(4) > a")).Click();


        //Clicking on the slider round button, to switch form annual to monthly

        driver.FindElement(By.CssSelector("body > section.section-first.section-head-pricing > div > div > div.switch_box > label > span")).Click();
        string jetSkiPrice = driver.FindElement(By.CssSelector("#monthly-plan > div:nth-child(1) > p.price")).Text;
        string speedboatPrice = driver.FindElement(By.CssSelector("#monthly-plan > div:nth-child(2) > p.price")).Text;
        string yachtPrice = driver.FindElement(By.CssSelector("#monthly-plan > div.active > p.price")).Text;
        string cruiseShipPrice = driver.FindElement(By.CssSelector("#monthly-plan > div:nth-child(4) > p.price")).Text;

        Assert.AreEqual(jetSkiPrice, "$54 / month");

        Assert.AreEqual(speedboatPrice, "$86 / month");

        Assert.AreEqual(yachtPrice, "$141 / month");

        Assert.AreEqual(cruiseShipPrice, "$272 / month");


        //Jet ski button check

        driver.FindElement(By.CssSelector("#monthly-plan > div:nth-child(1) > a.btn.btn-lg.btn-border-orange")).Click();
        Thread.Sleep(TimeSpan.FromSeconds(3));

        string currentUrl = driver.Url;

        Assert.AreEqual("https://getnave.com/select-platform", currentUrl);

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(3));

        //Speedboat button check

        
        driver.FindElement(By.CssSelector("#monthly-plan > div:nth-child(2) > a.btn.btn-lg.btn-border-orange")).Click();
        Thread.Sleep(TimeSpan.FromSeconds(3));

        currentUrl = driver.Url;

        Assert.AreEqual("https://getnave.com/select-platform", currentUrl);

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(3));

        //Yacht button check

        
        driver.FindElement(By.CssSelector("#monthly-plan > div.active > a.btn.btn-lg.btn-orange")).Click();
        Thread.Sleep(TimeSpan.FromSeconds(3));

        currentUrl = driver.Url;

        Assert.AreEqual("https://getnave.com/select-platform", currentUrl);

        driver.Navigate().Back();
        Thread.Sleep(TimeSpan.FromSeconds(3));

        // Cruise Ship button check

        
        driver.FindElement(By.CssSelector("#monthly-plan > div:nth-child(4) > a.btn.btn-lg.btn-border-orange")).Click();

        currentUrl = driver.Url;

        Assert.AreEqual("https://getnave.com/select-platform", currentUrl);
       





    }


    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

}

