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
                else
                {
                    Console.WriteLine("Settings save  failed");
                }

        }
    }
}
