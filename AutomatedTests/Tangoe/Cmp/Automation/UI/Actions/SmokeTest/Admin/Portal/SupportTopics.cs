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
            }
        }

        public void AddTopics()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.NewB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            String newtitle = BrowserDriver.Instance.Driver.Title;
            SwitchWindow("newtitle");
          //  BrowserDriver.Instance.Driver.SwitchTo().Window(newtitle);
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.Id("CMP_DIALOG_FRAME"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            BrowserDriver.Instance.Driver.FindElement(By.Id("supportTopicDescription")).SendKeys("Automated");
            //      typeDataID("supportTopicDescription","New Topic");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);

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


