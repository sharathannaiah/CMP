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
    class AllocationBucket : BaseActions
    {
        public void AllocationBucketFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuAllocationBuckets']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Allocation Bucket']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            if (CreateAllocationBucket())
            {
                SearchAllocation();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB Bucket']")), "Allocation Bucket Creation failed");
                Console.WriteLine("Allocation Bucket Creation Successful");
            }

            if (EditAllocation())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB Bucket1']")), "Allocation Bucket Edition failed");
                Console.WriteLine("Allocation Bucket Edition Successful");
            }

            if (DeleteAllocation())
            {
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AB Bucket1']")), "Allocation Bucket Deletion failed");
                Console.WriteLine("Allocation Bucket Deletion Successful");
              
            }

            if (CreateAllocationAttribute())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='1']")), "Allocation Bucket Attribute Creation failed");
                Console.WriteLine("Allocation Bucket Attribute Creation Successful");
            }
            if (DeleteAllocationBucketAttribute())
            {
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='1']")), "Allocation attribute Deletion failed");
                Console.WriteLine("Allocation Bucket Attribute Deletion Successful");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
                Console.WriteLine("Admin --> Bill Management --> allocation Bucket passed smoke test successfully");

            }
        }
            public Boolean CreateAllocationBucket()
            {
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('allocationBucketName')[2].value='AB Bucket'");
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('invoiceCountryCd')[2].selectedIndex='1'");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
                return true;
            }

            public void SearchAllocation()
            {
                SwitchToPopUps();
                typeDataID("allocationBucketName", "AB Bucket");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
            }

            public Boolean EditAllocation()
            {
                SwitchToPopUps();
                javascriptClick(By.XPath("//div[text()='AB Bucket']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('allocationBucketName')[2].value='AB Bucket1'");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
                return true;
            }

            public Boolean DeleteAllocation()
            {
                SwitchToPopUps();
                javascriptClick(By.XPath("//div[text()='AB Bucket1']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
                javascriptClick(By.XPath(General.Default.DeleteB));
                return true;
            }


            public Boolean CreateAllocationAttribute()
            {
                SwitchToPopUps();
                javascriptClick(By.Id("AllocDicMaintenanceTab"));
                BrowserDriver.Instance.Driver.FindElement(By.Id("addDictionaryButton")).Click();
                SelectfromDropdown("selectBoxallocationBucketAttribute", "1");
                BrowserDriver.Instance.Driver.FindElement(By.Id("addValueButton")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
                typeDataID("newVal", "1");
                javascriptClick(By.XPath(General.Default.OKB));
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.Id("addNormValueButton")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
                typeDataID("newVal", "1");
                javascriptClick(By.XPath(General.Default.OKB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
                return true;
            }

       public void SearchAllocationBucketAttribute()
        {
            SwitchToPopUps();
            SelectfromDropdown("allocationBucketAttribute", "1");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='1']")), "Search failed");
            Console.WriteLine("Search Successful");
        }

       public Boolean DeleteAllocationBucketAttribute()
       {
           SearchAllocationBucketAttribute();
           BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.DeleteB)).Click();
           Thread.Sleep(2000);
           SwitchToPopUps();
           return true;
       }
        }
    }

