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
using AutomatedTests.CMP.Company;

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
            Thread.Sleep(2000);
            AddComp("STC");
                
        }


        public void AddComp(string Compname)
        {
            IWebElement ff = BrowserDriver.Instance.Driver.FindElement(By.Id("CMP_DIALOG_FRAME"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ff);

           BrowserDriver.Instance.Driver.FindElement(By.Id("newCompanyButton")).Click();
           // retryingFindClickk("newCompanyButton");
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("companyName")).SendKeys(Compname);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            Thread.Sleep(4000);
           
        }

        public void DeleteComp()
        {
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[@title='CCT']")).Click();
        }


     

        public void ClickSubmitButton_Contacts()
        {
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.Id("ADMINCONTACTS"));//ADMIN_CONTACTLIST
            BrowserDriver.Instance.Driver.FindElement(By.Id(com.Default.Button));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Submit']")).Click();
            Thread.Sleep(2000);
        }
    }
}

    
