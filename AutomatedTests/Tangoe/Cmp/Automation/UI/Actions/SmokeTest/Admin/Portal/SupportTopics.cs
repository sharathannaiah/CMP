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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Portal
{
    class SupportTopics: BaseActions
    {
        public void SupportTopicsFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Portal']");
            retryingFindClickk(".//*[@id='mnuSupport_Topic']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Support Topic Maintenance']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            if(true)
            {
            AddTopics();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Automated']")), "Adding topic failed");
            Console.WriteLine("Support Topic added successfully");
            }

            if (true)
            {
                EditTopic();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='EditAutomated']")), "Editing topic failed");
                Console.WriteLine("Support Topic Edited successfully");
            }


            if (true)
            {
                DeleteTopic();
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='EditAutomated']")), "Delete topic failed");
                Console.WriteLine("Support Topic Deleted successfully");
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Admin--> Portal --> Support Topic passed Smoke Test Successfully");
            }
        }

        public void AddTopics()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.NewB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            BrowserDriver.Instance.Driver.FindElement(By.Id("supportTopicDescription")).SendKeys("Automated");
            typeDataID("supportTopicDescription", "Automated");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            SwitchToPopUps();
            //IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
            //BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);

        }

        public void EditTopic()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='Automated']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.EditB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            BrowserDriver.Instance.Driver.FindElement(By.Id("supportTopicDescription")).SendKeys("EditAutomated");
            typeDataID("supportTopicDescription", "EditAutomated");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            SwitchToPopUps();
        }


        public void DeleteTopic()
        {

            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='EditAutomated']"));
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm= function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToPopUps();
        }
    
            protected static Boolean SwitchWindow(string title)
            {
                var currentWindow = BrowserDriver.Instance.Driver.CurrentWindowHandle;
                var availableWindows = new List<string>(BrowserDriver.Instance.Driver.WindowHandles);

                foreach (string w in availableWindows)
                {
                    if (w != currentWindow)
                    {
                        BrowserDriver.Instance.Driver.SwitchTo().Window(w);
                        if (BrowserDriver.Instance.Driver.Title == title)
                            return true;
                        else
                        {
                            BrowserDriver.Instance.Driver.SwitchTo().Window(currentWindow);
                        }

                    }
                }
                return false;
            }
        }
    }


