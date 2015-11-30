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
                Thread.Sleep(2000);
                IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[text()='Contract Expiration Notification Test']"));
               if (!ele.Selected)
               {
                   BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
                   Thread.Sleep(2000);
               }
              //  BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.UninstallB)).Click();
                Console.WriteLine("Uninstallation of test successful");
                Console.WriteLine("Admin --> Assurance --> Uninstall Test passed smoke test successfully");
                javascriptClick(By.XPath(General.Default.CancelB));
            }
           
        }
    }
}
