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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Messaging
{
    class NotificationAdministration : BaseActions
    {
        public void NotificationAdministrationFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Messaging']");
            retryingFindClickk(".//*[@id='mnuAdmin_Notifications']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Notification Administration']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

            if (true)
            {
                CreateNotification();
                Console.WriteLine("Notification Created Successfully");
            }
            else 
            {
                Console.WriteLine(" Notification creation failed");
            }

            if (true)
            {
                DeleteNotification();
                Console.WriteLine("Notification Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Notification deletion failed");
            }

            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.CloseB));
            Console.WriteLine("Admin --> Messaging --> Notification Adminstration passed smoke test successfully");
        }

        public void CreateNotification()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.NewB));
            Thread.Sleep(2000);
            typeDataName("ehModuleName", "ABEnterprise");
            typeDataName("ehEventName", "Automation");
            typeDataName("ehDescription", "Auto Description");
            typeDataID("ehMessage", "Smoke Test");
            if (true)
            {
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABEnterprise']")), "Notification not Created");
            }
            else
            {
                Console.WriteLine(" Notification creation failed");
            }
        }


        public void DeleteNotification()
        {
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ABEnterprise']")), "Notification not deleted");
        }
                
    }
}
