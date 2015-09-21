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

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Localization
{
    class ExchangeRatesImportLog : BaseActions
    {
        public void ExchangeRatesImportLogFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Localization']");
            retryingFindClickk(".//*[@id='mnuCurrencyRateImportLog']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Exchange Rate Import Wizard']"));
                Console.WriteLine("Navigation Successful");
            }
            else 
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            if (true)
            {
                SwitchToPopUps();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('importSource').selectedIndex='1'");
                javascriptClick(By.XPath(General.Default.SubmitB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Tangoe Exchange Rate Template']")), "Unable to display details");
                Console.WriteLine("Exchanging Import Rates passed smoke test successfully");
                javascriptClick(By.XPath(General.Default.CloseB));
            }
            else 
            {
                Console.WriteLine("Exchanging Import Rates failed smoke test");

            }
        }
    }
}
