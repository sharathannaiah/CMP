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


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Inventory
{
    class NetworkApplications : BaseActions
    {

        public void NetworkApplicationsFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
            retryingFindClickk(".//*[@id='mnuAdmin_NetworkApplications']");
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            if (true)
            {
                WaitForElementToVisible(By.XPath("//td[text()='Network Application']"));
                Console.WriteLine("Navigation Successful");
            }
            else 
            {
                Console.WriteLine("Naviagtion failed");
            }
            Thread.Sleep(2000);
            
            if (true)
            {
                AddNetwork();
                Console.WriteLine("Network added Successfully");
            }
            else
            {
                Console.WriteLine("Network not added successfully");
            }
           
            if (true)
            {
                EditNetwork();
                Console.WriteLine("Network Edited Successfully");
            }

            if (true)
            {
                DeleteNetwork();
                Console.WriteLine("Network deleted Successfully");
            }
            else
            {
                Console.WriteLine("Network deletion  failed");
            
            }
            if (true)
            {
                Console.WriteLine("Network Applictions passed smoke test successfully");
            }
            else
            {
                Console.WriteLine("Network Applictions failed smoke test");
            }
        }
        public void AddNetwork() 
        {
        SwitchToPopUps();
        javascriptClick(By.XPath(General.Default.NewB));
        typeDataName("newApplicationID", "AB10");
        typeDataName("applicationName", "Automation");
        typeDataName("applicationDescription", "Automation Network");
        javascriptClick(By.XPath(General.Default.SaveB));
        Thread.Sleep(2000);
        BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB10']")), "Add Network Failed");
        }


        public void EditNetwork()
        {
            SwitchToPopUps();
            typeDataName("applicationDescription", "Edited Automation Network");
            javascriptClick(By.XPath(General.Default.SaveB));
         //   WaitForElement(By.Id("dWnd1title"));
            Thread.Sleep(7000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Edited Automation Network']")), "Edit Network Failed");
        }


        public void DeleteNetwork() 
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()= 'AB10' ]"));
            Thread.Sleep(1000);
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AB10']")), "Delete Network Failed");
            javascriptClick(By.XPath(General.Default.CloseB));
  
        }
    }
}
