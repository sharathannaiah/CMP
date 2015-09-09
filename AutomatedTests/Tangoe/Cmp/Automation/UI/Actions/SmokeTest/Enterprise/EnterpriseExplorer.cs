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
         //   retryingFindClickk(".//*[@id='mnuEnterprise_Explorer2']");
         //   Thread.Sleep(2000);
            CreateEntity();
            
      //      DeleteEntity();
        ///    CreateEntity();
            EditEntity();
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
           
        //Create Entity Marriott
        public void CreateEntity()
        {
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("NewTableEn")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(IsElementVisible(By.Id("tab1")), "Unable to display create new entity details table");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='modifyEntityFormDV']/div[2]/input")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            Assert.AreEqual("Validation", BrowserDriver.Instance.Driver.FindElement(By.XPath("html/body/fieldset/legend")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("html/body/fieldset/legend")), "No validation provided for category");
            //Assert.IsTrue(IsElementVisible(By.Id("entityName")), "No validation provided for entity name");
            javascriptClick(By.Id("OK"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            //BrowserDriver.Instance.Driver.FindElement(By.Name("entityName")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('entityName')[0].value='IBM'");
            //BrowserDriver.Instance.Driver.FindElement(By.Name("siteId")).Clear();
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            //    ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('siteId')[0].value='+ random'");
            BrowserDriver.Instance.Driver.FindElement(By.Name("siteId")).SendKeys("" + random);


            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('companyId').selectedIndex = 1;");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('orgEntityTypeId').selectedIndex = 6;");

            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('type').selectedIndex = 1;");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('siteStatus').selectedIndex = 0;");
            //     BrowserDriver.Instance.Driver.FindElement(By.Name("npanxx")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('npanxx')[0].value='55555'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('businessHours')[0].value='7'");
            //     BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlopenedDate")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.date));
            //      BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('notes').value='Entity creation'");
            //     BrowserDriver.Instance.Driver.FindElement(By.Name("ldn")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('ldn')[0].value='7777777'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('phone2')[0].value='999999'");
            //    BrowserDriver.Instance.Driver.FindElement(By.Name("phone2")).Clear();
            //  BrowserDriver.Instance.Driver.FindElement(By.Name("phone1")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('phone1')[0].value='0000000'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('fax')[0].value='5555555555'");
            //       BrowserDriver.Instance.Driver.FindElement(By.Name("fax")).Clear();
            //        BrowserDriver.Instance.Driver.FindElement(By.Name("fax")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.fax));
            Thread.Sleep(1000);
            javascriptClick(By.Name("save"));
            // BrowserDriver.Instance.Driver.FindElement(By.Name("save")).SendKeys(Keys.Enter);
            //javascriptClick(By.Name("save"));
            Thread.Sleep(3000);
            //javascriptClick(By.XPath("//input[@value='OK']"));
            
            Console.WriteLine("Entity Created Successfully");
        }
       


        public void EditEntity()
        {
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('entityName')[0].value='IBM'");
            javascriptClick(By.Name("queryEnterpriseButton"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('companyId').selectedIndex = 0;");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('type').selectedIndex = 1;");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('businessHours')[0].value='5'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('ldn')[0].value='9999999999'");
            javascriptClick(By.Name("save"));
            Thread.Sleep(3000);
            //javascriptClick(By.XPath("//input[@value='OK']"));
            Assert.AreEqual("Entity creation", BrowserDriver.Instance.Driver.FindElement(By.Name("notes")).Text);
            Console.WriteLine("Created Entity Edited Successfully");

        }

        public void DeleteEntity()
        {
           
           // ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg){return true;};");

            //BrowserDriver.Instance.Driver.FindElement(By.Id("tab2")).Click();
            //Thread.Sleep(2000);
            //SwitchToContent();
            //BrowserDriver.Instance.Driver.FindElement(By.ClassName("clsCollapse")).Click();
            //Thread.Sleep(2000);
            //SwitchToContent();
            //javascriptClick(By.XPath("//span[@title='IBM']"));
            //Thread.Sleep(2000);
            //SwitchToContent();
            
            Thread.Sleep(5000);
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(Enterp.Default.DeleteB));

           // javascriptClick(By.XPath("//input[@value='Delete']"));
         //   BrowserDriver.Instance.Driver.FindElement(By.CssSelector("button:contains('OK')")).Click();


            Thread.Sleep(5000);

     //     ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.prompt = function(msg) { return true; }");
         //   javascriptClick(By.XPath("//input[@value='Delete']"));
       //     BrowserDriver.Instance.Driver.FindElement(By.Id("deleteb")).Click();     
         //   Thread.Sleep(2000);
            //IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
          //  alert.Accept();
           // Thread.Sleep(2000);
            Assert.IsFalse(IsElementVisible(By.XPath("//div[.='IBM']")), "Entity Deletion failed");//div([.='Main'][1])
            Console.WriteLine("Entity Deleted Successfully");

        }

        public void CreateAddress()
        {
            SwitchToContent();
            //BrowserDriver.Instance.Driver.FindElement(By.Id("tab2")).Click();
            // BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#divTabstriptabstripDetails > #tab2")).Click();
          //  Thread.Sleep(2000);
            retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[4]");
            Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab2']")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=ADDRESS | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("create")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            //Assert.AreEqual("Create/Modify Address", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to create Address page failed");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('addressType').selectedIndex = 1;");
            BrowserDriver.Instance.Driver.FindElement(By.Id("addressType")).SendKeys("Main");
          //  new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("addressType"))).SelectByText("Main");
         //   BrowserDriver.Instance.Driver.FindElement(By.Id("street1")).Clear();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('street1').value='123'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('street2').value='abc'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('street3').value='xyz'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('city').value='Miami1'");
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("countryCode"))).SelectByText("United States");
            // new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("stateCode"))).SelectByText("Washington");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('postalCode').value='77777'");
            // BrowserDriver.Instance.Driver.FindElement(By.Name("primaryInd")).Click();
            javascriptClick(By.Name("returnButtonIds"));
            //BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='77777']")), "Creating Address to entity failed");
            Console.WriteLine("Address Created to Entity Successfully");


            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('entityName')[0].value='Marriott'");
            javascriptClick(By.Name("queryEnterpriseButton"));
            Thread.Sleep(3000);
            //Assert the address is created for entity
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=ADDRESS | ]]
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='add']")).Click();
            Thread.Sleep(3000);
            SwitchToPopUps();
            //Assert if page is opened
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            javascriptClick(By.Name("queryAddressButton"));
     //     BrowserDriver.Instance.Driver.FindElement(By.Name("queryAddressButton")).Click();
            Thread.Sleep(3000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg){return true;};");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            javascriptClick(By.Name("returnButtonIds"));
            //BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='77777']")), "Adding Address to entity failed"); 
            Console.WriteLine("Address Added to Entity Successfully");


        }


        public void ModifyAddress()
        {
            //Switch to Address tab to modify address
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            BrowserDriver.Instance.Driver.FindElement(By.Id("modify")).Click();
            Thread.Sleep(4000);
            SwitchToPopUps();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("createAddressForm");
 //           ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('addressType').selectedIndex = 4;");
      //      new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("addressType"))).SelectByText("Billing Address");
           ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('street2').value='777'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('street3').value='San Andreas'");
            javascriptClick(By.Name("returnButtonIds"));
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
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('demarcTypeId').selectedIndex = 2;");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('building').value='777'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('floor').value='333'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('suite').value='555'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('room').value='999'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('department').value='000'");
            BrowserDriver.Instance.Driver.FindElement(By.Id("primaryDemarcIndicator")).Click();
        //    javascriptClick(By.XPath(".//*[@id='bnOK']"));
            retryingFindClick(By.XPath("//input[@value='OK']"));

        //    BrowserDriver.Instance.Driver.FindElement(By.Id("bnOK")).SendKeys(Keys.Enter);
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
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('demarcTypeId').selectedIndex = 1;");
          //  new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("demarcTypeId"))).SelectByText("Extended");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('floor').value='555'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('suite').value='777'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('room').value='000'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('building').value='999'");
           
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("bnOK")).SendKeys(Keys.Enter);
            retryingFindClick(By.XPath("//input[@value='OK']"));

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
       //  BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#divTabstriptabstripDetails > #tab3")).Click();
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
         javascriptClick(By.XPath("//input[@value='Submit']"));
        // BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
         Thread.Sleep(4000);
         SwitchToPopUps();
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='CHARLES']")).Click();
         Thread.Sleep(2000);
      //   BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         javascriptClick(By.XPath("//input[@value='OK']"));
             Thread.Sleep(2000);
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTACTS");
      //   Assert.AreEqual("CHARLES", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"CHARLES\"]")).Text);
         Assert.IsTrue(IsElementVisible(By.XPath("//div[.='CHARLES']")), "Demarc modification failed");

        //Assert.IsTrue(IsElementVisible(By.XPath("//div[@title=\"CHARLES\"]")), "Adding Contact failed");//img
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
         javascriptClick(By.Name("returnButtonIds"));
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
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTRACTS | ]]
         SwitchToContent();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTRACTS");
         Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Text);
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


           javascriptClick(By.XPath("//div[@title='/'Verizon'/]"));
          Thread.Sleep(1000);
           javascriptClick(By.XPath("//input[@value='Remove']"));
      //   BrowserDriver.Instance.Driver.FindElement(By.Id("entityAccountRemoveButton")).Click();
        Thread.Sleep(2000);
         Assert.AreNotEqual("Verizonn",BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Verizon']")).Text);
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
         Assert.AreEqual("ACTIVE", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"ACTIVE\"]")).Text);
         Console.WriteLine("Cost Center Added Successfully");
        }

        public void UpdateFTE()
        {
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.FindelementsByName('numberOfEmployees')[0].value='5'");
            javascriptClick(By.XPath("//input[@value='Save']"));
            Thread.Sleep(2000);
         Console.WriteLine("Cost Center FTE Updated Successfully");

        }

        public void DeleteCostCenter()
        {
            javascriptClick(By.XPath("//input[@value='Remove']"));
         Assert.AreNotEqual("ACTIVE", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"ACTIVE\"]")).Text);
            Console.WriteLine("Cost Center Deleted Successfully");

        }
         
         
         //BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#divTabstriptabstripDetails > #tab7")).Click();
        

     //    BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
        
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
         Assert.AreEqual("Yes", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Yes']")).Text);

            Console.WriteLine("Value Added Successfully");

        }
            

        public void ClearExtendAttribute()
        {
        
                        javascriptClick(By.XPath("//input[@value='Clear']"));
         Assert.AreNotEqual("Yes", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='GL Account']")).Text);
         Console.WriteLine("Extended Attributed valued cleared successfully");


        }
         

           
#endregion
        
    }
}
