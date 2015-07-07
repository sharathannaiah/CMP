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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise.Employee
{
    class EmployeeExplorer :BaseActions
    {
        public void EmployeeCreation()
        {
            GoToMain("Enterprise");
            // Navigate to Employee
            retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
            //Navigate to Employee Explorer
            retryingFindClickk(".//*[@id='mnuEmployees_Explorer']");
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("New")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.IsTrue(IsElementVisible(By.Id("tabEmployee")), "Unable to display create new entity details table");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("EMPLOYEE");
            BrowserDriver.Instance.Driver.FindElement(By.Name("employeeIdentifier")).Clear();
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("employeeIdentifier")).SendKeys("SA" + random);
            BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.firstName));
            BrowserDriver.Instance.Driver.FindElement(By.Name("lastName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("lastName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.lastName));
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("contactTypeId"))).SelectByText("Billing Contact");
            BrowserDriver.Instance.Driver.FindElement(By.Name("save")).Click();
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            GoToMain("Enterprise");
            // Navigate to Employee
            retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
            //Navigate to Employee Explorer
            retryingFindClickk(".//*[@id='mnuEmployees_Explorer']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.firstName));
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryEmployeesButton")).Click();
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Sharath']")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Annaiah", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Annaiah']")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Annaiah']")), "Employee creation failed");
            Console.WriteLine("Employee Created Successfully");
            Thread.Sleep(2000);

            //  //Assigning Inventory
            //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //  BrowserDriver.Instance.Driver.FindElement(By.Id("tabInventory")).Click();
            //  Thread.Sleep(2000);
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            //  BrowserDriver.Instance.Driver.FindElement(By.Id("inventoryAddButton")).Click();
            //  Thread.Sleep(2000);
            //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            //  BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupinventoryId")).Click();
            //  Thread.Sleep(3000);
            //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            // // BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //  new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("queryTypeId"))).SelectByText("Other");
            //  BrowserDriver.Instance.Driver.FindElement(By.Id("queryConferencingInventoryButton")).Click();
            //  Thread.Sleep(2000);
            //  BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Verizon']")).Click();
            //  BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).Click();
            //  Thread.Sleep(2000);
            ////  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //  BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='inventoryMaintenanceFormDV']/div/input[1]")).SendKeys(Keys.Enter);
            //  Thread.Sleep(2000);
            //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            //  Assert.IsTrue(IsElementVisible(By.XPath(".//*[@id='inventoryMaintenanceFormDV']/div/input[1]")), "Assigning Invnetory to Employee failed");
            //  Console.WriteLine("Assigning Inventory to Employee Successful");
            //  Thread.Sleep(2000);

            //  //Assigning CostCenter
            //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //  BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tabCostCenter']")).Click();
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("COSTCENTER");
            //  Assert.IsTrue(IsElementVisible(By.XPath("//div[.='ASC']")), "Assigning CostCenter to Employee failed");
            //  Console.WriteLine("CostCenter Added Successfully");

            //Assigning Budget
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tabBudget']")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BUDGET");
            BrowserDriver.Instance.Driver.FindElement(By.Name("janBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("janBudget")).SendKeys("5");
            BrowserDriver.Instance.Driver.FindElement(By.Name("febBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("febBudget")).SendKeys("10");
            BrowserDriver.Instance.Driver.FindElement(By.Name("marBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("marBudget")).SendKeys("15");
            BrowserDriver.Instance.Driver.FindElement(By.Name("aprBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("aprBudget")).SendKeys("20");
            BrowserDriver.Instance.Driver.FindElement(By.Name("mayBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("mayBudget")).SendKeys("25");
            BrowserDriver.Instance.Driver.FindElement(By.Name("junBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("junBudget")).SendKeys("30");
            BrowserDriver.Instance.Driver.FindElement(By.Name("julBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("julBudget")).SendKeys("35");
            BrowserDriver.Instance.Driver.FindElement(By.Name("augBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("augBudget")).SendKeys("40");
            BrowserDriver.Instance.Driver.FindElement(By.Name("sepBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("sepBudget")).SendKeys("45");
            BrowserDriver.Instance.Driver.FindElement(By.Name("octBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("octBudget")).SendKeys("50");
            BrowserDriver.Instance.Driver.FindElement(By.Name("novBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("novBudget")).SendKeys("55");
            BrowserDriver.Instance.Driver.FindElement(By.Name("decBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("decBudget")).SendKeys("60");
            BrowserDriver.Instance.Driver.FindElement(By.Name("modifyEmployeeBudgetButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();

            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BUDGET");
            Assert.AreEqual("$ 390.00", BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='amountTotal']")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath(".//*[@id='amountTotal']")), "Assigning Budget to Employee failed");
            Console.WriteLine("Budget Added Successfully");

            //Updating Employee Details 
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tabEmployee']")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("EMPLOYEE");
            BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).SendKeys("Sharathh");
            BrowserDriver.Instance.Driver.FindElement(By.Name("save")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("EMPLOYEE");
            Assert.AreEqual("Sharathh", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Sharathh']")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Sharathh']")), "Employee Name modification failed");
            Console.WriteLine("Updated Employee Details Successfully");

            ////Updating Inventory Details
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("tabInventory")).Click();
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='JColResizer1']/tbody/tr[1]/td[2]/div/nobr/div")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.Id("inventoryModifyButton")).Click();
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("unassignCurrentEmployee")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='JColResizer1']/tbody/tr[1]/td[2]/div/nobr/div")).SendKeys(Keys.Enter);
            //Console.WriteLine("Updated Inventory Successfully");

            ////UnAssisgning Inventory from Employee
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath("tabInventory")).Click();
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='JColResizer1']/tbody/tr[1]/td[2]/div/nobr/div")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.Id("inventoryModifyButton")).Click();
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("unassignCurrentEmployee")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='JColResizer1']/tbody/tr[1]/td[2]/div/nobr/div")).SendKeys(Keys.Enter);
            //Thread.Sleep(2000);

            ////Delete Inventory
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='JColResizer1']/tbody/tr[1]/td[2]/div/nobr/div")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.Id("invDeleteButton")).Click();
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.FindElement(By.LinkText("OK")).SendKeys(Keys.Enter);
            //Console.WriteLine("Deleted Budget Successfully");

            //Updating Budget
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tabBudget']")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BUDGET");
            BrowserDriver.Instance.Driver.FindElement(By.Name("janBudget")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("janBudget")).SendKeys("10");
            BrowserDriver.Instance.Driver.FindElement(By.Name("modifyEmployeeBudgetButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BUDGET");
            Assert.AreEqual("$ 395.00", BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='amountTotal']")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath(".//*[@id='amountTotal']")), "Updating Budget to Employee failed");
            Console.WriteLine("Updated Budget Successful");
        }
    }
}
