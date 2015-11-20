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
    class FiscalCalendar : BaseActions
    {
        public void FiscalCalendarFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuBilling_FiscalCalendar']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Fiscal Calendar Configuration']"));
                Console.WriteLine("Navigation Successful");
            }


            if (AddNewYear())
            {
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
                //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("fiscalYearSelect"))).SelectByIndex(4);
                //      ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('fiscalYearSelect')[0].selectedIndex='4'");
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Jan 2000']")), "Adding new year failed");
                Console.WriteLine("New Year Added Successfully");
            }

            if (AddPeriod())
            {
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='January 2051']")), "Adding period failed");
                Console.WriteLine("Period Added Successfully");
            }
            if (EditPeriod())
            {
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Edited January 2051']")), "Editing period failed");
                Console.WriteLine("Period Edited Successfully");
            }

            if (DeletePeriod())
            {
                SwitchToPopUps();
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Edited January 2051']")), "Deleting period failed");
                Console.WriteLine("Period Deletion Successfully");
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Admin --> Bill Management --> Fiscal Calendar passed smoke test successfully");
            }
        }

        public Boolean AddNewYear()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("addYear")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlstartDate")).SendKeys("");
            typeDataID("dtControlstartDate", "01/01/2000");
            BrowserDriver.Instance.Driver.FindElement(By.Id("fiscalYear")).SendKeys("2000");
            typeDataID("fiscalYear", "2000");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("fiscalYear")).Click();
            Thread.Sleep(2000);
            retryingFindClick(By.XPath(General.Default.OKB));
            Thread.Sleep(2000);
            return true;
        }

        public Boolean AddPeriod()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlstartDate")).SendKeys("");
            typeDataID("dtControlstartDate", "01/01/2051");
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlendDate")).SendKeys("");
            typeDataID("dtControlendDate", "01/03/2051");
            BrowserDriver.Instance.Driver.FindElement(By.Id("nameField")).SendKeys("January 2051");
            typeDataID("nameField", "January 2051"); 
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("nameField")).Click();
            Thread.Sleep(2000);
            retryingFindClick(By.XPath(General.Default.OKB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            return true;
        }

        public Boolean EditPeriod()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='January 2051']"));
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.EditB)).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            typeDataID("nameField", "Edited January 2051");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            return true;
        }

        public Boolean DeletePeriod()
        {
            var count = 12;
            SwitchToPopUps();
            if (IsElementVisible(By.XPath("//div[text()='Dec 2000']")))
            {
                for (int i = 0; i <= count; i++)
                {
                    if (IsElementVisible(By.XPath("//div[text()='Dec 2000']")))
                    {
                        BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.RemoveB)).Click();
                        Thread.Sleep(2000);
                        count++;
                    }



                }

            }
            return true;
        }
    }
}
    
    

