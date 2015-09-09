using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using AutomatedTests.CMP.Contracts;
namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Contracts
{
    class ContractsExplorer :BaseActions
    {
        public void ContractSmokeFunctionality()
        {
            GoToMain1("Contracts", "Explorer");
         //   ContractSearch();
         //   CreateContract();
         //   CopyContract();
            DeleteContract();

        }


        public void ContractSearch()
        {
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierId')[0].value='AT&T'");
            javascriptClick(By.XPath(Contra.Default.QuerySubmitB));
            Thread.Sleep(4000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='AT&T']")), "Contract Search failed"); 
            Console.WriteLine("Contract Search Successful");
        }

            public void CreateContract()
            {
                SwitchToContent();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(Contra.Default.CreateNewB)).Click();
                Thread.Sleep(3000);
                SwitchToPopUps();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierId')[0].selectedIndex = 6;");
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('contractTypeId')[0].selectedIndex = 2;");
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('contractNumber')[0].value='12345'");
                javascriptClick(By.XPath(Contra.Default.OKB));
                Thread.Sleep(5000);
                SwitchToContent();
               // BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTRACT_DETAIL");
                
         //       Assert.AreEqual("12345", BrowserDriver.Instance.Driver.FindElement(By.Name("contractNumber")).Text);
                //Assert.IsTrue(IsElementVisible(By.Id("contractNumber']")), "Contract Creation failed");
                BrowserDriver.Instance.Driver.FindElement(By.LinkText("< Contract List")).Click();
                Thread.Sleep(2000);
                
                SwitchToContent();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierContractNumber')[0].value='12345'");
                javascriptClick(By.XPath(Contra.Default.QuerySubmitB));
                SwitchToContent();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[.='12345']")), "Contract Search failed");
                Console.WriteLine("Contract Created successfully"); 

            }

            public void CopyContract()
            {
                SwitchToContent();
                javascriptClick(By.XPath("//div[.='12345']"));
                Thread.Sleep(1000);
                BrowserDriver.Instance.Driver.FindElement(By.XPath(Contra.Default.CopyB)).Click();
                Thread.Sleep(2000);
                SwitchToPopUps();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('nameField').value='NewContract'");
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('contractNumber').value='567890'");
                javascriptClick(By.Name("contractCopyAddendumsFlag"));
                javascriptClick(By.XPath(Contra.Default.OKB));
                Thread.Sleep(3000);
                SwitchToContent();
                BrowserDriver.Instance.Driver.FindElement(By.LinkText("< Contract List")).Click();
                Thread.Sleep(2000);

                SwitchToContent();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierContractNumber')[0].value='567890'");
                javascriptClick(By.XPath(Contra.Default.QuerySubmitB));
                SwitchToContent();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[.='567890']")), "Copy Contract failed");
                Console.WriteLine("Contract Copied successfully"); 

            }


        public void DeleteContract()
        {
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierContractNumber')[0].value='567890'");
            javascriptClick(By.XPath(Contra.Default.QuerySubmitB));
            Thread.Sleep(2000);
            SwitchToContent();

            javascriptClick(By.XPath("//div[.='567890']"));
           
            Thread.Sleep(5000);
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.prompt = function(msg) { return true; };");

            javascriptClick(By.XPath(Contra.Default.DeleteB));

            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='567890']")), "Deletion of Contract failed");
            Console.WriteLine("Contract Deleted successfully");


        }
    }
}
