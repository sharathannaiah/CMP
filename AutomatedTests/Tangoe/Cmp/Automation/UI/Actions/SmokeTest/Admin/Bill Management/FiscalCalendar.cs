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
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("fiscalYearSelect"))).SelectByText("Automate 2050");
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Jan 2015']")), "Adding new year failed");
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
            if(DeletePeriod())
            {
                SwitchToPopUps();
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Jan 2050']")), "Deleting period failed");
                Console.WriteLine("Period Deletion Successfully");
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
            typeDataID("dtControlstartDate", "01/01/2050");
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlstartDate")).Click();
            typeDataID("fiscalYear", "Automate 2050");
            BrowserDriver.Instance.Driver.FindElement(By.Id("fiscalYear")).Click();
            Thread.Sleep(2000);
            javascriptClick(By.XPath(General.Default.OKB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            return true;
        }

        public Boolean AddPeriod()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            typeDataID("nameField", "January 2051");
            typeDataID("dtControlstartDate", "01/01/2051");
            typeDataID("dtControlendDate", "31/05/2051");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
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
            for (int i = 0; i <= count; i++)
            {
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.RemoveB)).Click();
                Thread.Sleep(2000);
                count++;
            }
            return true;
        }
        }
    }

