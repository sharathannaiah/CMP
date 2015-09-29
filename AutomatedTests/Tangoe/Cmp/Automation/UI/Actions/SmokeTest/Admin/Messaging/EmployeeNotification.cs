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
    class EmployeeNotification : BaseActions
    {
        public void EmployeeNotifiacationFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Messaging']");
            retryingFindClickk(".//*[@id='mnuAdmin_Messages']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Employee Notifications']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

            if (true)
            {
                CreateEmployeeNotification();
                Console.WriteLine("Employee notification created successfully");
            }
            else 
            {
                Console.WriteLine("Employee notification creation failed");
            }
           
            
            if (true)
            {
                SearchEmployeeNotification();
                Console.WriteLine("Employee notification search successfully");
            }
            else 
            {
                Console.WriteLine("Employee notification search failed");
            }

            if (true)
            {
                DeleteEmployeeNotification();
                Console.WriteLine("Employee notification deletion successful");
                Console.WriteLine("Admin --> Messaging --> Employee Notification passed smoke test successfully ");
            }
            else 
            {
                Console.WriteLine("Employee notification deletion not successful");
            }

        }



        public void CreateEmployeeNotification()
        {
            SwitchFrame();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            typeDataID("messageSubject", "Automation Employee Message");
            typeDataName("messageBody", "Employee Notification message body");
            javascriptClick(By.XPath(General.Default.CreateB));
            Thread.Sleep(2000);
            SwitchFrame();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Automation Employee Message']")), "Employee notification not created");

        }

        public void SearchEmployeeNotification()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMINMESSAGE");
            typeDataName("messageSubject", "Automation Employee Message");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(3000);
            SwitchFrame();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Automation Employee Message']")), "Search Unsuccessful");
        }


        public void DeleteEmployeeNotification()
        {
            SwitchFrame();
            javascriptClick(By.CssSelector("input.multiSelectRow"));
         //   javascriptClick(By.XPath("//div[text()='Automation Employee Message']"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchFrame();
            Assert.False(IsElementVisible(By.XPath("//div[text()='Automation Employee Message']")), "Deletion not successful");

        }

        public void SwitchFrame()
        {
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMINMESSAGE");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("MESSAGELIST");

        }
    }
}
