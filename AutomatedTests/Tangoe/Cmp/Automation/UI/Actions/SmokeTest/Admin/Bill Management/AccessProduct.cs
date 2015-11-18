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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management
{
    class AccessProduct : BaseActions
    {
        public void AccessProductFunctionality()
        {

            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuAccessProducts']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Access Products']"));
                Console.WriteLine("Navigation successful");
            }

            if (CreateAccessProduct() == true)
            {
                SearchAccessProduct();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Automation']")), "access Product creation failed");
                Console.WriteLine("Access Product created successfully");
            }

            if (DeleteAccessProduct() == true)
            {
                Assert.False(IsElementVisible(By.XPath("//div[text()='Automation']")), "access Product deletion failed");
                Console.WriteLine("Access Product deleted successfully");
            }

        }

        public Boolean CreateAccessProduct()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.Id("newCatButton"));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            typeDataName("displayValue", "Automation"+RandomNumbergeneratorL());
            javascriptClick(By.XPath(General.Default.OKB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            SwitchToPopUps();
            javascriptClick(By.Id("newTypeButton"));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele3 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele3);
            typeDataName("displayValue", "Automationtype"+RandomNumbergeneratorL());
            javascriptClick(By.XPath(General.Default.OKB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele4 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele4);
            //SelectfromDropdownByText("dataRateId", "4 K");
       var ele5 = new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("dataRateId")));
       ele5.SelectByText("4 K");
     //  new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("dataRateId"))).SelectByText("4 K");

            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(3000);
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.Name("frm_AX"));
            Thread.Sleep(2000);
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(5000);
            return true;

        }

        public void SearchAccessProduct()
        {
            SwitchToPopUps();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("queryAccessCat"))).SelectByText("Automation");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
        }

        public Boolean DeleteAccessProduct()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='Automation']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(5000);
            SwitchToPopUps();
            return true;
        }

    }
}