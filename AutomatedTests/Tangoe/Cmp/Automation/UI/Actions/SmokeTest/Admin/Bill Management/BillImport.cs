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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management
{
    class BillImport : BaseActions
    {

        public void BillImportFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuBillImportSettings']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Bill Import Settings']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }

            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("biConcurrentCount"))).SelectByIndex(2);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Change has been saved but not activiated. Restart is required.']")), "Bill Import settings save failed");
            javascriptClick(By.XPath(General.Default.OKB));
            Console.WriteLine("Bill Import Settings Saved successfully");
            Console.WriteLine("Admin --> Bill Management settings passed smoke test successfully");
        }
    }
}
