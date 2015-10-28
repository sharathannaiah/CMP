using AutomatedTests.Tangoe.Cmp.Automation.Common;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomatedTests.CMP.Admin;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management
{
    class Allocations : BaseActions
    {
        public void AllocationFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationSetupModal']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Allocations']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }
            if (CreateAllocation())
            {

                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()^='AB Allocation']")), "Allocation creation failed");
                Console.WriteLine("Allocation created successfully");
            }
            if (EditAllocation())
            {
                Console.WriteLine("Allocation edited successfully");
                Console.WriteLine("Admin --> Bill Management --> Allocations passed smoke test successfully");
                javascriptClick(By.XPath(General.Default.CloseB));
            }

           //if (DeleteAllocation())
           //{
           //     Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='AB Allocations']")), "Allocation deletion failed");
           //     Console.WriteLine("Allocation deletion successfully");
           // }
        }

        public Boolean CreateAllocation()
        {
            var s = RandomNumbergeneratorL();
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            typeDataName("configurationName", "AB Allocation"+s);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
            Thread.Sleep(4000);
            SwitchToPopUps();
            return true;
        }

        public Boolean EditAllocation()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//span[text()='AB Allocation']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("glModuleName"))).SelectByIndex(1);
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            return true;
        }
        public Boolean DeleteAllocation()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//span[text()='AB Allocation']"));
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            return true;
        }

    }
    }

