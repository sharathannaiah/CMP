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
    class Payment : BaseActions
    {

        public void PaymentFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuPaymentConfig']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Payments Configuration']"));
                Console.WriteLine("Navigation successful");
            }

            if(CreatePayment())
            {
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("span.clsCollapse")).Click();
                Thread.Sleep(1000);
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Allstream']")),"Payment Creation failed");
                Console.WriteLine("Payment created successfully");
            }

            if(DeletePayment() == true)
            {
                Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='Allstream']")), "Payment Deletion failed");
                Console.WriteLine("Payment deletion successfully");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
                Console.WriteLine("Admin --> Bill Management --> Payment passed smoke test successfully"); 
            }
            
        }

        public Boolean CreatePayment()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByText("Allstream");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
           return true;
        }

        public Boolean DeletePayment()
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
