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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise
{
    class EnterpriseExplorer :BaseActions
    {
        
#region Create Enterprise
        public void EnterpriseExplorerr()
        {
            GoToMain("Enterprise");
            retryingFindClickk(".//*[@id='mnuEnterprise_Explorer2']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("NewTableEn")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(IsElementVisible(By.Id("tab1")), "Unable to display create new entity details table");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='modifyEntityFormDV']/div[2]/input")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");

            Assert.AreEqual("Validation", BrowserDriver.Instance.Driver.FindElement(By.XPath("html/body/fieldset/legend")).Text);

            Assert.IsTrue(IsElementVisible(By.XPath("html/body/fieldset/legend")), "No validation provided for category");
            //     Assert.IsTrue(IsElementVisible(By.Id("entityName")), "No validation provided for entity name");
            BrowserDriver.Instance.Driver.FindElement(By.Id("OK")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("NewTableEn")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            BrowserDriver.Instance.Driver.FindElement(By.Name("entityName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("entityName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.entityName));

            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("companyId"))).SelectByText("CORPORATE");
            BrowserDriver.Instance.Driver.FindElement(By.Name("siteId")).Clear();
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("siteId")).SendKeys("" + random);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("orgEntityTypeId"))).SelectByText("1-1");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("type"))).SelectByText("Physical");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("siteStatus"))).SelectByText("Open");
            BrowserDriver.Instance.Driver.FindElement(By.Name("npanxx")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("npanxx")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.npanxx));
            BrowserDriver.Instance.Driver.FindElement(By.Name("businessHours")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("businessHours")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.businessHours));
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlopenedDate")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.date));
            BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).SendKeys("hii");
            BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).SendKeys("Creating Thomson Entity");
            BrowserDriver.Instance.Driver.FindElement(By.Name("ldn")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("ldn")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.ldn));
            BrowserDriver.Instance.Driver.FindElement(By.Name("phone2")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("phone2")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.phone2));
            BrowserDriver.Instance.Driver.FindElement(By.Name("phone1")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("phone1")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.phone1));
            BrowserDriver.Instance.Driver.FindElement(By.Name("fax")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("fax")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.fax));
            BrowserDriver.Instance.Driver.FindElement(By.Name("save")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Console.WriteLine("Entity Created Successfully");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");

            //BrowserDriver.Instance.Driver.FindElement(By.Id("tab2")).Click();
            // BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#divTabstriptabstripDetails > #tab2")).Click();
            Thread.Sleep(2000);
            retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[4]");
            Thread.Sleep(2000);

            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='tab2']")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=ADDRESS | ]]
            BrowserDriver.Instance.Driver.FindElement(By.Id("create")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //Assert.AreEqual("Create/Modify Address", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to create Address page failed");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("addressType"))).SelectByText("Main");
            BrowserDriver.Instance.Driver.FindElement(By.Id("street1")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("street1")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.street1));
            BrowserDriver.Instance.Driver.FindElement(By.Id("street2")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("street2")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.street2));
            BrowserDriver.Instance.Driver.FindElement(By.Id("street3")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("street3")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.street3));
            BrowserDriver.Instance.Driver.FindElement(By.Id("city")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("city")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.city));
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("countryCode"))).SelectByText("United States");
            //  Thread.Sleep(2000);
            // new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("stateCode"))).SelectByText("Washington");
            BrowserDriver.Instance.Driver.FindElement(By.Id("postalCode")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("postalCode")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.pincode));
            // BrowserDriver.Instance.Driver.FindElement(By.Name("primaryInd")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            Console.WriteLine("Address Added to Entity Successfully");
            //Assert the address is created for entity
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            //// ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=ADDRESS | ]]
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='add']")).Click();
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //Assert if page is opened
            // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryAddressButton")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            //Switch to Address tab to modify address
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            BrowserDriver.Instance.Driver.FindElement(By.Id("modify")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("addressType"))).SelectByText("Billing Address");
            BrowserDriver.Instance.Driver.FindElement(By.Id("street1")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("street1")).SendKeys("105");
            BrowserDriver.Instance.Driver.FindElement(By.Id("postalCode")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("postalCode")).SendKeys("707070");
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADDRESS");
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Washington']")), "Modification of Address failed"); //[@id='jstabletableAddress']/div/div[2]
            Console.WriteLine("Modification of Address Successful");
            Thread.Sleep(2000);


            //Demarc Tab 
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[6]");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("DEMARCS");
            Thread.Sleep(2000);
            // BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#divTabstriptabstripDetails > #tab9")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnAdd")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            Assert.AreEqual("Demarc", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("demarcTypeId"))).SelectByText("Primary");
            BrowserDriver.Instance.Driver.FindElement(By.Id("building")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("building")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.building));
            BrowserDriver.Instance.Driver.FindElement(By.Id("floor")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("floor")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.floor));
            BrowserDriver.Instance.Driver.FindElement(By.Id("suite")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("suite")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.suite));
            BrowserDriver.Instance.Driver.FindElement(By.Id("room")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("room")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.room));
            BrowserDriver.Instance.Driver.FindElement(By.Id("department")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("department")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.department));
            BrowserDriver.Instance.Driver.FindElement(By.Id("primaryDemarcIndicator")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnOK")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("DEMARCS");
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Primary']")), "Demarc creation failed");//div([.='Main'][1])
            Console.WriteLine("Creation of Demarc Successful");

            //Modification of Demarc
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnModify")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("demarcTypeId"))).SelectByText("Extended");
            BrowserDriver.Instance.Driver.FindElement(By.Id("building")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("building")).SendKeys("9");
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnOK")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("DEMARCS");
            //  Assert.AreEqual("Extended", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"Extended\"]")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='9']")), "Demarc modification failed");
            Console.WriteLine("Modification of Demarc Successful");


         //Contacts Tab
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
       //  BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#divTabstriptabstripDetails > #tab3")).Click();
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[8]");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTACTS");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.FindElement(By.Id("addEntityContactButton")).Click();
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         Assert.AreEqual("Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).Clear();
         BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).SendKeys("CHARLES");
         BrowserDriver.Instance.Driver.FindElement(By.Name("lastName")).Clear();
         BrowserDriver.Instance.Driver.FindElement(By.Name("lastName")).SendKeys("ABBINANTI");
         BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
         Thread.Sleep(3000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='CHARLES']")).Click();
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTACTS");
        // Assert.AreEqual("CHARLES", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"CHARLES\"]")).Text);
         Assert.IsTrue(IsElementVisible(By.XPath("//div[.='CHARLES']")), "Adding Contact failed");
         Console.WriteLine("Contacts added to Entity successfully");
         BrowserDriver.Instance.Driver.FindElement(By.Id("addEntityContactButton")).Click();
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
         Thread.Sleep(3000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
    //     BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTACTS | ]]
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTACTS");

         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='No']")).Click();
        // Assert.AreEqual("630-226-4880", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"630-226-4880\"]")).Text);
         BrowserDriver.Instance.Driver.FindElement(By.Id("removeEntityButton")).Click();
         Console.WriteLine("Contact deleted successfully");
         Thread.Sleep(2000);


         //Carrier Tab
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[10]");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CARRIERS");
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CARRIERS | ]]
         BrowserDriver.Instance.Driver.FindElement(By.Id("addEntityCarrierButton")).Click();
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //Assert.AreEqual("Carrier Lookup", BrowserDriver.Instance.Driver.Title);
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).Clear();
         BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).SendKeys("Trusted Carrier");
         BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CARRIERS");
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CARRIERS | ]]
         Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Text);
        Console.WriteLine("Carrier Added successfully");
         BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).Clear();
         BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).SendKeys("Trusted Carrier and the best");
         BrowserDriver.Instance.Driver.FindElement(By.Name("modifyEntityCarrierButton")).Click();
         Thread.Sleep(2000);
         Assert.AreEqual("Trusted Carrier and the best", BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).GetAttribute("value"));
            Console.WriteLine("Carrier modification successful");
         BrowserDriver.Instance.Driver.FindElement(By.Id("addEntityCarrierButton")).Click();
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='PolledPBX']")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CARRIERS | ]]
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CARRIERS");
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='PolledPBX']")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Name("removeEntityCarrierButton")).Click();
         Console.WriteLine("Carrier removed successfully");
         Thread.Sleep(2000);

