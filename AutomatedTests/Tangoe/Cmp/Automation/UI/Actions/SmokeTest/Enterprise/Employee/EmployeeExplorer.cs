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
using AutomatedTests.CMP.Enterprise;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise.Employee
{
    class EmployeeExplorer :BaseActions
    {
        public void EmployeeExplorerFunctions()
        {
            GoToMain("Enterprise");
            retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
            retryingFindClickk(".//*[@id='mnuEmployees_Explorer']");
            if (true)
            {
                SwitchToContent();
                WaitForElementToVisible(By.XPath("//div[text()='Employee Summary']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation not successful");
            }


            Thread.Sleep(2000);

            if (true)
            {
                EmployeeCreation();
                SwitchToContent();
                typeDataName("firstName", "Bill");
                typeDataName("lastName", "Minnow");
                EmployeeSearch("Bill","Minnow");
                Console.WriteLine("Employee Creation Successful");
                Console.WriteLine("Employee Search Successful");
            }
            else
            {
                Console.WriteLine("Employee Creation  failed");
                Console.WriteLine("Employee Search  failed");


            }
            //if (true)
            //{
               
            //    EmployeeSearch("CHARLES");
            //    Console.WriteLine("Employee Search Successful");
            //}
            //else
            //{
            //    Console.WriteLine("Employee Search  failed");
            
            //}
           

            if (true)
            {
                EditEmployee();

                //    DeleteEmployee();

                //  EmployeeCreation();

          //   CreateInventory();

          //    ModifyInventory();

          //     DeleteInventory();

             CreateBudget();

            //    DeleteEmployee();


                Console.WriteLine("Employee Explorer passed smoke Test Successfully");
            }
            else
            {
                Console.WriteLine("Employee Explorer failed smoke test");
            
            }
        }

        public void EmployeeSearch(String text, String lastName)
        {
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('firstName')[0].value='"+ text +"'");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.ResetB)).Click();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('firstName')[0].value='" + text + "'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('lastName')[0].value='" + lastName + "'");

            BrowserDriver.Instance.Driver.FindElement(By.Name("employeeIdentifier")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
            Thread.Sleep(5000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='"+ text +"']")), "Employee Search failed");
        }

        public void EmployeeCreation()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.CreateNewB)).Click();
            Thread.Sleep(3000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.Id("tabEmployee")), "Unable to display create new entity details table");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("EMPLOYEE");
             System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            typeDataName("employeeIdentifier", "12345"+RandomNumbergeneratorL());
            typeDataName("firstName", "Bill");
            typeDataName("lastName", "Minnow");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('contactTypeId')[0].selectedIndex = 3;");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.SaveB)).Click();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            Thread.Sleep(7000);
        
        }
           public void EditEmployee()
           {
               SwitchToContent();
               BrowserDriver.Instance.Driver.SwitchTo().Frame("EMPLOYEE");
               typeDataName("employeeIdentifier", "567890"+RandomNumbergeneratorL());
               typeDataName("firstName", "Michael");
               Thread.Sleep(2000);
               retryingFindClick(By.XPath(Enterp.Default.SaveB));
               Thread.Sleep(5000);
            SwitchToContent();
            javascriptClick(By.XPath(Enterp.Default.ResetB));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('employeeIdentifier')[0].value='567890'");
            typeDataName("employeeIdentifier", "567890");
            typeDataName("firstName", "Michael");
           retryingFindClick(By.XPath(Enterp.Default.QuerySubmitB));
            Thread.Sleep(5000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Minnow']")), "Employee Creation failed");
            Console.WriteLine("Employee Details Edited Successfully");
           }

        public void DeleteEmployee()
        {
          //  EmployeeSearch("Michael","Minnow");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
           javascriptClick(By.XPath(Enterp.Default.DeleteB));
            SwitchToContent();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='Michael']")), "Employee Delation failed");
            Console.WriteLine("Employee Deletion Successful");
        }


        public void CreateInventory()
        
        {
            //  //Assigning Inventory
         //   EmployeeSearch("CHARLES");
            SwitchToContent();
            Thread.Sleep(2000);
            retryingFindClick(By.Id("tabInventory"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");      
            javascriptClick(By.XPath(Enterp.Default.AddB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            WaitForElementToVisible(By.Id("imgLookupinventoryId"));
            javascriptClick(By.Id("imgLookupinventoryId"));
            Thread.Sleep(4000);
            InventoryLookup();
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[.='Verizon']"));
            javascriptClick(By.Id("returnButtonIds"));
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.CheckB));

            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.SaveB));
            Thread.Sleep(3000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            javascriptClick(By.XPath("//div[.='Conferencing']"));
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Conferencing']")), "Adding Inventory to employee failed");
            Console.WriteLine("Inventory Added to employee successfully");
        }
            
           public void ModifyInventory()
           {
             //  EmployeeSearch("CHARLES");
               SwitchToContent();
               Thread.Sleep(2000);
               retryingFindClick(By.Id("tabInventory"));
               Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
               Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath("//div[text()='Conferencing']"));
            javascriptClick(By.XPath("Enterp.Default.ModifyB"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('dtControlexpirationDate').value='10/10/2020'");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.SaveB));
               Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            javascriptClick(By.XPath("//div[text()='10/10/2020']"));
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Conferencing']")), "Modifying Inventory to employee failed");
            Console.WriteLine("Inventory Modified successfully");
           
           }

        public void DeleteInventory()
    {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            javascriptClick(By.XPath("//div[text()='Conferencing']"));
         ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;};");
            javascriptClick(By.XPath(Enterp.Default.DeleteB));
            Thread.Sleep(2000);
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='Conferencing']")), "Unable to Delete Inventory ");
            Console.WriteLine("Inventory Deleted successfully");
    }

            //Assigning Budget

        public void CreateBudget()
        {
            SwitchToContent();
            javascriptClick(By.Id("tabBudget"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BUDGET");
            BrowserDriver.Instance.Driver.FindElement(By.Name("janBudget")).Clear();
            typeDataName("janBudget", "5");
            BrowserDriver.Instance.Driver.FindElement(By.Name("febBudget")).Clear();
            typeDataName("febBudget", "10");
            BrowserDriver.Instance.Driver.FindElement(By.Name("marBudget")).Clear();
            typeDataName("marBudget", "15");
            BrowserDriver.Instance.Driver.FindElement(By.Name("aprBudget")).Clear();
            typeDataName("aprBudget", "20");
            BrowserDriver.Instance.Driver.FindElement(By.Name("mayBudget")).Clear();
            typeDataName("mayBudget", "25");
            BrowserDriver.Instance.Driver.FindElement(By.Name("junBudget")).Clear();
            typeDataName("junBudget", "30");
            BrowserDriver.Instance.Driver.FindElement(By.Name("julBudget")).Clear();
            typeDataName("julBudget", "35");
            BrowserDriver.Instance.Driver.FindElement(By.Name("augBudget")).Clear();
            typeDataName("augBudget", "40");
            BrowserDriver.Instance.Driver.FindElement(By.Name("sepBudget")).Clear();
            typeDataName("sepBudget", "45");
            BrowserDriver.Instance.Driver.FindElement(By.Name("octBudget")).Clear();
            typeDataName("octBudget", "50");
              BrowserDriver.Instance.Driver.FindElement(By.Name("novBudget")).Clear();
            typeDataName("novBudget", "55");
              BrowserDriver.Instance.Driver.FindElement(By.Name("decBudget")).Clear();
            typeDataName("decBudget", "60");
            javascriptClick(By.XPath(Enterp.Default.SaveB));
            Thread.Sleep(2000);
              SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("BUDGET");
            Assert.AreEqual("$ 390.00", BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='amountTotal']")).Text);
    //        Assert.IsTrue(IsElementVisible(By.XPath(".//*[@id='amountTotal']")), "Assigning Budget to Employee failed");
            Console.WriteLine("Budget Added Successfully");

        }

        
            //  //Assigning CostCenter
            //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //  BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tabCostCenter']")).Click();
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("COSTCENTER");
            //  Assert.IsTrue(IsElementVisible(By.XPath("//div[.='ASC']")), "Assigning CostCenter to Employee failed");
            //  Console.WriteLine("CostCenter Added Successfully");


        public void DeleteEmployee1()
        {
            SwitchToContent();

            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('employeeIdentifier')[0].value='12345'");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(Enterp.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToContent();
         //   Assert.IsFalse(IsElementVisible(By.XPath("//div[.='Michael']")), "Employee Delation failed");
            Console.WriteLine("Employee Deletion Successful");

        }


        public void InventoryLookup()
        {
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.Id("CMP_DIALOG_FRAME"));//CMP_DIALOG_FRAME
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('queryTypeId').selectedIndex = 2;");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB));
            Thread.Sleep(3000);
        }
        
    }
}
