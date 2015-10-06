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
    class SystemEvents : BaseActions
    {

        public void SystemEventsFunctionality()
        {

            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            retryingFindClickk(".//*[@id='mnuAdmin_SystemEvents']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='System Events']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            Console.WriteLine("Admin --> System Admin --> System Events passes smoke test successfully ");
        }
    }
}