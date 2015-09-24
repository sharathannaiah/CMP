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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous
{
    class Company : BaseActions
    {
        public void CreateComp()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            //Navigate to Employee Explorer
            retryingFindClickk(".//*[@id='mnuAdmin_Companies']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Company Maintenance']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            if (true)
            {
                AddComp("STC");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AutomationCity']")), "Adding company failed");
                Console.WriteLine("Adding Company Successful");
            }
            else
            {
                Console.WriteLine("Adding Company Failed");
            }
           
            if (true)
            {
                DeleteComp();
                SwitchToPopUps();
                 Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AutomationCity']")), "Deleting company failed");
                 javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Deleting Company Successful");
                Console.WriteLine("Admin --> Miscelleaneous --> Company passed smoke test successfully");
            }
            else
            {
                Console.WriteLine("Deleting Company Failed");
            }
            }
    

        
        public void AddComp(string Compname)
        {
            IWebElement ff = BrowserDriver.Instance.Driver.FindElement(By.Id("CMP_DIALOG_FRAME"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ff);

           BrowserDriver.Instance.Driver.FindElement(By.Id("newCompanyButton")).Click();
           // retryingFindClickk("newCompanyButton");
            Thread.Sleep(3000);
            typeDataName("companyName", "ACompname"+RandomNumbergeneratorL());
            typeDataName("city","AutomationCity");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            Thread.Sleep(4000);
            SwitchToPopUps();
           
        }

        public void DeleteComp()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='AutomationCity']"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; };");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
        }


     

        public void ClickSubmitButton_Contacts()
        {
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.Id("ADMINCONTACTS"));//ADMIN_CONTACTLIST
          //  BrowserDriver.Instance.Driver.FindElement(By.Id(ge.Default.Button));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Submit']")).Click();
            Thread.Sleep(2000);
        }
    }
}

    
