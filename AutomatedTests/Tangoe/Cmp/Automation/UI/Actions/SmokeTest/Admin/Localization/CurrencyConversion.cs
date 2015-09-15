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
    class CurrencyConversion :BaseActions
    {
        public void SmokeTestCurrencyConversion()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Localization']");
            retryingFindClickk(".//*[@id='mnuConverstionAdmin']");
            if (true)
            {
                SwitchToPopUps();
                WaitForElementToVisible(By.XPath("//td[text()='General Ledger (GL) Export Date']"));
                Console.WriteLine("Navigation Successful");
            }
            else 
            {
                Console.WriteLine("Navigation Unsuccessful");
            }

        SwitchToPopUps();
        javascriptClick(By.Id("policyOption"));
        javascriptClick(By.XPath(General.Default.SaveB));
        Thread.Sleep(2000);
        SwitchToPopUps();
        WaitForElementPresentAndEnabled(By.Id("policyOption"));
        Console.WriteLine("Currency Converion policy saved successfully");
        javascriptClick(By.XPath(General.Default.CloseB));
        Console.WriteLine("Admin --> Localization --> Currency Converion policy passed Smoke Test successfully");

        }
    }
}
