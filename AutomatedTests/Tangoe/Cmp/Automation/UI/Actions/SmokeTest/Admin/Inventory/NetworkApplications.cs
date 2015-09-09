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


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Inventory
{
    class NetworkApplications : BaseActions
    {

        public void NetworkApplicationsFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
            retryingFindClickk(".//*[@id='mnuAdmin_NetworkApplications']");
            WaitForElementToVisible(By.XPath("//td[text()='Network Application']"));
            Console.WriteLine("Navigation Successful");
            Thread.Sleep(2000);

            AddNetwork();
            DeleteNetwork();
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
        Console.WriteLine("Network added Successfully");
        }

        public void DeleteNetwork() 
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()= 'AB10' ]"));
            Thread.Sleep(1000);
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AB10']")), "Delete Network Failed");
            Console.WriteLine("Network Deleted Successfully");
            javascriptClick(By.XPath(General.Default.CloseB));
  
        }
    }
}
