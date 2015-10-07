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

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Tools
{
    class DataLoad : BaseActions
    {
        public void DataLoadFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_Tools']");
            retryingFindClickk(".//*[@id='mnuAdmin_DataLoad']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Data Load']"));
                Console.WriteLine("Navigation Successful");
                SearchDataLoad();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='CC Template']")), "Search failed");
                Console.WriteLine("Search Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            if (CreateDataLoad())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB Load']")), "Data Load creation failed");
                Console.WriteLine("Data Load created Successful");
            }
            if (EditDataLoad())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB Load Edited']")), "Data Load Edition failed");
                Console.WriteLine("Data Load edition Successful");
            }
            if (DeleteDataLoad())
            {
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AB Load Edited ']")), "Data Load Deletion failed");
                Console.WriteLine("Data Load deletion Successful");
                BrowserDriver.Instance.Driver.Navigate().Refresh();
            //    javascriptClick(By.XPath("//img[contains(@src,'https://dc2cmpqa.tangoe.com/cmp151/common/themes/default/buttons/xdlg.png')]"));
                Console.WriteLine("Admin --> Tools --> Data Load Passed smoke test successfully");
            }

        }

        public Boolean CreateDataLoad()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("UPLOAD_SUMMARY");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Configure']")).Click();
            SwitchFrames();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            SwitchFrames();
            typeDataID("loadName", "AB Load");
            SelectfromDropdown("spName", "1");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchFrames();
            return true;
        }
         public void SwitchFrames()
        {
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("loads");
        }

         public Boolean EditDataLoad()
         {
             SwitchFrames();
             typeDataID("loadName", "AB Load Edited");
             javascriptClick(By.XPath(General.Default.SaveB));
             SwitchFrames();
             return true;
         }

         public Boolean DeleteDataLoad() 
         {
             SwitchFrames();
             ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
             javascriptClick(By.XPath(General.Default.DeleteB));
             SwitchFrames();
             return true;
         }
         public void SearchDataLoad()
         {
             SwitchToContent();
             BrowserDriver.Instance.Driver.SwitchTo().Frame("UPLOAD_QUERY");
             typeDataName("userLoadNamePattern","CC Template");
             BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
             Thread.Sleep(2000);
             SwitchToContent();
             BrowserDriver.Instance.Driver.SwitchTo().Frame("UPLOAD_SUMMARY");
         }
    }
}