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

            if (SaveHeaderView("//a[text()='New Configuration']"))
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//input[@type='checkbox']")), "Saving Header Link for new configuration failed");
                Console.WriteLine("Saving Header Link for new configuration successful");
            }

            if (SaveHeaderView("//a[text()='Change Configuration']"))
            {

                Assert.IsTrue(IsElementVisible(By.XPath("//input[@type='checkbox']")), "Saving change configuration failed");
                Console.WriteLine("Saving Header Link for change configuration successful");
            }

            if (SaveHeaderView("//a[text()='Disconnect Configuration']"))
            {

                Assert.IsTrue(IsElementVisible(By.XPath("//input[@type='checkbox']")), "Saving disc configuration failed");
                Console.WriteLine("Saving Header Link for disconnect configuration successful");
            }


            if (CreateNewConfiguration())
            {
                //  Assert.IsTrue(IsElementVisible(By.CssSelector("div[title^='Automation']")), "New configuration creation failed");
                SwitchToContentFrame();
                //Assert.IsTrue(IsElementVisible(By.CssSelector("div[title='Automation Configuration']")), "New configuration creation failed");
                Console.WriteLine("Configuration created successfully");
            }

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


            //if (RemoveVendorLeadTime())
            //{
            //    SwitchToPopUps();
            //    BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            //    Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Allstream']")), "Removing Vendor Lead Time Configuration failed");
            //    Console.WriteLine("Vendor LeadTime Removed Successfully");
            //}

            if (AddVendorDelivery())
            {
                javascriptClick(By.CssSelector("span.clsCollapse"));
                Thread.Sleep(2000);
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Allstream']")), "Vendor Delivery Creation failed");
                Console.WriteLine("Vendor Deliver creation successful");
            }
            //if (RemoveVendorDelivery())
            //{
            //    javascriptClick(By.CssSelector("span.clsCollapse"));
            //    Thread.Sleep(2000);
            //    Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='Allstream']")), "Vendor Delivery Deletion failed");
            //    Console.WriteLine("Vendor Deliver Deletion successful");
            //    javascriptClick(By.XPath(General.Default.CloseB));
            //}

            if (AddRequestTemplate())
            {
                SwitchToContentFrame();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Automation Temp']")), "Request Template creation failed");
                Console.WriteLine("Request Template created successfully");
                javascriptClick(By.XPath("//div[text()='Automation Temp']"));
                javascriptClick(By.XPath(General.Default.ModifyB));
                Thread.Sleep(3000);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("RT_CONTENT");
                typeDataName("pmRequestTemplateDescription", "Template Automation Edited and modified");
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                VendorAddRemove();
                javascriptClick(By.XPath(General.Default.CloseB));
                Thread.Sleep(2000);
                SwitchToContentFrame();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Template Automation Edited and modified']")), "Request Template modification failed");
                Console.WriteLine("Request Template modified successfully");
                Thread.Sleep(2000);
            }

            if (CopyRequest())
            {
                SwitchToContentFrame();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Copy of Automation']")), "Request copy failed");
                Console.WriteLine("Request copied successfully");
            }

            //if (DeleteRequestTemplate())
            //{
            //    Thread.Sleep(2000);
            //    SwitchToContentFrame();
            //    Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Automation Temp']")), "Request Template Deletion failed");
            //    Console.WriteLine("Request Template deleted successfully");
            //}

            if (AddConfiguration())
            {
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
                javascriptClick(By.CssSelector("span.clsCollapse"));
                Thread.Sleep(2000);
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Allstream']")), "Configuration Addition failed");
                Console.WriteLine("Configuration Addition successful");
                Thread.Sleep(2000);
                javascriptClick(By.XPath("//span[text()='Allstream']"));
                javascriptClick(By.XPath(General.Default.CopyB));
                Thread.Sleep(5000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
                javascriptClick(By.CssSelector("input.multiSelectRow"));
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
                javascriptClick(By.CssSelector("span.clsCollapse"));
                Thread.Sleep(2000);
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Allstream']")), "Configuration copy failed");
                Console.WriteLine("Configuration copied successfully");
            }

            if (DeleteConfiguration())
            {
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
                Assert.IsFalse(IsElementVisible(By.XPath("//div[span[text()='Allstream']")), "Configuration deletion failed");
                Console.WriteLine("Configuration Deletion successful");
                javascriptClick(By.XPath(General.Default.CloseB));
                Thread.Sleep(2000);
            }

            if (EmailandPrinting("aemail"))
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Alert Information']")), "Modification of Email  failed");
                Console.WriteLine("Navigation and modification of Email successful");
            }

            if (EmailandPrinting("aprinting"))
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Alert Information']")), "Modification of Email  failed");
                Console.WriteLine("Navigation and modification of Email successful");
                Console.WriteLine("Admin --> Provisioning passed smoke test successfully");
            }

        }


        public Boolean SaveHeaderView
            (String View)
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

        public Boolean AddVendorDelivery()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("aVendorConfigurationDel")).Click();
            Thread.Sleep(3000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            javascriptClick(By.XPath(General.Default.AddB));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            Thread.Sleep(2000);
            javascriptClick(By.CssSelector("input.multiSelectRow"));
         //   javascriptClick(By.XPath("//input[@type='checkbox']"));
            javascriptClick(By.XPath(General.Default.OKB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            return true;
        }

        public Boolean RemoveVendorDelivery()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");
            javascriptClick(By.XPath("//span[text()='Allstream']"));
            Thread.Sleep(2000);
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SERVICE_CONTENT");              
            return true;
        }

        public Boolean AddRequestTemplate()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTAINER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("arequesttemplates")).Click();
            Thread.Sleep(2000);
            SwitchToContentFrame();
             javascriptClick(By.XPath(General.Default.AddB));
             Thread.Sleep(2000);
             SwitchToPopUps();
             //BrowserDriver.Instance.Driver.FindElement(By.Name("pmRequestTemplateName")).SendKeys("Automation Temp");
             typeDataName("pmRequestTemplateName", "Automation Temp");
             new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2ActivityId"))).SelectByText("Change/Add");
           //  BrowserDriver.Instance.Driver.FindElement(By.Name("pmRequestTemplateDescription")).SendKeys("Template Automation Created");
             typeDataName("pmRequestTemplateDescription", "Template Automation Created");
             javascriptClick(By.XPath(General.Default.OKB));
             Thread.Sleep(2000);
             return true;
        }

        public Boolean CopyRequest()
        {
            SwitchToContentFrame();
            javascriptClick(By.XPath("//div[text()='Automation Temp']"));
            javascriptClick(By.XPath(General.Default.CopyB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            typeDataName("pmRequestTemplateName", "Copy of Automation");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
            Thread.Sleep(2000);
            return true;
        }


        public Boolean DeleteRequestTemplate()
        {
            SwitchToContentFrame();
            javascriptClick(By.XPath("//div[text()='Automation Temp']"));
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.RemoveB)).Click();
          ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm= function(msg) {return true;};");
            return true;
        }

        public Boolean AddConfiguration()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTAINER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("avendorconfiguration")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.AddB)).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            javascriptClick(By.CssSelector("input.multiSelectRow"));
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            return true;
        }

        public Boolean DeleteConfiguration()
        {
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
            //javascriptClick(By.CssSelector("span.clsCollapse"));
            Thread.Sleep(2000);
            javascriptClick(By.XPath("//span[text()='Allstream']"));
            Thread.Sleep(1000);
            javascriptClick(By.XPath(General.Default.DeleteB));
            return true;
        }

        public void VendorAddRemove()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("arequestTemplateVendor")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("RT_CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.AddB)).Click();
            Thread.Sleep(2000);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2VendorId"))).SelectByText("Allstream");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("RT_CONTENT");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Allstream']")), "Vendor Addition  failed");
            Console.WriteLine("Vendor added successfully");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.DeleteB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("RT_CONTENT");
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Allstream']")), "Vendor deleted successfully");
            Console.WriteLine("Vendor deleted successfully");
        }

        public Boolean EmailandPrinting(String Tab)
        {
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTAINER");
            BrowserDriver.Instance.Driver.FindElement(By.Id(Tab)).Click();
            Thread.Sleep(2000);
            SwitchToContentFrame();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.ModifyB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
            Thread.Sleep(2000);
            SwitchToContentFrame();
            return true;

        }
    }
}