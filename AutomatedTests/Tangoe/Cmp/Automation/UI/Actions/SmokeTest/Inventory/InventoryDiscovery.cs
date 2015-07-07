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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Inventory
{
    class InventoryDiscovery :BaseActions
    {
       public void InventoryDiscoveryy()
            {
                GoToMain("Inventory");
                retryingFindClickk(".//*[@id='mnuInventory_DiscoverInventory']");
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | CONTENT | ]]
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("inventoryType"))).SelectByText("Phone Numbers");
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
                BrowserDriver.Instance.Driver.FindElement(By.Name("queryLinesbutton")).Click();
                Thread.Sleep(3000);

                
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                BrowserDriver.Instance.Driver.FindElement(By.Id("acceptButton")).Click();
                Thread.Sleep(3000);

                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                BrowserDriver.Instance.Driver.FindElement(By.Id("nextButton")).Click();
                Thread.Sleep(2000);
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("flexibleMappingSource"))).SelectByText("Account");
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath("(//select[@name='flexibleMappingSource'])[2]"))).SelectByText("Account");
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath("(//select[@name='flexibleMappingSource'])[3]"))).SelectByText("Account");
                BrowserDriver.Instance.Driver.FindElement(By.Id("nextButton")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                Assert.AreEqual("Accepted LINE", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
                Console.WriteLine("Inventory Accepted Successfully");
                BrowserDriver.Instance.Driver.FindElement(By.Id("closeButton")).Click();
                Thread.Sleep(2000);
                Console.WriteLine("Inventory Discovery passed successfully");
            }

    }
}
