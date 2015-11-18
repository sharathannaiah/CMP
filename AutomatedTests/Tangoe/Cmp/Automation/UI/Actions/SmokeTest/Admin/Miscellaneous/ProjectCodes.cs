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

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class ProjectCodes : BaseActions
    {
        public void ProjectCodesSmokeFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            retryingFindClickk(".//*[@id='mnuProjectCodes']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Project Maintenance']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            if (true)
            {
                NewProject();
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABProject']")), "Adding new project failed");
                Console.WriteLine("New Project added successfully");
            }
            if (true)
            {
                EditProject();
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABProject1']")), "Editing new project failed");
                Console.WriteLine("New Project edited successfully");
            }
            if (true)
            {
              //  DeleteProject();
               // SwitchToPopUps();
               // Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ABProject1']")), "Deleting new project failed");
               // Console.WriteLine("New Project edited successfully");
                Thread.Sleep(2000);
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Project Codes passed smoke test successfully");
            }

        }
        public void NewProject()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            typeDataName("pmProjectName", "ABProject"+RandomNumbergeneratorL());
            typeDataName("pmProjectDescription", "ABProject");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Thread.Sleep(3000);
        }
        public void EditProject()
        {
            SwitchToPopUps();
            typeDataName("pmProjectDescription", "ABProject1");
         //   typeDataName("pmProjectName", "ABProject1"+RandomNumbergeneratorL());
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Thread.Sleep(2000);
        }
        public void DeleteProject()
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.DeleteB)).Click();
            Thread.Sleep(2000);
        }
    }
}

