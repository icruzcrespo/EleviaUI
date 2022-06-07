using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace EleviaAutomation
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Driver.CreateWebDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Driver.Instance.Dispose();
        }

    }
}
