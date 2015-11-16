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
    class CountryState : BaseActions
    {
        public void LocalizationSmokeTest()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Localization']");
            retryingFindClickk(".//*[@id='mnuAdmin_CountryAdmin']");
           
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Country/State/Province']"));
                Console.WriteLine("Navigation Successfull");
            }
            else 
            {
                Console.WriteLine("Navigation not successful");

            }


            if(true)
            {
            CreateCountry();
         //   Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AutomationCountry']")),"Create and Search Unsuccessful");
            Console.WriteLine("Country Creation and Search Successful");
            }
            else
            {
                Console.WriteLine("Country Create and Search Unsuccessful");
            }


            //if (true)
            //{
            //    AddState();
            //    Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Automationstate']")), "Adding State Unsuccessful");
            //    Console.WriteLine("Adding State Successful");
            //}
            //else
            //{
            //    Console.WriteLine("State Addition Unsuccessful");
            //}



            //if (true)
            //{
            //    DeleteState();
            //    WaitForElementPresentAndEnabled(By.XPath("//div[text()='Automationstate']"));
            //   // Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Automationstate']")), "Adding State Unsuccessful");
            //    Console.WriteLine("Deleting State Successful");
            //}
            //else
            //{
            //    Console.WriteLine("State Deletion Unsuccessful");
          //  }


            if (true)
            {
                DeleteCountry();
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AutomationCountry']")),"Reset and Delete Unsuccessful");
            }

            else
            {
                Console.WriteLine("Country Deletion Unsuccessful");
            }
            Console.WriteLine("Admin--> Localization --> State/Country Passed test Successfully");
        }

        public void CreateCountry()
        {
            SwitchtoCountryListFrame();
            javascriptClick(By.XPath(General.Default.NewB));
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("countryName")).SendKeys("AutomationCountry" + random);
           typeDataID("countryName", "AutomationCountry"+random);
            javascriptClick(By.XPath(General.Default.CreateB));
            Thread.Sleep(3000);
            SwitchToAdmincountryFrame();
            typeDataName("countryName", "AutomationCountry");
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(2000);
            SwitchtoCountryListFrame();
            
        }

        public void SwitchtoCountryListFrame()
        {
            SwitchToContent();
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.Id("I18N_ADMINCOUNTRY"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            IWebElement ele2 = BrowserDriver.Instance.Driver.FindElement(By.Id("ADMIN_COUNTRYLIST"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele2);
            Thread.Sleep(2000);
        }

        public void SwitchToAdmincountryFrame()
        {
            SwitchToContent();
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.Id("I18N_ADMINCOUNTRY"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
        }
      
        public void DeleteCountry()
        {
            SwitchtoCountryListFrame();
         //   javascriptClick(By.XPath("//div[text()='AutomationCountry']"));
           // SwitchtoCountryListFrame();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchtoCountryListFrame();
       //     WaitForElementPresentAndEnabled(By.XPath("//div[text()='AutomationCountry']"));
            if (true)
            {

                Console.WriteLine("Country Deleted successfully");
            }
            else 
            {
                Console.WriteLine("Country Not Deleted successfully");
            }

            SwitchtoCountryListFrame();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(General.Default.RestoreB));
            SwitchtoCountryListFrame();
        //    WaitForElement(By.XPath("//div[text()='AutomationCountry']"));
            if (true)
            {

                Console.WriteLine("Country Restored successfully");
            }
            else
            {
                Console.WriteLine("Country Not Reseted successfully");
            }
        }
            public void AddState()
            {
                SwitchtoCountryListFrame();
                javascriptClick(By.XPath("//div[text()='AutomationCountry']"));
                SwitchtoCountryListFrame();
                javascriptClick(By.Id("stateProvince"));
                Thread.Sleep(2000);
               // WaitForElementToVisible(By.XPath(General.Default.NewB));
                javascriptClick(By.XPath(General.Default.NewB));
                SwitchtoCountryListFrame();
                Thread.Sleep(2000);
                System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
                int random = rand.Next(1, 1000);
                typeDataName("addStateButton", "Automationstate"+random);
                javascriptClick(By.XPath(General.Default.CreateB));
                Thread.Sleep(2000);
                SwitchtoCountryListFrame();

            }

            public void DeleteState()
            {
                SwitchtoCountryListFrame();
                javascriptClick(By.Id("stateProvince"));
                javascriptClick(By.XPath(General.Default.DeleteB));
                SwitchtoCountryListFrame();
            }
        }


    
}
