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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement.Accounts
{
    class AccountMerge : BaseActions
    {

        public void AccountToMerge()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BMAccounts']");
            retryingFindClickk(".//*[@id='mnuBilling_AccountMerge']");
            Thread.Sleep(2000);

            SwitchToPopUps();

            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("carrierId"))).SelectByText("AT&T");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupaccountFromId")).Click();
            Thread.Sleep(3000);
            //SwitchToPopUps();

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Name("queryCostCentersButton")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='ACS-IR']")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
           
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupaccountToId")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();

            BrowserDriver.Instance.Driver.FindElement(By.Name("queryCostCentersButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='ACS-IR'][2]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Name("saveButton")).Click();
            Thread.Sleep(5000);
            Console.WriteLine("Account Merged Successfully");
        }
    }
}
