using AutomatedTests.Tangoe.Cmp.Automation.Common;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using AutomatedTests.CMP.Admin;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Contracts
{
    class RateQualifiers :BaseActions
    {
        public void RateQualifierTest()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
            retryingFindClickk(".//*[@id='mnuRateQualifiers']");
            WaitForElementToVisible(By.XPath("//td[text()= 'Rate Qualifiers']"));
            Console.WriteLine("Navigation Successful");
            CreateQualifiers();
      //      DeleteQualifiers();
            Console.WriteLine("Rate Qualifier passed smoke test Successfully");
            

        }

        public void CreateQualifiers()
        {

            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.NewB));
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[1].value='Rate Qualifier'");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            typeDataName("nameField", "Rate Qualifier");
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text() = 'Rate Qualifier']")), "Failed to create Qualifiers");
            Console.WriteLine("Search Qualifier Successfull");
            Console.WriteLine("Qualifier created successfully");
        }

        public void DeleteQualifiers()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text() = 'Rate Qualifier']")), "Failed to create Qualifiers");
            Console.WriteLine("Qualifier Deleted Successfully");
            javascriptClick(By.XPath(General.Default.CloseB));
        }
    }
}
