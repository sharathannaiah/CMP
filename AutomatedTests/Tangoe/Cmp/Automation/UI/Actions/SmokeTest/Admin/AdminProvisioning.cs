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
using AutomatedTests.CMP.Admin;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin
{
    class AdminProvisioning : BaseActions
    {
        public void AdminProvisioningFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Provisioning']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Provisioning']"));
                Console.WriteLine("Navigation Successful");
            }

            // if (SaveHeaderView("//a[text()='New Configuration']"))
            // {
            //     Assert.IsTrue(IsElementVisible(By.XPath("//input[@type='checkbox']")), "Saving Header Link for new configuration failed");
            //     Console.WriteLine("Saving Header Link for new configuration successful");
            // }

            // if (SaveHeaderView("//a[text()='Change Configuration']"))
            // {

            //     Assert.IsTrue(IsElementVisible(By.XPath("//input[@type='checkbox']")), "Saving change configuration failed");
            //     Console.WriteLine("Saving Header Link for change configuration successful");
            // }

            // if (SaveHeaderView("//a[text()='Disconnect Configuration']"))
            // {

            //     Assert.IsTrue(IsElementVisible(By.XPath("//input[@type='checkbox']")), "Saving disc configuration failed");
            //     Console.WriteLine("Saving Header Link for disconnect configuration successful");
            // }


            // if (CreateNewConfiguration())
            //{
            //   //  Assert.IsTrue(IsElementVisible(By.CssSelector("div[title^='Automation']")), "New configuration creation failed");
            // SwitchToContentFrame();
            // Assert.IsTrue(IsElementVisible(By.CssSelector("div[title='Automation Configuration']")), "New configuration creation failed");
            // Console.WriteLine("Configuration created successfully");
            //}

            if (ChangeServiceConfiguration())
            {
                Assert.IsTrue(IsElementVisible(By.Id("AccessDropDown")), "Saving Service Configuration failed");
                Console.WriteLine("Saving Service configuration successful");
                javascriptClick(By.XPath("//a[text()=' Access']"));
                Thread.Sleep(2000);
                ChangeConfig();
                Boolean check = BrowserDriver.Instance.Driver.FindElement(By.Id("reqIndicator59")).Selected;
                javascriptClick(By.Id("reqIndicator59"));
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                Console.WriteLine("Service configuration modified successfully");
                    //  Assert.AreEqual("Simple View", BrowserDriver.Instance.Driver.FindElement(By.Id("AccessDropDown")).GetAttribute("label").);
            }

            if (VendorLeadTimeAdd())
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Allstream']")), "Adding Vendor Lead Time Configuration failed");
                Console.WriteLine("Vendor LeadTime Added Successfully");
            }


            if (RemoveVendorLeadTime())
            {
                Thread.Sleep(2000);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Allstream']")), "Removing Vendor Lead Time Configuration failed");
                Console.WriteLine("Vendor LeadTime Removed Successfully");
            }
        }


        public Boolean SaveHeaderView(String View)
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTAINER");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(View)).Click();
            Thread.Sleep(2000);
            SwitchToContentFrame();
            javascriptClick(By.XPath("//div[text()='Simple View']"));
            Thread.Sleep(2000);
            SwitchToContentFrame();
            IWebElement element = BrowserDriver.Instance.Driver.FindElement(By.Id("reqIndicator14"));
            if (!element.Selected)
            {
                element.Click();
                typeDataID("tooltip14", "Automation Tooltip");
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToContentFrame();
                Boolean check = BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='reqIndicator14']")).Selected;
                WaitForElementPresentAndEnabled(By.Id("reqIndicator14"));
                javascriptClick(By.XPath(".//*[@id='reqIndicator14']"));
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToContentFrame();
            }
            return true;
        }


        public Boolean CreateNewConfiguration()
        {
            SwitchToContentFrame();
            javascriptClick(By.XPath(General.Default.NewB));
            Thread.Sleep(2000);
            SwitchToContentFrame();
            typeDataName("configuredView", "Automation Configuration");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            return true;
        }

        public Boolean ChangeServiceConfiguration()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTAINER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("aserviceconfiguration")).Click();
            Thread.Sleep(2000);
            SwitchToContentFrame();
            SelectfromDropdown("AccessDropDown", "0");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContentFrame();
            return true;
        }


        public void SwitchToContentFrame()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTAINER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
            Thread.Sleep(2000);
        }


        public void ChangeConfig()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            Thread.Sleep(2000);
                IWebElement element = BrowserDriver.Instance.Driver.FindElement(By.Id("reqIndicator59"));
            if (!element.Selected)
            {
                element.Click();
                typeDataID("tooltip59", "Automation Tooltip");
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            }
        }

        public Boolean VendorLeadTimeAdd()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("aserviceconfigurationvendorleadtime")).Click();
            Thread.Sleep(4000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            javascriptClick(By.XPath(General.Default.AddB));
            Thread.Sleep(2000);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2VendorId"))).SelectByText("Allstream");
            BrowserDriver.Instance.Driver.FindElement(By.Name("pm2RequestTypeCarrierDaysToComplete")).SendKeys("5");
            SelectfromDropdownByText("pm2VendorId", "Allstream");
            typeDataName("pm2RequestTypeCarrierDaysToComplete", "5");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            return true;
        }

        public Boolean RemoveVendorLeadTime()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            javascriptClick(By.XPath("//div[text()='Allstream']"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.RemoveB));
            Thread.Sleep(2000);
            return true;
        }
    }
}