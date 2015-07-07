// Revision History
//
// Bob Lichtenfels - 2/9/13 -  Created. Let there be test for everything under Gear->System.
// Bob Lichtenfels - 2/17/13 -  Checked in all tests for MDM Server and Login Settings.
// Bob Lichtenfels - 2/20/13 -  Checked in all test for Standalone User Options. 
// Bob Lichtenfels - 2/22/13 -  Checked in all test for Environment Settings.
// Bob Lichtenfels - 2/23/13 -  Checked in all test for Environment Settings.
// Bob Lichtenfels - 2/24/13 -  Finished and checked in.
// Bob Lichtenfels - 3/8/13  -  Made no access pulldown tests less complicated (convoluted) by splitting pull down no access
//                              tests into separate tests.
//

using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests; // Allows instantiatiation of CommonMethods.
using System.Threading;
using System.Text.RegularExpressions;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Any_configuration_state.Security_Roles; // Need to get base class inheritance to work.


namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_Configuration_State.Security_Roles
{

    [TestFixture]
    class ConfigurationAdministrationSystem : SecurityRoleBase
    {

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies full access for the following selections found under Gear->System.
        // 1) MDM Server.
        // 2) Login Settings.
        // 3) Stand Alone Users.
        // 4) Environment Settings.
        // 5) API.
        // 6) APNS.
        // 7) SCEP.
        // 8) MDM Saas Connector.
        // 9) Windows Event Logging.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemFullAccessTest()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            // Call base class method that selects the correct tabs, sets the access level, saves the security role page, and logs out.
            Console.WriteLine("    \nSetup security page for non-admin user for FULL access to selections in Systems selections");
            string PermissionsTab = "//li/a[contains(text(),'Configuration Administration')]";
            string NextLevelTab = "System";
            string AccessLevel = "//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']";
            SelectTabs_SetAccessLevel_Save(PermissionsTab, NextLevelTab, AccessLevel);

            // Login as non-admin and select MDM server page (found under Gear -> System). Will stay logged in through whole series of test.
            Console.WriteLine("    * Login as non-admin user, select MDM server page and verify save is present and enabled.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            // ///////////////
            // MDM server.
            // ///////////////
            // The method below selects System pulldown and then selects MDM Server. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "MDM Server", ref VerificationErrors))
            {
                cm.VerifyElementPresentAndDisplayed(true, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify full access to Login Settings
            // /////////////////
            // Login Settings.
            // /////////////////
            Console.WriteLine("    * Open Login Settings and verify editable text boxes and enabled save button.");
            // The method below selects System pulldown and then selects Login Settings. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "Login Settings", ref VerificationErrors))
            {
                cm.VerifyElementEnabled(true, By.XPath("//button[not(@disabled=\"disabled\")][@id=\"btnSave\"]"), ref VerificationErrors, driver, WaitTimeForElement, true);
                cm.VerifyElementEnabled(true, By.XPath("//button[not(@disabled=\"disabled\")][@id=\"btnReset\"]"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify full access to Standalone User Options
            // ////////////////////////////
            // Standalone User Options
            // ////////////////////////////
            Console.WriteLine("    * Open Standalone User Options and verify editable text boxes and enabled save button.");
            // The method below selects System pulldown and then selects Standalone User Options. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "Standalone User Options", ref VerificationErrors))
            {
                cm.VerifyTextBoxEditable(true, By.Id("txtMinimumPasswordLength"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy String", true);
                cm.VerifyTextBoxEditable(true, By.Id("txtPasswordResetTimeout"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy String", true);
                cm.VerifyElementEnabled(true, By.Id("btnSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify full access to Environment Settings.
            // ////////////////////////////
            // Environment Settings.
            // ////////////////////////////
            Console.WriteLine("    * Open Environment Settings and verify enabled save and cancel.");
            // The method below selects System pulldown and then selects Environment Settings. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "Environment Settings", ref VerificationErrors))
            {
                cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
                cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_lnkCancel"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify full access to API
            // ////////////////////////////
            // API
            // ////////////////////////////
            Console.WriteLine("    * Open API and verify enabled save and delete.");
            // The method below selects System pulldown and then selects API. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "API", ref VerificationErrors))
            {
                cm.VerifyElementEnabled(true, By.CssSelector("a.add-key-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
                cm.VerifyElementEnabled(true, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify full access to MDM SaaS Connector.
            // ////////////////////////////
            // MDM SaaS Connector.
            // ////////////////////////////
            Console.WriteLine("    * Open MDM SaaS Connector and verify save button is enabled.");
            // The method below selects System pulldown and then selects MDM SaaS Connector. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "MDM SaaS Connector", ref VerificationErrors))
            {
                cm.VerifyElementEnabled(true, By.Id("lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);                
            }

            // Now verify read access to Windows Event Logging.
            // ////////////////////////////
            // Windows Event Logging.
            // ////////////////////////////
            Console.WriteLine("    * Open Windows Event Logging and verify save and delete buttons are there.");
            // The method below selects System pulldown and then selects Windows Event Logging. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "Windows Event Logging", ref VerificationErrors))
            {
                cm.VerifyElementPresentAndDisplayed(true, By.CssSelector("a.add-monitor-btn-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies read access for the following selections found under Gear->System.
        // 1) MDM Server.
        // 2) Login Settings.
        // 3) Stand Alone Users.
        // 4) Environment Settings.
        // 5) API.
        // 6) APNS.
        // 7) SCEP.
        // 8) MDM Saas Connector.
        // 9) Windows Event Logging.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemReadAccessTest()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            // Call base class method that selects the correct tabs, sets the access level, saves the security role page, and logs out.
            Console.WriteLine("    \nSetup security page for non-admin user for READ access to selections in Systems selections");
            string PermissionsTab = "//li/a[contains(text(),'Configuration Administration')]";
            string NextLevelTab = "System";
            string AccessLevel = "//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: ReadAccessAll']";
            SelectTabs_SetAccessLevel_Save(PermissionsTab, NextLevelTab, AccessLevel);

            // Login as non-admin and select MDM server page (found under Gear -> System). Will stay logged in through whole series of test.
            Console.WriteLine("    * Login as non-admin user, select MDM server page and verify save is present and enabled.");
            cm.LogIntoMdm(driver, regularUser, password, url);
            
            // ///////////////
            // MDM server.
            // ///////////////
            // The method below selects System pulldown and then selects MDM Server. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            //  
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "MDM Server", ref VerificationErrors))
            {
                cm.VerifyElementEnabled(false, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify full access to Login Settings
            // /////////////////
            // Login Settings.
            // /////////////////
            Console.WriteLine("    * Open Login Settings and verify save and reset buttons are not present.");
            // The method below selects System Pulldown and then selects Login Settings. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "Login Settings", ref VerificationErrors))
            {
                // NOTE: Even though the save and reset buttons are visible, the check for their NOT enabled fails. So, doing check for no presence here.
                //       This was the same type of test that was done in the selemium RC code. In read access the buttons were tested for being present.
                cm.VerifyElementPresentAndDisplayed(false, By.XPath("//button[not(@disabled=\"disabled\")][@id=\"btnSave\"]"), ref VerificationErrors, driver, WaitTimeForElement, true);
                cm.VerifyElementPresentAndDisplayed(false, By.XPath("//button[not(@disabled=\"disabled\")][@id=\"btnReset\"]"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify read access to Standalone User Options
            // ////////////////////////////
            // Standalone User Options
            // ////////////////////////////
            Console.WriteLine("    * Open Standalone User Options and verify non-editable text boxes and disabled save button.");
            // The method below selects System Pulldown and then selects Standalone User Options. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if(SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "Standalone User Options", ref VerificationErrors))
            {
                cm.VerifyTextBoxEditable(false, By.Id("txtMinimumPasswordLength"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy String", true);
                cm.VerifyTextBoxEditable(false, By.Id("txtPasswordResetTimeout"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy String", true);
                cm.VerifyElementEnabled(false, By.Id("btnSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify read access to Environment Settings.
            // ////////////////////////////
            // Environment Settings.
            // ////////////////////////////
            Console.WriteLine("    * Open Environment Settings and verify save and cancel are not present and displayed.");
            // The method below selects System Pullldown and then selects Environment Settings. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "Environment Settings", ref VerificationErrors))
            {
                cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
                cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkCancel"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify read access to API
            // ////////////////////////////
            // API
            // ////////////////////////////
            Console.WriteLine("    * Open API and verify save and delete are not there.");
            // The method below selects System Pulldown and then selects API. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "API", ref VerificationErrors))
            {
                // NOTE: Even though the save and cancel buttons are visible, the check for their NOT enabled fails. So, doing check for no presence here.
                //       This was the same type of test that was done in the selemium RC code. In read access the buttons were tested for being present.
                cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.add-key-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
                cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);        
            }

            // Now verify read access to MDM SaaS Connector.
            // ////////////////////////////
            // MDM SaaS Connector.
            // ////////////////////////////
            Console.WriteLine("    * Open MDM SaaS Connector and verify save button is disabled.");
            // The method below selects System pulldown and then selects MDM SaaS Connector. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "MDM SaaS Connector", ref VerificationErrors))
            {
                cm.VerifyElementEnabled(false, By.Id("lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }

            // Now verify read access to Windows Event Logging.
            // ////////////////////////////
            // Windows Event Logging.
            // ////////////////////////////
            Console.WriteLine("    * Open Windows Event Logging and verify save and delete buttons are not there.");
            // The method below selects System pulldown and then selects Windows Event Logging. If if doesn't find the page text, it shows and logs an error, 
            // and returns false. If it fails, skip any test(s) to be done on the page.
            if (SelectSystemPullDownAndSelectPulldownItem(WaitTimeForElement, "Windows Event Logging", ref VerificationErrors))
            {
                cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.add-monitor-btn-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            }
        }

        [Test]
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 1) MDM Server (this is given access ).
        // 2) Login Settings.
        // 3) Stand Alone Users.
        // 4) Environment Settings.
        // 5) API.
        // 6) APNS.
        // 7) SCEP.
        // 8) MDM Saas Connector.
        // 9) Windows Event Logging.
        //
        // This test will disable all pulldown selections except MDM Server and then verify all slections are not selectable except MDM server.
        //
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemNoAccessTest_PulldownVisible_ViewOnlyMdmServer()
        {
            int WaitTimeForElement = 3; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user given NO access to System selections except MDM Server. Verify all System selections are missing in pulldown except MDM Server.");

            // Select permissions tab.
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"), 10);
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]")).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText("System"));
            driver.FindElement(By.LinkText("System"));
            driver.FindElement(By.LinkText("System")).Click();

            // Set all access level to no access.
            cm.WaitForElement(driver, By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"), 10);
            driver.FindElement(By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']")).Click();

            // Now set access level to MDM server to read.
            cm.WaitForElement(driver, By.XPath("(//input[@name='read'])[38]"), 10);
            driver.FindElement(By.XPath("(//input[@name='read'])[38]"));
            driver.FindElement(By.XPath("(//input[@name='read'])[38]")).Click();
                        
            // Save security role and log out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), 10);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin and verify correct no access for all except MDM server.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select the System List.
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            // Verify the ony selection shown is MDM Server. Very all others are not there.
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("MDM Server"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Login Settings"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Stand Alone User Options"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Environment Settings"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("API"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("APNS"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("SCEP"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("MDM SaaS Connector"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Windows Event Logging"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 1) MDM Server.
        // 2) Login Settings  (this is given access ).
        // 3) Stand Alone Users.
        // 4) Environment Settings.
        // 5) API.
        // 6) APNS.
        // 7) SCEP.
        // 8) MDM Saas Connector.
        // 9) Windows Event Logging.
        //
        // This test will disable all pulldown selections except Login Settings and then verify Login Settings is selectable 
        // and MDM Server is not selectable.
        // All other selections are verified for no access in another test case in this test class.
        //
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemNoAccessTest_PulldownVisible_ViewOnlyLoginSettings()
        {
            int WaitTimeForElement = 3; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user given NO access to System selections except Login Settings. Verify Login Settings are selectable and MDM Server is not.");

            // Select permissions tab.
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"), 10);
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]")).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText("System"));
            driver.FindElement(By.LinkText("System"));
            driver.FindElement(By.LinkText("System")).Click();

            // Set all access level to no access.
            cm.WaitForElement(driver, By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"), 10);
            driver.FindElement(By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']")).Click();

            // Now set access level to Login Settings to read.
            cm.WaitForElement(driver, By.XPath("(//input[@name='read'])[39]"), 10);
            driver.FindElement(By.XPath("(//input[@name='read'])[39]"));
            driver.FindElement(By.XPath("(//input[@name='read'])[39]")).Click();

            // Save security role and log out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), 10);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin and verify correct no access for all except MDM server.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select the System List.
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            // Verify the ony selection shown is MDM Server. Very all others are not there.
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("MDM Server"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Login Settings"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }        

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies NO access for the following selections found under Gear->System and access to security Events.
        // 1) MDM Server.
        // 2) Login Settings.
        // 3) Stand Alone Users.
        // 4) Environment Settings.
        // 5) API.
        // 6) APNS.
        // 7) SCEP.
        // 8) MDM Saas Connector.
        // 9) Windows Event Logging.
        // 
        // Verify by doing this:
        // Give Security->AccessControl->Security Roles grant access. Set all access to the listed selections above to no access.
        // Verify no access to customization pulldown selections and verify access to the Security pulldown.
        // ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemNoAccessTest_PulldownNotVisible()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("\nSetup security page for non-admin user to have NO access to System selections and access to the Security selection. ");
            Console.WriteLine("Verify the customization pulldown is not there and Security selection is there.");

            // 
            // Select permissions tab (SECURITY ROLES).
            cm.WaitForElement(driver, By.XPath("//li/a[.='Security']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Security']"));
            driver.FindElement(By.XPath("//li/a[.='Security']")).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText("Access Control"));
            driver.FindElement(By.LinkText("Access Control"));
            driver.FindElement(By.LinkText("Access Control")).Click();

            // Set access level to read.
            cm.WaitForElement(driver, By.XPath("//tr[td='Security Roles']/td/input[@name='read']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//tr[td='Security Roles']/td/input[@name='read']"));
            driver.FindElement(By.XPath("//tr[td='Security Roles']/td/input[@name='read']")).Click();

            // Select permissions tab (GEAR->SYSTEM).
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]")).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText("System"));
            driver.FindElement(By.LinkText("System"));
            driver.FindElement(By.LinkText("System")).Click();

            // Set access level to no access.
            cm.WaitForElement(driver, By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"), 10);
            driver.FindElement(By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']")).Click();

            // Save security role and log out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), WaitTimeForElement);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin and verify no access to System pulldown and verify access to the Activity pulldown.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Verify security activity pulldown is found and customization pulldown is not.
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Security"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("img[alt=\"Configuration/Administration\"]"), ref VerificationErrors, driver, WaitTimeForElement, true);
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
        // Return: 
        // False if expected text on page opened is not found and True if expected text on page opened is found.
        // 
        // /////////////////////////////////////////////////////////////////////////////////////////////////////        
        public bool SelectSystemPullDownAndSelectPulldownItem(int WaitTime, string ByLinkText, ref StringBuilder VerificationErrors)
        {
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.LinkText(ByLinkText), WaitTime);
            driver.FindElement(By.LinkText(ByLinkText));
            driver.FindElement(By.LinkText(ByLinkText)).Click();
            if(driver.PageSource.Contains(ByLinkText))
            {
                return true;
            }
            else
            {
                Console.WriteLine("    !Failed in method SelectSystemPullDownAndSelectPulldownItem when trying to verify page open for " + ByLinkText + ".");
                VerificationErrors.Append("Failed to find expected page text " + ByLinkText + " in method SelectSystemPullDownAndSelectPulldownItem.");                
                return false;
            }
        } 
    }
}
