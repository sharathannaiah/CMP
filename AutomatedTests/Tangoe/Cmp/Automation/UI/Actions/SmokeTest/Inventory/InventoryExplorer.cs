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
using AutomatedTests.CMP.Inventory;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Inventory
{
    class InventoryExplorer :BaseActions
    {
        public void InventorySmokeFunctionality()
        {
           
            GoToMain1("Inventory","Explorer");
          // InventorySearch();
          //  CreateInventory("12345" + RandomNumbergeneratorL());
          //  DeleteInventory();
            
            CreateInventory("56789" + RandomNumbergeneratorL());
            EditInventory("12345" + RandomNumbergeneratorL());
       //     DeleteInventory();
        //    CreateInventory("56789" + RandomNumbergeneratorL());
            AddAlias();
          RemoveAlias();
            AddSpid();
           EditSpid();
         //  DeleteSpid();
            AddTollNumber();
            RemoveTollNumber();
            AddFeatures();
            EditFeatures();
            RemoveFeatures();
            AddAllocation();
            RemoveAllocation();
            AddDirectoryInfo();
        //    AddEmployee();
        //    EditEmployee();
        //    DeleteEmployee(); 


            Console.WriteLine("Inventory Explorer Passed Succesfully");

            Console.WriteLine("Inventory --> Inventory Explorer Passed smoke test Succesfully");

        }


        public void InventorySearch()
        {
        SwitchToContent();
        BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.QSubmitB)).Click();
            Thread.Sleep(3000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            //Assert.AreEqual("Entity creation", BrowserDriver.Instance.Driver.FindElement(By.Name("notes")).Text);
            //div[@class='rating']/@title

            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Active']")), "Inventory Search Unsuccessful");

            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
          //  Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('inventoryTypeId')[0].selectedIndex = 15;");
            //Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.QSubmitB)).Click();
            Thread.Sleep(3000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='LINE']")), " Inventory Search Unsuccessful");
            Console.WriteLine("Inventory Search Successful");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

        }

        public void CreateInventory(String phoneNumber)
        {
            SwitchToContent();
          //  ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('inventoryType').selectedIndex = 1;");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("inventoryType"))).SelectByText("Lines");
         //   SelectfromDropdown("inventoryType", "1");
        Thread.Sleep(3000);
        SwitchToContent();
        BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.NewB)).Click();
            Thread.Sleep(2000);
           SwitchToContent();
           BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
           BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_GENERAL");
    //       ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('phoneNumber').value = '77777'");
       ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('phoneNumber')[0].value='" + phoneNumber + "'");
       ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierId')[0].selectedIndex= '4';");
       typeDataName("description", "Automation");
         //   typeDataName("phonenumber", "77777");
           javascriptClick(By.XPath(Inven.Default.SaveB));
           Thread.Sleep(3000);
           SwitchToContent();
           BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
           Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Automation']")), " Inventory Creation Unsuccessful");
           Console.WriteLine("Inventory Created Successfully");
     //      SearchPhonenumber("77777");
       //    SwitchToContent();
       //    BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
         
        }


        public void EditInventory(String phoneNumber)
        {
          Thread.Sleep(2000);
          SwitchToContent();
          BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
        BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_GENERAL");
    //    typeDataName("btnId", "5555555555");
      //  typeDataName("description", "Automation");
      //  ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('phoneNumber')[1].value='567890'");
        ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('phoneNumber')[0].value='" + phoneNumber + "'");
        ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierId')[0].selectedIndex= '5';");
        typeDataName("description", "Automation Updated");


     //   typeDataName("phonenumber", "567890");
        javascriptClick(By.XPath(Inven.Default.SaveB));
        Thread.Sleep(4000);
        SearchPhonenumber(phoneNumber);
        SwitchToContent();

        BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
        Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Automation Updated']")), " Inventory Edition Unsuccessful");
           Console.WriteLine("Inventory Edited Successfully");

        }
        public void DeleteInventory()
        {
            Thread.Sleep(2000);
            SearchPhonenumber("12345");
            SwitchToContent();
        BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.DeleteB)).Click();
        Assert.IsFalse(IsElementVisible(By.XPath("//div[.='567890']")), " Inventory Deletion Unsuccessful");
           Console.WriteLine("Inventory Deleted Successfully");

        }

        public void SearchPhonenumber(String phonenumber)
        {
        SwitchToContent();
        BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
        ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('phoneNumberPattern')[0].value='" + phonenumber + "'");
        BrowserDriver.Instance.Driver.FindElement(By.XPath(Inven.Default.QSubmitB)).Click();
        Thread.Sleep(4000);
        }

        public void AddAlias()
        {
            //Inventory Alias Tab
            //  SearchPhonenumber("");
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab11']")).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALIAS");
            javascriptClick(By.Id("addAliasButton"));
            Thread.Sleep(3000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
            typeDataName("phoneNumberPattern", "123");
            javascriptClick(By.XPath(Inven.Default.QSubmitB));
            Thread.Sleep(4000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_TABLE_FRAME");
            javascriptClick(By.XPath("//div[text()='AT&T']"));
       //     ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(2000);
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            //    BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[text()='Verizon']")).Click();
            SwitchToContent();
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALIAS");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AT&T']")), "Additon of alias failed");
            Console.WriteLine("Alias Added Successfully");
        }



            public void RemoveAlias()
            {
                Thread.Sleep(2000);
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALIAS");
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(Inven.Default.RemoveB));
         //   IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
         //   alert.Accept();
            //    BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[text()='Verizon']")).Click();
            SwitchToContent();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AT&T']")), "Removal of alias failed");
            Console.WriteLine("Alias Removed Successfully");
            }

        public void AddSpid()
            {
            SwitchToContent();
             BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            javascriptClick(By.XPath("//div[text()='SPID']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");
            javascriptClick(By.XPath(Inven.Default.AddB));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            SwitchToPopUps();
            typeDataName("spidText", "567890");
            retryingFindClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='567890']")), "Adding SPID failed");
            Console.WriteLine("SPID added successfully");
        }

        public void EditSpid()
        {
          SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");
            javascriptClick(By.XPath(Inven.Default.EditB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@Name='spidText']")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('spidText')[0].value = '12345';");
            Thread.Sleep(1000);
            javascriptClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(4000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='12345']")), "Editing SPID failed");
            Console.WriteLine("SPID edited successfully");
        }

        public void DeleteSpid()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(Inven.Default.DeleteB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_SPID");
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='12345']")), " SPID Deletion Unsuccessful");
            Console.WriteLine("SPID Deleted Successfully");
           
        }
        public void AddTollNumber()
        {
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
               javascriptClick(By.XPath("//div[text()='Toll Free Numbers']"));
               Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_TFN");
            javascriptClick(By.XPath(Inven.Default.AddB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('itemName')[0].value = 'a';");
            javascriptClick(By.XPath(Inven.Default.QSubmitB));
            Thread.Sleep(3000);
            SwitchToPopUps();
            retryingFindClick(By.XPath("//div[text()='IR/Trane']"));
            Thread.Sleep(2000);
            javascriptClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(3000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_TFN");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='IR/Trane']")), "Adding Toll Number failed");
            Console.WriteLine("Toll Number Added Successfully");
             
        }
        public void RemoveTollNumber()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_TFN");
            Thread.Sleep(2000);
            javascriptClick(By.XPath(Inven.Default.RemoveB));
            Thread.Sleep(3000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_TFN");
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='IR/Trane']")), " Toll Number Deletion Unsuccessful");
           Console.WriteLine("Toll Number Deleted Successfully");
        }



        public void AddFeatures()
        {
         SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
               javascriptClick(By.XPath("//div[text()='Chrgs/Features']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");
            javascriptClick(By.XPath(Inven.Default.AddContractB));
            Thread.Sleep(4000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nonconDescription')[0].value = '500';");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nonconAmount')[0].value = '500';");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('currencyCode')[0].selectedIndex = 8;");
       //     new SelectElement (BrowserDriver.Instance.Driver.FindElement(By.Name("currencyCode"))).SelectByText("USD - United States of America, Dollars");
            javascriptClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(5000);
              SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='500.00']")), "Adding charges/Features failed");
            Console.WriteLine("Adding Charges Successful");

        }

        
            public void EditFeatures()
        {
         SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
               javascriptClick(By.XPath("//div[text()='Chrgs/Features']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");
            javascriptClick(By.XPath(Inven.Default.EditB));
            Thread.Sleep(5000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@Name='nonconDescription']")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nonconDescription')[0].value = '900';");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@Name='nonconAmount']")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nonconAmount')[0].value = '900';");
            javascriptClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(4000);
              SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");
           Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='900.00']")), "Editing charges/Features failed");
            Console.WriteLine("Editing Charges Successful");

        }

        
        public void RemoveFeatures()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");
            javascriptClick(By.XPath(Inven.Default.RemoveB));
            Thread.Sleep(4000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_CHARGES");
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='300']")), " Charges/Features Deletion Unsuccessful");
           Console.WriteLine("Charges/Featues Deleted Successfully");
        }


        public void AddEmployee()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
               javascriptClick(By.XPath("//div[text()='Employees']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
            javascriptClick(By.XPath(Inven.Default.AddB));
            Thread.Sleep(2000);
               
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupemployeeId")).Click();
            Thread.Sleep(4000);
            SwitchToPopUps();
            javascriptClick(By.XPath(Inven.Default.QSubmitB));
            Thread.Sleep(4000);
            SwitchToPopUps();
            javascriptClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
           Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Active']")), "Adding Employee failed");
           Console.WriteLine("Employee added successfully");
        }

         public void EditEmployee()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
            javascriptClick(By.XPath(Inven.Default.ModifyB));
            Thread.Sleep(2000);
               
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlexpirationDate")).SendKeys("10/10/2020");
            javascriptClick(By.XPath(Inven.Default.OKB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
           Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='10/10/2020']")), "Editing Employee failed");
           Console.WriteLine("Employee edited successfully");
            javascriptClick(By.XPath(Inven.Default.ExpireB));
             Thread.Sleep(2000);
             SwitchToContent();
             BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
             BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
           Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='10/10/2020']")), "Employee Expire failed");
           Console.WriteLine("Employee expire successfully");


        }


          public void DeleteEmployee()
          {
              AddEmployee();
           SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_EMPLOYEES");
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.prompt = function(msg) { return true; }");
            javascriptClick(By.XPath(Inven.Default.DeleteB));
            //    BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[text()='Verizon']")).Click();
            SwitchToContent();
            Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AT&T']")), "Removal of alias failed");
            Console.WriteLine("Employee Deleted Successfully");
              Thread.Sleep(2000);
          }


       

        public void AddAllocation()
        {
             SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                javascriptClick(By.XPath("//div[text()='Allocation']"));
            Thread.Sleep(4000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALLOC");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");
            javascriptClick(By.XPath(Inven.Default.AddB));
            Thread.Sleep(3000);
            javascriptClick(By.Id("imgLookupcostCenterId"));
            Thread.Sleep(2000);
            SelectChildPopupRecordWithoutQuerying();
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALLOC");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");
            javascriptClick(By.XPath(Inven.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALLOC");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='100%']")), "Adding cost center failed");
         Console.WriteLine("Allocation Added Successfully");
        }

        public void RemoveAllocation()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALLOC");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");   
            javascriptClick(By.XPath(Inven.Default.RemoveB));
             Thread.Sleep(4000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_ALLOC");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER_COST_CENTER");
            Assert.False(IsElementVisible(By.XPath("//div[text()='100%']")), "Deleting cost center failed");
         Console.WriteLine("Allocation Deleted Successfully");
            Thread.Sleep(2000);
   
        }

        public void AddDirectoryInfo()
        {

            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            javascriptClick(By.XPath("//div[text()='Directory Info']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_DIRECTORYINFO");
            typeDataName("ldn", "9999999");
            typeDataName("listingHeading", "Automation Listing");
            typeDataName("zip", "77777");
            javascriptClick(By.XPath(Inven.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_DIRECTORYINFO");
         //   Assert.IsTrue(IsElementVisible(By.XPath("//td[text()='LDN']")), "Adding Directory info Failed");
            Console.WriteLine("Directory Info added successfully");
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("LINE_DIRECTORYINFO");
            javascriptClick(By.XPath(Inven.Default.ResetB));
            Assert.IsFalse(IsElementVisible(By.XPath("//input[text()='77777']")), "Deleting Directory info Failed");
            Console.WriteLine("Directory Info reset successfully");
        }


           
        

    }
}
