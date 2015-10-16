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
    class VoiceProduct : BaseActions
    {

        public void VoiceProductFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuVoiceProducts']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Voice Products']"));
                Assert.AreEqual("Voice Products", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
                Console.WriteLine("Navigation successful");
            }

            if (CreateVoiceProduct() == true)
            {
                Thread.Sleep(2000);
           //     SearchVoiceProduct("Conferencing", "Audio", "Data");
                Assert.AreEqual("Conferencing", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title='Conferencing']")));
                Assert.IsTrue(IsElementVisible(By.CssSelector("div[title='Conferencing']")), "Voice Product creation failed");
                Console.WriteLine("Voice Product Creation successful");
            }


            if (EditVoiceProduct() == true)
            {
                Assert.AreEqual("International", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[text()='International']")));
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='International']")), "Voice Product edition failed");
                Console.WriteLine("Voice Product edition successful");
            }

            if (DeleteVoiceProduct() == true)
            {
                Assert.False(IsElementVisible(By.XPath("//div[text()='International']")), "Voice Product deletion failed");
                Console.WriteLine("Voice Product Deletion successful");
            }
            
        }

        public Boolean CreateVoiceProduct()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("productCategoryCode"))).SelectByIndex(1);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("productTypeCode"))).SelectByIndex(1);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("voiceProductServiceCode"))).SelectByIndex(1);
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

        public void SearchVoiceProduct(String Productcat, String Producttype, String ProductService)
        {
            Thread.Sleep(2000);
            SwitchToPopUps();
           
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('queryVoiceCat').selectedText='"+Productcat+"'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('queryVoiceType').selectedText='" + Productcat + "'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('queryVoiceServ').selectedText='" + Productcat + "'");
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("queryVoiceType"))).SelectByText(Producttype);
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("queryVoiceServ"))).SelectByText(ProductService);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
        }

        public Boolean EditVoiceProduct()
        {
            SwitchToPopUps();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("productCategoryCode"))).SelectByText("International");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(5000);
            SwitchToPopUps();
         //   SearchVoiceProduct("International", "Audio", "Data");
            return true;
        }

        public Boolean DeleteVoiceProduct()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            SearchVoiceProduct("International", "Audio", "Data");
            return true;
        }
    }
}