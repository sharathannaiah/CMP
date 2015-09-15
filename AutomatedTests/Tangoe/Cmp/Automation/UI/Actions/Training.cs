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
//using OpenQA.Selenium.JavascriptExecutor;
namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete
{
    class Training : BaseActions
    {
        #region Helper Methods

        public void Navigation()
        {
            // Call Base action class to navigate to enterprise menu
          //  GoToEnterprise("Enterprise");
            // Navigate to Enterprise--> Explorer page
            retryingFindClickk(".//*[@id='mnuEnterprise_Explorer2']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //  BrowserDriver.Instance.Driver.Navigate().GoToUrl("javascript:document.getElementById('pageTitle').click()");
            //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //  WaitForElementOnNextPage(By.Id("pageTitle"), "Navigation to Enterprise Explorer Failed");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Entity Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Enterprise--> Explorer page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to Employee --> Explorer
            BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
            // Navigate to Employee
            retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
            //Navigate to Employee Explorer
            retryingFindClickk(".//*[@id='mnuEmployees_Explorer']");
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Employee Management", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Enterprise--> Employee --> Explorer page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);

            //Navigate to employee --> Support Ticket
            BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
            retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
            retryingFindClickk(".//*[@id='mnuEmployees_HelpDeskTickets']");
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("HELPDESKTICKETS");
            Assert.AreEqual("Help Desk Support Tickets", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Enterprise--> employee --> Support Ticket page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);

            //Navigate to types
            BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
            //Navigate to Types
            BrowserDriver.Instance.Driver.FindElement(By.Id("mnuEnterprise_Types")).Click();
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            Assert.AreEqual("Modify Entity Types", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ModifyEntityTypeForm']/input[3]")).SendKeys(Keys.Enter);
            //  BrowserDriver.Instance.Driver.Navigate().Refresh();
            //Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Enterprise-->Types Failed");
            //  Assert.IsTrue(IsElementVisible(By.Id("divContentsmainTabControl")), "Navigation to Enterprise-->Types Failed");
            // BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ModifyEntityTypeForm']/input[3]")).Click(); //.//*[@id='dWnd1']/table/tbody/tr[1]/td[4]/img
            // Thread.Sleep(10000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
            // BrowserDriver.Instance.Driver.Navigate().GoToUrl("javascript:document.getElementById('tgx-main-container').click()");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("tgx-main-container")).Click();


            //Navigate to Regions
            //GoToEnterprise("Enterprise");
           // BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
          //  BrowserDriver.Instance.Driver.Navigate().GoToUrl("javascript:document.getElementById('menuMainEnterprise').click()");
            retryingFindClickk(".//*[@id='mnuEnterprise_Region']");
          //  BrowserDriver.Instance.Driver.FindElement(By.Id("mnuEnterprise_Region")).Click();
            Thread.Sleep(1000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            Assert.AreEqual("Enterprise Region Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            BrowserDriver.Instance.Driver.FindElement(By.Id("closeButton")).SendKeys(Keys.Enter);
            // Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Enterprise-->Regions Failed");
            // BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='dWnd1']/table/tbody/tr[1]/td[4]/img")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Console.Write("Navigation to Enterprise Module Successful\n");
            Thread.Sleep(1000);


            //////////////////////////////////////////////////Contract////////////////////////////////////////////////////////////////

            //Navigate to contract
            BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainContracts")).Click();
            //Navigate to Explorer
            retryingFindClickk(".//*[@id='mnuContracts_Explorer27']");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Contracts", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to contract-->Explorer page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);
            Console.Write("Navigation to Contracts Module Successful\n");

            /////////////////////////////////////////////////////Inventory///////////////////////////////////////////////////////////

            //Navigate to Inventory --> Explorer
            GoToMain("Inventory");
            retryingFindClickk(".//*[@id='mnuInventory_ExplorerServices']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Inventory", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Inventory --> Explorer page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to Inventory --> Access Ring
            GoToMain("Inventory");
            retryingFindClickk(".//*[@id='mnuInventory_accessRing']");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Inventory Access Rings", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Inventory --> Access Ring page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to Inventory --> Data Networks
            GoToMain("Inventory");
            retryingFindClickk(".//*[@id='mnuInventory_DataNetwork']");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Data Networks", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Inventory --> Data Networks page failed");//    Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Inventory --> Access Ring page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to Inventory --> Inventory discovery
            GoToMain("Inventory");
            retryingFindClickk(".//*[@id='mnuInventory_DiscoverInventory']");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Inventory Discovery", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Inventory --> Inventory discovery page failed");//    Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Inventory --> Access Ring page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Console.WriteLine("Navigation to Inventory Module Successful\n");
            Thread.Sleep(1000);

            //////////////////////////////////////////////////////////////////Provisioning///////////////////////////////////////////////////////

            //Navigate to Provisioning Hub
            GoToMain("Provisioning");
            retryingFindClickk(".//*[@id='mnuProvisionHub']");
            Thread.Sleep(5000);
            Assert.AreEqual("Hub", BrowserDriver.Instance.Driver.FindElement(By.Id("pageTitle")).Text);
            Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Provisioning Hub failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();



            //Navigate to Provisioning -->Explorer
            GoToMain("Provisioning");
            retryingFindClickk(".//*[@id='mnuProvisionExplorer']");
            Thread.Sleep(3000);
            WaitForElement(By.Id("pageTitle"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            Assert.AreEqual("Provisioning", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Provisioning -->Explorer page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


            //Navigate to Provisioning --> View Requests
            GoToMain("Provisioning");
            retryingFindClickk(".//*[@id='mnuProvisionRequests']");
            WaitForElement(By.Id("pageTitle"));
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("requestFrame");
            Assert.AreEqual("Requests", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Provisioning --> View Requests page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


            //Navigate to Provisioning --> View Orders
            GoToMain("Provisioning");
            retryingFindClickk(".//*[@id='mnuProvisionOrders']");
            WaitForElement(By.Id("pageTitle"));
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            Assert.AreEqual("Provisioning", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Provisioning --> View Orders page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);

            //Navigate to Provisioning --> Create Request
            GoToMain("Provisioning");
            retryingFindClickk(".//*[@id='mnuProvisionCreate']");
            WaitForElement(By.Id("pageTitle"));
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            Assert.AreEqual("Provisioning", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Provisioning -->Explorer page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to View eBonding Message
            GoToMain("Provisioning");
            retryingFindClickk(".//*[@id='mnuProvisionEbond']");
            WaitForElement(By.Id("pageTitle"));
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("eBonding Messages - Query", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Provisioning --> View eBonding Message page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to Bulk Provisioning Processing --> Batch Request
            GoToMain("Provisioning");
            retryingFindClickk(".//*[@id='mnuProvisionBulk']");
            retryingFindClickk(".//*[@id='mnuProvBulkReq']");
            WaitForElement(By.Id("pageTitle"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("UPLOAD_QUERY");
            Assert.AreEqual("Upload Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Provisioning --> View eBonding Message page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to Provisioning Processing --> Vendor Orders Import 
            GoToMain("Provisioning");
            retryingFindClickk(".//*[@id='mnuProvisionBulk']");
            retryingFindClickk(".//*[@id='mnuProvBulkOrdrImp']");
            WaitForElement(By.Id("pageTitle"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("UPLOAD_QUERY");
            Assert.AreEqual("Upload Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Provisioning --> View eBonding Message page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Console.Write(" Navigation to Provisioning successful\n ");

////////////////////////////////////////////////////////////Bill Management////////////////////////////////////////////////////////////////////////

            ////Navigate to Bill Management --> Invoice Processing
            //GoToBillManagement("Bill Management");
            //retryingFindClickk(".//*[@id='mnuBilling_Invoice_Processing']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //Assert.AreEqual("Invoice Processing", BrowserDriver.Instance.Driver.FindElement(By.Id("pageTitle")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Invoice Processing --> failed");
            

            //////Navigate to Bill Processing --> Upload e-bills
            ////GoToBillManagement("Bill Management");
            ////BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //////Navigate to Upload e-bills
            ////retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            ////retryingFindClickk(".//*[@id='mnuBilling_BillUpload']");
            ////Thread.Sleep(2000);
            ////BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            ////BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            ////BrowserDriver.Instance.Driver.SwitchTo().Frame("BILL_UPLOAD_MAIN");
            ////Assert.AreEqual("Welcome to the CMP Bill Import Wizard. To begin the CMP Bill Import process. Select a carrier billing system below and click Next to continue.", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("span")).Text);
            ////BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ProcessSelectBillingSystem']/div[2]/input[2]")).SendKeys(Keys.Enter);
            ////BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            ////Thread.Sleep(2000);

            //////Navigate to Bill Management --> Bill Processing -->Standard Bill Import
            ////GoToBillManagement("Bill Management");
            ////retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            ////retryingFindClickk(".//*[@id='mnuBilling_StandardBillImport']");
            ////Thread.Sleep(2000);
            ////BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            ////BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            ////BrowserDriver.Instance.Driver.SwitchTo().Frame("BILL_UPLOAD_MAIN");
            ////Assert.AreEqual("Welcome to the CMP Standard Bill Import Wizard. Please complete the applicable information below and select 'Next' to continue.", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("span")).Text);
            ////Assert.IsTrue(IsElementVisible(By.ClassName("btnCMP")), "Navigation to Bill Management --> Invoice Processing --> failed");
            ////BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ProcessSelectBillingSystem']/div[2]/input[2]")).SendKeys(Keys.Enter);
            ////BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            
           

            ////Navigate to Bill Management --> Bill Processing -->Manage Uploads
            //GoToBillManagement("Bill Management");
            //retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            //retryingFindClickk(".//*[@id='mnuBilling_ManageUpload']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("SELECT_BILL_UPLOAD_QUERY");
            //Assert.AreEqual("Select Bill Upload Subset", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management --> Bill Processing --> Manage Uploads page failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //Thread.Sleep(2000);

            ////Navigate to Bill Management --> Bill Processing --> Offline Invoice Entry
            //GoToBillManagement("Bill Management");
            //retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            //retryingFindClickk(".//*[@id='mnuBilling_OfflineInvoice']");
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("Offline Invoice Submission", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management --> Bill Processing --> Offline Invoice Entry failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //Thread.Sleep(1000);

            ////Navigate to Bill Management --> Bill Processing --> Invoice Submission
            //GoToBillManagement("Bill Management");
            //retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            //retryingFindClickk(".//*[@id='mnuBilling_InvoiceSubmission']");
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("Invoice Submission Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text); ;
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management --> Bill Processing --> Invoice Submission failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////Navigate to Bill Management --> Bill Processing --> Manage Bills
            //GoToBillManagement("Bill Management");
            //retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            //retryingFindClickk(".//*[@id='mnuBilling_ManageBills']");
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("SELECT_BILL_QUERY");
            //Assert.AreEqual("Bill Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text); ;
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management --> Bill Processing --> Manage Bills failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to Bill Management --> Bill Processing -->Group Invoice Modification
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            retryingFindClickk(".//*[@id='mnuBilling_GroupInvoiceChange']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            Assert.AreEqual("Group Invoice Modifications", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Bill Management --> Bill Processing -->Group Invoice Modification page Failed");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='dWnd1']/table/tbody/tr[1]/td[4]/img")).SendKeys(Keys.Enter);
            BrowserDriver.Instance.Driver.Navigate().Refresh();
            Thread.Sleep(2000);

            //Navigate to Bill Management --> Bill Processing --> A/P to Export
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            retryingFindClickk(".//*[@id='mnuBilling_Invoice APExport']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("A/P Export Batch Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management -->  Bill Processing --> A/P to Export page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);
           

        //    //Navigate to Accounts --> Account Maintenance
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_BMAccounts']");
        //    retryingFindClickk(".//*[@id='mnuBilling_AccountMaintenance']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Account --> Account Maintenance failed");

        //    //Navigate to Accounts --> Account Discovery
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_BMAccounts']");
        //    retryingFindClickk(".//*[@id='mnuBilling_AccountDiscovery']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Account --> Account Discovery failed");

        //    //Navigate to Accounts --> Account Merge
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_BMAccounts']");
        //    retryingFindClickk(".//*[@id='mnuBilling_AccountMerge']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Account --> Account Merge failed");
        //    BrowserDriver.Instance.Driver.Navigate().Refresh();

        //    //Navigate to Accounts --> Invoice Management
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_BMAccounts']");
        //    retryingFindClickk(".//*[@id='mnuBilling_Invoice_Management']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Account --> Invoice Management failed");

        //    //Navigate to Accounts --> Recurring Invoice
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_BMAccounts']");
        //    retryingFindClickk(".//*[@id='mnuBilling_RecurringInvoices']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Account --> Recurring Invoice failed"); 
            
            
        //    //Navigate to Allocation --> Allocation Processing
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_AllocationMenu']");
        //    retryingFindClickk(".//*[@id='mnuBilling_AllocationProcessing']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Allocation --> Allocation Processing failed"); 

        //    //Navigate to Allocation --> Allocation Query
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_AllocationMenu']");
        //    retryingFindClickk(".//*[@id='mnuBilling_AllocationQuery']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Allocation --> Allocation Query failed"); 

        //    //Navigate to Allocation --> Allocation Query by Cost Center
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_AllocationMenu']");
        //    retryingFindClickk(".//*[@id='mnuBilling_AllocationCostCenter']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Allocation --> Allocation Query by Cost Center failed"); 

        //     //Navigate to Bill View --> Accounts
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_BillView']");
        //    retryingFindClickk(".//*[@id='mnuBilling_Accounts']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Bill View --> Accounts failed"); 

        //    //Navigate to Bill View --> Invoice
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_BillView']");
        //    retryingFindClickk(".//*[@id='mnuBilling_Invoices']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Bill View --> Invoice failed");
 
        //    //Navigate to Bill View --> CDR Inquiry
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_BillView']");
        //    retryingFindClickk(".//*[@id='mnuBilling_CDRInquiry']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Bill View --> CRD Inquiry failed");

                  
        //    //Navigate to Bill Management --> Allocation Code Management
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_AllocationCodeManagement'] ");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Allocation Code Management failed");

        //    //Navigate to Bill Management --> Cost Center Management
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_CostCenterManage']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Cost Center Management failed");

        //    //Navigate to Bill Management --> Cost Center Hub
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_CostCenterManagerHub']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Cost Center Hub failed");

        //    //Navigate to Bill Management --> Credit Management
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_CreditManage']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Credit Management failed"); 

        //    //Navigate to Bill Management --> Saving Tracker
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_DisputeManage']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Saving Tracker failed"); 

            
        //    //Navigate to Bill Management --> Saving Tracker Hub
        //    GoToBillManagement("Bill Management");
        //    retryingFindClickk(".//*[@id='mnuBilling_SavingsTrackerHub']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Saving Tracker Hub failed");

        //    //Navigate to Assurance --> Explorer
        //    GoToMain("Assurance");
        //    retryingFindClickk(".//*[@id='mnuAssurance_Explorer']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Assurance --> Explorer failed");

        //    //Navigate to Assurance --> Test Results
        //    GoToMain("Assurance");
        //    retryingFindClickk(".//*[@id='mnuAssurance_TestResults']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Assurance --> Test Results failed"); 

        //    //Navigate to Assurance --> Test Log --> Event Log
        //    GoToMain("Assurance");
        //    retryingFindClickk(".//*[@id='mnuAssurance_EvtLog']");
        //    retryingFindClickk(".//*[@id='mnuAssurance_EvtLogNu']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Assurance --> Test Log --> Event log failed"); 

        //    //Navigate to Assurance --> Test Log --> Alert Log
        //    GoToMain("Assurance");
        //    retryingFindClickk(".//*[@id='mnuAssurance_EvtLog']");
        //    retryingFindClickk(".//*[@id='mnuAssurance_AlertsNu']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Assurance --> Test Log --> Alert log failed"); 

        //    //Navigate to Reporting --> Operational Reports
        //    GoToMain("Reporting");
        //    retryingFindClickk(".//*[@id='mnuReporting_operational']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigate to Reporting --> Operational Reports failed");

        //    //Navigate to Reporting --> Data Warehouse Reports 
        //    GoToMain("Reporting");
        //    retryingFindClickk(".//*[@id='mnuReporting_DataWarehouse']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to reporting --> Data Warehouse Reports failed");

            
        //    //Navigate to Ad Hoc Reports
        //    GoToMain("Reporting");
        //    retryingFindClickk(".//*[@id='mnuReporting_AdHoc']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Reports --> Ad Hoc Reports failed"); 

        //    //Navigate to Admin --> Assurance --> Install test
        //    GoToMain("Admin");
        //    retryingFindClickk(".//*[@id='mnuAssurance_testUpdates']");
        //    retryingFindClickk(".//*[@id='mnuAssurance_inst']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
        //    Assert.AreEqual("To install a new test, or a new version of an existing test, click Browse and point to the location of the new .JAR file. Or you can also enter a URL in the space provided. After selecting the file click Next to continue.", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("td")).Text); 
        //  //BrowserDriver.Instance.Driver.FindElement(By.XPath("html/body/div[1]/input[2]")).Click();
        //    BrowserDriver.Instance.Driver.Navigate().Refresh();
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            
            
            
        //   //BrowserDriver.Instance.Driver.Navigate().GoToUrl("javascript:document.getElementByXPath('.//*[@id='dWnd1']/table/tbody/tr[1]/td[4]/img').click()");


        //    //Navigate to Admin --> Assurance --> Uninstall test
        //   // Thread.Sleep(2000);
        //   // GoToMain("Admin");
        //    GoToMain("Admin");
        //    //retryingFindClickk(".//*[@id='menuMainAdministration']");
        //    retryingFindClickk(".//*[@id='mnuAssurance_testUpdates']");
        //    retryingFindClickk(".//*[@id='mnuAssurance_uninst']");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    Assert.AreEqual("Select the assurance test that you want to uninstall.", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("td")).Text);
        //    BrowserDriver.Instance.Driver.Navigate().Refresh();
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

        //   //Navigate to Admin --> Bill Management --> Allocation
        //    GoToMain("Admin");
        //    retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
        //    retryingFindClickk(".//*[@id='mnuBilling_AllocationSetupModal']");
        //    Thread.Sleep(2000);
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
        //    // BrowserDriver.Instance.Driver.SwitchTo().Frame("BILL_UPLOAD_MAIN");
        //    Assert.AreEqual("Select a configuration from the list on the left, or click New to create a new configuration.", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("p")).Text);
        //    BrowserDriver.Instance.Driver.Navigate().Refresh();
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////Navigate to Admin --> Bill Management --> Allocation Bucket
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            //retryingFindClickk(".//*[@id='mnuAllocationBuckets']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //// BrowserDriver.Instance.Driver.SwitchTo().Frame("BILL_UPLOAD_MAIN");
            //Assert.AreEqual("Search Criteria", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            //BrowserDriver.Instance.Driver.Navigate().Refresh();
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////Navigate to Admin --> Bill Management --> Bill Import Settings
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            //retryingFindClickk(".//*[@id='mnuBillImportSettings']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
            //// BrowserDriver.Instance.Driver.SwitchTo().Frame("BILL_UPLOAD_MAIN");
            //Assert.AreEqual("Parallel Bill Import", BrowserDriver.Instance.Driver.FindElement(By.Id("srvcHdr")).Text);
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

          //  //Navigate to Admin --> Bill Management --> Fiscal Calendar
          //  GoToMain("Admin");
          //  retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
          //  retryingFindClickk(".//*[@id='mnuBilling_FiscalCalendar']");
          //  Thread.Sleep(2000);
          //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
          //  Assert.AreEqual("Periods", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
          //  Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Bill Management --> Fiscal Calendar failed");
          //  BrowserDriver.Instance.Driver.Navigate().Refresh();
          //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

          //  //Navigate to Admin --> Bill Management --> Inventory 
          //  GoToMain("Admin");
          //  retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
          //  retryingFindClickk(".//*[@id='mnuBilling_AccrualInventory']");
          //  Thread.Sleep(2000);
          //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
          //  Assert.AreEqual("Accrual Calculation", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
          //  Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Bill Management --> Inventory failed");
          //  BrowserDriver.Instance.Driver.Navigate().Refresh();
          //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

           
          //  // //Navigate to Admin --> Bill Management --> GL Number configuration
          //  GoToMain("Admin");
          //  retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
          //  retryingFindClickk(".//*[@id='mnuAcctng_glNumberConfigModal']");
          //  Thread.Sleep(2000);
          //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
          //  Assert.AreEqual("Select a configuration from the list on the left, or click New to create a new configuration.", BrowserDriver.Instance.Driver.FindElement(By.Id("splashDiv")).Text);
          //  Assert.IsTrue(IsElementVisible(By.Id("splashDiv")), "Navigation to Admin--> Bill Management --> GL Number Configuration failed");
          //  BrowserDriver.Instance.Driver.Navigate().Refresh();
          //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

          //  //Navigate to Admin --> Bill Management --> CDR Archive and Restoration
          //  GoToMain("Admin");
          //  retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
          //  retryingFindClickk(".//*[@id='mnuInvoiceArchival']");
          //  Thread.Sleep(2000);
          //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
          ////  BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
          //  Assert.AreEqual("Invoice Archive Query", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
          //  Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Bill Management --> CDR Archive and Restoration failed");
          //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            
          //  // //Navigate to Admin --> Bill Management --> Invoice Validation/Approval
          //  GoToMain("Admin");
          //  retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
          //  retryingFindClickk(".//*[@id='mnuInvoiceValidation']");
          //  Thread.Sleep(2000);
          //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
          //  Assert.AreEqual("Please click on a level in the menu to the left to see the configuration rules for that level, or click New to create rules for a new level.", BrowserDriver.Instance.Driver.FindElement(By.Id("splashText")).Text);
          //  Assert.IsTrue(IsElementVisible(By.Id("splashText")), "Navigation to Admin--> Bill Management --> Invoice Validation/Approval failed");
          //  BrowserDriver.Instance.Driver.Navigate().Refresh();
          //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            
          //  //Navigate to Admin --> Bill Management --> Invoice Approval Rules
          //  GoToMain("Admin");
          //  retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
          //  retryingFindClickk(".//*[@id='mnuInvoiceApprovalRules']");
          //  Thread.Sleep(2000);
          //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
          //  Assert.AreEqual("Select a level in the tree menu to edit the\r\nInvoice Approval Configuration rules for that level.\r\nTo create a new set of rules, choose a vendor and optionally a master account.", BrowserDriver.Instance.Driver.FindElement(By.Id("splashText")).Text);
          //  Assert.IsTrue(IsElementVisible(By.Id("splashText")), "Navigation to Admin--> Bill Management --> Invoice Approval Rules failed");
          //  BrowserDriver.Instance.Driver.Navigate().Refresh();
          //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            
            ////Navigate to Admin --> Bill Management --> Allocation Approval Rules
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            //retryingFindClickk(".//*[@id='mnuAllocationApprovalRules']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //Assert.AreEqual("Select a level in the tree menu to edit the\r\nAllocation Approval Configuration rules for that level.\r\nTo create a new set of rules, choose a vendor and optionally a master account.", BrowserDriver.Instance.Driver.FindElement(By.Id("splashText")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("splashText")), "Navigation to Admin--> Bill Management --> Allocation Approval Rules failed");
            //BrowserDriver.Instance.Driver.Navigate().Refresh();
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            
            //////Navigate to Admin --> Bill Management --> Invoice Export
            // GoToMain("Admin");
            // retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            // retryingFindClickk(".//*[@id='mnuBilling_Invoice_Export']");
            // Thread.Sleep(2000);
            // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            // Assert.AreEqual("Please click on a level in the menu to the left to see the settings for that level.\r\nOr click New to create settings for a new level.", BrowserDriver.Instance.Driver.FindElement(By.Id("splashText")).Text);
            // Assert.IsTrue(IsElementVisible(By.Id("splashText")), "Navigation to Admin--> Bill Management --> Invoice Export failed");
            // BrowserDriver.Instance.Driver.Navigate().Refresh();
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            // //Navigate to Admin --> Bill Management --> Manual Invoice - General Configuration
            // GoToMain("Admin");
            // retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            // retryingFindClickk(".//*[@id='mnuBilling_General']");
            // Thread.Sleep(2000);
            // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            // Assert.AreEqual("Processing", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            // Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Bill Management -->  Manual Invoice - General Configuration failed");
            // BrowserDriver.Instance.Driver.Navigate().Refresh();
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            // //Navigate to Admin --> Bill Management --> Manual Invoice - Fast Entry Configuration
            // GoToMain("Admin");
            // retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            // retryingFindClickk(".//*[@id='mnuBilling_FastEntry']");
            // Thread.Sleep(2000);
            // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            // Assert.AreEqual("Template Attributes", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            // Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Bill Management --> Manual Invoice - Fast Entry Configuration failed");
            // BrowserDriver.Instance.Driver.Navigate().Refresh();
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////// Navigate to Admin --> Bill Management --> Data Validation
            // GoToMain("Admin");
            // retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            // retryingFindClickk(".//*[@id='mnuBilling_Validation']");
            // Thread.Sleep(2000);
            // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            // Assert.AreEqual("Data Validation Level", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            // Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Bill Management --> Data Validation failed");
            // BrowserDriver.Instance.Driver.Navigate().Refresh();
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            // //Navigate to Admin --> Bill Management --> Payments
            // GoToMain("Admin");
            // retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            // retryingFindClickk(".//*[@id='mnuPaymentConfig']");
            // Thread.Sleep(2000);
            // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            // Assert.AreEqual("Select a level in the tree menu to edit the payment rules for that level.", BrowserDriver.Instance.Driver.FindElement(By.Id("splashText")).Text);
            // Assert.IsTrue(IsElementVisible(By.Id("splashText")), "Navigation to Admin--> Bill Management -->  Payments failed");
            // BrowserDriver.Instance.Driver.Navigate().Refresh();
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            
            ////Navigate to Admin --> Bill Management --> Data Products
            // GoToMain("Admin");
            // retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            // retryingFindClickk(".//*[@id='mnuDataProducts']");
            // Thread.Sleep(2000);
            // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            // Assert.AreEqual("Product Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            // Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Bill Management --> Data Products failed");
            // BrowserDriver.Instance.Driver.Navigate().Refresh();
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            
            
            
            ////Navigate to Admin --> Bill Management --> Access Product
            // GoToMain("Admin");
            // retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            // retryingFindClickk(".//*[@id='mnuAccessProducts']");
            // Thread.Sleep(2000);
            // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            // Assert.AreEqual("Product Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            // Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Bill Management --> Access Product failed");
            // BrowserDriver.Instance.Driver.Navigate().Refresh();
            // BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

          //  // //Navigate to Admin --> Bill Management --> USOC Maintenance
          //  GoToMain("Admin");
          //  retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
          //  retryingFindClickk(".//*[@id='mnuUsoc']");
          //  Thread.Sleep(2000);
          //  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          //  BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
          ////  BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
          //  Assert.AreEqual("USOC Maintenance", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
          //  Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Bill Management --> USOC Maintenance failed");
          //  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////Navigate to Admin --> Bill Management --> Standard Bill Import
           // //GoToMain("Admin");
          // // Thread.Sleep(1000);
          // // retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
          // // Thread.Sleep(1000);
          // // retryingFindClickk(".//*[@id='mnuSbiChargeTypes']");
          // // Thread.Sleep(2000);
          // // BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          // // BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
          // // BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTENT");
          // // Assert.AreEqual("USOC Maintenance", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
          // // Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Bill Management --> Standard Bill Import failed");
          //  //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


         //   //Navigate to Admin --> Contracts--> Rate regions
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
         //   retryingFindClickk(".//*[@id='mnuRateRegions']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Rate Region Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         //   Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Contracts--> Rate regions failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Contracts --> Rate Qualifiers
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
         //   retryingFindClickk(".//*[@id='mnuRateQualifiers']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Rate Qualifier Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         //   Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Contracts --> Rate Qualifiers failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Contracts --> Terms
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
         //   retryingFindClickk(".//*[@id='mnuContractTerms']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Terms Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         //   Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Contracts --> Terms failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Contracts --> Tariff
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
         //   retryingFindClickk(".//*[@id='mnuContracts_TariffAdmin']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Tariff Parameters", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         //   Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Bill Management --> Contracts --> Tariff failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Inventory --> Catalog
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_DeviceCatalog']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CAT_DEVICE_DETAILS");
         //   Assert.AreEqual("Equipment Model Results", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Inventory --> Catalog failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Inventory --> Features
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_Features']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Feature Details", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
         //   Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Admin--> Inventory --> Features failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Inventory --> Product speed
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
         //   retryingFindClickk(".//*[@id='mnuProductSpeeds']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("General\r\nSpeed:\r\nSpeed (Kbps):\r\nSystem speed", BrowserDriver.Instance.Driver.FindElement(By.Id("speedsFormDV")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("speedsFormDV")), "Navigation to Admin--> Inventory --> Product speed failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   ////Navigate to Admin --> Inventory --> Network application
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_InventoryAdmin']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_NetworkApplications']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Application Details\r\nApplication ID:\r\nApplication:\r\nDescription:", BrowserDriver.Instance.Driver.FindElement(By.Id("NetworkApplicationFormDV")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("NetworkApplicationFormDV")), "Navigation to Admin--> Inventory --> Network application failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Localization --> Country/State/Province
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Localization']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_CountryAdmin']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("I18N_ADMINCOUNTRY");
         //   Assert.AreEqual("Country Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Localization --> Country/State/Province failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Localization --> Currency Conversion Policy
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Localization']");
         //   retryingFindClickk(".//*[@id='mnuConverstionAdmin']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Currency conversion is date driven. Please choose a date of record from the options below. This date will be used to determine the exchange rate for currency conversion.", BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='saveFormDV']/table[1]/tbody/tr/td/p[1]/label")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("saveFormDV")), "Navigation to Admin--> Localization --> Country/State/Province failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Localization --> Currencies
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Localization']");
         //   retryingFindClickk(".//*[@id='mnuSupportedCurrenciesAdmin']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   Assert.AreEqual("Select Currencies that CMP needs to support and input the Default rate for converting one unit of that currency into Configured Common Currency\r\nCMP will use the default rate in the absence of an exchange rate.\r\nConfigured Common Currency:  USD - United States of America, Dollars", BrowserDriver.Instance.Driver.FindElement(By.Id("defaultFormDV")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("defaultFormDV")), "Navigation to Admin--> Localization --> Currencies failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Localization --> Exchange Rates
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Localization']");
         //   retryingFindClickk(".//*[@id='mnuRateManagementAdmin']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   Assert.AreEqual("Currency Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Localization --> Exchange Rates failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Localization --> Exchange Rates Import
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Localization']");
         //   retryingFindClickk(".//*[@id='mnuCurrencyRateImportAdmin']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CURRENCY_RATE_IMPORT_MAIN");
         //   Assert.AreEqual("To import exchange rates, select the Source, Rate Application and click Next to continue.", BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='page1Info']/form/div/table[1]/tbody/tr[1]/td")).Text);
         //   Assert.IsTrue(IsElementVisible(By.XPath(".//*[@id='page1Info']/form/div/table[1]/tbody/tr[1]/td")), "Navigation to Admin--> Localization --> Exchange Rates Import failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


         //   //Navigate to Admin --> Localization --> Exchange Rates Import Log
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Localization']");
         //   retryingFindClickk(".//*[@id='mnuCurrencyRateImportLog']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Search Criteria", BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='importLogFormDV']/fieldset/legend")).Text);
         //   Assert.IsTrue(IsElementVisible(By.XPath(".//*[@id='importLogFormDV']/fieldset/legend")), "Navigation to Admin--> Localization --> Exchange Rates Import Log failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            
         //   //Navigate to Admin --> Localization --> User Defined Translation
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Localization']");
         //   retryingFindClickk(".//*[@id='mnuBaseTextTransformation']");
         //   Thread.Sleep(2000);
         //   Assert.AreEqual("User Defined Translation", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin--> Localization --> User Defined Translation failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Messaging --> E-Mail Notification 
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Messaging']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_Email_Notifications']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
         //   Assert.AreEqual("Email Notifications", BrowserDriver.Instance.Driver.FindElement(By.XPath("html/body/fieldset/legend")).Text);
         //   Assert.IsTrue(IsElementVisible(By.XPath("html/body/fieldset/legend")), "Navigation to Admin--> Localization --> Exchange Rates Import failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Messaging --> Notifications
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Messaging']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_Notifications']");
         //   Thread.Sleep(2000);
         //   Assert.AreEqual("Notification Administration", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin--> Localization --> Messaging --> Notifications failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


         //   //Navigate to Admin --> Messaging --> Employee Notifications
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Messaging']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_Messages']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMINMESSAGE");
         //   Assert.AreEqual("Message Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Messaging --> Employee Notifications failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


         //   //Navigate to Admin --> Messaging --> Email Audit
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Messaging']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_Email_Audit']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("EMAILAUDITMESSAGE");
         //   Assert.AreEqual("Email Audit Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Messaging --> Email Audit failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();  

         //  //Navigate to Admin --> Messaging --> Email Inbound Audit
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Messaging']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_EmailInb_Audit']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("EMAILINBOUNDAUDITMESSAGE");
         //   Assert.AreEqual("Email Inbound Audit Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Messaging --> Email Inbound Audit failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();  
            

         // //Navigate to Admin --> Miscelleneous --> Carriers
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_Carriers']");
         //   Thread.Sleep(2000);
         //   Assert.AreEqual("Carrier Maintenance", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin--> Miscelleneous --> Carriers failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         // //Navigate to Admin --> Miscelleneous --> Carrier Merge
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_CarrierMerge']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   Assert.AreEqual("Merge Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Miscelleneous --> Carrier Merge failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         ////Navigate to Admin --> Miscelleneous --> Vendor Remit Address Merge
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_VendorAddressMerge']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   Assert.AreEqual("Merge Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Miscelleneous --> Vendor Remit Address Merge failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

         ////Navigate to Admin --> Miscelleneous --> Companies
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_Companies']");
         //   Thread.Sleep(2000);
         //   Assert.AreEqual("Company Maintenance", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin--> Miscelleneous --> Companies failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //  //Navigate to Admin --> Miscelleneous --> Contacts
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_Contacts']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMINCONTACTS");
         //   Assert.AreEqual("Contact Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Miscelleneous --> Contacts failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

         // //Navigate to Admin --> Miscelleneous --> Extended Attributes
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_EA_new']");
         //   Thread.Sleep(2000);
         //   Assert.AreEqual("Extended Attribute Configuration", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin--> Miscelleneous --> Extended Attributes failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //  // Navigate to Admin --> Miscelleneous --> Dropdown List
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuAdmin_LookupList']");
         //   Thread.Sleep(2000);
         //   Assert.AreEqual("Lookup List Maintenance", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin--> Miscelleneous --> Dropdown List failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

         //   //Navigate to Admin --> Miscelleneous --> Project Code
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuProjectCodes']");
         //   Thread.Sleep(2000);
         //   Assert.AreEqual("Project Maintenance", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin--> Miscelleneous --> Project Code failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


         //   //Navigate to Admin --> Miscelleneous --> Phase Code Maintenanace
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Misc']");
         //   retryingFindClickk(".//*[@id='mnuPhraseCodeMaintenance']");
         //   Thread.Sleep(2000);
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
         //   Assert.AreEqual("Phrase Code Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
         //   Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Miscelleneous --> Phase Code Maintenanace failed");
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

         //   //Navigate to Admin --> Portal --> Configuration
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Portal']");
         //   retryingFindClickk(".//*[@id='mnuEmployeePortal_Config']");
         //   Thread.Sleep(2000);

         //   //Navigate to Admin --> Portal Support Topic
         //   GoToMain("Admin");
         //   retryingFindClickk(".//*[@id='mnu_Portal']");
         //   retryingFindClickk(".//*[@id='mnuSupport_Topic']");
         //   Thread.Sleep(2000);
         //   Assert.AreEqual("Support Topic Maintenance", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
         //   Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin --> Portal Support Topic failed");
         //   BrowserDriver.Instance.Driver.Navigate().Refresh();
         //   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //////Navigate to Admin --> Provisioning
            ////GoToMain("Admin");
            ////retryingFindClickk(".//*[@id='mnu_Provisioning']");
            ////Thread.Sleep(2000);
            ////BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            ////Assert.AreEqual("Select User", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            ////Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin --> Provisioning failed");
            ////BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

            ////Navigate to Admin --> Reporting --> Display Reports
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnu_ReportingAdmin']");
            //retryingFindClickk(".//*[@id='mnuDisplayReports']");
            //Thread.Sleep(2000);
            //Assert.AreEqual("Display Reports", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin --> Reporting --> Display Reports failed");
            //BrowserDriver.Instance.Driver.Navigate().Refresh();
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


            ////Navigate to Admin --> Reporting --> Publish Custom Reports 
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnu_ReportingAdmin']");
            //retryingFindClickk(".//*[@id='mnuPublishCustom']");
            //Thread.Sleep(2000);
            //Assert.AreEqual("Publish Custom Reports", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin --> Reporting --> Publish Custom Reports failed");
            //BrowserDriver.Instance.Driver.Navigate().Refresh();
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();



            ////Navigate to Admin --> Reporting --> Manage Custom Reports 
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnu_ReportingAdmin']");
            //retryingFindClickk(".//*[@id='mnuCustomReportsIntegration']");
            //Thread.Sleep(2000);
            //Assert.AreEqual("Manage Custom Reports", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin --> Reporting --> Manage Custom Reports failed");
            //BrowserDriver.Instance.Driver.Navigate().Refresh();
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();


            ////Navigate to Admin --> System Admin --> Users and Groups 
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            //retryingFindClickk(".//*[@id='mnuAdmin_Security']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("Select User/Group", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> System Admin --> Users and Groups failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

            ////Navigate to Admin --> System Admin --> Passwords 
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            //retryingFindClickk(".//*[@id='mnuAdmin_Policy']");
            //Thread.Sleep(2000);
            //Assert.AreEqual("CMP Security Provider - Policy Administration", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin --> System Admin --> Passwords failed");
            //BrowserDriver.Instance.Driver.Navigate().Refresh();
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////Navigate to Admin --> System Admin --> Properties
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            //retryingFindClickk(".//*[@id='mnuAdmin_PropertiesEditor']"); 
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("SYSTEM_PROPERTIES_EDITOR");
            //Assert.AreEqual("System Properties Editor", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> System Admin --> Properties failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 


            ////Navigate to Admin --> System Admin --> Monitor Users
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            //retryingFindClickk(".//*[@id='mnuAdmin_MonitorUsers']");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> System Admin --> Monitor Users failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

            ////Navigate to Admin --> System Admin --> System Events
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            //retryingFindClickk(".//*[@id='mnuAdmin_SystemEvents']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("SYSTEMAUDITMESSAGE");
            //Assert.AreEqual("Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> System Admin --> System Events failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

            ////Navigate to Admin --> Tools --> Hubs
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_Tools'] ");
            //retryingFindClickk(".//*[@id='mnuAdmin_Hubs']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("Hub Administration", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Tools --> Hubs failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

            ////Navigate to Admin --> Tools --> Scheduler
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_Tools'] ");
            //retryingFindClickk(".//*[@id='mnuAdmin_Scheduler']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Tools --> Scheduler failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent(); 

            ////Navigate to Admin --> Tools  --> Data Load 
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_Tools'] ");
            //retryingFindClickk(".//*[@id='mnuAdmin_DataLoad']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("Upload Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> Tools  --> Data Load  failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////Navigate to Admin --> WorkFlow --> Bulk Reassignment 
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_Workflow'] ");
            //retryingFindClickk(".//*[@id='mnuWorkflowConsole_bulk']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("User's Step Results", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> WorkFlow --> Workflow Designer failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////Navigate to Admin --> WorkFlow --> Management 
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_Workflow'] ");
            //retryingFindClickk(".//*[@id='mnuWorkflowConsole_mgt']");
            //Thread.Sleep(2000);
            //Assert.AreEqual("Workflow Management", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
            //Assert.IsTrue(IsElementVisible(By.Id("dWnd1title")), "Navigation to Admin --> WorkFlow --> Management  failed");
            //BrowserDriver.Instance.Driver.Navigate().Refresh();
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            ////Navigate to Admin --> WorkFlow --> User Availability 
            //GoToMain("Admin");
            //retryingFindClickk(".//*[@id='mnuAdmin_Workflow'] ");
            //retryingFindClickk(".//*[@id='mnuWorkflowConsole_userAvail']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            //Assert.AreEqual("Query Results Summary", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Admin--> WorkFlow --> User Availability  failed");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            
            //Navigate to Admin --> WorkFlow --> Workflow Transfer 
            //Navigate to Admin --> WorkFlow --> Export / Import 
            //Navigate to Admin --> WorkFlow --> Template Instance Control 
            //Navigate to Admin --> WorkFlow --> Engine Monitor 
            //Navigate to Admin --> WorkFlow --> Resource Diagram 

            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).SendKeys(Keys.Enter);
            //BrowserDriver.Instance.Driver.FindElement(By.Id("mnuEnterprise_Explorer2")).SendKeys(Keys.Enter);

        }
        #endregion

#region Enterprise 

#region Create Enterprise
        public void Enterprise()
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

#region Enterprise --> Employee --> Explorer

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
            BrowserDriver.Instance.Driver.FindElement(By.Name("employeeIdentifier")).SendKeys("SA"+random);
            BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("firstName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.firstName));
            BrowserDriver.Instance.Driver.FindElement(By.Name("lastName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("lastName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.lastName));
            new SelectElement (BrowserDriver.Instance.Driver.FindElement(By.Name("contactTypeId"))).SelectByText("Billing Contact");
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

        public void EntityType()
        {
            BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("mnuEnterprise_Types")).Click();
            Thread.Sleep(2000);
            //Create Entity Type 
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("ttab2")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("frmName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("frmName")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeName));
            BrowserDriver.Instance.Driver.FindElement(By.Id("frmDescription")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("frmDescription")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeDescription));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
           BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='CreateEntityTypeForm']/div[2]/input[1]")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            //Modify Entity Type
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            Assert.AreEqual("Name", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Name']")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='Name']")), "Creation of Entity Type failed ");
            Console.WriteLine("Entity Type Added Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).SendKeys("S-2");
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmDescription")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmDescription")).SendKeys(TestProperties.Instance.GetPropertyByName(TestProperty.typeDescription));
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='CreateEntityTypeForm']/div[2]/input[2]")).SendKeys(Keys.Enter);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            Assert.AreEqual("S-2", BrowserDriver.Instance.Driver.FindElement(By.Name("frmName")).Text);
            Assert.IsTrue(IsElementVisible(By.Name("frmName")), "Modification of Entity Type failed ");
            Console.WriteLine("Entity Type modified successfully");
            //Delete Entity Type
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ttab1']/form[2]/input[4]")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Entity deleted Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Name("frmCancel")).SendKeys(Keys.Enter); 

        }
        public void EntityRegion()
        {
            GoToMain("Enterprise");
            BrowserDriver.Instance.Driver.FindElement(By.Id("mnuEnterprise_Region")).Click();
            Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
          
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("1");
           // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_FRAME_DIALOG");
            BrowserDriver.Instance.Driver.FindElement(By.Id("new")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='nameField'])[2]")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='nameField'])[2]")).SendKeys("India");
            BrowserDriver.Instance.Driver.FindElement(By.Id("description")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("description")).SendKeys("India");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='geographyType'])[3]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("saveRegionButton")).Click();
     
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_FRAME_DIALOG");

            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='India']")).Click();
            Assert.AreEqual("India", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='India']")).Text);
            Console.WriteLine("Region Added Successfully");
           // BrowserDriver.Instance.Driver.FindElement(By.XPath("//table[@id='JColResizer3']/tbody/tr[4]/td[2]/div/nobr/div")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("deleteButton")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            
       //     Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Are you sure you want to delete this region[\\s\\S]$"));
            BrowserDriver.Instance.Driver.FindElement(By.Id("closeButton")).Click();
            Console.WriteLine("Deletion of Region Successful");
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
        }

        public void Contract()
        {
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='menuMainContracts']")).Click();
            retryingFindClickk(".//*[@id='mnuContracts_Explorer27']");
            Thread.Sleep(4000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Id("new")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            new SelectElement (BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByText("AT&T");
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("contractTypeId"))).SelectByText("Addendum");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("parentContractId"))).SelectByText("LEC");
            BrowserDriver.Instance.Driver.FindElement(By.Name("contractNumber")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.ClassName("btnCMP")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("contractForm");
            Assert.AreEqual("123", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='123']")).Text);
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='123']")), "Contract Creation failed");
            
            BrowserDriver.Instance.Driver.FindElement(By.LinkText("Contract List")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.FindElement(By.Name("carrierContractNumber")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("carrierContractNumber")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContractsbutton")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("AT&T", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.=AT&T]")).Text);
            Console.WriteLine("Contract Added Successfully");
            BrowserDriver.Instance.Driver.FindElement(By.Id("delete")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();
            Console.WriteLine("Contract deleted successfully");

        }
