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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous
{
    class Carrier : BaseActions
    {
        public void CarrierSmokeFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            retryingFindClickk(".//*[@id='mnuAdmin_Carriers']");
            if (true)
                {
                    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                    WaitForElementToVisible(By.XPath("//td[text()='Carrier Maintenance']"));
                    Console.WriteLine("Navigation Successful");
                }
                else
                {
                    Console.WriteLine("Navigation Unsuccessful");

                }

            if (true)
            {
                CreateAddress();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='123']")), "Address not created");
                Console.WriteLine("Address Added to carrier successfully");
            }
            else
            {
                Console.WriteLine("Address not addded to carrier");
            }

            if (true)
            {
                EditCarrier();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ABcity']")), "Address not edited");
                Console.WriteLine("Address Edited to carrier successfully");

            }
            else 
            {
                Console.WriteLine("Address not edited to carrier");
            }

            if (true)
            {
                DeleteCarrier();
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ABcity']")), "Carrier not deleted");
                Console.WriteLine("Address deleted successfully");
                javascriptClick(By.XPath(General.Default.CloseB));

            }
            else
            {
                Console.WriteLine("Address not deleted successfully");
            
            }
            Console.WriteLine("Admin --> Miscellaneous --> Carrier passed smoke test successfully");
        }

            public void CreateAddress()
            {
                SwitchToPopUps();
                SelectfromDropdown("carrierIdSelect", "1");
                Thread.Sleep(3000);
                SwitchToPopUps();
                javascriptClick(By.XPath(General.Default.NewB));
                typeDataID("vendorNumber", "123");
                SelectfromDropdown("paymentTerm", "5");
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                
            }


            public void EditCarrier()
            {
                SwitchToPopUps();
                javascriptClick(By.XPath("//div[text()='123']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                typeDataID("street1", "ABcity");
                typeDataID("street2", "Automation Edited street");
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
            }


            public void DeleteCarrier()
            {
                SwitchToPopUps();
                javascriptClick(By.XPath("//div[text()='ABcity']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
                javascriptClick(By.XPath(General.Default.DeleteB));
               
            }
            }
        
    }

