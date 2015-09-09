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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement
{
    class InvoiceProcessing : BaseActions
    {

        public void invoiceprocessing()
        {
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_Invoice_Processing']");
            WaitForElementOnNextPage(By.Id("pageTitle"), "Navigation to Invoice Processing Failed");
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.Id("newButton")).Click();

        }

    }
}
