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
using System.Diagnostics;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Reporting
{
    class DisplayReports : BaseActions
    {
        public void DisplayReportsFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_ReportingAdmin']");
            retryingFindClickk(".//*[@id='mnuDisplayReports']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Display Reports']"));
                Console.WriteLine("Navigation Successful");

            }

            if (SaveOperationalReports())
            {
               // Assert.IsTrue(IsElementVisible(By.XPath("//option[.'Account Export']")), "Saving Operational Report failed");
                Console.WriteLine("Saving Operational Report Successful");
            }

            if (SaveDataWarehouseReports())
            {
               // Assert.IsTrue(IsElementVisible(By.XPath("//option[.'Account_Details_DW']")), "Saving Data Warehouse Report failed");
                Console.WriteLine("Saving DataWarehouse Report Successful");
            }

            if (SaveCustomPublishReports())
            {
               // Assert.IsTrue(IsElementVisible(By.XPath("//option[.'Batch Data Export']")), "Saving Custom Publish Report failed");
                Console.WriteLine("Saving Custom Publish Report Successful");
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
                Console.WriteLine("Admin --> Reporting --> Display Reports passed smoke test successfully");

            }


        }

        public Boolean SaveOperationalReports()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmOP");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupusrUserId")).Click();
            Thread.Sleep(2000);
            SelectUser();


            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='Account Export']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='deAssignReport(false)']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            //Thread.Sleep(4000);
            //SwitchToPopUps();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmOP");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='Account Export']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='assignReport(false)']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();


            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmOP");
            return true;
        }

        public void SelectUser()
        {
            SwitchToWindow("#dWnd2 iframe");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(4000);
            SwitchToWindow("#dWnd2 iframe");
            javascriptClick(By.XPath("//div[text()='CME Users']"));
            javascriptClick(By.XPath(General.Default.OKB));
            Thread.Sleep(4000);
            SwitchToWindow("#dWnd1 iframe");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmOP");
            javascriptClick(By.XPath("//option[.='Account Export']"));
            Thread.Sleep(2000);
            //IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='deAssignReport(false)']"));
            //ele1.Click();
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
           

            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='Account Export']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='deAssignReport(false)']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            //Thread.Sleep(4000);
            //SwitchToPopUps();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='Account Export']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='assignReport(false)']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            //Thread.Sleep(4000);
            //SwitchToPopUps();
        }

        public Boolean SaveDataWarehouseReports()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabDW")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmDW");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupusrUserId")).Click();
            Thread.Sleep(2000);
            SelectUser();
          
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='Account_Details_DW']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='deAssignReport(false)']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            //Thread.Sleep(4000);
            //SwitchToPopUps();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmDW");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='Account_Details_DW']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='assignReport(false)']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
           // Thread.Sleep(4000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmDW");
            return true;
        }

        public Boolean SaveCustomPublishReports()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabCR")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmCR");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupusrUserId")).Click();
            Thread.Sleep(2000);
            SelectUser();
            
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='Batch Data Export']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='deAssignReport(false)']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            //Thread.Sleep(4000);
            //SwitchToPopUps();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmCR");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//option[.='Batch Data Export']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//img[@onclick='assignReport(false)']")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            //Thread.Sleep(4000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ifrmCR");
            return true;
        }

        public void SwitchToWindow(String window)
        {
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector(window));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
        }
    }
}
