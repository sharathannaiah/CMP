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
    class Hubs : BaseActions
    {
        public void HubsFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_Tools']");
            retryingFindClickk(".//*[@id='mnuAdmin_Hubs']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Hubs']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }

            if (CreateHubs())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABHub']")), "Hubs creation failed");
                Console.WriteLine("Hub Creation Successful");
            }

            if (EditHub())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Copy of ABHub']")), "Hubs copy failed");
                Console.WriteLine("Hub copied successfully");
                Console.WriteLine("Admin --> Tools --> Hubs passed smoke test successfully");

            }

            //if (DeleteHubs("Copy of ABHub"))
            //{
            //    Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Copy of ABHub']")), "Hubs deletion  failed");
            //    DeleteHubs("ABHub");
            //    Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ABHub']")), "Hubs deletion  failed");
            //    Console.WriteLine("Hub Deletion Successful");
            //}

            
        }

        public Boolean CreateHubs()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            typeDataID("hubName", "ABHub");
            typeDataID("description", "ABAutomationHub");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }

        public Boolean EditHub()
        {
            SwitchToContent();
            javascriptClick(By.XPath("//div[text()='ABHub']"));
            Thread.Sleep(2000);
            javascriptClick(By.XPath(General.Default.CopyB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }

        public Boolean DeleteHubs(String text)
        {
            SwitchToContent();
            javascriptClick(By.XPath("//div[text()='"+ text +"']"));
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            return true;
        }
    }
}