/// <summary>
/// /////////////////////////////////////////////////////////////////////Inventory/////////////////////////////////////////////////
/// </summary>
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
            //Inventory Discovery Tab

            public void InventoryDiscovery()
            {
                GoToMain("Inventory");
                retryingFindClickk(".//*[@id='mnuInventory_DiscoverInventory']");
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | CONTENT | ]]
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("inventoryType"))).SelectByText("Phone Numbers");
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
                BrowserDriver.Instance.Driver.FindElement(By.Name("queryLinesbutton")).Click();
                Thread.Sleep(3000);

                
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                BrowserDriver.Instance.Driver.FindElement(By.Id("acceptButton")).Click();
                Thread.Sleep(3000);

                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                BrowserDriver.Instance.Driver.FindElement(By.Id("nextButton")).Click();
                Thread.Sleep(2000);
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("flexibleMappingSource"))).SelectByText("Account");
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath("(//select[@name='flexibleMappingSource'])[2]"))).SelectByText("Account");
                new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath("(//select[@name='flexibleMappingSource'])[3]"))).SelectByText("Account");
                BrowserDriver.Instance.Driver.FindElement(By.Id("nextButton")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                Assert.AreEqual("Accepted LINE", BrowserDriver.Instance.Driver.FindElement(By.Id("dWnd1title")).Text);
                Console.WriteLine("Inventory Accepted Successfully");
                BrowserDriver.Instance.Driver.FindElement(By.Id("closeButton")).Click();
                Thread.Sleep(2000);
                Console.WriteLine("Inventory Discovery passed successfully");
            }

        public void CostCenterManagement()
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
            

        //Allocation Code Management
        public void AllocationCodeManagement()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationCodeManagement']");
            WaitForElement(By.Id("pageTitle"));
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            WaitForElement(By.Name("NewTableCC"));
            BrowserDriver.Instance.Driver.FindElement(By.Name("NewTableCC")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            BrowserDriver.Instance.Driver.FindElement(By.Name("allocationCode")).Clear();
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("allocationCode")).SendKeys("" + random);
            BrowserDriver.Instance.Driver.FindElement(By.Id("allocationCodeName")).SendKeys("New Allocation Name");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("allocationCodeTypeLUID"))).SelectByText("Purchase Order#");
            BrowserDriver.Instance.Driver.FindElement(By.Name("save")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Purchase Order#", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='Purchase Order#']")).Text);
            Console.WriteLine("Allocation Code Created Successfully");

            //Allocation Definition Tab
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='allocDefTab']")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCDEF");
            BrowserDriver.Instance.Driver.FindElement(By.Id("addButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Name("nextButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("lookUpIFRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryCostCentersButton")).Click();
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Name("nextButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("Finish")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Allocation Definition Added Successfully");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCDEF");
            BrowserDriver.Instance.Driver.FindElement(By.Name("removeButton")).Click();
            Thread.Sleep(2000);
            Assert.AreNotEqual("Allocate", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='']")).Text);
            Console.WriteLine("Allocation Definition removed successfully");
            Console.WriteLine("Allocation Code Management Passed Successfully");
        }

        public void CreateRequest()
       
        {
            GoToMain("Provisioning");
            //BrowserDriver.Instance.Driver.FindElement(By.Id("mnuProvisionExplorer")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("mnuProvisiontCreate")).Click();
            WaitForElement(By.Id("pageTitle"));
            //[selectFrame | CONTENT | ]]
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
      //      BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("createFrame");      
            BrowserDriver.Instance.Driver.FindElement(By.LinkText("Key System")).Click();
            Thread.Sleep(5000);

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
       //     BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("createFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_setup"); 
            BrowserDriver.Instance.Driver.FindElement(By.Id("addServiceLink")).Click();
            Thread.Sleep(4000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@type='checkbox'])[22]")).Click();
           BrowserDriver.Instance.Driver.FindElement(By.Id("bnOK")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
             BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
      //      BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("createFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.FindElement(By.Id("reqWiz_nextButton")).Click();
            Thread.Sleep(5000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
            //[selectWindow | null | ]]
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderPriorityId"))).SelectByText("Medium");
           BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderBusinessJustification")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderBusinessJustification")).SendKeys("None");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderSourceId"))).SelectByText("Internal");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderTicketNumber")).Clear();
           BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderTicketNumber")).SendKeys("7777777");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderPONumber")).Clear();
           BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderPONumber")).SendKeys("5555555");
           BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderAdditionalInfoName")).Clear();
           BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderAdditionalInfoName")).SendKeys("sharath");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderAdditionalInfoValue")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderAdditionalInfoValue")).SendKeys("777");
            BrowserDriver.Instance.Driver.FindElement(By.Id("bnAddAdditionalInfo")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | CONTENT | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame |  | ]]
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame |  | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
      //      BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
             BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2HeaderOrgEntityId")).Click();
            //[selectWindow | CMP_DIALOG_FRAME | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  
            BrowserDriver.Instance.Driver.FindElement(By.Name("entityName")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Name("entityName")).SendKeys("ACS");
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryEntityButton")).Click();
            Thread.Sleep(2000);
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  
            BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).Click();
            Thread.Sleep(2000);
            //[selectWindow | EditFrame | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
     //       BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
           BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2HeaderPrimaryContactId")).Click();
            Thread.Sleep(2000);
            //[selectWindow | CMP_DIALOG_FRAME | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  
            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
       //     BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
             
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2HeaderVendorId"))).SelectByText("AT&T");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='pm2HeaderBillingType'])[2]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("costCenterAddButton")).Click();
            Thread.Sleep(2000);
            //[selectWindow | CMP_DIALOG_FRAME | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  

            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupeditCostCenterId")).Click();
            Thread.Sleep(2000);
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  

            BrowserDriver.Instance.Driver.FindElement(By.Name("costCenterName")).SendKeys("Trane");
             BrowserDriver.Instance.Driver.FindElement(By.Name("queryCostCentersButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME"); 

           
           BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME"); 
           BrowserDriver.Instance.Driver.FindElement(By.Id("cca_saveButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.FindElement(By.Id("cca_okButton")).Click();

            //[selectWindow | editFrame | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
      //      BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
            BrowserDriver.Instance.Driver.FindElement(By.Id("reqWiz_nextButton")).Click();
            Thread.Sleep(5000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
              BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
   //          BrowserDriver.Instance.Driver.SwitchTo().Frame("menuFrame");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT"); 
            
             BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2VendorContactId")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME"); 

            BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME"); 
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT"); 
            BrowserDriver.Instance.Driver.FindElement(By.Id("dtControlpm2DueDate")).SendKeys("07/07/2015");
          
        
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("ddl_pm2BusinessUnitLuid"))).SelectByText("srd1");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2ManufacturerId"))).SelectByText("Unknown/Other");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("option[value=\"11100\"]")).Click();
            Thread.Sleep(2000);
           BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='pm2ShipToTypeId'])[2]")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2ShipToContactId")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME"); 

           BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);

             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME"); 

            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).Click();
            Thread.Sleep(2000);


            //[selectWindow | null | ]] Fill in the template details
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT"); 
             BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress1")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress1")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress2")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress2")).SendKeys("456");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress3")).Clear();
             BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress3")).SendKeys("789");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCity")).Clear();
             BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCity")).SendKeys("Bangalore");
            new SelectElement( BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCountryId"))).SelectByText("United States");
            Thread.Sleep(3000);
             BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryZip")).Clear();
             BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryZip")).SendKeys("560001");

            
            //[selectWindow | reqWizFrame_header | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");  

              BrowserDriver.Instance.Driver.FindElement(By.Id("reqWiz_nextButton")).Click();
            Thread.Sleep(2000);


            //[selectWindow | Equipment 2 | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT"); 
            
               BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2VendorContactId")).Click();
            Thread.Sleep(2000);
            // [selectWindow | CMP_DIALOG_FRAME | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  
             BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  
            BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).Click();
            Thread.Sleep(2000);

            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT"); 
            new SelectElement( BrowserDriver.Instance.Driver.FindElement(By.Id("ddl_pm2BusinessUnitLuid"))).SelectByText("srd1");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("pm2ManufacturerId"))).SelectByText("Unknown/Other");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("option[value=\"11100\"]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='pm2ShipToTypeId'])[2]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookuppm2ShipToContactId")).Click();
            Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  
             BrowserDriver.Instance.Driver.FindElement(By.Name("queryContactsButton")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");  
             BrowserDriver.Instance.Driver.FindElement(By.Name("returnButtonIds")).SendKeys(Keys.Enter);
           Thread.Sleep(2000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_EQUIPMENT"); 

            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress1")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress1")).SendKeys("123");
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress2")).Clear();
             BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress2")).SendKeys("456");
             BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress3")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryAddress3")).SendKeys("678");
             BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCity")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCity")).SendKeys("Bangalore");
            new SelectElement( BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryCountryId"))).SelectByText("United States");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryZip")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("pm2DeliveryZip")).SendKeys("560097");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
             BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("reqWizFrame_header");  

            BrowserDriver.Instance.Driver.FindElement(By.Id("reqWiz_nextButton")).Click();
            Thread.Sleep(5000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | null | ]]
           BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");  
            BrowserDriver.Instance.Driver.SwitchTo().Frame("editFrame"); 
            Thread.Sleep(5000);
     //       BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"Key System(Qty:1)\"]")).Click();
            Assert.AreEqual("Key System(Qty:1)",  BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"Key System(Qty:1)\"]")).Text);
