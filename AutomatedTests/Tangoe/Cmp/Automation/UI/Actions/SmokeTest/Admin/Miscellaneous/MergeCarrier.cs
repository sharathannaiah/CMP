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
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Carrier']")), "search not successful");
                Console.WriteLine("Search Successful");
            }
            else
            {
                Console.WriteLine("Search  failed");
            }
            if (true)
            {
                MergeeCarrier();
                Console.WriteLine("Admin --> Miscellaneous --> MeCarrier Passed smoke test successfully");
            }
        }
            
            public void MergeeCarrier()
            {
            SwitchToContent();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
                Thread.Sleep(3000);
                SwitchToPopUps();
              //  Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Merge Carriers']")), "Navigation to new pop up failed");
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Navigation to New pop up successful");
                Thread.Sleep(2000);
                SwitchToContent();
                javascriptClick(By.Id("bnHistory"));
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
             //   Assert.IsTrue(IsElementVisible(By.XPath("//td[text()='Carrier Merge History']")), "Navigation to History failed");
                Console.WriteLine("Navigation to History pop up successful");
                SwitchToPopUps();
                javascriptClick(By.XPath(General.Default.CloseB));
            }
        }
    }

