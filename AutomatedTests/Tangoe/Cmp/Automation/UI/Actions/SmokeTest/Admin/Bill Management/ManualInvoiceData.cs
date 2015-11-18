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
    class ManualInvoiceData : BaseActions
    {

        public void ManualInvoiceDataFunctionality()
        {

            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuBilling_Validation']");

            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Manual Invoice Configuration']"));
                Console.WriteLine("Navigation successful");
            }

            if(CreateNew() ==true)
            {
                javascriptClick(By.CssSelector("span.clsCollapse"));
                Thread.Sleep(1000);
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Allstream']")),"Creation of new invoice data failed");
                Console.WriteLine("Creation of new Invoice data successful");
            }

            if(EditInvoice() == true)
            {
                javascriptClick(By.CssSelector("span.clsCollapse"));
                Thread.Sleep(1000);
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Allstream']")),"Edition of new invoice data failed");
                Console.WriteLine("Edition of new Invoice data successful");
            }

            if(DeleteInvoice()== true)
            {
            Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='Allstream']")),"Deletion of new invoice data failed");
                Console.WriteLine("Deletion of new Invoice data successful");
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Admin --> Bill Management --> Manual Invoice Data passed smoke test successfully");

            }
        }
            public Boolean CreateNew()
            {
            SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByText("Allstream");
                Thread.Sleep(1000);
                BrowserDriver.Instance.Driver.FindElement(By.Name("allowNewAccount")).Click();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
                Thread.Sleep(3000);
                SwitchToPopUps();
                return true;
            }

        public Boolean EditInvoice()
        {
            Thread.Sleep(2000);
        SwitchToPopUps();
        javascriptClick(By.XPath("//span[text()='Allstream']"));
        Thread.Sleep(3000);
        SwitchToPopUps();
      //  ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierId').selectedText='AT&T'");
          //  new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByText("Alltel");
        javascriptClick(By.Name("allowNewAccount"));
        javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
                SwitchToPopUps();
                return true;
        }

        public Boolean DeleteInvoice()
        {
        SwitchToPopUps();
        javascriptClick(By.XPath("//span[text()='Allstream']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            return true;
        }
        
    }
}
