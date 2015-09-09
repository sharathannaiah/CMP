using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Navigation
{
    class CompleteNavigation : BaseActions
    {
        public void Navigation()
        {
        //    // Call Base action class to navigate to enterprise menu
        //    GoToMain("Enterprise");
        //    // Navigate to Enterprise--> Explorer page
        //    retryingFindClickk(".//*[@id='mnuEnterprise_Explorer2']");
        //  //  Thread.Sleep(2000);
        //    WaitForElementOnNextPage(By.Id("pageTitle"), "Navigation to Enterprise Explorer Failed");
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
        //    Assert.AreEqual("Entity Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
        //    Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Enterprise--> Explorer page failed");
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

        //    //Navigate to Employee --> Explorer
        //    GoToMain("Enterprise");
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
        //    // Navigate to Employee
        //    retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
        //    //Navigate to Employee Explorer
        //    retryingFindClickk(".//*[@id='mnuEmployees_Explorer']");       
        //    WaitForElementOnNextPage(By.Id("pageTitle"), "Navigation to Employee Explorer Failed");
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
        //    Assert.AreEqual("Employee Management", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
        //    Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Enterprise--> Employee --> Explorer page failed");
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
        //    Thread.Sleep(2000);

        //    //Navigate to employee --> Support Ticket
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
        //    retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
        //    retryingFindClickk(".//*[@id='mnuEmployees_HelpDeskTickets']");
        ////    Thread.Sleep(1000);
        //    WaitForElementOnNextPage(By.Id("pageTitle"), "Navigation to Support ticket Failed");
        //    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("HELPDESKTICKETS");
        //    Assert.AreEqual("Help Desk Support Tickets", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
        //    Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Enterprise--> employee --> Support Ticket page failed");
        //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
          //  Thread.Sleep(2000);


            //Navigate to types Tab
            BrowserDriver.Instance.Driver.FindElement(By.Id("menuMainEnterprise")).Click();
            //Navigate to Types
            retryingFindClickk(".//*[@id='mnuEnterprise_Types']");
            Thread.Sleep(1000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("POPUP_CONTENT");
            Assert.AreEqual("Modify Entity Types", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("legend")).Text);
            Assert.IsTrue(IsElementVisible(By.CssSelector("legend")), "Navigation to Enterprise-->Types Failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='dWnd1']/table/tbody/tr[1]/td[4]/img")).Click();
            // BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ModifyEntityTypeForm']/input[3]")).SendKeys(Keys.Enter);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);
          
            //Navigate to Regions
            GoToMain("Enterprise");
            retryingFindClickk(".//*[@id='mnuEnterprise_Region']");
            Thread.Sleep(1000);
            SwitchToPopUps();
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
            Thread.Sleep(2000);


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

            //Navigate to Bill Management --> Invoice Processing
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_Invoice_Processing']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            Assert.AreEqual("Invoice Processing", BrowserDriver.Instance.Driver.FindElement(By.Id("pageTitle")).Text);
            Assert.IsTrue(IsElementVisible(By.Id("pageTitle")), "Navigation to Bill Management --> Invoice Processing --> failed");


            ////Navigate to Bill Processing --> Upload e-bills
            //GoToBillManagement("Bill Management");
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            ////Navigate to Upload e-bills
            //retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            //retryingFindClickk(".//*[@id='mnuBilling_BillUpload']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("BILL_UPLOAD_MAIN");
            //Assert.AreEqual("Welcome to the CMP Bill Import Wizard. To begin the CMP Bill Import process. Select a carrier billing system below and click Next to continue.", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("span")).Text);
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ProcessSelectBillingSystem']/div[2]/input[2]")).SendKeys(Keys.Enter);
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //Thread.Sleep(2000);

            ////Navigate to Bill Management --> Bill Processing -->Standard Bill Import
            //GoToBillManagement("Bill Management");
            //retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            //retryingFindClickk(".//*[@id='mnuBilling_StandardBillImport']");
            //Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("BILL_UPLOAD_MAIN");
            //Assert.AreEqual("Welcome to the CMP Standard Bill Import Wizard. Please complete the applicable information below and select 'Next' to continue.", BrowserDriver.Instance.Driver.FindElement(By.CssSelector("span")).Text);
            //Assert.IsTrue(IsElementVisible(By.ClassName("btnCMP")), "Navigation to Bill Management --> Invoice Processing --> failed");
            //BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ProcessSelectBillingSystem']/div[2]/input[2]")).SendKeys(Keys.Enter);
            //BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();



            //Navigate to Bill Management --> Bill Processing -->Manage Uploads
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            retryingFindClickk(".//*[@id='mnuBilling_ManageUpload']");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SELECT_BILL_UPLOAD_QUERY");
            Assert.AreEqual("Select Bill Upload Subset", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management --> Bill Processing --> Manage Uploads page failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);

            //Navigate to Bill Management --> Bill Processing --> Offline Invoice Entry
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            retryingFindClickk(".//*[@id='mnuBilling_OfflineInvoice']");
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Offline Invoice Submission", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text);
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management --> Bill Processing --> Offline Invoice Entry failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);

            //Navigate to Bill Management --> Bill Processing --> Invoice Submission
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            retryingFindClickk(".//*[@id='mnuBilling_InvoiceSubmission']");
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            Assert.AreEqual("Invoice Submission Query Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text); ;
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management --> Bill Processing --> Invoice Submission failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

            //Navigate to Bill Management --> Bill Processing --> Manage Bills
            GoToMain("Bill Management");
            retryingFindClickk(".//*[@id='mnuBilling_BillProcess']");
            retryingFindClickk(".//*[@id='mnuBilling_ManageBills']");
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("SELECT_BILL_QUERY");
            Assert.AreEqual("Bill Criteria", BrowserDriver.Instance.Driver.FindElement(By.ClassName("bbHeaderText")).Text); ;
            Assert.IsTrue(IsElementVisible(By.ClassName("bbHeaderText")), "Navigation to Bill Management --> Bill Processing --> Manage Bills failed");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();

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
        }
    }
}
