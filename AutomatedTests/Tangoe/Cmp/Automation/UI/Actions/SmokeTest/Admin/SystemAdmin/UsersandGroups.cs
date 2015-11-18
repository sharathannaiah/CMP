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
    class UsersandGroups : BaseActions
    {
        public void UsersandGropusFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            retryingFindClickk(".//*[@id='mnuAdmin_Security']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Users and Groups']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

            if (true)
            {
                AddUser();
                SearchUser();
                Console.WriteLine("User Added Successfully");
            }
                else
                {
                    Console.WriteLine("User addition  failed");
                }
            if (true)
            {
                DeleteUser();
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='777']")), "Searching user  failed");
                Console.WriteLine("User Deleted Successfully");
                Console.WriteLine("User and Groups passed smoke test successfully");
            }
            
        }

        public void AddUser()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
            javascriptClick(By.XPath(General.Default.NewB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            typeDataName("logonId", "123"+RandomNumbergeneratorL());
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("providerId"))).SelectByText("CMP Native Security");
          //  ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('providerId').selectedIndex='1'");
            typeDataName("firstName", "AB"+RandomNumbergeneratorL());
            typeDataName("lastName", "XY");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("contactTypeId"))).SelectByText("External");
          //  ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('contactTypeId').selectedIndex='1'");
            typeDataName("password", "12345");
            typeDataName("passwordRetype", "12345");
            typeDataName("phone1", "777");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);

        }


        public void SearchUser()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("QUERYUSERS");
            BrowserDriver.Instance.Driver.FindElement(By.Name("nameField")).SendKeys("AB");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='777']")), "Searching user  failed");
            Console.WriteLine("User Search Successful");
        }

        public void DeleteUser()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
            javascriptClick(By.XPath("//div[text()='777']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            //((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath("//button[text()='Yes']"));
            Thread.Sleep(2000);
            IAlert ele = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            ele.Accept();
            Thread.Sleep(4000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
        }

    }
}
