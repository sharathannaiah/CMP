﻿using AutomatedTests.Tangoe.Cmp.Automation.Common;
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
                WaitForElementToVisible(By.XPath("//td[text()='Exchange Rate Import Wizard']"));
                Console.WriteLine("Navigation Successful");
            }
            else 
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
      //      if (true)
      //      {
      //          SwitchToPopUps();
      //          ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('importSource').selectedIndex='1'");
      //          javascriptClick(By.XPath(General.Default.SubmitB));
      //          new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("importSource"))).SelectByIndex(1);
      //          Thread.Sleep(2000);
      //          SwitchToPopUps();
      //          Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Tangoe Exchange Rate Template']")), "Unable to display details");
      //          javascriptClick(By.XPath("//div[text()='0']"));
      //          javascriptClick(By.XPath(General.Default.DetailsB));
      //          Thread.Sleep(2000);
      //          BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
      ////          BrowserDriver.Instance.Driver.SwitchTo().Window(BrowserDriver.Instance.Driver.WindowHandles.Last());
      //          Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Tangoe Exchange Rate Template']")), "Unable to display details");
      //          Console.WriteLine("Navigation to details page successful");

            SwitchToPopUps();
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Exchanging Import Rates passed smoke test successfully");
            
            

        }
    }
}
