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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous
{
    class MergeCarrier :BaseActions
    {
        public void MergeCarrierFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            retryingFindClickk(".//*[@id='mnuAdmin_CarrierMerge']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Carrier Merge']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

            if (true)
            {
                SwitchToContent();
                SelectfromDropdown("carrierMergeType", "1");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                Thread.Sleep(2000);
                SwitchToContent();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='carrier']")), "search not successful");
                Console.WriteLine("Search Successful");
            }
            else
            {
                Console.WriteLine("Search  failed");
            }
            javascriptClick(By.XPath(General.Default.CloseB));
        }
            
            public void MergeeCarrier()
            {
            SwitchToContent();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
                Thread.Sleep(3000);
                SwitchToPopUps();
                javascriptClick(By.XPath(General.Default.CloseB));
            }
        }
    }

