// Revision History
//
// Bob Lichtenfels - 1/11/13 -   Checked into correct folder in Webdriver environment.
// Bob Lichtenfels - 11/24/12 -  Brought into WebDriver new ENV from old ENV. Inherited from SecurityRoleBase.
// Bob Lichtenfels - 12/12/12 -  Checked in with full, read, no access tests and teardown class.
// Bob Lichtenfels - 1/19/13  -  Change some test classes to use base class methods.
// Bob Lichtenfels - 2/3/13  -   Cleanup some comments.
//


using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests; // Allows to instantiate CommonMethods.
using System.Threading;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Any_configuration_state.Security_Roles; // To get base class

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_Configuration_State.Security_Roles
{
    [TestFixture]
    class SecurityAccessControl :  SecurityRoleBase
    {

        int WaitTimeForElement = 0; // How long to wait when calling WaitForElement method.

        //[SetUp]
        //public void SetupTest()
        //{
        //}

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check full access for Security roles page with non-admin user.
        // Role being edited is Security > Access Control > Security Roles > Access Control > Security Roles. 
        // Page being tested is Security > Access Control > Security Roles.
        // 1) At this point security role page is opened to a pre-existing security role.
        // 2) Setup a non-admin role that will allow full acces to page being tested.
        // 3) Login as non-admin and verify full access to page being tested.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SecurityAccessControlFullAccessTest()
        {
            WaitTimeForElement = 5; // How long to wait when calling WaitForElement.

            Console.WriteLine("\nRunning full access for Security Roles page.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for FULL access to security list and security page - save and logout.");


            // Call base class method that selects the correct tabs, sets the access level, saves the security role page, and logs out.
            SelectTabs_SetAccessLevel_Save("//li/a[.='Security']", "Access Control", "//tr[td='Security Roles']/td/input[@name='full']");

            // Login as the non-admin user.
            Console.WriteLine("    Log in as non-admin user, open security role page, and check READ access security.");
            cm.LogIntoMdm(driver, regularUser, password, url);
            Common.WaitForElement(driver, By.LinkText("Security"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Security"));
            driver.FindElement(By.LinkText("Security")).Click();
            Common.WaitForElement(driver, By.LinkText("Security Roles"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Security Roles"));
            driver.FindElement(By.LinkText("Security Roles")).Click();

            Console.WriteLine("    Verify add and delete selections for security roles list are present.");
            cm.VerifyElementPresentAndDisplayed(true, By.CssSelector("a.add-security-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Open a security role and verify it is editable.
            Console.WriteLine("    Open a security role and verify it is editable.");
            cm.WaitForElement(driver, By.LinkText("delete me"), 10);
            driver.FindElement(By.LinkText("delete me"));
            driver.FindElement(By.LinkText("delete me")).Click();

            // Check role name textbox.
            cm.VerifyTextBoxEditable(true, By.Id("roleNameTextBox"), ref VerificationErrors, driver, WaitTimeForElement, roleName, true);

            // Assume we are looking at Devices->User Actions. Verify some editable checkboxes in Devices->UserActions.
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Access To User Profiles']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Change Language and Culture']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Change Language and Culture']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Verify some editable checkboxes in Activity. First select activity tab.
            cm.WaitForElement(driver, By.LinkText("Activity"), 10);
            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Activity Status']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Activity Status']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Error Log']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Error Log']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Verify some editable checkboxes in MDM Clients. First select MDM clients tab.
            cm.WaitForElement(driver, By.LinkText("MDM Clients"), 10);
            driver.FindElement(By.LinkText("MDM Clients"));
            driver.FindElement(By.LinkText("MDM Clients")).Click();

            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Access to Enterprise Application Portal']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Access to Enterprise Application Portal']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Go to role assignment text box and check readonly.
            Console.WriteLine("    Select role assignment text box and check full access.");
            cm.WaitForElement(driver, By.XPath("//button[contains(.,'Edit Assignment')]"), 15);
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]"));
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]")).Click();

            //cm.DebugTimeout(20, "Is text box there (edit assignment) -- fails with new webdriver EXE.");

            cm.VerifyTextBoxEditable(true, By.Id("undefined_txtLdapFreeform"), ref VerificationErrors, driver, WaitTimeForElement, roleName, true);

            Console.WriteLine("Have reached the end of full access test for Security Roles page.");
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check read access for Security roles page with non-admin user.
        // Role being edited is Security > Access Control > Security Roles > Access Control > Security Roles. 
        // Page being tested is Security > Access Control > Security Roles.
        // 1) At this point security role page is opened to a pre-existing security role.
        // 2) Setup a non-admin role that will allow read access to page being tested.
        // 3) Login as non-admin and verify read access to page being tested.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SecurityAccessControlReadAccessTest()
        {
            int WaitTimeForElement = 5;

            Console.WriteLine("\nRunning read access for Security Roles page.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for READ access to security list and security page - save and logout.");

            string PermissionsTab = "//li/a[.='Security']";
            string NextLevelTab = "Access Control";
            string AccessLevel = "//tr[td='Security Roles']/td/input[@name='read']";

            // Call base class method that selects the correct tabs, sets the access level, saves the security role page, and logs out.
            SelectTabs_SetAccessLevel_Save(PermissionsTab, NextLevelTab, AccessLevel);

            // Login as the non-admin user.
            Console.WriteLine("    Log in as non-admin user, open security role page, and check READ access security.");
            cm.LogIntoMdm(driver, regularUser, password, url);
            cm.WaitForElement(driver, By.LinkText("Security"), 15);
            driver.FindElement(By.LinkText("Security"));
            driver.FindElement(By.LinkText("Security")).Click();
            cm.WaitForElement(driver, By.LinkText("Security Roles"), 15);
            driver.FindElement(By.LinkText("Security Roles"));
            driver.FindElement(By.LinkText("Security Roles")).Click();
            Console.WriteLine("    Finished opening security role page.");

            Console.WriteLine("    Verify add and delete selections for security roles list are present.");
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.add-security-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Open a security role and verify it is editable.
            Console.WriteLine("    Open a security role and verify it is editable.");
            cm.WaitForElement(driver, By.LinkText("delete me"), 10);
            driver.FindElement(By.LinkText("delete me"));
            driver.FindElement(By.LinkText("delete me")).Click();

            // Check role name textbox.
            cm.VerifyTextBoxEditable(false, By.Id("roleNameTextBox"), ref VerificationErrors, driver, WaitTimeForElement, roleName, true);

            // Assume we are looking at Devices->User Actions. Verify some editable checkboxes in Devices->UserActions.
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Access To User Profiles']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Change Language and Culture']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Change Language and Culture']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Verify some editable checkboxes in Activity. First select activity tab.
            cm.WaitForElement(driver, By.LinkText("Activity"), 10);
            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Activity Status']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Activity Status']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Error Log']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Error Log']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Verify some editable checkboxes in MDM Clients. First select MDM clients tab.
            cm.WaitForElement(driver, By.LinkText("MDM Clients"), 10);
            driver.FindElement(By.LinkText("MDM Clients"));
            driver.FindElement(By.LinkText("MDM Clients")).Click();

            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Access to Enterprise Application Portal']/td/input[@name='grant']"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Access to Enterprise Application Portal']/td/input[@name='deny']"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Go to role assignment text box and check readonly.
            cm.WaitForElement(driver, By.XPath("//button[contains(.,'Edit Assignment')]"), 15);
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]"));
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]")).Click();

            cm.VerifyTextBoxEditable(false, By.Id("undefined_txtLdapFreeform"), ref VerificationErrors, driver, WaitTimeForElement, roleName, true);

            Console.WriteLine("Have reached the end of read access test for Security Roles page.");
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check no access for Security roles page with non-admin user.
        // Role being edited is Security > Access Control > Security Roles > Access Control > Security Roles. 
        // Page being tested is Security > Access Control > Security Roles.
        // 1) At this point security role page is opened to a pre-existing security role.
        // 2) Setup a non-admin role that will allow no access to page being tested.
        // 3) Allow non-admin user access to the event log page so something comes up at login.
        // 3) Login as non-admin and verify no access to page being tested.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SecurityAccessControlNoAccessTest()
        {
            int WaitTimeForElement = 5;

            Console.WriteLine("\nRunning no access for Security Roles page.");

            // Setup security page for non-admin user for no access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for NO access to all security Access control - save and log out.");

            cm.WaitForElement(driver, By.XPath("//li/a[.='Security']"), 10);
            driver.FindElement(By.XPath("//li/a[.='Security']")).Click();
            cm.WaitForElement(driver, By.LinkText("Access Control"), 10);
            driver.FindElement(By.LinkText("Access Control")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[td='Security Roles']/td/input[@name='none']"), 10);
            driver.FindElement(By.XPath("//tr[td='Security Roles']/td/input[@name='none']")).Click();

            // Give non-admin user some access to event log so MDM comes up with something in admin page when they log in.
            Console.WriteLine("    Give non-admin user some access to event log so MDM comes up with something in admin page when they log in.");
            cm.WaitForElement(driver, By.XPath("//li/a[.='Activity']"), 10);
            driver.FindElement(By.XPath("//li/a[.='Activity']")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[td='Event Log']/td/input[@name='grant']"), 10);
            driver.FindElement(By.XPath("//tr[td='Event Log']/td/input[@name='grant']")).Click();

            cm.DebugTimeout(15, "More Selections done");

            // Save security role and log out.
            Console.WriteLine("    Save security role and log out.");
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.DebugTimeout(15, "Save/Logout");

            // Login as the non-admin user and check security selection on admin page is not present and event log selection on admin page is present.
            Console.WriteLine("    Login as the non-admin user and check security selection on admin page is not present and event log selection is present.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Activity"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Security"), ref VerificationErrors, driver, WaitTimeForElement, true);

            Console.WriteLine("Have reached the end of no access test for Security Roles page.");
        }
    }
}

