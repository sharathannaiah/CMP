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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Localization
{
    class Currencies : BaseActions
    {
        public void CurrenciesSomkeTest()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Localization']");
            retryingFindClickk(".//*[@id='mnuSupportedCurrenciesAdmin']");
            if (true)
            {
                SwitchToContent();
                WaitForElementToVisible(By.XPath("//div[text()='CMP Currency Manager']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }

            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("frm_AFN")).Click();
            WaitForElementToVisible(By.Name("frm_AMD"));
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('frm_AFN')[1].value='1.9'");
           // typeDataName("frm_AMD", "0.9");
            //Send("1");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Thread.Sleep(3000);
            //IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            //alert.Accept();
            SwitchToContent();
            Assert.IsFalse(IsElementVisible(By.XPath("//input[@value='1.']")), "Currency value not set");
            Console.WriteLine("Currency value added successfully to Country");
            BrowserDriver.Instance.Driver.FindElement(By.Name("frm_AFN")).Click();
            typeDataName("frm_AFN", "2");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Assert.IsFalse(IsElementVisible(By.XPath("//input[@value='2.']")), "Currency value not edited");
            Console.WriteLine("Currency value edited successfully to Country");

            Console.WriteLine("Admin --> Localization --> Currency passed smoke test successfully");
        }
        public void Send(String longstring)
        {
            IWebElement inputField = BrowserDriver.Instance.Driver.FindElement(By.Name("frm_AFN"));

            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("arguments[0].setAttribute('value', '" + longstring + "')", inputField);

        }
    }
}
