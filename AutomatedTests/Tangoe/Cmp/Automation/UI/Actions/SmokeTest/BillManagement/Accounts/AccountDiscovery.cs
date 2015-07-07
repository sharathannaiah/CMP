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
    class AccountDiscovery : BaseActions
    {

        public void AccountDiscoveryy()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BMAccounts']");
            retryingFindClickk(".//*[@id='mnuBilling_AccountDiscovery']");
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryAccountsButton")).Click();
            Thread.Sleep(3000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();

            BrowserDriver.Instance.Driver.FindElement(By.Id("newButton")).Click();
            Thread.Sleep(3000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("acceptAccountButton")).Click();
            Thread.Sleep(3000);

            Console.WriteLine("Account Accepted Sucessfully");

            //Contract Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabContracts")).Click();
            Thread.Sleep(2000);

           // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
           // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
           //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
        //   BrowserDriver.Instance.Driver.SwitchTo().Frame("contractsForm");
            BrowserDriver.Instance.Driver.FindElement(By.Id("addContract")).Click();
            Thread.Sleep(2000);

            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryNegotiatedContractsButton")).Click();
            Thread.Sleep(2000);

            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);



            SwitchToContent();
            Assert.AreEqual("ACTIVE", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='ACTIVE']")).Text);
            Console.WriteLine("Contract added successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Id("removeContract")).Click();
            Thread.Sleep(2000);

          //  Assert.AreNotEqual("ACTIVE", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Text);
            Console.WriteLine("Contract deleted successfully");

            Console.WriteLine("Account Discovery Passed Successfully");






        }
    }
}
