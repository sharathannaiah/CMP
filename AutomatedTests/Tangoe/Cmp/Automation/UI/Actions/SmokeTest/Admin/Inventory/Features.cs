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
    class Features : BaseActions
    {
        public void FeaturesFunctionality()
        {
            if (true)
            {
                GoToMain("Admin");
                retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
                retryingFindClickk(".//*[@id='mnuAdmin_Features']");
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                if (true)
                {
                    WaitForElementToVisible(By.XPath("//td[text()='Feature Maintenance']"));
                    Console.WriteLine("Navigation Successful");
                }
                else
                {
                    Console.WriteLine("Navigation Unsuccessful");
                }

                Thread.Sleep(2000);
                if (true)
                {
                    CreateNewFeature();
                }
                if (true)
                {
                    CopyFeatures();
                }
                if (true)
                {
                    DeleteFeatures();
                    javascriptClick(By.XPath(General.Default.CloseB));
                    Console.WriteLine("Admin --> Inventory --> Features passed Smoke Test successfully");
                }

                else
                {
                    Console.WriteLine("Admin --> Inventory --> Features passed Smoke Test successfully");
                }
            }
        }
        public void CreateNewFeature()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.NewB));
            WaitForElementToVisible(By.Id("inventoryTypeId"));
            SelectfromDropdown("inventoryTypeId", "2");
            SelectfromDropdown("invFeatCategory", "1");
            typeDataID("invFeatName", "AB Automation");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            javascriptClick(By.XPath("//div[text()='AB Automation']"));
            if (true)
            {
                WaitForElementToVisible(By.XPath("//div[text()='AB Automation']"));
                Console.WriteLine("Feature Creation Successful");
            }
            else
            {
                Console.WriteLine("Feature Creation Failed");
            }

        }

        public void CopyFeatures()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.CopyB));
            WaitForElementToVisible(By.Id("inventoryTypeId"));
            javascriptClick(By.XPath(General.Default.SaveB));
             Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            javascriptClick(By.XPath("//div[text()='Copy of AB Automation']"));
            if (true)
            {
                WaitForElementToVisible(By.XPath("//div[text()='Copy of AB Automation']"));
                Console.WriteLine("Feature Copy Successful");
            }
            else
            {
                Console.WriteLine("Feature Copy Failed");
            }


        }
        public void DeleteFeatures()
        {
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='AB Automation']"));
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='AB Automation']")), "Deletion of features failed");
            Console.WriteLine("Feature Deletion Successful");
            javascriptClick(By.XPath("//div[text()='Copy of AB Automation']"));
            javascriptClick(By.XPath(General.Default.DeleteB));
          
        }


    }
}
