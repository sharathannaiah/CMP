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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Inventory
{
    class AccessRings : BaseActions
    {
        public void AccessRingsFunctionality()
        {
            GoToMain("Inventory");
            retryingFindClickk(".//*[@id='mnuInventory_accessRing']");
            retryingFindClickk(".//*[@id='mnuAllocationBuckets']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Access Rings']"));
                Console.WriteLine("Navigation Successful");
            }

            if (CreateAccessRing() == true)
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Automation Access Ring']")), "Access Ring Creation failed");
                Console.WriteLine("Access Ring Created Successfully");
            }
            if (EditAccessRing() == true)
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Edited Automation Access Ring']")), "Access Ring Edition failed");
                Console.WriteLine("Access Ring Edited Successfully");
            }
           
            if (DeleteAccessRing() == true)
            {
                Thread.Sleep(2000);
                SwitchToContent();
                Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='Edited Automation Access Ring']")), "Access Ring Deletion failed");
                Console.WriteLine("Access Ring Deletion Successfully");
            }

        }

        public Boolean CreateAccessRing()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            FillGeneralDetails("Automation Access Ring");
            SwitchToContent();
            return true;
        }

        public void FillGeneralDetails(String Ringname)
        {
            BrowserDriver.Instance.Driver.FindElement(By.Name("ringId")).SendKeys("AB" + RandomNumbergeneratorL());
            typeDataName("ringId", "AB" + RandomNumbergeneratorL());
            BrowserDriver.Instance.Driver.FindElement(By.Name("itemName")).SendKeys(Ringname);
                typeDataName("itemName", Ringname);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByText("Allstream");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("ringDirection"))).SelectByText("East");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("accessProductId"))).SelectByIndex(1);
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(5000);
        }

        public Boolean EditAccessRing()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//span[text()='Automation Access Ring']")).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            FillGeneralDetails("Edited Automation Access Ring");
            SwitchToContent();
            return true;
        }

        public Boolean DeleteAccessRing()
        {
            SwitchToContent();
           // ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            return true;
        }
    }
}
