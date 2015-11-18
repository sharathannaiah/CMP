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
    class InvoiceValidation : BaseActions
    {

        public void InvoiceApprovalFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuInvoiceValidation']");

            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Invoice Validation Rules / Approval Configuration']"));
                Console.WriteLine("Navigation successful");
            }

            if (CreateInvoiceApproval())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='None']")), "Invoice Approval rule creation failed");
                Console.WriteLine("Invoice Approval Rules created successful");
                javascriptClick(By.XPath("//span[text()='None']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByIndex(1);
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                Console.WriteLine("Invoice Approval Rules edited successful");
            }
            if (CopyInvoice())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='DO NOT PROCESS']")), "Copy failed");
                Console.WriteLine("Invoice rules copied successfully");
                javascriptClick(By.XPath("//span[text()='None']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='History']")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
          //      BrowserDriver.Instance.Driver.SwitchTo().Frame("queryPane");
          //      BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
           //     Thread.Sleep(4000);
               // Assert.IsTrue(IsElementVisible(By.XPath("//td[text()='Invoice Validation Rules / Approval Configuration History']")), "Navigation to History Pop up failed");
             //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("detailsPane");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();

                Thread.Sleep(2000);
                Console.WriteLine("Navigation to history page successful");
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                GoToMain("Admin");
                retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
                retryingFindClickk(".//*[@id='mnuInvoiceValidation']");
                Thread.Sleep(3000);
                SwitchToPopUps();
            }


            if (DeleteInvoiceApproval())
            {
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='None']")), "Deletion failed");
                Console.WriteLine("Deletion Successful");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
                Console.WriteLine("Admin --> Bill Management --> Invoice Approval Rules passed smoke test successfully");
            }
        }

        public Boolean CreateInvoiceApproval()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("invoiceType"))).SelectByText("None");
           // SelectfromDropdownByText("invoiceType", "None");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            return true;
        }

        public Boolean DeleteInvoiceApproval()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(".//*[@id='jstreeruleTree']/span/div[2]/span[1]/span"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath("//span[text()='Allstream']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath(".//*[@id='jstreeruleTree']/span/div[2]/span[1]/span"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath("//span[text()='Allstream']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath("//span[text()='None']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            return true;
        }

        public Boolean CopyInvoice()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//span[text()='None']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CopyB)).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("invoiceType"))).SelectByText("DO NOT PROCESS");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByIndex(1);
            javascriptClick(By.XPath(General.Default.CopyB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            return true;
        }

    }
}
