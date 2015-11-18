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
    class ExtendedAttributes: BaseActions
    {
        public void ExtendedAttribyesFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            retryingFindClickk(".//*[@id='mnuAdmin_EA_new']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Extended Attribute Configuration']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

            if (true)
            {
                AddExtendAttribute();
                //Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Automated Extended Attribute1']")), "Adding Extended Attribute failed");
                //Console.WriteLine("Adding Extended Attribute Successful");
                //javascriptClick(By.XPath(General.Default.CloseB));
                //Console.WriteLine("Admin --> Miscellaneous --> Extended Attribute passed smoke test Successfully");

            }


        }

        public void AddExtendAttribute()
        {
            SwitchToPopUps();

            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("category"))).SelectByIndex(1);

            BrowserDriver.Instance.Driver.FindElement(By.Id("filter")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            retryingFindClick(By.XPath(General.Default.NewB));
           BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
           // Thread.Sleep(5000);
           // typeDataID("nameField", "AutomatedEA");
           // SelectElement se = new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("DataType")));
           // se.SelectByText("True/False");
           // typeDataID("sequence", "10");

           // Thread.Sleep(2000);
           // SelectElement se1 = new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("TrueFalse_Val")));
           // se1.SelectByText("False");
           // javascriptClick(By.Id("notes"));
           //IWebElement ele= BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB));
           //ele.Click();
           // Thread.Sleep(2000);
           // SwitchToPopUps();
        }
    }
}
