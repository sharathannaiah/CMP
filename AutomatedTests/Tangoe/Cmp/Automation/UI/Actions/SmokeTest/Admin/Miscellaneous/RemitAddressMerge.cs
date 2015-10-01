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

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class RemitAddressMerge : BaseActions
    {

        public void RemitAddressMergeFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            retryingFindClickk(".//*[@id='mnuAdmin_VendorAddressMerge']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Vendor Remit Address Merge']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }
           
            if(true)
            {
            SearchRemitAddress();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AT&T']")),"Search not successful");
                Console.WriteLine("Search Successful");
            }
            else
            {
                Console.WriteLine("Search not Successful");
            }

            if(true)
            {
            HideChecked();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Yes']")), "Hide not successful");
                Console.WriteLine("Hide Successful");
            }
            else
            {
                Console.WriteLine("Hide failed");
            }

            if(true)
            {
            DisplayChecked();
                 Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='No']")), "Display not successful");
                Console.WriteLine("Display Successful");
                Console.WriteLine("Admin --> Miscellaneous --> Remit Address Added Successfully");
            }
           
            else
            {
            Console.WriteLine("Display not successful");
            }
        }


            public void SearchRemitAddress()
            {
            SwitchToContent();
                typeDataID("carrierId", "1");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                Thread.Sleep(2000);
                SwitchToContent();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.ResetB)).Click();
                SwitchToContent();

            }

        public void HideChecked()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Hide Checked']")).Click();
            Thread.Sleep(2000);
            SwitchToContent();
        }

        public void DisplayChecked()
        {
        SwitchToContent();
             BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Display Checked']")).Click();
            Thread.Sleep(2000);
            SwitchToContent();
        }
        }
    }
