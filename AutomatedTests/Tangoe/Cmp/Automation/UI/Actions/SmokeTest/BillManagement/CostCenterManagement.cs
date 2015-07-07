using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement
{
    class CostCenterManagement :BaseActions
    {

        public void CostCenterManagementt()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_CostCenterManage']");
            WaitForElement(By.Id("pageTitle"));
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            WaitForElement(By.Name("NewTableCC"));
            BrowserDriver.Instance.Driver.FindElement(By.Name("NewTableCC")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=GENERAL | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("costCenterName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("costCenterName")).SendKeys("AndoridCostCenter");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupparentCostCenterId")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryCostCentersButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=GENERAL | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Name("save")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTENT | ]]
            Assert.AreEqual("AndroidCostCenter", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AndoridCostCenter']")).Text);
            Console.WriteLine("Cost Center Created Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab2']")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCDEF");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=ALLOCDEF | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("addButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            BrowserDriver.Instance.Driver.SwitchTo().Frame("BLANK");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
            BrowserDriver.Instance.Driver.FindElement(By.Id("nextButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BLANK");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("lookUpIFRAME");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=lookUpIFRAME | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryCostCentersButton")).Click();
            Thread.Sleep(3000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BLANK");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=MAIN | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("nextButton")).Click();
            Thread.Sleep(3000);





            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BLANK");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");


            BrowserDriver.Instance.Driver.FindElement(By.Id("expenseCode")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("expenseCode")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).SendKeys("Allocation");
            BrowserDriver.Instance.Driver.FindElement(By.Id("finishButton")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=MAIN | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("cancelButton")).SendKeys(Keys.Enter);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=ALLOCDEF | ]]

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCDEF");
            BrowserDriver.Instance.Driver.FindElement(By.Name("removeButton")).Click();
            Thread.Sleep(3000);
            Console.WriteLine("Deletion of Allocation Code Successful");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=MAIN | ]]


            //Reallocation Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");

            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab3']")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("REALLOCRULES");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=REALLOCRULES | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("addAllocationButton")).Click();
            Thread.Sleep(2000);

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryCostCentersButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).Click();
            Thread.Sleep(3000);


            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=REALLOCRULES | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("REALLOCRULES");

            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();

            BrowserDriver.Instance.Driver.FindElement(By.Id("percent")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("percent")).SendKeys("10%");
            BrowserDriver.Instance.Driver.FindElement(By.Id("saveAllocationOverride")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Reallocation created and updated Successfully");


            BrowserDriver.Instance.Driver.FindElement(By.Id("bnRemove")).Click();
            Thread.Sleep(3000);
            Console.WriteLine("Reallocation Deletion Successful");

            // Entities Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab3']")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ENTITIES");
            //[selectWindow | name=ENTITIES | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("assignEntityCostCenterButton")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]

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

            //[selectWindow | name=ENTITIES | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ENTITIES");

            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='ACS']")).Click();

            Assert.AreEqual("ACS", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("//div[.='ACS']")).Text);
            Console.WriteLine("Entity Added Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Id("deleteEntityCostCenterButton")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Entity Deleted Successfully");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTENT | ]]

            //Contacts Tab
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab6']")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTACTS");


            BrowserDriver.Instance.Driver.FindElement(By.Id("ccc_addButton")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupcontactId")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");


            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTACTS | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTACTS");
            BrowserDriver.Instance.Driver.FindElement(By.Id("ccc_saveButton")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Contact added Successfully");

            BrowserDriver.Instance.Driver.FindElement(By.Id("ccc_removeButton")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Contact deleted Successfully");
            Console.WriteLine("Center Center Management Passed Successfully");

        }
            
    }
}
