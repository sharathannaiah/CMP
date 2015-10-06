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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.SystemAdmin
{
    class Properties : BaseActions
    {
        public void PropertiesFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            retryingFindClickk(".//*[@id='mnuAdmin_PropertiesEditor']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Properties']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

            if (CreateProperties())
            {
                SearchProperties("AB.Automation.Cmp");
                Console.WriteLine("New Properties created successfully");
            }
            

            if (EditProperties())
            {
                SearchProperties("AB.Automation.Cmp");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Automation9']")), "Edition failed");
                Console.WriteLine("New Properties Edited successfully");
            }
            

            if (DeleteProperties())
            {
                SwitchFrames();
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Automation9']")), "Deletion failed");
                Console.WriteLine("New Properties Deletion successful");
                Console.WriteLine("Admin --> System Admin --> Proerties Passed smoke test successfully");
            }
           
        }
            public Boolean CreateProperties()
            {
                SwitchFrames();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
                SwitchFrames();
                typeDataID("newPropertyName", "AB.Automation.Cmp");
                typeDataID("propertyValue", "Automation007");
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                return true;
            }


            public void SearchProperties(String text)
            {
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("SYSTEM_PROPERTIES_EDITOR");
                typeDataName("propertyName", "AB.Automation.Cmp");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                Thread.Sleep(2000);
                SwitchFrames();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='" + text + "']")), "Search Failed");
                Console.WriteLine("Properties search Successful");
            }
            public void SwitchFrames()
            {
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("SYSTEM_PROPERTIES_EDITOR");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("SYSTEM_PROPERTIES_LIST");
                Thread.Sleep(2000);
            }

            public Boolean EditProperties()
            {
                SwitchFrames();
                javascriptClick(By.XPath("//div[text()='AB.Automation.Cmp']"));
                SwitchFrames();
                typeDataID("propertyValue", "Automation9");
                javascriptClick(By.XPath(General.Default.SaveB));
                return true;
            }

            public Boolean DeleteProperties()
            {
                SwitchFrames();
                javascriptClick(By.XPath("//div[text()='AB.Automation.Cmp']"));
                SwitchFrames();
                javascriptClick(By.CssSelector("input.multiSelectRow"));
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window=confirm = function(msg) {return true;};");
                javascriptClick(By.XPath(General.Default.DeleteB));
                return true;
            }

        }
    
}
