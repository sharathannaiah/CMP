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
    class CDRArchive : BaseActions
    {
        public void CDRArchiveFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuInvoiceArchival']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='CDR Archive & Restore']"));
                Console.WriteLine("Navigation Successful");
                Thread.Sleep(5000);
            }

            if (CreateCDR())
            {
                //SearchCDR("AB Archive");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB Archive']")), "Archive Creation failed");
                Console.WriteLine("CDR Archive creation successful");
            }

            if (EditCDR())
            {
                SearchCDR("AB Edited Archive");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB Edited Archive']")), "Archive Edition failed");
                Console.WriteLine("CDR Archive edition successful");
            }

            if (DeleteCDR())
            {
                SwitchToContent();
                Assert.IsFalse(IsElementVisible(By.XPath("/div[text()='Edited AB Archive']")), "Deletion failed");
                Console.WriteLine("CDR Archive Deletion successful");
                Console.WriteLine("Admin --> Bill Management --> CDR Archive passed smoke successfully");

            }
        }


        public Boolean CreateCDR()
        {

            SwitchToContent();
            Thread.Sleep(2000);
              BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
          Thread.Sleep(3000);
            SwitchToContent();
      ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('archiveName')[1].value='abb'");
      BrowserDriver.Instance.Driver.FindElement(By.Id("archiveName")).SendKeys("abb");
       Thread.Sleep(2000);
       BrowserDriver.Instance.Driver.FindElement(By.Id("archiveName")).Click();
            javascriptClick(By.Id("archiveName"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('archiveName')[1].value='abb123'");
            Thread.Sleep(2000);
           //javascriptClick(By.Id("archiveUser"));
            //javascriptClick(By.XPath(General.Default.SaveB));
            //Thread.Sleep(2000);
            //SwitchToPopUps();
            //javascriptClick(By.XPath(General.Default.OKB));
            //Thread.Sleep(2000);
            //SwitchToContent();
            //javascriptClick(By.Id("browseServerButton"));
            //Thread.Sleep(2000);
            //SwitchToPopUps();
            //javascriptClick(By.XPath("//input[@value='SelectDirectory']"));
            //Thread.Sleep(2000);
            //SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.Id("archiveUser")).Click();
           javascriptClick(By.XPath(General.Default.SaveB));
           Thread.Sleep(2000);
           SwitchToContent();
            return true;
        }

        public void SearchCDR(String s)
        {
            SwitchToContent();
            typeDataName("archiveName",s);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
        }

        public Boolean EditCDR()
        {
            SwitchToContent();
            javascriptClick(By.XPath("//div[text()='AB Archive']"));
            Thread.Sleep(2000);
            SwitchToContent();
            typeDataID("archiveName", "AB Edited Archive");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }

      public Boolean DeleteCDR()
        {
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            return true;

        }
    }
}
