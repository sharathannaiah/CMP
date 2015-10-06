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

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.SystemAdmin
{
    class MonitorUsers : BaseActions
    {
        public void MonitorUsersFunctionality()
        {
         
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            retryingFindClickk(".//*[@id='mnuAdmin_MonitorUsers']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Monitor Users']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

          if(SearchUsers())
          {
          Console.WriteLine("Search Successful");
          SwitchToContent();

          Console.WriteLine("Admin --> System Admin --> Monitor Users Passed Smoke Test Successfully");
          }

        }

        public Boolean SearchUsers()
        {
        SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(4000);
            SwitchToContent();
            javascriptClick(By.XPath("//div[text()='CmpAdmin']"));
            Thread.Sleep(2000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='EnterpriseCMP']")), "Search users failed");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.ResetB)).Click();
            return true;
        }
    }
}
