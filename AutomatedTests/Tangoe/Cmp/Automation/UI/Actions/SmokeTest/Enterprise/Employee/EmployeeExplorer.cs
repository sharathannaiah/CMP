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
         
         EmployeeCreation();
         EmployeeSearch();
           EditEmployee();

        //    DeleteEmployee();

          //  EmployeeCreation();

            CreateInventory();

            ModifyInventory();

            DeleteInventory();

            CreateBudget();

            DeleteEmployee();

            Console.WriteLine("Employee Explorer passed smoke Test Successfully");

        }

        public void EmployeeSearch()
        {
            SwitchToContent();
         //   ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.findElementsByName('firstName').value='Charles'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('firstName')[0].value='Charles'");
            BrowserDriver.Instance.Driver.FindElement(By.Name("employeeIdentifier")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
            Thread.Sleep(5000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='CHARLES']")), "Employee Search failed");
            Console.WriteLine("Employee Search Successful");
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
        //    BrowserDriver.Instance.Driver.FindElement(By.Name("employeeIdentifier")).SendKeys("SA" + random);

       // ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.findElementsByName('employeeIdentifier').value ='123'");

        ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('employeeIdentifier')[0].value='12345'");
        

            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('firstName')[0].value='Bill'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('lastName')[0].value='Minnow'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('contactTypeId')[0].selectedIndex = 3;");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.SaveB)).Click();
            Thread.Sleep(7000);
            SwitchToContent();
            javascriptClick(By.XPath(Enterp.Default.ResetB));

            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('employeeIdentifier')[0].value='12345'");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Minnow']")), "Employee Creation failed");
            Console.WriteLine("Employee Creation Successful");




        }


           
           public void EditEmployee()
           {

               SwitchToContent();
               BrowserDriver.Instance.Driver.SwitchTo().Frame("EMPLOYEE");
               ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('employeeIdentifier')[0].value='567890'");
               ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('firstName')[0].value='Michael'");

               javascriptClick(By.XPath(Enterp.Default.SaveB));
               Thread.Sleep(3000);
            SwitchToContent();
            javascriptClick(By.XPath(Enterp.Default.ResetB));
         
              
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('employeeIdentifier')[0].value='567890'");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
         
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='567890']")), "Employee Creation failed");
            Console.WriteLine("Employee Deatils Edited Successfully");

           }

        public void DeleteEmployee()
        {
                   

    //    ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            SwitchToContent();
           
           ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('employeeIdentifier')[0].value='567890'");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(Enterp.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToContent();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='Michael']")), "Employee Delation failed");
            Console.WriteLine("Employee Deletion Successful");

        }


        public void CreateInventory()
        
        {
            //  //Assigning Inventory

            SwitchToContent();
            Thread.Sleep(2000);
            retryingFindClick(By.Id("tabInventory"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");      
            javascriptClick(By.XPath(Enterp.Default.AddB));
            Thread.Sleep(2000);
            SwitchToPopUps();

            javascriptClick(By.Id("imgLookupinventoryId"));
            Thread.Sleep(4000);
           // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
       //     BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
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
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            javascriptClick(By.XPath("Enterp.Default.ModifyB"));
               Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('dtControlexpirationDate').value='10/10/2020'");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.SaveB));
               Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
            javascriptClick(By.XPath("//div[.='Conferencing']"));
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Conferencing']")), "Modifying Inventory to employee failed");
            Console.WriteLine("Inventory Modified successfully");
           
           }

        public void DeleteInventory()
    {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY");
         ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
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
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('janBudget').value='5'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('febBudget').value='10'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('marBudget').value='15'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('aprBudget').value='20'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('mayBudget').value='25'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('junBudget').value='30'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('julBudget').value='35'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('augBudget').value='40'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('sepBudget').value='45'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('octBudget').value='50'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('novBudget').value='55'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('decBudget').value='60'");

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
            SwitchToPopUps();
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('queryTypeId').selectedIndex = 2;");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB));
            Thread.Sleep(3000);
        }
        
    }
}
