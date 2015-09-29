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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Contracts
{
    class RateRegions : BaseActions
    {
        public void RateRegionfunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
            retryingFindClickk(".//*[@id='mnuRateRegions']");
            WaitForElementToVisible(By.XPath("//td[text()='Rate Regions']"));
            Console.WriteLine("Navigation Successful");
            Thread.Sleep(2000);
            AddRegions();
            Thread.Sleep(2000);
       //    AddCountry();
       //     RemoveCountry();
         //   RemoveRegion();

        }

        public void AddRegions()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.NewB));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[1].value='Bangalore'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('description')[1].value='Asia-Pacific Country Region'");
            javascriptClick(By.XPath(General.Default.SaveB));
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //WaitForElementToVisible(By.XPath("//td[text()='India']"));
            SearchRegion();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Bangalore']")), "Adding Region Failed");
            Console.WriteLine("Region Added Successfully");
        }

        public void SearchRegion()
        {
            SwitchToPopUps();
            typeDataName("nameField", "Bangalore");
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Asia-Pacific Country Region']")), "Searching Region Failed");
            Console.WriteLine("Region search Successful");
            Thread.Sleep(2000);
        
        }

        public void AddCountry()
        {
            
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='Bangalore']"));
            javascriptClick(By.XPath(General.Default.AddB));
            Thread.Sleep(2000);
            String newtitle = BrowserDriver.Instance.Driver.Title;
            SwitchWindow("newtitle");
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            SwitchToPopUps();
            typeDataName("countryName", "United States");
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(4000);
            SwitchToPopUps();
            javascriptClick(By.CssSelector("input.multiSelectRow"));
            javascriptClick(By.XPath(General.Default.OKB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='United States']")), "Adding Country Failed");
            Console.WriteLine("Country Added to Region Successfully");
        }

        public void RemoveCountry() 
        {
            SwitchToPopUps();
            SearchRegion();
            javascriptClick(By.CssSelector("input.multiSelectRow"));
            javascriptClick(By.XPath(General.Default.RemoveB));
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='United States']")), "Removing Country Failed");
            Console.WriteLine("Country Deleted from Region Successfully"); 
        
        }
        public void RemoveRegion()
        {
            SwitchToPopUps();
            SearchRegion();
         //   ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function () { return true } ");
            //string script = "window.confirm = function() { return true; }";
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)BrowserDriver.Instance.Driver;
            //executor.ExecuteScript(script);
            javascriptClick(By.XPath(General.Default.DeleteB));
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            SwitchToPopUps();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Bangalore']")), "Deleting Region Failed");
        }
        protected static Boolean SwitchWindow(string title)
        {
            var currentWindow = BrowserDriver.Instance.Driver.CurrentWindowHandle;
            var availableWindows = new List<string>(BrowserDriver.Instance.Driver.WindowHandles);

            foreach (string w in availableWindows)
            {
                if (w != currentWindow)
                {
                    BrowserDriver.Instance.Driver.SwitchTo().Window(w);
                    if (BrowserDriver.Instance.Driver.Title == title)
                        return true;
                    else
                    {
                        BrowserDriver.Instance.Driver.SwitchTo().Window(currentWindow);
                    }

                }
            }
            return false;
        }

    }
}




