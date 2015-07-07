using AutomatedTests.Tangoe.Cmp.Automation.Common;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement.Allocations
{
    class AllocationQuery : BaseActions
    {
        public void AllocationQueryy()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationMenu']");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationQuery']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCATION_QUERY");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupcostCenterId")).Click();
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryCostCentersButton")).Click();
            Thread.Sleep(5000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='returnButtonIds']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCATION_QUERY");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryAllocationsButton")).Click();
            Thread.Sleep(3000);
            Console.WriteLine("Allocation Query Passed Successfully");


        }
    }

}
