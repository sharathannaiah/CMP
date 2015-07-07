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
    class InventoryExplorer :BaseActions
    {
        public void Inventory()
        {
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            GoToMain("Inventory");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='menuMainInventory']")).Click();
            retryingFindClickk(".//*[@id='mnuInventory_ExplorerServices']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("inventoryType"))).SelectByText("Lines");
            Thread.Sleep(8000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("new")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_GENERAL");
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("phoneNumber")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("phoneNumber")).SendKeys("" + random);
            BrowserDriver.Instance.Driver.FindElement(By.Name("saveLineButton")).SendKeys(Keys.Enter);
            Thread.Sleep(4000);

            //   //Inventory Alias Tab
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //   BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab11']")).Click();
            //   Thread.Sleep(2000);
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALIAS");
            //   BrowserDriver.Instance.Driver.FindElement(By.Id("addAliasButton")).Click();
            //   Thread.Sleep(3000);
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
            //   BrowserDriver.Instance.Driver.FindElement(By.Name("phoneNumberPattern")).SendKeys("123");
            //   BrowserDriver.Instance.Driver.FindElement(By.Name("queryLinesbutton")).SendKeys(Keys.Enter);
            //   Thread.Sleep(5000);
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_TABLE_FRAME");
            ////   BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Click();
            //  // retryingFindClickk("//div[.='Verizon']");
            //   BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[text()='Verizon']")).Click();

            //   BrowserDriver.Instance.Driver.FindElement(By.Id("okButton")).SendKeys(Keys.Enter);
            //   Thread.Sleep(2000);
            //   IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            //   alert.Accept();
            //   Thread.Sleep(4000);
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALIAS");
            //   Assert.AreEqual("LINE", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='LINE']")).Text);
            //   Console.WriteLine("Alias Added successfully");
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALIAS");
            //   BrowserDriver.Instance.Driver.FindElement(By.Id("removeAliasButton")).Click();
            //   Thread.Sleep(2000);
            //   IAlert alert3 = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            //   alert3.Accept();
            //   Thread.Sleep(2000);
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALIAS");
            //   Assert.AreNotEqual("LINE", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Text);
            //   Console.WriteLine("Alias Removed Successfully");

            ////SPID Tab
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab9']")).Click();
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("addSpid")).Click();
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //    // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            //BrowserDriver.Instance.Driver.FindElement(By.Name("spidText")).Clear();
            //BrowserDriver.Instance.Driver.FindElement(By.Name("spidText")).SendKeys("12345");

            //BrowserDriver.Instance.Driver.FindElement(By.ClassName("btnCMP")).Click();
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");

            //Assert.IsTrue(IsElementVisible(By.XPath("//div[.='12345']")), "SPID addition failed");
            //Console.WriteLine("SPID Added Successfully");

            //BrowserDriver.Instance.Driver.FindElement(By.Id("editSpid")).Click();
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            //BrowserDriver.Instance.Driver.FindElement(By.Name("spidText")).Clear();
            //BrowserDriver.Instance.Driver.FindElement(By.Name("spidText")).SendKeys("123456");
            //BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.btnCMP")).SendKeys(Keys.Enter);
            //Thread.Sleep(2000);
            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_SPID | ]]
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");
            //Assert.IsTrue(IsElementVisible(By.XPath("//div[.='123456']")), "SPID modification failed");
            //Console.WriteLine("SPID Modification Successful");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("deleteSpid")).Click();
            //Thread.Sleep(2000);
            //IAlert alert1 = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            //alert1.Accept();
            //Assert.AreNotEqual("LINE", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Text);
            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            //Console.WriteLine("SPID Deletion Successful");

            //   //TollFree Number
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //   BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab3']")).Click();
            //   BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            //   // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_TFN | ]]
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_TFN");
            //   WaitForElement(By.XPath(".//*[@id='add']"));
            //   BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='add']")).Click();
            //   BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            //   // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //   BrowserDriver.Instance.Driver.FindElement(By.Name("queryLinesbutton")).Click();
            // //  BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
            //   Thread.Sleep(2000);
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //   BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            //   BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
            //   // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_TFN | ]]
            //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_TFN");
            ////   BrowserDriver.Instance.Driver.FindElement(By.XPath("div[title=\"8665344651\"]")).Click();
            //   Assert.AreEqual("8665344651", (BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='8665344651']")) ).Text);

            ////   Assert.IsTrue(IsElementPresent(By.CssSelector("td[title=\"8665344651\"]")),"Addition of TollFree Number failed");
            //   Console.WriteLine("Addition of TollFree Number Successful");

            //   BrowserDriver.Instance.Driver.FindElement(By.Id("btnRemove")).Click();
            //   BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            //   Assert.AreNotEqual("LINE", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Text);
            //   Console.WriteLine("Deletion of TollFree Number Successful");
            //   BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));



            ////Charges NC Tab
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab4']")).Click();
            //BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_CHARGES | ]]
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");
            //BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            //BrowserDriver.Instance.Driver.FindElement(By.Id("addNC")).Click();
            //BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            //BrowserDriver.Instance.Driver.FindElement(By.Name("nonconDescription")).Clear();
            //BrowserDriver.Instance.Driver.FindElement(By.Name("nonconDescription")).SendKeys("777");
            //BrowserDriver.Instance.Driver.FindElement(By.Name("nonconUSOC")).Clear();
            //BrowserDriver.Instance.Driver.FindElement(By.Name("nonconUSOC")).SendKeys("555");
            //BrowserDriver.Instance.Driver.FindElement(By.Name("nonconAmount")).Clear();
            //BrowserDriver.Instance.Driver.FindElement(By.Name("nonconAmount")).SendKeys("999");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tfAdvFeatFormDV']/div/input[1]")).SendKeys(Keys.Enter);
            //Thread.Sleep(3000);

            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_CHARGES | ]]
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");

            //Assert.AreEqual("777", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='777']")).Text);
            //Console.WriteLine("Charges/Features Added Successfully");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("edit")).Click();
            //Thread.Sleep(2000);

            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            //BrowserDriver.Instance.Driver.FindElement(By.Name("nonconDescription")).Clear();
            //BrowserDriver.Instance.Driver.FindElement(By.Name("nonconDescription")).SendKeys("7777");
            //BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.btnCMP")).Click();
            //Thread.Sleep(2000);

            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_CHARGES | ]]
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");
            //Assert.AreEqual("7777", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='7777']")).Text);
            //Console.WriteLine("Edit for Charges/features successful");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("remove")).Click();
            //Assert.AreNotEqual("LINE", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Text);
            //Console.WriteLine("Deletion of Charges Successful");


            //Attribute Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab5']")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_ATT | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ATT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlextAttributeDate")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.date));
            BrowserDriver.Instance.Driver.FindElement(By.Id("eaSaveButton")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            // [selectFrame | CONTENT | ]]
            // [selectFrame | INVENTORY_EXPLORER | ]]
            //[selectFrame | LINE_ATT | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ATT");
            Assert.AreEqual("2015-07-07", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='2015-07-07']")).Text);
            Console.WriteLine("Attribute Value date added successfully");

            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlextAttributeDate")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlextAttributeDate")).SendKeys("09/09/2015");
            BrowserDriver.Instance.Driver.FindElement(By.Id("eaSaveButton")).Click();
            Thread.Sleep(2000);

            Assert.AreEqual("2015-09-09", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.= '2015-09-09']")).Text);
            Console.WriteLine("Date Edited Successfully");
            Thread.Sleep(2000);

            //Employee Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab7']")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
            BrowserDriver.Instance.Driver.FindElement(By.Id("addButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupemployeeId")).Click();
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryQueryEmployeesButton")).Click();
            Thread.Sleep(3000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControleffectiveDate")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControleffectiveDate")).SendKeys("07/07/2015");
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlexpirationDate")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlexpirationDate")).SendKeys("09/09/2019");
            BrowserDriver.Instance.Driver.FindElement(By.Id("okButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_EMPLOYEES | ]]

            Assert.AreEqual("9/9/19", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"9/9/19\"]")).Text);

            BrowserDriver.Instance.Driver.FindElement(By.Id("modifyButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControleffectiveDate")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControleffectiveDate")).SendKeys("05/05/2015");
            BrowserDriver.Instance.Driver.FindElement(By.Id("okButton")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_EMPLOYEES | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
            Assert.AreEqual("5/5/15", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"5/5/15\"]")).Text);
            Console.WriteLine("Employee Details Edited Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Id("deleteButton")).Click();
            Thread.Sleep(2000);
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            Console.WriteLine("Deletion of Employee Successful");
            Thread.Sleep(2000);

            //Allocation Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab6']")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("add")).Click();
            Thread.Sleep(2000);

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryCostCentersButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=INVENTORY_EXPLORER_COST_CENTER | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");

            BrowserDriver.Instance.Driver.FindElement(By.Id("saveCostCenterButton")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Cost Center Added Successfully");

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");

            BrowserDriver.Instance.Driver.FindElement(By.Name("expenseCode")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("expenseCode")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.Id("saveExpenseCodeBtn")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("remove")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Cost Center Deleted Successfully");

            //Directory Info Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");

            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab10']")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_DIRECTORYINFO");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=LINE_DIRECTORYINFO | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Name("ldn")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("ldn")).SendKeys("12345");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("listingTypeLuId"))).SelectByText("White");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("country"))).SelectByText("United States");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("listingHeading")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("listingHeading")).SendKeys("a");
            BrowserDriver.Instance.Driver.FindElement(By.Id("comments")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("comments")).SendKeys("b");
            BrowserDriver.Instance.Driver.FindElement(By.Name("street1")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("street1")).SendKeys("c");
            BrowserDriver.Instance.Driver.FindElement(By.Name("street2")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("street2")).SendKeys("d");
            BrowserDriver.Instance.Driver.FindElement(By.Name("street3")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("street3")).SendKeys("e");
            BrowserDriver.Instance.Driver.FindElement(By.Name("city")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("city")).SendKeys("h");
            BrowserDriver.Instance.Driver.FindElement(By.Name("saveDirectoryInfoButton")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Directory Info creation Successful");

            BrowserDriver.Instance.Driver.FindElement(By.Name("resetButton")).Click();
            Console.WriteLine("Inventory Explorer Passed Succesfully");
        }

    }
}
