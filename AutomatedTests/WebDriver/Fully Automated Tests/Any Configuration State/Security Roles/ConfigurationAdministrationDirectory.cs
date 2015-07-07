// Revision History
//
// Bob Lichtenfels - 4/20/13 - Started tes class,  checked in full access for LDAP schema.
// Bob Lichtenfels - 4/27/13 - Checkin all tests for Ldap Schemas and Ldap Servers.
//
using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests; // Allows instantiatiation of CommonMethods.
using System.Threading;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Any_configuration_state.Security_Roles; // Need to get base class inheritance to work.


//namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_Configuration_State.Security_Roles // copied - this works.
namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_Configuration_State.Security_Roles // 
{
    [TestFixture]
    class ConfigurationAdministrationDirectory : SecurityRoleBase
    {
        int WaitTimeForElement = 0; // How long to wait when calling WaitForElement method.

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check full access for Gear->LDAP Servers.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllFullAccessTest_LDAPSchemas()
        {
            WaitTimeForElement = 5;
            
            Console.WriteLine("\nRunning read access for Gear->LDAP Servers.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for FULL access to Gear->LDAP Schemas - save and logout.");

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click(); // Make security role admin role.

            // Select full access for LDAP servers and save.
            SelectTabs_SetAccessLevel_Save("//li/a[contains(text(),'Configuration Administration')]", "Directory", "(//input[@name='full'])[52]");

            // Login as non-admin and select MDM server page (found under Gear -> System). Will stay logged in through whole series of test.
            Console.WriteLine("    Login as non-admin user, select LDAP Schemas page and verify page has enabled add/delete buttons.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select LDAP Schemas and verify the schemas page has enabled add/delete buttons.
            SelectDirectoryPullDownAndSelectPulldownItem(WaitTimeForElement, "LDAP Schemas");

            // Verify text boxes and pulldowns.
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_btnAddSchema"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_btnDeleteSchema"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check read access for Gear->LDAP Servers.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllReadAccessTest_LDAPSchemas()
        {
            WaitTimeForElement = 5;

            Console.WriteLine("\nRunning read access for Gear->LDAP Servers.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for READ access to Gear->LDAP Schemas - save and logout.");

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click(); // Make security role admin role.

            // Select read access for LDAP schemas and save.
            SelectTabs_SetAccessLevel_Save("//li/a[contains(text(),'Configuration Administration')]", "Directory", "(//input[@name='read'])[52]");

            // Login as non-admin and select MDM server page (found under Gear -> System). Will stay logged in through whole series of test.
            Console.WriteLine("    Login as non-admin user, select LDAP Schemas page and verify page has enabled add/delete buttons.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select LDAP Schemas and verify the schemas page has enabled add/delete buttons.
            SelectDirectoryPullDownAndSelectPulldownItem(WaitTimeForElement, "LDAP Schemas");

            // Verify text boxes and pulldowns.
            //cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_btnAddSchema"), ref VerificationErrors, driver, WaitTimeForElement, true);
            //cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_btnDeleteSchema"), ref VerificationErrors, driver, WaitTimeForElement, true);

            cm.DebugTimeout(5, "what see");

            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_btnAddSchema"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_btnDeleteSchema"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check no access  for Gear->LDAP Servers. Set no access to LDAP Schemas and read access to the other 
        // directory selections.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceNoAccessTest_LDAPSchemas()
        {
            WaitTimeForElement = 5; // How long to wait when calling WaitForElement.

            Console.WriteLine("\nRunning no access for Gear->LDAP Schemas.");

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click(); // Make security role admin role.

            // Enable all selections for Gear->Directory.
            EnableAllCustimizationDirectorySelections(WaitTimeForElement);

            // Select no access for LDAP schemas.
            SelectTabs_SetAccessLevel_Save("//li/a[contains(text(),'Configuration Administration')]", "Directory", "(//input[@name='none'])[52]");

           // Login as non-admin and select MDM server page (found under Gear -> System). Will stay logged in through whole series of test.
            Console.WriteLine("    Login as non-admin user, select LDAP Schemas page and verify page has enabled add/delete buttons.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select configuration pullldown to show available selections.
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            // Verify LDAP schemas is not there and all others are.
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("LDAP Servers"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("LDAP Queries"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("LDAP Schemas"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }
        
        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check full access for Gear->LDAP Servers.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllFullAccessTest_LDAPServers()
        {

            WaitTimeForElement = 5; // How long to wait when calling WaitForElement.

            Console.WriteLine("\nRunning full access for Gear->LDAP Servers.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for FULL access to Gear->LDAP Servers - save and logout.");
            
            driver.FindElement(By.Name("isAdminProfileChkBx")).Click(); // Make security role admin role.
            
            // Select full access for LDAP servers.
            SelectTabs_SetAccessLevel_Save("//li/a[contains(text(),'Configuration Administration')]", "Directory", "(//input[@name='full'])[53]");

            // Login as non-admin and select MDM server page (found under Gear -> System). Will stay logged in through whole series of test.
            Console.WriteLine("    Login as non-admin user, select LDAP Servers page and verify page has full access.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select LDAP Servers, verify full access text boxes, pulldowns, and checkbox.
            SelectDirectoryPullDownAndSelectPulldownItem(WaitTimeForElement, "LDAP Servers");

            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthHostName"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthUserBase"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_ucAuthLdapServer_ddlAuthLdapSchema"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_ucAuthLdapServer_ddlAuthReferralType"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthAdminUserName"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthAdminPassword"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_txtCustomLblField"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_ucLookupLdapServer_cbxUseAuthValues"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthPortNumber"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_ucAuthLdapServer_cbxAuthUsesSSL"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_ucAuthLdapServer_cbxAuthUseRoot"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.Id("ctl00_MainContent_lnkCancel"), ref VerificationErrors, driver, WaitTimeForElement, true);        
        }


        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check full access for Gear->LDAP Servers.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllReadAccessTest_LDAPServers()
        {

            WaitTimeForElement = 5; // How long to wait when calling WaitForElement.

            Console.WriteLine("\nRunning read access for Gear->LDAP Servers.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for READ access to Gear->LDAP Servers - save and logout.");

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click(); // Make security role admin role.

            // Select read access for LDAP servers.
            SelectTabs_SetAccessLevel_Save("//li/a[contains(text(),'Configuration Administration')]", "Directory", "(//input[@name='read'])[53]");

            // Login as non-admin and select MDM server page (found under Gear -> System). Will stay logged in through whole series of test.
            Console.WriteLine("    Login as non-admin user, select LDAP Servers page and verify page has read access.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select LDAP Servers, verify read only text boxes, pulldowns, and checkbox.
            SelectDirectoryPullDownAndSelectPulldownItem(WaitTimeForElement, "LDAP Servers");

            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthHostName"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthUserBase"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyElementEnabled(false, By.Id("ctl00_MainContent_ucAuthLdapServer_ddlAuthLdapSchema"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.Id("ctl00_MainContent_ucAuthLdapServer_ddlAuthReferralType"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthAdminUserName"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthAdminPassword"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_txtCustomLblField"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_ucLookupLdapServer_cbxUseAuthValues"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_ucAuthLdapServer_txtAuthPortNumber"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyElementEnabled(false, By.Id("ctl00_MainContent_ucAuthLdapServer_cbxAuthUsesSSL"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.Id("ctl00_MainContent_ucAuthLdapServer_cbxAuthUseRoot"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement,true);
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkCancel"), ref VerificationErrors, driver, WaitTimeForElement,true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check no access  for Gear->LDAP Servers.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceNoAccessTest_LDAPServers()
        {
            WaitTimeForElement = 5; // How long to wait when calling WaitForElement.

            Console.WriteLine("\nRunning no access for Gear->LDAP Servers.");

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click(); // Make security role admin role.

            // Enable all selections for Gear->Directory.
            EnableAllCustimizationDirectorySelections(WaitTimeForElement);

            // Select no access for LDAP servers.
            SelectTabs_SetAccessLevel_Save("//li/a[contains(text(),'Configuration Administration')]", "Directory", "(//input[@name='none'])[53]");

            // Login as non-admin and select MDM server page (found under Gear -> System). Will stay logged in through whole series of test.
            Console.WriteLine("    Login as non-admin user, select LDAP Schemas page and verify page has enabled add/delete buttons.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select configuration pullldown to show available selections.
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            // Verify LDAP schemas is not there and all others are.
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("LDAP Servers"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("LDAP Queries"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("LDAP Schemas"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllFullAccessTest_LDAPQueries()
        {
            WaitTimeForElement = 5;
            
            Console.WriteLine("\nRunning full access for Gear->LDAP Queries.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for FULL access to Gear->LDAP Queries - save and logout.");

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click(); // Make security role admin role.

            // Select full access for LDAP Queries.
            SelectTabs_SetAccessLevel_Save("//li/a[contains(text(),'Configuration Administration')]", "Directory", "(//input[@name='full'])[54]");
        }
        
 
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description:
        // This method selects System pulldown and then selects the link text passeed in (ByLinkText). If if doesn't find the 
        // page text of the page selected for ByLinkText, it shows and logs an error to passed-by-ref verificationErrors
        // and returns false, else returns true.
        //
        // Parameters:
        // 1) WaitTime           - How long to wait for the element under system pulldown to be found.
        // 2) ByLinkText         - Text of pulldown selection to find (ByLink)
        // 3) VerificationErrors - By ref, holds any errors found.
        //
        // 
        // /////////////////////////////////////////////////////////////////////////////////////////////////////        
        public void SelectDirectoryPullDownAndSelectPulldownItem(int WaitTime, string ByLinkText)
        {
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.LinkText(ByLinkText), WaitTime);
            driver.FindElement(By.LinkText(ByLinkText));
            driver.FindElement(By.LinkText(ByLinkText)).Click();
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // TODO!! -- put in base class SelectTabs_SetAccessLevel_Save and re-writeSelectTabs_SetAccessLevel_Save.
        //
        // Set all customization settings to access passed in.
        //
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void EnableAllCustimizationDirectorySelections(int WaitTimeForElement)
        {
            // Select permissions tab 
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]")).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText("Directory"));
            driver.FindElement(By.LinkText("Directory"));
            driver.FindElement(By.LinkText("Directory")).Click();

            // Set access level to read.
            cm.WaitForElement(driver, By.XPath("(//input[@type='checkbox'])[263]"), WaitTimeForElement);
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[263]"));
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[263]")).Click();
        }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
