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
                if (true)
                {
                    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                    WaitForElementToVisible(By.XPath("//div[text()='Inventory Discovery']"));
                    Console.WriteLine("Navigation Successful");
                }
                else
                {
                    Console.WriteLine("Navigation Unsuccessful");

                }

                if (true)
                {
                    InventorySearch();
                    SwitchToContent();
                  //  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_SUMMARY");
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                    Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Verizon']")), "Search failed");
                    Console.WriteLine("Inventory Search Successfully");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Inventory Search failed");
                }

                if (true)
                {
                    AcceptInventory();
                    Console.WriteLine("Inventory Accepted Successfully");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Inventory Accept failed");            
                }


                Console.WriteLine("Inventory Discovery passed successfully");
       }

       public void InventorySearch()
       {
           SwitchToContent();
           typeDataName("inventoryType", "1");
           Thread.Sleep(4000);
           SwitchToContent();
           BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
           typeDataName("carrierId", "4");
           BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.QSubmitB)).Click();
           Thread.Sleep(5000);
       }

        public void AcceptInventory()
        {
            //[selectFrame | CONTENT | ]]
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='acceptButton']")).Click();
            Thread.Sleep(5000);
            SwitchToPopUps();
            SelectElement se = new SelectElement(FindElement(By.Name("targetInventoryTypeId")));
            se.SelectByText("OTHER");
            javascriptClick(By.Id("nextButton"));
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("nextButton")).Click();
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
           IWebElement ele= BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
           BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
      //   Assert.IsTrue(IsElementVisible(By.XPath("//td[text()='Accepted OTHER']")), "Accept failed");
         // BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
      //    BrowserDriver.Instance.Driver.SwitchTo().Frame("OTHER_GENERAL");
            javascriptClick(By.XPath(Inven.Default.CloseB));
            Thread.Sleep(4000);
           
            }


        public void IgnoreInventory()
        {
            SwitchToContent();

        }

        protected static Boolean SwitchWindow(string title)
        {
            var currentWindow = BrowserDriver.Instance.Driver.CurrentWindowHandle;
            var availableWindows = new List<string>(BrowserDriver.Instance.Driver.WindowHandles);

            foreach (string w in availableWindows)
            {
                if (w != currentWindow)
                {
                    BrowserDriver.Instance.Driver.SwitchTo().Window(w);
                    if (BrowserDriver.Instance.Driver.Title == title)
                        return true;
                    else
                    {
                        BrowserDriver.Instance.Driver.SwitchTo().Window(currentWindow);
                    }

                }
            }
            return false;
        }
    }
}
