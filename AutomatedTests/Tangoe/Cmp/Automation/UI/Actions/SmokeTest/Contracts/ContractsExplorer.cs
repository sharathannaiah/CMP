using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Contracts
{
    class ContractsExplorer :BaseActions
    {
        public void Contract()
        {
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='menuMainContracts']")).Click();
            retryingFindClickk(".//*[@id='mnuContracts_Explorer27']");
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("new")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByText("AT&T");
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("contractTypeId"))).SelectByText("Addendum");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("parentContractId"))).SelectByText("LEC");
            BrowserDriver.Instance.Driver.FindElement(By.Name("contractNumber")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.ClassName("btnCMP")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("contractForm");
            Assert.AreEqual("123", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='123']")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='123']")), "Contract Creation failed");

            BrowserDriver.Instance.Driver.FindElement(By.LinkText("Contract List")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Name("carrierContractNumber")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("carrierContractNumber")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContractsbutton")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.=AT&T]")).Text);
            Console.WriteLine("Contract Added Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Id("delete")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            Console.WriteLine("Contract deleted successfully");

        }
    }
}
