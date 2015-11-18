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
    class ProductSpeed : BaseActions
    {
        public void ProductSpeedFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
            retryingFindClickk(".//*[@id='mnuProductSpeeds']");
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            if (true)
            {
                WaitForElementToVisible(By.XPath("//td[text()='Speed Maintenance']"));
                Console.WriteLine("Navigation Successful");
            }
            else 
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            if (true)
            {
                Thread.Sleep(2000);
                AddProductSpeed();
            }
            //if (true)
            //{
            //    Thread.Sleep(2000);
            //    DeleteSpeed();
            //}
            if (true)
            {
                javascriptClick(By.XPath(General.Default.CancelB));
                Console.WriteLine("Admin --> Inventory --> Product Speed Passed Smoke Test Successfully");
            }
            else
            {
                Console.WriteLine("Admin --> Inventory --> Product Speed Failed Smoke Test");
            }
        }

        public void AddProductSpeed()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
         //   WaitForElementToVisible(By.Name("speedDisplay"));
            SwitchToPopUps();
            typeDataName("speedDisplay", "1");
            typeDataName("speedKbps", "1");
            retryingFindClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(5000);
            SwitchToPopUps();
      //      WaitForElementToVisible(By.XPath("//div[text()='100K']"));
        //  javascriptClick(By.XPath("//div[text()='100K']"));
            if(true)
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='1']")), "Adding  Product speed failed");
                Console.WriteLine("Product Speed Added Successful");
            }
            else
            {
                Console.WriteLine("Unable to Add Product Speed");
            }


        }

        public void DeleteSpeed() {
           
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='1")), "Deletion of Product Speed failed");
            Console.WriteLine("Product Speed Deleted Successfully");

        }
    }
}
