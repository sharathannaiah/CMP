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
    class ExchangeRates : BaseActions
    {
        public void ExchangeRatesFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Localization']");
            retryingFindClickk(".//*[@id='mnuRateManagementAdmin']");
            if (true)
            {
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
                WaitForElementToVisible(By.XPath("//div[text()='Exchange Rate Details']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            if (true)
            {
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("QUERYSINGLE");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                Thread.Sleep(2000);
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.AddRateB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
                typeDataName("exchangeRate", "5");
                typeDataID("dtControleffectiveDate", "02/02/2015");
                typeDataID("dtControlexpirationDate", "10/10/2020");
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
                Assert.IsTrue(IsElementVisible(By.XPath("//td[text()='5']")), "Unable to Add Rates");
                Console.WriteLine("Rates added Successfully");

            }
            else
            {
                Console.WriteLine("Adding Rates Failed");
            }
            

        }
    }
}
