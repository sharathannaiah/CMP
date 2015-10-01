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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous
{
    class DropdownList : BaseActions
    {
        public void DropdownListFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            retryingFindClickk(".//*[@id='mnuAdmin_LookupList']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Lookup List Maintenance']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }
            if (true)
            {
                AddNewDropdown();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABAutomation']")), "Adding dropdown failed");
                Console.WriteLine("Dropdown list added successfully");
            }
            else
            {
                Console.WriteLine("Dropdown list addition  failed");
            }
            if (true)
            {
                EditDropdown();
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABAutomationEdited']")), "Editing dropdown failed");
                Console.WriteLine("Dropdown list edited successfully");
            }
            else
            {
                Console.WriteLine("Dropdown list edition  failed");
            }
            if (true)
            {
              //  DeleteDropdown();
               // SwitchToPopUps();
               // Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ABAutomationEdited']")), "Deleting dropdown failed");
               // Console.WriteLine("Dropdown list deleted successfully");
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Admin --> Miscellaneous --> Dropdown List passed smoke test successfully");

            }
            else
            {
                Console.WriteLine("Dropdown list deletion  failed");
            }

        }


        public void AddNewDropdown()
        {
            SwitchToPopUps();
            SelectElement se = new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("lookupListIdSelect")));
           // se.SelectByText("Item1");
            se.SelectByIndex(1);
            Thread.Sleep(2000);
            SwitchToPopUps();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("lookupListIdSelect"))).SelectByText("Admin - Locale Supported Language Codes");
        //    ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('lookupListIdSelect').selectedIndex ='2'");
            javascriptClick(By.XPath(General.Default.NewB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            typeDataName("description", "ABAutomation");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CreateB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();

        }
        public void EditDropdown()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='ABAutomation']"));
            typeDataName("description", "ABAutomationEdited");
            javascriptClick(By.XPath(General.Default.UpdateB));
        }

        public void DeleteDropdown()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='ABAutomationEdited']"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
        }
    }
}
