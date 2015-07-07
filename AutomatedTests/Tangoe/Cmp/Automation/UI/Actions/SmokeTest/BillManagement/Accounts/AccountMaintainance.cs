using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement.Accounts
{
    class AccountMaintainance: BaseActions
    {
        public void createAccount()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BMAccounts']"); 
            retryingFindClickk(".//*[@id='mnuBilling_AccountMaintenance']");
            Thread.Sleep(2000);

           // BrowserDriver.Instance.Driver.FindElement(By.Id("mnuBilling_AccountMaintenance")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                           // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | CONTENT | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("newAccountButton1")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=GENERAL | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");

            BrowserDriver.Instance.Driver.FindElement(By.Id("genTabAcctNum")).Clear();
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("genTabAcctNum")).SendKeys("" + random);

            BrowserDriver.Instance.Driver.FindElement(By.Name("accountName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("accountName")).SendKeys("Account1");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("carrierId"))).SelectByText("AT&T");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("saveAccountButton")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
           
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            WaitForElementToVisible(By.Id("tabSubAccounts"));

            retryingFindClick(By.XPath(".//*[@id='tabSubAccounts']"));
            Thread.Sleep(3000);

            
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SUBACCOUNTS");
        

            BrowserDriver.Instance.Driver.FindElement(By.Id("add")).Click();
            Thread.Sleep(2000);


            //  [selectWindow ]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Name("queryCostCentersButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=SUBACCOUNTS | ]]

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SUBACCOUNTS");


            Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Text);
            Console.WriteLine("Sub Account Added Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Id("subAccountsRemove")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SUBACCOUNTS");
            Assert.AreNotEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Text);
            Console.WriteLine("Sub Account Deleted successfully");

            //Contracts Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabContracts")).Click();
            Thread.Sleep(2000);

            // Switch to contract frame
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTRACTS");

            BrowserDriver.Instance.Driver.FindElement(By.Id("addContract")).Click();
            Thread.Sleep(2000);


            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryNegotiatedContractsButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();

            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            
            // Switch back to contract frame
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTRACTS");
           //BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Click();
            Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Text);
            Console.WriteLine("Contract Added Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Id("removeContract")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreNotEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Text);
            Console.WriteLine("Contracts removed successfully");
         
            
            
            //Entity Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");

            BrowserDriver.Instance.Driver.FindElement(By.Id("tabEntity")).Click();
            Thread.Sleep(2000);
            
            //Switch to entity frame
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ENTITY");
            BrowserDriver.Instance.Driver.FindElement(By.Id("addEntity")).Click();
            Thread.Sleep(2000);


            //switch to pop up frame
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Name("queryEntityButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);


            // Switch back to entity frame
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ENTITY");
            Assert.AreEqual("ACS", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='ACS']")).Text);
            Console.WriteLine("Entity Created Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Id("removeEntity")).Click();
            Assert.AreEqual("ACS", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='ACS']")).Text);

            //Cost Center
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabAllocation")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=COST_CENTER | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTER");
            
            BrowserDriver.Instance.Driver.FindElement(By.Id("add")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryCostCentersButton")).Click();
            Thread.Sleep(2000);

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).Click();
            Thread.Sleep(2000);

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=COST_CENTER | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTER");
            BrowserDriver.Instance.Driver.FindElement(By.Name("saveCostCenterButton")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTER");
            Assert.AreEqual("100%", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='100%']")).Text);
           
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=COST_CENTER | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("remove")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTENT | ]]


            //Charges Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT"); 
            BrowserDriver.Instance.Driver.FindElement(By.Id("tabCharges")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CHARGES | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CHARGES"); 

            BrowserDriver.Instance.Driver.FindElement(By.Id("add")).Click();

            BrowserDriver.Instance.Driver.FindElement(By.Id("description")).Clear();
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("recurringFrequency"))).SelectByText("Monthly");
            BrowserDriver.Instance.Driver.FindElement(By.Id("amount")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("amount")).SendKeys("100");
            BrowserDriver.Instance.Driver.FindElement(By.Id("add")).Click();
            Thread.Sleep(2000);
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();



            BrowserDriver.Instance.Driver.FindElement(By.Id("save")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CHARGES"); 
            Assert.AreEqual("sharath", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.= 'sharath']")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CHARGES | ]]
           BrowserDriver.Instance.Driver.FindElement(By.Id("removeButton")).Click();
           Console.WriteLine("Charges deleted sucessfully");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
        
            //Delete Account
            BrowserDriver.Instance.Driver.FindElement(By.Id("deleteAccountButton1")).Click();
            IAlert alert1 = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert1.Accept();

            Console.WriteLine("Account Maintainance passed successfully");

        }
    }
}
