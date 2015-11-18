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


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class ManualInvoiceGeneral : BaseActions
    {

        public void ManualInvoiceFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuBilling_General']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Manual Invoice Configuration']"));
                Console.WriteLine("Navigation Successful");
            }
            if (SaveGeneralInvoice() == true)
            {
                Console.WriteLine("Saving General Manual Invoice successful");
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Admin --> Bill Management --> General Manual Invoice passed smoke test successfully");
            
            }

        }

            public Boolean SaveGeneralInvoice()
            {
            SwitchToPopUps();
            IWebElement element = BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@type='checkbox']"));
            if (!element.Selected)
            {
                element.Click();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
                WaitForElementPresentAndEnabled(By.XPath("//input[@type='checkbox']"));
                element.Click();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
            }
            return true;
        }
    }
}
