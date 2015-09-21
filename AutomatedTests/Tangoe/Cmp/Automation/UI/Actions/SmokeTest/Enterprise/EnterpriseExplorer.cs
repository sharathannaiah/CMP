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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise
{
    class EnterpriseExplorer :BaseActions
    {
        
#region Create Enterprise
        public void EnterpriseExplorerFunctionality()
        {
            GoToMain1("Enterprise", "Explorer");
         
            if (true)
            {
                SwitchToContent();
                WaitForElementToVisible(By.XPath("//div[text()='Query Result Summary']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Failed");
            }
           
            if (true)
            {
                CreateEntity();
                Console.WriteLine("Entity Created Successfully");
            }
            else 
            {
                Console.WriteLine("Entity Creation Failed");
            }

            //if (true)
            //{
            //    DeleteEntity();
            //    SwitchToContent();
            //    Assert.IsFalse(IsElementVisible(By.XPath("//div[.='IBM']")), "Entity Deletion failed");//div([.='Main'][1])
            //    Console.WriteLine("Entity Deleted Successfully");
            //    CreateEntity();
            //}
            //else
            //{
            //    Console.WriteLine("Entity deletion  failed");
            //}

            
            if (true)
            {
                EditEntity();
                Console.WriteLine("Created Entity Edited Successfully");
            }
            else
            {
                Console.WriteLine("Created Entity not edited");
            }

            CreateAddress();
            ModifyAddress();
            RemoveAddress();
            AddDemarc();
            ModifyDemarc();
            DeleteDemarc();
            AddContacts();
            DeleteContact();
            AddCarrier();
            ModifyCarrier();
            DeleteCarrier();
            AddContract();
            
            UpdateContract();
            DeleteContract();

            AssignAccount();
            RemoveAccount();
            AssignCostCenter();
            UpdateFTE();

            DeleteCostCenter();

            ExtendedAttributes();
            ClearExtendAttribute();


            Console.WriteLine("Enterprise Explorer Passed Smoke Test Successfully");
            
        }
           
        //Create Entity IBM
        public void CreateEntity()
        {
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("NewTableEn")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(IsElementVisible(By.Id("tab1")), "Unable to display create new entity details table");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='modifyEntityFormDV']/div[2]/input")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.AreEqual("Validation", BrowserDriver.Instance.Driver.FindElement(By.XPath("html/body/fieldset/legend")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("html/body/fieldset/legend")), "No validation provided for category");
            javascriptClick(By.Id("OK"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('entityName')[0].value='IBM'");
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("siteId")).SendKeys("" + random);
            typeDataID("companyId", "1");
            typeDataID("orgEntityTypeId", "6");
            SelectfromDropdown("type", "1");
            typeDataID("siteStatus", "0");
            typeDataID("siteStatus", "0");
            typeDataName("npanxx", "55555");
            typeDataName("businessHours", "7");
            typeDataID("notes", "Entity creation");
            typeDataName("ldn", "7777777");
            typeDataName("phone2", "999999");
            typeDataName("phone1", "00000");
            typeDataName("fax", "5555555555");
            Thread.Sleep(1000);
            javascriptClick(By.XPath(Enterp.Default.SaveB));
            Thread.Sleep(3000);
            searchEntity();
            javascriptClick(By.XPath("//div[text()='IBM']"));
           
        }

        public void searchEntity()
        {
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('entityName')[0].value='IBM'");
            javascriptClick(By.Name("queryEnterpriseButton"));
            Thread.Sleep(2000);
            SwitchToContent();
            if (true)
            {
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='IBM']")), "Search Unsuccessful");
                Console.WriteLine("Entity Search Successful");
            }
            else 
            {
                Console.WriteLine("Entity Search Unsuccessful");
            }
        }

        public void EditEntity()
        {
            searchEntity();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            typeDataID("companyId", "0");
            SelectfromDropdown("type", "0");
            typeDataName("businessHours", "5");
            typeDataName("ldn", "9999999999");
            javascriptClick(By.XPath(Enterp.Default.SaveB));
            Thread.Sleep(3000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            //javascriptClick(By.XPath("//input[@value='OK']"));
            Assert.AreEqual("Entity creation", BrowserDriver.Instance.Driver.FindElement(By.Name("notes")).Text);

        }

        public void DeleteEntity()
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;}; ");
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.Id("deleteb")).Click();
           
        }

        public void CreateAddress()
        {
            if (true)
            {
                SwitchToContent();
                retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[4]");
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
                // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=ADDRESS | ]]
                javascriptClick(By.XPath(Enterp.Default.CreateB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                typeDataID("addressType", "1");
                typeDataID("street1", "123");
                typeDataID("street2", "abc");
                typeDataID("street3", "xyz");
                typeDataID("city", "Miami1");
                typeDataID("postalCode", "77777");
                javascriptClick(By.XPath(Enterp.Default.OKB));
                Thread.Sleep(3000);
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[.='77777']")), "Creating Address to entity failed");
                Console.WriteLine("Address Created to Entity Successfully");
            }
            else
            {
                Console.WriteLine("Address Creation to Entity  failed");
            }

            if (true)
            {
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
                //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=ADDRESS | ]]
                BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='add']")).Click();
                Thread.Sleep(3000);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
                Thread.Sleep(3000);
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
                javascriptClick(By.XPath(Enterp.Default.OKB));
                Thread.Sleep(2000);
                SwitchToContent();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[.='77777']")), "Adding Address to entity failed");
                Console.WriteLine("Address Added to Entity Successfully");
            }
            else
            {
                Console.WriteLine("Address not Added to Entity");
            }
        }
      
        public void ModifyAddress()
        {
            //Switch to Address tab to modify address
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            BrowserDriver.Instance.Driver.FindElement(By.Id("modify")).Click();
            Thread.Sleep(4000);
            SwitchToPopUps();
            typeDataID("street2", "777");
            typeDataID("street3", "San Andreas");
            javascriptClick(By.XPath(Enterp.Default.OKB));
          //  BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='San Andreas']")), "Modification of Address failed"); //[@id='jstabletableAddress']/div/div[2]
            Console.WriteLine("Modification of Address Successful");
            Thread.Sleep(2000);

        }

        public void RemoveAddress()
        {  
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg){return true;};");
            BrowserDriver.Instance.Driver.FindElement(By.Id("remove")).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            Assert.AreNotEqual(IsElementVisible(By.XPath("//div[.='San Andreas']")), "Deletion of Address failed"); 
            Console.WriteLine("Deletion of Address Successful");
        }

        //Demarc Tab
        public void AddDemarc()
        {
            //Demarc Tab 
            SwitchToContent();
            retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[6]");
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("DEMARCS");
            // BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#divTabstriptabstripDetails > #tab9")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnAdd")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.AreEqual("Demarc", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            SelectfromDropdown("demarcTypeId", "2");
            typeDataID("building", "777");
            typeDataID("floor", "333");
            typeDataID("suite", "333");
            typeDataID("room", "999");
            typeDataID("department", "000");
            BrowserDriver.Instance.Driver.FindElement(By.Id("primaryDemarcIndicator")).Click();
            retryingFindClick(By.XPath(Enterp.Default.OKB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("DEMARCS");
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Primary']")), "Demarc creation failed");//div([.='Main'][1])
            Console.WriteLine("Creation of Demarc Successful");
        }

        public void ModifyDemarc()
        {
            //Modification of Demarc
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnModify")).Click();
            SwitchToPopUps();
            SelectfromDropdown("demarcTypeId", "1");
            typeDataID("building", "999");
            typeDataID("floor", "555");
            typeDataID("suite", "777");
            typeDataID("room", "000");
            retryingFindClick(By.XPath(Enterp.Default.OKB));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("DEMARCS");
            //  Assert.AreEqual("Extended", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"Extended\"]")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='555']")), "Demarc modification failed");
            Console.WriteLine("Modification of Demarc Successful");
        }

        public void DeleteDemarc()
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg){return true;};");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='bnRemove']")).Click();
            Thread.Sleep(2000);
           Assert.AreNotEqual(IsElementVisible(By.XPath("//div[.='555']")), "Demarc Deletion failed");
            Console.WriteLine("Deletion of Demarc Successful");
        }

        public void AddContacts()
        {
         //Contacts Tab
            SwitchToContent();
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[8]");
         Thread.Sleep(2000);
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTACTS");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.FindElement(By.Id("addEntityContactButton")).Click();
         Thread.Sleep(4000);
         SwitchToPopUps();
         Assert.AreEqual("Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
       //  BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).Clear();
         ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('firstName').value='CHARLES'");
         ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('lastName').value='ABBINANTI'");
         Thread.Sleep(2000);
         javascriptClick(By.XPath(Enterp.Default.QuerySubmitB));
         Thread.Sleep(4000);
         SwitchToPopUps();
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='CHARLES']")).Click();
         Thread.Sleep(2000);
         javascriptClick(By.XPath(Enterp.Default.OKB));
             Thread.Sleep(2000);
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTACTS");
         Assert.IsTrue(IsElementVisible(By.XPath("//div[.='CHARLES']")), "Demarc modification failed");
         Console.WriteLine("Contacts added to Entity successfully");

        }

        public void DeleteContact()
        {

         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Yes']")).Click();
        // Assert.AreEqual("630-226-4880", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"630-226-4880\"]")).Text);
         BrowserDriver.Instance.Driver.FindElement(By.Id("removeEntityButton")).Click();
         Console.WriteLine("Contact deleted successfully");
         Thread.Sleep(2000);

        }


        public void AddCarrier()
        {
         //Carrier Tab
            SwitchToContent();
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[10]");
         Thread.Sleep(2000);
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CARRIERS");
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CARRIERS | ]]
         BrowserDriver.Instance.Driver.FindElement(By.Id("addEntityCarrierButton")).Click();
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
         SwitchToPopUps();
         //Assert.AreEqual("Carrier Lookup", BrowserDriver.Instance.Driver.Title);
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Click();
         ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('notes').value='Trusted Carrier'");
         javascriptClick(By.XPath(Enterp.Default.OKB));
         Thread.Sleep(2000);
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CARRIERS");

         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CARRIERS | ]]
         Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Text);
        Console.WriteLine("Carrier Added successfully");
        }

        public void ModifyCarrier()
        {
         ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('notes')[0].value='Trusted Carrier and the best'");
         BrowserDriver.Instance.Driver.FindElement(By.Name("modifyEntityCarrierButton")).Click();
         Thread.Sleep(2000);
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CARRIERS");
         Assert.AreEqual("Trusted Carrier and the best", BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).GetAttribute("value"));
         Console.WriteLine("Carrier modification successful");
        }

        public void DeleteCarrier()
        {

            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Name("removeEntityCarrierButton")).Click();
         Console.WriteLine("Carrier removed successfully");
         Thread.Sleep(2000);
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddContract()
        {
        //Contract Tab
         SwitchToContent();
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[12]");
         Thread.Sleep(2000);
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTRACTS");
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTRACTS | ]]
         BrowserDriver.Instance.Driver.FindElement(By.Id("addEntityContractButton")).Click();
         Thread.Sleep(2000);
         SwitchToPopUps();
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
        // Assert.AreEqual("Contract Lookup", BrowserDriver.Instance.Driver.Title);
         javascriptClick(By.Name("queryNegotiatedContractsButton"));
       //  BrowserDriver.Instance.Driver.FindElement(By.Name("queryNegotiatedContractsButton")).Click();
         Thread.Sleep(4000);
      //   BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Click();
         javascriptClick(By.Name("returnButtonIds"));
       
        //    BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         Thread.Sleep(3000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTRACTS | ]]
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTRACTS");
         Assert.IsTrue(IsElementVisible(By.XPath("//div[.='AT&T']")), "Adding contract not successful");
   //      Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Text);
         Console.WriteLine("Contract Added Successfully");

        }

        public void UpdateContract()
        {
         
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('notes')[0].value='Contract notes Updated'");
            javascriptClick(By.Name("modifyEntityContractButton"));
            Thread.Sleep(2000);
         Assert.AreEqual("Contract notes Updated", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Contract notes Updated']")).Text);
         Console.WriteLine("Contract Notes Updated successfully");

        }
         
        //Delete Contract
        public void DeleteContract()
        {
            javascriptClick(By.XPath("//input[@value='Remove']"));
            Thread.Sleep(2000);
            Console.WriteLine("Contract deleted successfully");
     //    Assert.AreNotEqual("Contract notes Updated", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Contract notes Updated']")).Text);


        }
        
        //Accounts Tab Assigning Accounts to Entity 
        public void AssignAccount()
        {
            SwitchToContent();
            retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[14]");
              Thread.Sleep(2000);
            SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("ACCOUNTS");
         Thread.Sleep(2000);
            javascriptClick(By.XPath("//input[@value='Add']"));
      //   BrowserDriver.Instance.Driver.FindElement(By.Id("assignEntityAccountButton")).Click();
         Thread.Sleep(2000);
         SwitchToPopUps();
         Assert.AreEqual("Account Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('carrierId').value ='Verizon' ;");
         Thread.Sleep(2000);
            javascriptClick(By.XPath("//input[@value='Submit']"));
            Thread.Sleep(3000);
            SwitchToPopUps();
        javascriptClick(By.CssSelector("input.multiSelectRow"));
            Thread.Sleep(1000);
         javascriptClick(By.XPath("//input[@value='OK']"));
            Thread.Sleep(3000);
            SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("ACCOUNTS");
         Assert.AreEqual("Verizon", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Verizon']")).Text);
         Console.WriteLine("Accounts Added Successfully");

        }

        
       public void RemoveAccount()
       {


           javascriptClick(By.XPath("//div[.='Verizon']"));
          Thread.Sleep(1000);
           javascriptClick(By.XPath("//input[@value='Remove']"));
      //   BrowserDriver.Instance.Driver.FindElement(By.Id("entityAccountRemoveButton")).Click();
        Thread.Sleep(2000);
         Assert.IsFalse(IsElementVisible(By.XPath("//div[.='Verizon']")),"Account removal failed");
         Console.Write("Account deleted Succesfully");

       }
       
         //CostCenter Tab Assigning Cost Center to Entity
        public void AssignCostCenter()
        {
            SwitchToContent();
            retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[16]");
             Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTERS");
            javascriptClick(By.XPath("//input[@value='Add']"));
     //    BrowserDriver.Instance.Driver.FindElement(By.Id("assignEntityCostCenterButton")).Click();
         Thread.Sleep(2000);
        SwitchToPopUps();
         Assert.AreEqual("Cost Center Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            javascriptClick(By.XPath("//input[@value='Submit']"));
         Thread.Sleep(3000);
         SwitchToPopUps();
         javascriptClick(By.CssSelector("input.multiSelectRow"));
        Thread.Sleep(1000);
         javascriptClick(By.XPath("//input[@value='OK']"));
            Thread.Sleep(2000);
             Thread.Sleep(2000);
        SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTERS");
         Assert.IsTrue(IsElementVisible(By.XPath("//div[.='ACTIVE']")), "Adding cost center not successful");
    //     Assert.AreEqual("ACTIVE", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"ACTIVE\"]")).Text);
         Console.WriteLine("\n Cost Center Added Successfully");
        }

        public void UpdateFTE()
        {
            javascriptClick(By.XPath("//div[.='ACTIVE']"));
            typeDataName("numberOfEmployees", "5");
          //  ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.FindElementsByName('numberOfEmployees')[0].value='5'");
            javascriptClick(By.XPath("//input[@value='Save']"));
            Thread.Sleep(2000);
         Console.WriteLine("Cost Center FTE Updated Successfully");

        }

        public void DeleteCostCenter()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTERS");
            javascriptClick(By.XPath("//div[.='ACTIVE']"));
            javascriptClick(By.XPath("//input[@value='Remove']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTERS");
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='5']")), "Adding cost center not successful");
            Console.WriteLine("Cost Center Deleted Successfully");

        }
         
        public void ExtendedAttributes()
        {
             
         SwitchToContent();
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[18]");
         Thread.Sleep(2000);
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("EXTENDED_ATTRIBUTES");
         Assert.AreEqual("GL Account", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='GL Account']")).Text);
         Thread.Sleep(2000);
            javascriptClick(By.XPath("//div[.='GL Account']"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('extAttributeText').value='1'");
                        javascriptClick(By.XPath("//input[@value='Update']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("EXTENDED_ATTRIBUTES");
     //    Assert.AreEqual("1", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='1']")));
         Assert.IsTrue(IsElementVisible(By.XPath("//div[.='1']")), "Value not added successful");
            Console.WriteLine("Value Added Successfully");
        }
            

        public void ClearExtendAttribute()
        {
        
         javascriptClick(By.XPath("//input[@value='Clear']"));
       //  Assert.IsFalse(IsElementVisible(By.XPath("//div[.='1']")), "Value not cleared successfuly");
         Assert.AreNotEqual("1", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='GL Account']")).Text);
         Console.WriteLine("Extended Attributed valued cleared successfully");
        }
         

           
#endregion
        
    }
}
