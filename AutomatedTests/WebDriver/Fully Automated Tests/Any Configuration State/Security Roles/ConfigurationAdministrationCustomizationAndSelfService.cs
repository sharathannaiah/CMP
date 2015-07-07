// Revision History
//
// Bob Lichtenfels - 1/20/13 -  Created and started bringing in web driver code from old Selenium test
// Bob Lichtenfels - 1/27/13 -  Setup majority of read and full access test.
// Bob Lichtenfels - 1/27/13 -  Setup majority of read and full access test.
// Bob Lichtenfels - 2/3/13 -   Checked in all tests except issue with error message text box. See TODO.
// Bob Lichtenfels - 2/8/13 -   Commented some test from read and full access page content sections. There are countless numbers 
//                              of pages so just doing a general check. Add a message in VerifyPageContentSecurity and GoBackToPageContentPage
// Bob Lichtenfels - 2/9/13 -   Added test for text box and search button in devices page test. They are enabled in both full access and read.
// Bob Lichtenfels - 3/7/13 -   Made pulldown visible test simpler. Seperated into smaller tests.
//

using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests; // Allows instantiatiation of CommonMethods.
using System.Threading;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Any_configuration_state.Security_Roles; // Need to get base class inheritance to work.


namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_Configuration_State.Security_Roles
{
    [TestFixture]
    class ConfigurationAdministrationCustomizationAndSelfService : SecurityRoleBase
    {
        // This is used to hold the current link text when selecting a page in the page access page. There 
        // are numerous page links that have to be selected in the page access test. This makes assigning 
        // temporary text in the test code less tedious.
        string TempPageAccessLink = ""; 
        
        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies read access for the following selections found under Gear->Customization.
        // 1) User Interface.
        // 2) Devices.
        // 3) Page Content.
        // 4) Error Mesages.
        // 5) Wireless Carriers.
        // 6) Activation Instructions
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllReadAccessTest()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            // Call base class method that selects the correct tabs, sets the access level, saves the security role page, and logs out.
            Console.WriteLine("    \nSetup security page for non-admin user for READ access to Customization selections - save and logout.");
            string PermissionsTab = "//li/a[contains(text(),'Configuration Administration')]";
            string NextLevelTab = "Customization and Self-service";
            string AccessLevel = "//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: ReadAccessAll']";
            SelectTabs_SetAccessLevel_Save(PermissionsTab, NextLevelTab, AccessLevel);

            // ///////////////
            // User Interface
            // ///////////////
            // Login as non-admin and select user interface page (found under Gear -> Customization).
            Console.WriteLine("    Login as non-admin user, select user interface page and verify save/cancel are NOT present and visible.");
            cm.LogIntoMdm(driver, regularUser, password, url);
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.LinkText("User Interface"), WaitTimeForElement);
            driver.FindElement(By.LinkText("User Interface")).Click();

            // Verify save/cancel are not present.
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkCancel"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // ///////////////
            // Devices
            // ///////////////
            // Verify read access to Devices (found under Gear -> Customization).

            Console.WriteLine("    Select devices page and verify delete/add are NOT present and visible.");
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[.='Devices']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Devices']")).Click();

            // Verify add/delete are not present.
            cm.VerifyElementPresentAndDisplayed(false, By.ClassName("add-device-btn-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.XPath("//div/a[not(@style=\"display: none;\")][@class=\"delete-btn-small\"]"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Verify the search text box and search button are editable.
            Console.WriteLine("    Verify search text and button are editable/enabled."); 
            cm.VerifyTextBoxEditable(true, By.Id("searchText"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy Text For test", true);
            cm.VerifyElementEnabled(true, By.XPath("//div[@id='deviceProfileListFeature']/div/div/div/form/button"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // ////////////////
            // Error Messages
            // ////////////////
            // Verify read access to Error Mesages (found under Gear -> Customization).

            Console.WriteLine("    Select error message page and verify save button is NOT enabled.");
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[.='Error Messages']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Error Messages']")).Click();

            // Verify save button status.
            cm.WaitForElement(driver, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), WaitTimeForElement);
            cm.VerifyElementEnabled(false, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);


            // ///////////////////
            // Wireless Carriers
            // ///////////////////
            // Verify full access to Wireless Carriers (found under Gear -> Customization).
            Console.WriteLine("    Select Wireless Carrier page and verify add delete/buttons are NOT present.");
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[.='Wireless Carriers']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Wireless Carriers']")).Click();

            // Verify add and delete selections are NOT there.
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.add-carrier-btn-large"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // ////////////////////////
            // Activation Instructions
            // ////////////////////////
            // Verify full access to Activation Instructions (found under Gear -> Customization).
            Console.WriteLine("    Select Activation Instructions page and verify \"Delete Checked Instructions\" and \"New Activation Instructions\" are NOT present.");
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[.='Activation Instructions']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Activation Instructions']")).Click();

            // Verify edit selections are enabled  - Delete Checked Instructions and New Activation Instructions.
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkDeleteCollection"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkAddCollection"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // ///////////////
            // Page Content
            // ///////////////
            // Verify read access to Page Content (found under Gear -> Customization).

            Console.WriteLine("    -- Starting series of page content tests --.");

            // **************
            TempPageAccessLink = "Android Client Installation Email"; 
            Console.WriteLine("    Select page content selection \"Android Client Installation Email\". Verify save button and text box are present and NOT enabled.");
            GoBackToPageContentPage(WaitTimeForElement); // Get to page content page.
            cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            // Save button and text box not enabled.
            VerifyPageContentSecurity(WaitTimeForElement, false);

            // **************
            TempPageAccessLink = "BlackBerry Activation Email"; 
            Console.WriteLine("    Select page content selection \"BlackBerry Activation Email\". Verify save button and text box are present and NOT enabled.");
            GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            driver.FindElement(By.LinkText(TempPageAccessLink));
            driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            // Save button and text box not enabled.
            VerifyPageContentSecurity(WaitTimeForElement, false);

            // Remove too many tests below.
            //// ************************
            //TempPageAccessLink = "BlackBerry Delete Account"; 
            //Console.WriteLine("    Select page content selection \"BlackBerry Delete Account\". Verify save button and text box are present and NOT enabled.");
            //GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            //cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            //driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            //// Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            //VerifyPageContentSecurity(WaitTimeForElement, false);

            //// ************************
            //TempPageAccessLink = "BlackBerry New Device Activation";
            //Console.WriteLine("    Select page content selection \"BlackBerry New Device Activation\". Verify save button and text box are present and NOT enabled.");
            //GoBackToPageContentPage(WaitTimeForElement); // Get to page content page.
            //cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            //driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            //// Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            //VerifyPageContentSecurity(WaitTimeForElement, false);

            //// ************************
            //TempPageAccessLink = "BlackBerry Reset Activation Password";
            //Console.WriteLine("    Select page content selection \"BlackBerry Reset Activation Password\". Verify save button and text box are present and NOT enabled.");
            //GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            //cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            //driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            //// Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            //VerifyPageContentSecurity(WaitTimeForElement, false);

            //// ************************
            //TempPageAccessLink = "BlackBerry Reset Device Password";
            //Console.WriteLine("    Select page content selection \"BlackBerry Reset Device Password\". Verify save button and text box are present and NOT enabled.");
            //GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            //cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            //driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            //// Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            //VerifyPageContentSecurity(WaitTimeForElement, false);

            // ************************
            TempPageAccessLink = "Windows Phone 7 Client Installation E-mail";
            Console.WriteLine("    Select page content selection \"Windows Phone 7 Client Installation E-mail\". Verify save button and text box are NOT present and enabled.");
            GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            // Verify "Font Family" pulldown is present, save button and text box are NOT present and enabled.
            VerifyPageContentSecurity(WaitTimeForElement, false);

            Console.WriteLine("    -- Starting series of page content tests DONE --.");

        }

        [Test]
        // ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // This verifies no access for the following selections found under Gear->Customization except 
        // User Interface.
        //
        // 1) User Interface (this is left visible).
        // 2) Devices.
        // 3) Page Content.
        // 4) Error Mesages.
        // 5) Wireless Carriers.
        // 6) Activation Instructions
        //
        // Verify by doing this:
        // Set all access to the selections above to no access except User Interface. Then verify 
        // User Interface is present and displayed and all other selections are not present and displayed.
        // ///////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllNoAccessTest_PulldownVisible_ViewOnlyUserInterface() 
        {

            int WaitTimeForElement = 3; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user for NO access to Customization selections except User Interface. Verify all missing selections and User Interface is not missing.");

            //// Select permissions tab.
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"), 10);
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]")).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText("Customization and Self-service"));
            driver.FindElement(By.LinkText("Customization and Self-service"));
            driver.FindElement(By.LinkText("Customization and Self-service")).Click();

            // Set access level to no access.
            cm.WaitForElement(driver, By.XPath("//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"), 10);
            driver.FindElement(By.XPath("//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']")).Click();

            // Set user interface to read access
            cm.WaitForElement(driver, By.XPath("(//input[@name='read'])[57]"), 10);
            driver.FindElement(By.XPath("(//input[@name='read'])[57]"));
            driver.FindElement(By.XPath("(//input[@name='read'])[57]")).Click();
            cm.SaveSecurityRole(driver);

            Console.WriteLine("    \nLogout admin, login as non-admin.");
            // Logout admin, login as non-admin
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select the customization list.
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            // Verify the ony selection shown is User Interface. Very all others are not there.
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("User Interface"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Devices"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Page Content"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Error Messages"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Wireless Carriers"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Activation instructions"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // This verifies no access for the following selections found under Gear->Customization except 
        // User Interface.
        //
        // 1) User Interface. 
        // 2) Devices.
        // 3) Page Content (this is left visible).
        // 4) Error Mesages.
        // 5) Wireless Carriers.
        // 6) Activation Instructions
        //
        // Verify by doing this:
        // Set all access to the selections above to no access except Page Content and then verify Page 
        // Content is present and displayed and User Interface is not. All other no access scenarios are 
        // tested in the other two No Access tests found in this test class.
        // ///////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllNoAccessTest_PulldownVisible_ViewOnlyPageContent()
        {

            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user for NO access to Customization selections except Error Log. Verify Error log is present and visible and User Interface is not.");

            // Select permissions tab.
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"), 10);
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[contains(text(),'Configuration Administration')]")).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText("Customization and Self-service"));
            driver.FindElement(By.LinkText("Customization and Self-service"));
            driver.FindElement(By.LinkText("Customization and Self-service")).Click();

            // Set access level to no access.
            cm.WaitForElement(driver, By.XPath("//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"), 10);
            driver.FindElement(By.XPath("//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']")).Click();

            // Set Page Content to read access.
            cm.WaitForElement(driver, By.XPath("(//input[@name='read'])[59]"), 10);
            driver.FindElement(By.XPath("(//input[@name='read'])[59]"));
            driver.FindElement(By.XPath("(//input[@name='read'])[59]")).Click();
            cm.SaveSecurityRole(driver);

            Console.WriteLine("    \nLogout admin, login as non-admin, and check what's visible/nonn-visible.");
            // Logout admin, login as non-admin
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select the customization list.
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            // Verify the ony selection shown is User Interface. Very all others are not there.
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("User Interface"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Page Content"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // ///////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // This verifies no access for the following selections found under Gear->Customization.
        //
        // 1) User Interface.
        // 2) Devices.
        // 3) Page Content.
        // 4) Error Mesages.
        // 5) Wireless Carriers.
        // 6) Activation Instructions
        //
        // Verify by doing this:
        // Give Security->AccessControl->Security Roles grant access. Set all access to the listed selections above to no access.
        // Verify no access to customization pulldown and verify access to the Security pulldown.
        // ///////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllNoAccessTest_PulldownNotVisible() 
        {

            // TEST NOTE: Verified fail with security disabled and Customization And Self Service enabled - fails.
            // TEST NOTE: Verified fail with security enabled and Customization And Self Service disabled - fails.
            
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("\nSetup security page for non-admin user to have NO access to Customization selections and access to the Security Roles selection. ");
            Console.WriteLine("Verify the customization pulldown is not there and Security Roles selection is there.");

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

            // Select permissions tab (GEAR->CUSTOMIZATION).
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

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies full access for the following selections found under Gear->Customization.
        // 1) User Interface.
        // 2) Devices.
        // 3) Page Content.
        // 4) Error Mesages.
        // 5) Wireless Carriers.
        // 6) Activation Instructions
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllFullAccessTest()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            // Call base class method that selects the correct tabs, sets the access level, saves the security role page, and logs out.
            Console.WriteLine("    \nSetup security page for non-admin user for FULL access to Customization selections - save and logout.");
            string PermissionsTab = "//li/a[contains(text(),'Configuration Administration')]";
            string NextLevelTab = "Customization and Self-service";
            string AccessLevel = "//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']";
            SelectTabs_SetAccessLevel_Save(PermissionsTab, NextLevelTab, AccessLevel);
            
            // ///////////////
            // User Interface
            // ///////////////
            // Login as non-admin and select user interface page (found under Gear -> Customization).
            Console.WriteLine("    Login as non-admin user, select user interface page and verify save/cancel are present and visible.");
            cm.LogIntoMdm(driver, regularUser, password, url);
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"),WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.LinkText("User Interface"), WaitTimeForElement);            
            driver.FindElement(By.LinkText("User Interface")).Click();

            // Verify save/cancel are present.
            cm.VerifyElementPresentAndDisplayed(true, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.Id("ctl00_MainContent_lnkCancel"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // ///////////////
            // Devices
            // ///////////////
            // Verify full access to Devices (found under Gear -> Customization).

            Console.WriteLine("    Select devices page and verify delete/add are present and visible.");
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[.='Devices']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Devices']")).Click();

            // Verify add/delete are present.
            cm.VerifyElementPresentAndDisplayed(true, By.ClassName("add-device-btn-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.XPath("//div/a[not(@style=\"display: none;\")][@class=\"delete-btn-small\"]"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Verify the search text box and search button are editable.
            Console.WriteLine("    Verify search text and button are editable/enabled.");
            cm.VerifyTextBoxEditable(true, By.Id("searchText"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy Text For test", true);
            // Verify the search button is enabled.            
            driver.FindElement(By.XPath("//div[@id='deviceProfileListFeature']/div/div/div/form/button")).Click();
            cm.VerifyElementEnabled(true, By.XPath("//div[@id='deviceProfileListFeature']/div/div/div/form/button"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // ////////////////
            // Error Messages
            // ////////////////
            // Verify full access to Error Mesages (found under Gear -> Customization).
            
            Console.WriteLine("    Select error message page and verify save button is enabled.");
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[.='Error Messages']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Error Messages']")).Click();

            // Verify save button status.
            cm.WaitForElement(driver, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), WaitTimeForElement);
            cm.VerifyElementEnabled(true, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // TODO: This By.ID doesn't work -- Error Message text box.
            // Verify one of the text box statuses.     
            //cm.WaitForElement(driver, By.Id("52393396977"), WaitTimeForElement);
            //cm.VerifyTextBoxEditable(true, By.Id("52393396977"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy Text To Write", true);

            // ///////////////////
            // Wireless Carriers
            // ///////////////////
            // Verify full access to Wireless Carriers (found under Gear -> Customization).

            Console.WriteLine("    Select Wireless Carrier page and verify add delete/buttons are present.");
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[.='Wireless Carriers']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Wireless Carriers']")).Click();

            // Verify add and delete selections are there.
            //cm.WaitForElement(driver, By.CssSelector("a.delete-btn-small"), WaitTimeForElement);
            cm.VerifyElementEnabled(true, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
            //cm.WaitForElement(driver, By.CssSelector("a.add-carrier-btn-large"), WaitTimeForElement);
            cm.VerifyElementEnabled(true, By.CssSelector("a.add-carrier-btn-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            
            // ////////////////////////
            // Activation Instructions
            // ////////////////////////
            // Verify full access to Activation Instructions (found under Gear -> Customization).
            Console.WriteLine("    Select Activation Instructions page and verify \"Delete Checked Instructions\" and \"New Activation Instructions\" are enabled.");
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[.='Activation Instructions']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Activation Instructions']")).Click();

            // Verify edit selections are enabled  - Delete Checked Instructions and New Activation Instructions.
            cm.WaitForElement(driver, By.Id("ctl00_MainContent_lnkDeleteCollection"), WaitTimeForElement);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_lnkDeleteCollection"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.WaitForElement(driver, By.Id("ctl00_MainContent_lnkAddCollection"), WaitTimeForElement);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_lnkAddCollection"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // ///////////////
            // Page Content
            // ///////////////
            // Verify full access to Page Content (found under Gear -> Customization).

            Console.WriteLine("    -- Starting series of page content tests --.");

            // **************
            TempPageAccessLink = "Android Client Installation Email"; 
            Console.WriteLine("    Select page content selection \"Android Client Installation Email\". Verify save button and text box are present and enabled.");
            GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            driver.FindElement(By.LinkText(TempPageAccessLink)).Click();
            
            // Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            VerifyPageContentSecurity(WaitTimeForElement, true);


            // **************            
            TempPageAccessLink = "BlackBerry Activation Email"; 
            Console.WriteLine("    Select page content selection \"BlackBerry Activation Email\". Verify save button and text box are present and enabled.");
            GoBackToPageContentPage(WaitTimeForElement); // Get to page content page.
            cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            driver.FindElement(By.LinkText(TempPageAccessLink)).Click();
            
            // Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            VerifyPageContentSecurity(WaitTimeForElement, true);

            // Remove too many tests below.
            // ************************
            //TempPageAccessLink = "BlackBerry Delete Account"; 
            //Console.WriteLine("    Select page content selection \"BlackBerry Delete Account\". Verify save button and text box are present and enabled.");
            //GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            //cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            //driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            //// Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            //VerifyPageContentSecurity(WaitTimeForElement, true);

            //// ************************
            //TempPageAccessLink = "BlackBerry New Device Activation";
            //Console.WriteLine("    Select page content selection \"BlackBerry New Device Activation\". Verify save button and text box are present and enabled.");
            //GoBackToPageContentPage(WaitTimeForElement); // Get to page content page.
            //cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            //driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            //// Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            //VerifyPageContentSecurity(WaitTimeForElement, true);

            //// ************************
            //TempPageAccessLink = "BlackBerry Reset Activation Password";
            //Console.WriteLine("    Select page content selection \"BlackBerry Reset Activation Password\". Verify save button and text box are present and enabled.");
            //GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            //cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            //driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            //// Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            //VerifyPageContentSecurity(WaitTimeForElement, true);

            //// ************************
            //TempPageAccessLink = "BlackBerry Reset Device Password";
            //Console.WriteLine("    Select page content selection \"BlackBerry Reset Device Password\". Verify save button and text box are present and enabled.");
            //GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            //cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            //driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            //// Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            //VerifyPageContentSecurity(WaitTimeForElement, true);

            // ************************
            TempPageAccessLink = "Windows Phone 7 Client Installation E-mail";
            Console.WriteLine("    Select page content selection \"Windows Phone 7 Client Installation E-mail\". Verify save button and text box are present and enabled.");
            GoBackToPageContentPage(WaitTimeForElement); // Get tp page content page.
            cm.WaitForElement(driver, By.LinkText(TempPageAccessLink), WaitTimeForElement);
            driver.FindElement(By.LinkText(TempPageAccessLink)).Click();

            // Verify "Font Family" pulldown is present, save button and text box are present and enabled.
            VerifyPageContentSecurity(WaitTimeForElement, true);

            Console.WriteLine("    -- Starting series of page content tests DONE --.");

        }

        // ///////////////////////////////////////////////////////////////////////////////////////
        // Page content page is opened numerous times. This cuts down on repetitive code.
        // Go back to page content page. Page content is found under gear->customization.
        // Input parameter:
        // WaitTimeForElement - number of seconds to wait for timeout in WaitForElement.
        // ///////////////////////////////////////////////////////////////////////////////////////
        void GoBackToPageContentPage(int WaitTimeForElement)
        {
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), WaitTimeForElement);
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            cm.WaitForElement(driver, By.LinkText("Page Content"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Page Content")).Click();
            // Make sure have gotten to Page Content page by checking breadcrum link.
            if(!cm.VerifyElementPresentAndDisplayed(true, By.CssSelector("span.breadcrumBase"), ref VerificationErrors, driver, WaitTimeForElement, true))
            {
                Console.WriteLine("    ERROR in method GoBackToPageContentPage. Expected element to always be present");            
            }
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////
        // Page content page save and text box are checked numerous times. This cuts down on repetitive code.
        // Check that the font pulldown is there. This is a sanity check that the page is open.
        // Then assume a page content page is open. Check element enabled for the text box and the 
        // save button.
        // Parameters:
        // WaitTimeForElement - number of seconds to wait for timeout in WaitForElement.
        // ExpectedResult - whether element is to be present and displayed or not.
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////
        void VerifyPageContentSecurity(int WaitTimeForElement, bool ExpectedResult)
        {
            // Verify "Font Family" pulldown is present. This is a sanity check to verify page is opened.
            cm.WaitForElement(driver, By.Id("txtContentHTML_fontselect_open"), WaitTimeForElement);
            if (!cm.VerifyElementPresentAndDisplayed(true, By.Id("txtContentHTML_fontselect_open"), ref VerificationErrors, driver, WaitTimeForElement, true))
            {
                Console.WriteLine("    ERROR in method VerifyPageContentSecurity. Expected element to always be present");
            }
            // Verify save button status.
            cm.WaitForElement(driver, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), WaitTimeForElement);
            cm.VerifyElementEnabled(ExpectedResult, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);
            // Verify text box status.            
            cm.WaitForElement(driver, By.Id("contentCollectionName"), WaitTimeForElement);
            cm.VerifyTextBoxEditable(ExpectedResult, By.Id("contentCollectionName"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy Text To Write", true);
        }
    }
}


