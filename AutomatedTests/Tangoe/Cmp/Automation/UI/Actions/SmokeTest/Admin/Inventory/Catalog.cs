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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Inventory
{
    class Catalog : BaseActions
    {
        public void CatalogFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
            retryingFindClickk(".//*[@id='mnuAdmin_DeviceCatalog']");
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            WaitForElementToVisible(By.XPath("//div[text()='Catalog']"));
            if (true)
            {
                Console.WriteLine("Admin --> Inventory--> Catalog Navigation Succesfull ");
            }
            else
            {
                Console.WriteLine("Admin --> Inventory--> Catalog Navigation Unsuccessful");
            }
            if (true)
            {
                CreateCatalog();
                Console.WriteLine("Catalog Created Successfully");
            }
            else
            {
                Console.WriteLine("Catalog Creation  failed");
            }
            if (true)
            {
                DeleteCatalog();
                Console.WriteLine("Catalog Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Catalog   Deletion  failed");
            }

            if (true)
            {
                Console.WriteLine("Inventory --> Catalog passed smoke test successfully");
            }
        }

        public void CreateCatalog()
        { 
           Thread.Sleep(3000);
           WaitForElementToVisible(By.XPath("//div[text()='Catalog']"));
           SwitchToContent();
           BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_DEVICE_DETAILS");
           BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
           SwitchToContent();
           BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_DEVICE_DETAILS");
           typeDataID("catalogItemName", "ABCD12345");
           SelectfromDropdown("manufacturerLookupId", "1");
           SelectfromDropdown("inventoryTypeId", "7");
           javascriptClick(By.XPath(General.Default.SaveB));
           Thread.Sleep(2000);
          // SearchCatalog();
        //   Console.WriteLine("Catlog Search Successful");
         //  Thread.Sleep(2000);
           SwitchToContent();
           BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_DEVICE_DETAILS");
           Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABCD12345']")), "Create Catalog Failed");
        }
       
       
        public void DeleteCatalog()
        {
            Thread.Sleep(2000);
          //  SearchCatalog();
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_DEVICE_DETAILS");
            javascriptClick(By.XPath("//input[@class='multiSelectRow']"));
         //   ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(General.Default.RemoveB));
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_DEVICE_DETAILS");
            Thread.Sleep(2000);
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ABCD12345")), "Deletion of Catalog Failed");


        }

        public void SearchCatalog()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_QUERY_FRAME");
            typeDataID("name", "ABCD12345");
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_QUERY_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Name("getDeviceCatalogItems[1]")).Click();
        //    javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(4000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_DEVICE_DETAILS");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABCD12345")), "Search of Catalog Failed");
            Thread.Sleep(3000);
        }
    }
}
