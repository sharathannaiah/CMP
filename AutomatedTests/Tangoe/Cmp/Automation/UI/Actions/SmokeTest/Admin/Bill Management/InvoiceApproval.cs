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
    class InvoiceApproval : BaseActions
    {

        public void InvoiceApprovalFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuInvoiceApprovalRules']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Invoice Approval Rule Configuration']"));
                Console.WriteLine("Navigation Successful");
            }

            if(CreateInvoice())
            {
                Thread.Sleep(2000);
                javascriptClick(By.XPath("//span[text()='None']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='None']")), "New Invoice Approval rules creation failed");
                Console.WriteLine("Invoice Approval Rules created successfully");
            }

             if (CopyInvoice())
            {
                SwitchToPopUps();
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
                BrowserDriver.Instance.Driver.SwitchTo().Frame("detailsPane");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
                Thread.Sleep(2000);
                Console.WriteLine("Navigation to history page successful");
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            }

            if (RemoveRule())
            {
                Thread.Sleep(3000);
                Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='DO NOT PROCESS']")), "Removing rules failed");
                Console.WriteLine("Invoice Rules removed successfully");
            }


            if (DeleteInvoice())
            {
                Thread.Sleep(2000);
                Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='None']")), "Deleting Invoice rules failed");
                Console.WriteLine("Invoice Rules removed successfully");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
                Console.WriteLine("Admin --> Bill Management --> Invoice Approval Rules passed smoke test successfully");
            }
        }

        public Boolean CreateInvoice()
        { 
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("createRuleButton")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("invoiceType"))).SelectByText("None"); 
            BrowserDriver.Instance.Driver.FindElement(By.Id("newRuleButton")).Click();
            Thread.Sleep(4000);
            SwitchToPopUps();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("currencyCodeSelect"))).SelectByText("AUD"); 
            typeDataID("requiredApprovalCount", "1");
            typeDataID("sequenceNumber", "1");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='z1 z1']")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='assignRecipient(1)']")).Click();
            Thread.Sleep(2000);
       //     BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            retryingFindClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(4000);
            SwitchToPopUps();
            return true;
        }

           public Boolean CopyInvoice()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CopyB)).Click();
            Thread.Sleep(4000);
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

           public Boolean RemoveRule()
           {
               SwitchToPopUps();
               javascriptClick(By.XPath(".//*[@id='jstreeruleTree']/span/div[2]/span/span"));
               Thread.Sleep(1000);
               javascriptClick(By.XPath("//span[text()='Allstream']"));
               Thread.Sleep(2000);
               SwitchToPopUps();
               BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.RemoveB)).Click();
               Thread.Sleep(4000);
               SwitchToPopUps();
               return true;
           }

          public Boolean DeleteInvoice()
            {
            SwitchToPopUps();
            //javascriptClick(By.XPath(".//*[@id='jstreeruleTree']/span/div[2]/span/span"));
            //Thread.Sleep(1000);
            javascriptClick(By.XPath("//span[text()='None']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            return true;
            }
        }
    }

