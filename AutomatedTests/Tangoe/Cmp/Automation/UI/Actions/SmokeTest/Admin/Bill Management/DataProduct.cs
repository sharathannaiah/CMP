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
    class DataProduct : BaseActions
    {
         public void DataProductFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuDataProducts']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Data Products']"));
                Assert.AreEqual("Data Products", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
                Console.WriteLine("Navigation successful");
            }

            if (CreateDataProduct() == true)
            {
                Thread.Sleep(3000);
                SwitchToPopUps();
                //SearchDataProduct("ATM - Domestic", "Bundled Port");
              //  Assert.AreEqual("Conferencing", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[text()='Conferencing']")));
                Assert.IsTrue(IsElementVisible(By.XPath("//div[.='ATM - Domestic']")), "Voice Product creation failed");
                Console.WriteLine("Data Product Creation successful");
            }


            if (EditDataProduct() == true)
            {
                Thread.Sleep(3000);
                SwitchToPopUps();
                //IWebElement dropDownListBox = BrowserDriver.Instance.Driver.FindElement(By.Id("queryDataCat"));
                //SelectElement clickThis = new SelectElement(dropDownListBox);
                //clickThis.SelectByIndex(1); 

               
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Edited Data Product']")), "Data Product edition failed");
                Console.WriteLine("Data Product edition successful");
          //      javascriptClick(By.XPath(General.Default.CloseB));

            }

            if (DeleteDataProduct() == true)
            {
                SwitchToPopUps();
                IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.Id("queryDataCat"));
                ele.SendKeys("ATM - Domestic");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                Thread.Sleep(3000);
                Console.WriteLine("Data Product Search successful");
                SwitchToPopUps();
                Assert.False(IsElementVisible(By.XPath("//div[text()='Conferencing']")), "Voice Product deletion failed");
                Console.WriteLine("Voice Product Deletion successful");
                Thread.Sleep(2000);
               
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Admin --> Bill Management --> Data Product  passed Smoke Test sucessfully");
            }
            
        }

        public Boolean CreateDataProduct()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("productCategoryCode"))).SelectByIndex(1);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("productSubCategoryCode"))).SelectByIndex(1);
        //    ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(5000);
            //SwitchToPopUps();
            Thread.Sleep(2000);
            IAlert ele = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            ele.Accept();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Name("frm_AX")).Click();
            Thread.Sleep(2000);
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(5000);
            SwitchToPopUps();
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='queryVoiceCat']"))).SelectByIndex(1);
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='queryVoiceType']"))).SelectByIndex(1);
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='queryVoiceServ']"))).SelectByIndex(1);
            //javascriptClick(By.XPath(General.Default.SubmitB));
           // Thread.Sleep(4000);
            //SwitchToPopUps();
            return true;
        }

        public Boolean EditDataProduct()
        {
            SwitchToPopUps();
            javascriptClick(By.Id("tab1"));
            typeDataName("description", "Edited Data Product");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(5000);
            SwitchToPopUps();
            return true;
        }

        public Boolean DeleteDataProduct()
        {
            SwitchToPopUps();
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm =function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            return true;
        }
    }
}
  
