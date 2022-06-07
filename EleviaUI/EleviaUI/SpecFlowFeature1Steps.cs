using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace AutomationElevia
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            Driver.Instance.Navigate().GoToUrl("https://www.amazon.es/");
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            Driver.FindMyElement(By.Id("twotabsearchtextbox")).SendKeys(p0.ToString());
            Thread.Sleep(3000);
            Assert.AreEqual(p0, 120);

        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
