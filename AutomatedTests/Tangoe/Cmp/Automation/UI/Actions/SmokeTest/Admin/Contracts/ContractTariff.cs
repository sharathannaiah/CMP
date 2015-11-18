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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Contracts
{
    class ContractTariff : BaseActions
    {
        public void ContractTariffFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
            retryingFindClickk(".//*[@id='mnuContracts_TariffAdmin']");
            WaitForElementToVisible(By.XPath("//td[text()='Tariff']"));
            if (true)
            {
                Console.WriteLine("Admin --> Contracts--> Tariff Navigation Succesfull ");
            }
            else
            {
                Console.WriteLine("Admin --> Contracts--> Tariff Navigation Unsuccessful");
            }

            if (true)
            {
                CreateTariff();
                Console.WriteLine("Tariff Created Successfully");
            }
            else
            {
                Console.WriteLine("Tariff Creation failed");
            }

            if (true)
            {
                EditTariff();
                Console.WriteLine("Tariff Edited Successfully");
            }
            else
            {
                Console.WriteLine("Tariff Edition failed");
            }

            if (true)
            {
               DeleteTariff();
               SwitchToPopUps();
               Assert.IsFalse(IsElementVisible(By.XPath("'//div[text()='AB Contract']")), "Contract Tariff Search Failed");
               Console.WriteLine("Tariff Deleted Successfully");
               Console.WriteLine("Contract Tariff passed smoke test successfully");

            }
            else
            {
           //     Console.WriteLine("Tariff Deletion failed");
            }
            
        }

        public void CreateTariff()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.NewB));
            WaitForElementToVisible(By.Id("carrierId"));
            Thread.Sleep(2000);
        //    ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carriedId')[1].value='AT&T'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierId')[1].selectedIndex = 3;");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[1].value='AB Tariff'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('url')[1].value='www.tangoeautomatiom.com'");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(4000);
            SwitchToPopUps();
        //    SearchTariff("nameField", "AB Tariff");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AT&T']")), "Contract Tariff Search Failed");
            Console.WriteLine("Contract Tariff Search successful");
       //     Console.WriteLine("Contract Tariff Created Successfully");
        
            
        }

        public void SearchTariff(String field, String data)
        {
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('" + field + "')[0].value='" + data + "'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('" + field + "')[0].value='" + data + "'");
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
        }
        
        public void EditTariff()
        {
            SwitchToPopUps();
         //   SearchTariff("nameField","AB Tariff" );
           // BrowserDriver.Instance.Driver.FindElement(By.Name("nameField")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tariffFormDV']/fieldset/table/tbody/tr[2]/td[2]/input")).Clear();
         //   BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tariffFormDV']/fieldset/table/tbody/tr[2]/td[2]/input")).
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[1].value='AB Contract'");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(4000);
            SwitchToPopUps();
           IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.Id("nameField"));
            ele.SendKeys("AB Contract");
            typeDataID("nameField", "AB Contract");
            Thread.Sleep(2000);
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(3000);
            SwitchToPopUps();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB Contract']")), "Contract Tariff Search Failed");
        }

        public void DeleteTariff()
        {
            SwitchToPopUps();
            //SearchTariff("nameField", "AB Contract");
            javascriptClick(By.XPath("//div[text()='AB Contract']"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
        }
            public void Send(String longstring)
            {
            IWebElement inputField = BrowserDriver.Instance.Driver.FindElement(By.Name("frm_AFN"));

            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("arguments[0].setAttribute('value', '" + longstring + "')", inputField);

            }
        }
    }

