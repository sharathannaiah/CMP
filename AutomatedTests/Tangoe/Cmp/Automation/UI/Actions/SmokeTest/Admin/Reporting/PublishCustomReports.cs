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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Reporting
{
    class PublishCustomReports : BaseActions
    {
        public void PublishCustomReportsFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_ReportingAdmin']");
            retryingFindClickk(".//*[@id='mnuPublishCustom']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Publish Custom Reports']"));
                Console.WriteLine("Navigation Successful");
                Thread.Sleep(2000);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
                javascriptClick(By.XPath(General.Default.CancelB));
                Console.WriteLine("Admin --> Reporting -->Publish Custom Reports passed smoke test successfully");
            }
        }
      }
}
