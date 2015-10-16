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
    class USOCMaintainancee : BaseActions
    {
         public void USOCMaintainanceFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuUsoc']");

             if (true)
            {
                    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                    WaitForElementToVisible(By.XPath("//div[text()='USOC Maintenance']"));
                    Console.WriteLine("Navigation successful");
            }

            if (CreateUSOC() == true)
            {
                SearchUSOCMaintainance("AutomationUSOC");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AutomationUSOC']")), "USOC creation failed");
                Console.WriteLine("USOC created successfully");
            }
           
            if (EditUSOC() == true)
            {
                SearchUSOCMaintainance("AutomationUSOCEdited");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AutomationUSOCEdited']")), " USOC Edition failed");
                Console.WriteLine("USOC edited successfully");
            }
            if (DeleteUSOC() == true)
            {
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AutomationUSOCEdited']")), " USOC Deletion failed");
                Console.WriteLine("USOC deleted successfully");
                Console.WriteLine("Admin --> Bill Management --> USOC Maintainance passed smoke test successfully"); 
            }
        }

        public Boolean CreateUSOC()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("General");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('usoc')[0].value='AutomationUSOC'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('description')[0].value='New USOC'");
            Thread.Sleep(2000);
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }

        public void SearchUSOCMaintainance(String Search)
        {
            Thread.Sleep(2000);
            SwitchToContent();
            typeDataName("usoc", Search);
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.ResetB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='" + Search + "']")), "USOC Maintainance Search successful");
            Console.WriteLine("USOC Maintainance search successful");

        }

        public Boolean EditUSOC()
        {
            SwitchToContent();
            javascriptClick(By.XPath("//div[text()='AutomationUSOC']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("General");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('usoc')[0].value='AutomationUSOCEdited'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('description')[0].value='Edited USOC'");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }

        public Boolean DeleteUSOC()
        {
            javascriptClick(By.XPath("//div[text()='AutomationUSOCEdited']"));
            Thread.Sleep(2000);
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }
    }
}

