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
    class StandardBillImport : BaseActions
    {

        public void StandardBillImportFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuSbiChargeTypes']");
            if (true)
            {
                    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                    WaitForElementToVisible(By.XPath("//div[text()='Standard Bill Import - Charge Types']"));
                    Console.WriteLine("Navigation successful");
            }

            if (CreateChargeType() == true)
            {
                SearchChargeType("AutomationCharges");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AutomationCharges']")), "Bill Import Charge Type creation failed");
                Console.WriteLine("Bill Import charge type created successfully");
            }


            if (EditChargeType() == true)
            {
              //  SearchChargeType("EditedAutomationCharges");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='EditedAutomationCharges']")), " Charge Type Edition failed");
                Console.WriteLine("Bill Import Charge Type edited successfully");
                Console.WriteLine("Admin --> Bill Management --> Standard Bill Import passed smoke test successfully");

            }

            //if (DeleteChargeType() == true)
            //{
            //    Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='EditedAutomationCharges']")), " Bill Import Charge Type Deletion failed");
            //    Console.WriteLine("Bill Import Charge Type deleted successfully");
            //    Console.WriteLine("Admin --> Bill Management --> Standard Bill Import passed smoke test successfully");
            //}
        }

        public Boolean CreateChargeType()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('chargeTypeName')[1].value='AutomationCharges'");
           // new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath("//select[@name='amountBucket'])[2]"))).SelectByIndex = "1";
            IWebElement dropDownListBox = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div#detailFormDV select"));
            SelectElement clickThis = new SelectElement(dropDownListBox);
            clickThis.SelectByText("Access");
            IWebElement dropDownListBox1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div#detailFormDV select[name='amountBucket']"));
            SelectElement clickThis1 = new SelectElement(dropDownListBox1);
            clickThis1.SelectByText("Discount");
            Thread.Sleep(2000);
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }

        public void SearchChargeType(String Search)
        {
            Thread.Sleep(2000);
            SwitchToContent();
            typeDataName("chargeTypeName", Search);
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.ResetB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='" + Search + "']")), "Charge Type Search successful");
            Console.WriteLine("Bill Import Charge Type search successful"); 
        }

        public Boolean EditChargeType()
        {
            SwitchToContent();
            javascriptClick(By.XPath("//div[text()='AutomationCharges']"));
            Thread.Sleep(2000);
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('chargeTypeName')[1].value='EditedAutomationCharges'");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div#detailFormDV select"))).SelectByText("Misc");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }

        public Boolean DeleteChargeType()
        {
           // javascriptClick(By.XPath("//div[text()='EditedAutomationCharges']"));
            Thread.Sleep(2000);
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }
    }
}
