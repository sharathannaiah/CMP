﻿using AutomatedTests.Tangoe.Cmp.Automation.Common;
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
    class ContractTerms : BaseActions
    {
        public void ContractTermsFunctions() 
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
            retryingFindClickk(".//*[@id='mnuContractTerms']");
            WaitForElementToVisible(By.XPath("//td[text()='Terms']"));
            Console.WriteLine("Navigation Successful");
            CreateTerms();
            DeleteTerms();
            if(true)
            {
                Console.WriteLine("Admin --> Contracts --> Contract Term passed smoke test Successfully");
            }
            else
            {
                Console.WriteLine("Contract terms smoke test failed");
            }

        }

        public void CreateTerms()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.NewB));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[1].value='AutomationTerms'");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[0].value='AutomationTerms'");
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.IsTrue(IsElementVisible(By.XPath("//td[text()='True/False']")), "Term creation Failed");
            Console.WriteLine("Terms Created Succesfully");
        }
        public void DeleteTerms()
        {

            SwitchToPopUps();
          //  ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[0].value='AutomationTerms'");
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(2000);
            Assert.IsTrue(IsElementVisible(By.XPath("//td[text()='True/False']")), "Contract Term Search Failed");
            Console.WriteLine("Contract Term Search Successful");
            javascriptClick(By.XPath("//td[text()='AutomationTerms']"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.DeleteB));
      ((IJavaScriptExecutor) BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            
       //     ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.alert = function() { return true; };" );
          //  Thread.Sleep(2000);
            SwitchToPopUps();
           Assert.IsFalse(IsElementVisible(By.XPath("//td[text()='Number']")), "Term Deletion Failed");
            Console.WriteLine("Delete Successfull");

        }

        


        }
    
}