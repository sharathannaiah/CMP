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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Portal
{
    class Configuration : BaseActions
    {

        public void ConfigurationFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Portal']");
            retryingFindClickk(".//*[@id='mnuEmployeePortal_Config']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Configuration']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }

            if(true)
            {
            SaveSettings("tab1", "MODULES_CONFIGURATION");
            Console.WriteLine("Module settings save successful");
            }
            else
            {
            Console.WriteLine("Module settings save  failed");
            }

            if(true)
            {
            SaveSettings("tab2", "REGISTRATION_CONFIGURATION");
            Console.WriteLine("Registration configuration save successful");
            }
            else
            {
            Console.WriteLine("Registration configuration save  failed");
            }
            
            if (true)
            {
                SaveSettings("tab3", "EXPENSE_CONFIGURATION");
             Console.WriteLine("Expense configuration save successful");

            }
            else
            {
                Console.WriteLine("Expense configuration save  failed");
            }
            
            if (true)
            {
                SaveSettings("tab6", "PROFILE_CONFIGURATION");
             Console.WriteLine("Profile configuration save successful");
            }
            else
            {
                Console.WriteLine("Profile configuration save  failed");
            }

            if(true)
            {
            CatlogProfile();
            DeleteCatlogProfile();
            }

            if(true)
            {
            ApprovalValidation();
                DeleteApprovalCountry();
            }

            if(true)
            {
            AddExternalLink();
                DeleteExternalLink();
            }

            if (true)
            {
                AddValidateCountry();
                DeleteCountry();
                Console.WriteLine("Admin -- > Portal --> Configuration passed smoke test successfully");
            }
        }
            public void SaveSettings(String Tabs, String Frame)
            {
                SwitchToContent();
                javascriptClick(By.Id(Tabs));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(Frame);
                IWebElement element = BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@type='checkbox']"));
                if (element.Selected)
                {
                    element.Click();
                    ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.alert =  function(msg) {return true;};");
                    javascriptClick(By.XPath(General.Default.SaveB));
                    Thread.Sleep(2000);
                    SwitchToContent();
                    BrowserDriver.Instance.Driver.SwitchTo().Frame(Frame);
                    WaitForElementPresentAndEnabled(By.XPath("//input[@type='checkbox']"));
                    element.Click();
                    ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.alert =  function(msg) {return true;};");
                    javascriptClick(By.XPath(General.Default.SaveB));
                }
            }

                public void CatlogProfile()
                {
               SwitchToContent();
                javascriptClick(By.Id("tab7"));
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("CATALOG_PROFILE");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS");
                    javascriptClick(By.XPath(General.Default.NewB));
                    Thread.Sleep(2000);
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL_TAB");
                    typeDataID("catalogProfileName", "ABProfile");
                   javascriptClick(By.XPath(General.Default.SaveB));
                     Thread.Sleep(2000);
                     SwitchToContent();
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("CATALOG_PROFILE");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS");
                    Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABProfile']")),"Adding profile failed");
              Console.WriteLine("Profile added successfully");

                }

        public void DeleteCatlogProfile()
        {
        SwitchToContent();
             BrowserDriver.Instance.Driver.SwitchTo().Frame("CATALOG_PROFILE");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
                    javascriptClick(By.XPath(General.Default.DeleteB));
                    Thread.Sleep(2000);
                     SwitchToContent();
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("CATALOG_PROFILE");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS");
                    Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ABProfile']")),"Deleting profile failed");
              Console.WriteLine("Profile deleted successfully");
        }

        public void ApprovalValidation()
        {
        SwitchToContent();
            javascriptClick(By.Id("tab8"));
             BrowserDriver.Instance.Driver.SwitchTo().Frame("APPROVER_VALIDATION");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS");
                    javascriptClick(By.XPath(General.Default.NewB));
                    Thread.Sleep(2000);
                   SelectfromDropdown("countryCode", "2");
            SelectfromDropdown("title","2");
            javascriptClick(By.XPath(General.Default.SaveB));
                     Thread.Sleep(2000);
                     SwitchToContent();
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("APPROVER_VALIDATION");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS");
                    Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Afghanistan']")),"Adding country failed");
              Console.WriteLine("Country added successfully");
        }

         public void DeleteApprovalCountry()
        {
        SwitchToContent();
             BrowserDriver.Instance.Driver.SwitchTo().Frame("APPROVER_VALIDATION");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS");
                    javascriptClick(By.CssSelector("input.multiSelectRow"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
                    javascriptClick(By.XPath(General.Default.DeleteB));
                    Thread.Sleep(2000);
                     SwitchToContent();
                     BrowserDriver.Instance.Driver.SwitchTo().Frame("APPROVER_VALIDATION");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS");
                    Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Afghanistan']")), "Deleting country failed");
              Console.WriteLine("Country deleted successfully");
        }


        public void AddExternalLink()
        {
        SwitchToContent();
        javascriptClick(By.Id("tab9"));
        BrowserDriver.Instance.Driver.SwitchTo().Frame("EXTERNAL_LINKS");
        javascriptClick(By.XPath(General.Default.NewB));
        Thread.Sleep(2000);
                   SelectfromDropdownByText("externalLinkClientId", "EP");
            typeDataID("externalLinkLabel","ABExternalLink");
            typeDataID("url","http://www.tangoe.com");
                   javascriptClick(By.XPath(General.Default.SaveB));
                     Thread.Sleep(2000);
                     SwitchToContent();
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("EXTERNAL_LINKS");
                    Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABExternalLink']")),"Adding url link failed");
              Console.WriteLine("URL Link added successfully");
        }

        public void DeleteExternalLink()
        {
         SwitchToContent();
        BrowserDriver.Instance.Driver.SwitchTo().Frame("EXTERNAL_LINKS");
            javascriptClick(By.CssSelector("input.multiSelectRow"));
              ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
                    javascriptClick(By.XPath(General.Default.DeleteB));
                    Thread.Sleep(2000);
                     SwitchToContent();
                     BrowserDriver.Instance.Driver.SwitchTo().Frame("EXTERNAL_LINKS");
                    Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ABExternalLink']")),"Deleting External link failed");
              Console.WriteLine("External Link deleted successfully");
        }


        public void AddValidateCountry()
        {
            SwitchToContent();
            javascriptClick(By.Id("tab10"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame("VMC");
            javascriptClick(By.XPath(General.Default.AddB));
            Thread.Sleep(4000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("VMC");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Aaland Islands']")), "Country not added");
            Console.WriteLine("Valid Country Added Successfully");
        }

        public void DeleteCountry()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("VMC");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("VMC");
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Aaland Islands']")), "Deleting Country failed");
            Console.WriteLine("Country deleted successfully");

        }
        }
    }


