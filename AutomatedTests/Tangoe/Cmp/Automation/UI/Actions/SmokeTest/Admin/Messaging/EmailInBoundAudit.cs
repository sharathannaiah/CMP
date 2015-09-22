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
    class EmailInBoundAudit : BaseActions
    {
        public void EmailInBoundAuditSmokeFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Messaging']");
            retryingFindClickk(".//*[@id='mnuAdmin_EmailInb_Audit']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Email Inbound Audit']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }
            Console.WriteLine("Admin --> Messaging --> Email Inbound Audit passed smoke test successfully");
        }
    }
}