///////////////////////////////////////////// Code working fine till here///////////////////////////////////////////////////////////////

        //Contract Tab
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[12]");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTRACTS");
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTRACTS | ]]
         BrowserDriver.Instance.Driver.FindElement(By.Id("addEntityContractButton")).Click();
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
        // Assert.AreEqual("Contract Lookup", BrowserDriver.Instance.Driver.Title);
         BrowserDriver.Instance.Driver.FindElement(By.Name("queryNegotiatedContractsButton")).Click();
         Thread.Sleep(4000);
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         Thread.Sleep(2000);
         // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=CONTRACTS | ]]
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTRACTS");
         Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='AT&T']")).Text);
         BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).Clear();
         BrowserDriver.Instance.Driver.FindElement(By.Id("notes")).SendKeys("12345");
         BrowserDriver.Instance.Driver.FindElement(By.Name("modifyEntityContractButton")).Click();
         Thread.Sleep(2000);
         Assert.AreEqual("12345", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='12345']")).Text);
         Console.WriteLine("Contract to Entity assigned successfully");

         //Accounts Tab Assigning Accounts to Entity 
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[14]");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("ACCOUNTS");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.FindElement(By.Id("assignEntityAccountButton")).Click();
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         Assert.AreEqual("Account Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         BrowserDriver.Instance.Driver.FindElement(By.Name("queryCostCentersButton")).Click();
         Thread.Sleep(3000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("ACCOUNTS");
         Assert.AreEqual("Verizon", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Verizon']")).Text);
         Console.WriteLine("Accounts Added Successfully");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Verizon']")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Id("entityAccountRemoveButton")).Click();
         BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
         Assert.AreNotEqual("Verizonn",BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Verizon']")).Text);
         Console.Write("Account deleted Succesfully");
         BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
         
         //CostCenter Tab Assigning Cost Center to Entity
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[16]");
         //BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#divTabstriptabstripDetails > #tab7")).Click();
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTERS");
         BrowserDriver.Instance.Driver.FindElement(By.Id("assignEntityCostCenterButton")).Click();
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         Assert.AreEqual("Cost Center Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         BrowserDriver.Instance.Driver.FindElement(By.Name("queryCostCentersButton")).Click();
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
         BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTERS");
         Assert.AreEqual("ACTIVE", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"ACTIVE\"]")).Text);
         Console.WriteLine("Cost Center Added Successfully");
         BrowserDriver.Instance.Driver.FindElement(By.Name("numberOfEmployees")).SendKeys("5");
         BrowserDriver.Instance.Driver.FindElement(By.Id("updateEntityCostCenterButton")).Click();
         Console.WriteLine("Cost Center Modified Successfully");
         Thread.Sleep(2000);

            //Extended Attribute
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         retryingFindClickk(".//*[@id='divTabstriptabstripDetails']/div[18]");
         Thread.Sleep(2000);
         BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
         BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         BrowserDriver.Instance.Driver.SwitchTo().Frame("EXTENDED_ATTRIBUTES");
         Assert.AreEqual("GL Account", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='GL Account']")).Text);
         Thread.Sleep(2000);
         new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("extAttributeList"))).SelectByText("Yes");
         BrowserDriver.Instance.Driver.FindElement(By.Id("eaSaveButton")).Click();
         Thread.Sleep(2000);
         Assert.AreEqual("Yes", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Yes']")).Text);
         Console.WriteLine("Extended Attributed updated successfully");

        }

#endregion
        
    }
}
