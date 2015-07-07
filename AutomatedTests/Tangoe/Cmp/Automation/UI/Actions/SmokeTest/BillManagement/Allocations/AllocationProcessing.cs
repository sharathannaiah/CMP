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
    class AllocationProcessing :BaseActions
    {
        public void AllocationProccessing()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationMenu']");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationProcessing']");
            WaitForElement(By.Id("pageTitle"));
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("New")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            BrowserDriver.Instance.Driver.FindElement(By.Name("allocationRunName")).SendKeys("Allocation Batch");
            BrowserDriver.Instance.Driver.FindElement(By.Name("saveAllocation")).Click();
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabInvoices")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVOICES");
            BrowserDriver.Instance.Driver.FindElement(By.Id("addInvoice")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryInvoicesButton")).Click();
            Thread.Sleep(5000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Console.WriteLine("Source document or inventory added successfully");

            //Remove the inventory source
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVOICES");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("removeInvoiceButton")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Inventory removed successfully");


            //CostCenter Tab 
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabCostCenters")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COSTCENTERS");

            //Adjustment Tab

            //Errors in Adjustment Tab

            //GL Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabGL")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GL");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("GLEntries")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("buttonCreateGLEntries")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("buttonClose")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Console.WriteLine("GL Code created Successfully");
            Console.WriteLine("Allocation Processing Passed successfully");
        }

    }
}
