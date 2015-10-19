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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Assurance
{
    class UninstallAssurance : BaseActions
    {

        public void UninstallAssuranceFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAssurance_testUpdates']");
            retryingFindClickk(".//*[@id='mnuAssurance_uninst']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='CMP Assurance Test Uninstallation']"));
                Console.WriteLine("Navigation Successful");
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CancelB)).Click();
                Console.WriteLine("Admin --> Assurance passed smoke test successfully");
            }
           
        }
    }
}
