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
    class InvoiceExport :  BaseActions
    {
        public void InvoiceExportFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuBilling_Invoice_Export']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Invoice Export']"));
                Console.WriteLine("Navigation Successful");
            }


            if (CreateInvoiceExport())
            {
                javascriptClick(By.CssSelector("span.clsCollapse"));
                Thread.Sleep(2000);
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Allstream']")), "Invoice Export Creation failed");
                Console.WriteLine("Invoice Export creation successful");
            }

            if (DeleteInvoiceExport())
            {
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='Allstream']")), "Invoice Export Deletion failed");
                Console.WriteLine("Invoice Export Deletion Successful");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
                Console.WriteLine("Admin --> Bill Management --> Invoice Export passed smoke test successfully");
            }
        
        }

        public Boolean CreateInvoiceExport()
        {
            SwitchToPopUps();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("carrierId"))).SelectByIndex(1);
            IWebElement Save = BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB));
            Save.Click();
            Thread.Sleep(4000);
            SwitchToPopUps();
            return true;
        }

        public Boolean DeleteInvoiceExport()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//span[text()='Allstream']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm =function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            return true;
        }
    }
}