//driver.FindElement(By.CssSelector("div[title=\"PC Hardware(Qty:1)\"]")).Click();
            Assert.AreEqual("PC Hardware(Qty:1)",  BrowserDriver.Instance.Driver.FindElement(By.CssSelector("div[title=\"PC Hardware(Qty:1)\"]")).Text);
             BrowserDriver.Instance.Driver.FindElement(By.Id("generateOrder_sendButton")).Click();
            Thread.Sleep(3000);
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Accept();

            Console.WriteLine("Provisioning Request Created Successfully");

        }
            //Complete provisioning today

            //Allocation

            //Allocation Proceesing
            public void AllocationProccessing()
            {
                GoToMain("Bill Management");
                retryingFindClickk(".//*[@id='mnuBilling_AllocationMenu']");
                retryingFindClickk(".//*[@id='mnuBilling_AllocationProcessing']");
                WaitForElement(By.Id("pageTitle"));
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.FindElement(By.Id("New")).Click();
                 BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
                BrowserDriver.Instance.Driver.FindElement(By.Name("allocationRunName")).SendKeys("Allocation Batch");
                BrowserDriver.Instance.Driver.FindElement(By.Name("saveAllocation")).Click();
                Thread.Sleep(3000);
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.FindElement(By.Id("tabInvoices")).Click();
                Thread.Sleep(2000);
                     BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INVOICES");
                BrowserDriver.Instance.Driver.FindElement(By.Id("addInvoice")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                BrowserDriver.Instance.Driver.FindElement(By.Id("queryInvoicesButton")).Click();
                Thread.Sleep(5000);
                 BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                BrowserDriver.Instance.Driver.FindElement(By.Id("returnButtonIds")).SendKeys(Keys.Enter);
                Thread.Sleep(2000);
                Console.WriteLine("Source document or inventory added successfully");

                //Remove the inventory source
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                 BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("INVOICES");
            BrowserDriver.Instance.Driver.FindElement(By.CssSelector("input.multiSelectRow")).Click();
                BrowserDriver.Instance.Driver.FindElement(By.Id("removeInvoiceButton")).Click();
                Thread.Sleep(2000);
                Console.WriteLine("Inventory removed successfully");


                //CostCenter Tab 
                 BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                 BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.FindElement(By.Id("tabCostCenters")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                 BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("COSTCENTERS");

                //Adjustment Tab

                //Errors in Adjustment Tab

                //GL Tab
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                 BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.FindElement(By.Id("tabGL")).Click();
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                 BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("GL");
                Thread.Sleep(2000);
                BrowserDriver.Instance.Driver.FindElement(By.Id("GLEntries")).Click();
                Thread.Sleep(2000);
                   BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                 BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                BrowserDriver.Instance.Driver.FindElement(By.Name("buttonCreateGLEntries")).SendKeys(Keys.Enter);
                Thread.Sleep(2000);
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                 BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
                BrowserDriver.Instance.Driver.FindElement(By.Name("buttonClose")).SendKeys(Keys.Enter);
                Thread.Sleep(2000);
                Console.WriteLine("GL Code created Successfully");
                Console.WriteLine("Allocation Processing Passed successfully");
            }

        //Allocation Query
        public void AllocationQuery()
        {
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationMenu']");
            retryingFindClickk(".//*[@id='mnuBilling_AllocationQuery']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCATION_QUERY");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("imgLookupcostCenterId")).Click();
            Thread.Sleep(3000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
              BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryCostCentersButton")).Click();
            Thread.Sleep(5000);

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='returnButtonIds']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ALLOCATION_QUERY");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("COST_CENTER");
            BrowserDriver.Instance.Driver.FindElement(By.Id("queryAllocationsButton")).Click();
            Thread.Sleep(3000);
            Console.WriteLine("Allocation Query Passed Successfully");


        }

        //Allocation by Cost Center 

        //Account Maintainance 

        //Account discovery

        //Account Merge

        //Invoice Management

        //Recurring Invoice




            


            





            





        
            








            




        
            
            
            
            
            

        

            


#endregion
        
        private bool IsElementPresent(By by)
        {
            try
            {
                BrowserDriver.Instance.Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                BrowserDriver.Instance.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

#endregion

        }

    
}









    