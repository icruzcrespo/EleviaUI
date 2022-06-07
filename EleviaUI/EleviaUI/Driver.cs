using Microsoft.CodeAnalysis;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Configuration;
static class Driver
{
    public static IWebDriver Instance { get; set; }
    public static DefaultWait<IWebDriver> fluentWait { get; set; }
    public static IWebDriver CreateWebDriver()
    {
        Instance = CreateChromeDriver();
        fluentWait = new DefaultWait<IWebDriver>(Instance);
        return Instance;

    }

    private static IWebDriver CreateChromeDriver()
    {
        
        return new ChromeDriver(Environment.CurrentDirectory);
    }
    public static IWebElement FindMyElement(By by)
    {
        fluentWait.Timeout = TimeSpan.FromSeconds(60);
        fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
        /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //fluentWait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
        fluentWait.Message = "Element to be searched not found";
        fluentWait.Until(x => x.FindElement(by));
        fluentWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        return fluentWait.Until(ExpectedConditions.ElementToBeClickable(by));
    }
    public static IWebElement FindMyElementWithTimeout(By by, int seconds)
    {
        fluentWait.Timeout = TimeSpan.FromSeconds(seconds);
        fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        fluentWait.Message = "Element to be searched not found";
        fluentWait.Until(x => x.FindElement(by));
        fluentWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        return fluentWait.Until(ExpectedConditions.ElementToBeClickable(by));
    }
}