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
    class InventoryAccrual: BaseActions
    {

        public void InventroyAccrualFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuBilling_AccrualInventory']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Inventory Accrual Rules']"));
                Console.WriteLine("Navigation Successful");
            }

            if(SaveInventoryAccural("2"))
            {
               
            Console.WriteLine("Inventory Accrual saved successfully");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.CloseB)).Click();
            Console.WriteLine("Admin --> Bill Management --> Inventory Accrual passed smoke test successfully");
            }


        }

        public Boolean SaveInventoryAccural(String a)
        {
            SwitchToPopUps();
            Thread.Sleep(2000);
            SelectfromDropdown("invAccrualConfig", a);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
            Thread.Sleep(2000);
            return true;

        }
    }
}
