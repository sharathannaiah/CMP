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
using System.Diagnostics;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Assurance
{
    class InstallAssurance : BaseActions
    {

        public void AssuranceFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAssurance_testUpdates']");
            retryingFindClickk(".//*[@id='mnuAssurance_inst']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='CMP Assurance Test Installation']"));
                Console.WriteLine("Navigation Successful");
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CancelB)).Click();
                Console.WriteLine("Admin --> Assurance passed smoke test successfully");
            }



        }

        public void InstallAssuranceFile()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
            javascriptClick(By.Name("uploadFile"));
            Thread.Sleep(5000);
            // Process proc = System.Runtime.getRuntime().exec("C:\\Documents and Settings\\nirkumar\\Desktop\\Browse.exe");
            // System.Runtime.getRuntime().exec("rundll32 url.dll,FileProtocolHandler " + "C:\\Documents and Settings\\new.exe"); 

        }


    }
}
