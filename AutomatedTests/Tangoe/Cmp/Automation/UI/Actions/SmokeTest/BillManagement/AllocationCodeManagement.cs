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


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement
{
    class AllocationCodeManagement :BaseActions
    {
        public void AllocationCodeManagementt()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationCodeManagement']");
            WaitForElement(By.Id("pageTitle"));
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            WaitForElement(By.Name("NewTableCC"));
            BrowserDriver.Instance.Driver.FindElement(By.Name("NewTableCC")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            BrowserDriver.Instance.Driver.FindElement(By.Name("allocationCode")).Clear();
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("allocationCode")).SendKeys("" + random);
            BrowserDriver.Instance.Driver.FindElement(By.Id("allocationCodeName")).SendKeys("New Allocation Name");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("allocationCodeTypeLUID"))).SelectByText("Purchase Order#");
            BrowserDriver.Instance.Driver.FindElement(By.Name("save")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Purchase Order#", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Purchase Order#']")).Text);
            Console.WriteLine("Allocation Code Created Successfully");

            //Allocation Definition Tab
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='allocDefTab']")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCDEF");
            BrowserDriver.Instance.Driver.FindElement(By.Id("addButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("nextButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("lookUpIFRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryCostCentersButton")).Click();
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Name("nextButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("Finish")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Allocation Definition Added Successfully");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCDEF");
            BrowserDriver.Instance.Driver.FindElement(By.Name("removeButton")).Click();
            Thread.Sleep(2000);
            Assert.AreNotEqual("Allocate", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Text);
            Console.WriteLine("Allocation Definition removed successfully");
            Console.WriteLine("Allocation Code Management Passed Successfully");
        }


    }
}
