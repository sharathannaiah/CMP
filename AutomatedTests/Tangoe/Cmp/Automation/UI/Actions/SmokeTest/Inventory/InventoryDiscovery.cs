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
using AutomatedTests.CMP.Inventory;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Inventory
{
    class InventoryDiscovery :BaseActions
    {
       public void InventoryDiscoveryFunctionality()
            {

                GoToMain1("Inventory", "Inventory Discovery");
       }


        public void AcceptInventory()
        {
            //[selectFrame | CONTENT | ]]
            SwitchToContent();
            SelectfromDropdown("inventoryType", "1");
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.QSubmitB)).Click();
            Thread.Sleep(5000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            javascriptClick(By.CssSelector("input.multiSelectRow"));
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.AcceptB)).Click();
            Thread.Sleep(3000);
            SwitchToPopUps();
            javascriptClick(By.Id("nextButton"));
            Thread.Sleep(2000);
         //   SelectfromDropdown("flexibleMappingSource", "1");
            //((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('flexibleMappingSource')[1].selectedIndex='1';");
            //((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('flexibleMappingSource')[2].selectedIndex='1';");
            //((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('flexibleMappingSource')[3].selectedIndex='1';");
            javascriptClick(By.XPath(Inven.Default.DoneB));
            Thread.Sleep(7000);
            SwitchToPopUps();
            Assert.AreEqual("Accepted LINE", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_GENERAL");
           // BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@Name='phoneNumber']")).Clear();
           // typeDataName("phoneNumber", "7777777777");
            javascriptClick(By.XPath(Inven.Default.SaveB));
            Thread.Sleep(2000);
            javascriptClick(By.XPath(Inven.Default.CloseB));
            Thread.Sleep(4000);
        
            
            //   BrowserDriver.Instance.Driver.FindElement(By.Name("phoneNumber")).GetAttribute("ng-change");
         
            
            //navigate to inventory explorer and search for the accepted inventory 


            Console.WriteLine("Inventory Accepted Successfully");
            Thread.Sleep(2000);
            Console.WriteLine("Inventory Discovery passed successfully");
            }


        public void IgnoreInventory()
        {
            SwitchToContent();

        }
    }
}
