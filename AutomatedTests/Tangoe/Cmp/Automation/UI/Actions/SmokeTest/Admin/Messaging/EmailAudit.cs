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
    class EmailAudit : BaseActions
    {
        public void EmailAuditFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Messaging']");
            retryingFindClickk(".//*[@id='mnuAdmin_Messages']");

            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Email Audit']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

            if(true)
            {
            SearchAudit();
            Console.WriteLine("Audit Search Successful");
            }
            else
            {
            Console.WriteLine("Audit Search Unsuccessful");
            }
             Console.WriteLine("Admin --> --> Email Audit passed smoke test Successfully");

        }
            public void SearchAudit()
            {
            SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("EMAILAUDITMESSAGE");
                SelectfromDropdown("statusInt","1");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                Thread.Sleep(2000);
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("EMAILAUDITMESSAGE");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("EMAILAUDITLIST");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()=.'Success']")), "Search Failed");
            }

        }
    }

