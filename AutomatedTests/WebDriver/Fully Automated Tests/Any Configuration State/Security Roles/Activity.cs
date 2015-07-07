// Revision History
//
// Bob Lichtenfels - 2/28/13 -  Started and finished Grant test.
// Bob Lichtenfels - 3/5/13 - Finished.
//

using System;
using System.Collections.Generic;
using System.Linq;
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
    class Activity : SecurityRoleBase
    {

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies grant access for the following selections found Activity pulldown.
        // 1) Activity Dashboard.
        // 2) Reports.
        // 3) Activity Status.
        // 4) Event Log.
        // 5) Error Log.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ActivityGrantAccessTest()
        {

            int WaitTimeForElement = 5; // Timeout for calls to methods with waits.

            Console.WriteLine("    \nSetup security page for non-admin user given GRANT access to Activity pulldown. Save and logout.");            
            // Set full access (grant) for the activity pulldown.
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Activity')]"));
            driver.FindElement(By.XPath("//li/a[.='Activity']"));
            driver.FindElement(By.XPath("//li/a[.='Activity']")).Click();
            driver.FindElement(By.XPath("//tr[th='Activity']/th/div[div[contains(.,'Grant')]]/input[@type='checkbox']")).Click();
            cm.SaveSecurityRole(driver);

            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin, select Activity pulldown, and check grant access for all pulldown selections.
            Console.WriteLine("    Login as non-admin, select Activity pulldown, and check grant access for all pulldown selections.");
            cm.LogIntoMdm(driver, regularUser, password, url);
            
            cm.WaitForElement(driver,By.LinkText("Activity"),10);
            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();
            
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Activity Dashboard"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Reports"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Activity Status"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Event Log"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Error Log"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies deny access for the following selections found Activity pulldown.
        // 1) Activity Dashboard.
        // 2) Reports.
        // 3) Activity Status.
        // 4) Event Log.
        // 5) Error Log.
        //
        // Do this by diasbling all Activity pulldown selections and enabaling the Gear-System pulldown. Then verify
        // the Gear->System is visible and the Activity pulldown is not.
        // 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ActivityDenyAccessTest_ActivityPulldownNotVisible()
        {

            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user to DENY access to selections in Activity pulldown.");

            // Set deny access for the activity pulldown. This will disable the 
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Activity')]"));
            driver.FindElement(By.XPath("//li/a[.='Activity']"));
            driver.FindElement(By.XPath("//li/a[.='Activity']")).Click();
            driver.FindElement(By.XPath("//tr[th='Activity']/th/div[div[contains(.,'Deny')]]/input[@type='checkbox']")).Click();

            // Call base class method that selects the correct tabs, sets the access level, saves the security role page, and logs out.
            // This will enable the Gear->System pulldown selection.
            string PermissionsTab = "//li/a[contains(text(),'Configuration Administration')]";
            string NextLevelTab = "System";
            string AccessLevel = "//tr[th='System']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']";
            SelectTabs_SetAccessLevel_Save(PermissionsTab, NextLevelTab, AccessLevel);

            cm.LogIntoMdm(driver, regularUser, password, url);
            cm.VerifyElementPresentAndDisplayed(true, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Activity"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }


        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies deny access for the following selections found Activity pulldown.
        // 1) Activity Dashboard.
        // 2) Reports.
        // 3) Activity Status.
        // 4) Event Log.
        // 5) Error Log.
        //
        // This test will disable all pulldown selections except Reports and then verify all slections are not selectable except Reports.
        // 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ActivityDenyAccessTest_ActivityPulldownVisible_ViewOnlyReports()
        {

            int WaitTimeForElement = 3; // Timeout for calls that use waiting.

            Console.WriteLine("    \nSetup security page for non-admin user given NO access to Activity selections except Reports. Verify all System selections are missing in pulldown except Reports.");

            // Set deny access for the activity pulldown (as admin) and save.
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Activity')]"));
            driver.FindElement(By.XPath("//li/a[.='Activity']"));
            driver.FindElement(By.XPath("//li/a[.='Activity']")).Click();
            driver.FindElement(By.XPath("//tr[th='Activity']/th/div[div[contains(.,'Deny')]]/input[@type='checkbox']"));
            driver.FindElement(By.XPath("//tr[th='Activity']/th/div[div[contains(.,'Deny')]]/input[@type='checkbox']")).Click();
            // Grant reports.
            driver.FindElement(By.XPath("(//input[@name='grant'])[32]"));
            driver.FindElement(By.XPath("(//input[@name='grant'])[32]")).Click();
            cm.SaveSecurityRole(driver);
            
            // Logout admin.
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin, select Activity pulldown, and check grant access is only given to Reports.
            Console.WriteLine("    Login as non-admin, select Activity pulldown, and check grant access for all pulldown selections.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            cm.WaitForElement(driver, By.LinkText("Activity"), 10);
            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            // Verify the ony selection shown is Reports. Very all others are not there.
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Reports"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Error Log"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Activity Dashboard"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("EActivity Status"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Event Log"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies deny access for the following selections found under Activity pulldown except event log.
        // 1) Activity Dashboard.
        // 2) Reports.
        // 3) Activity Status.
        // 4) Event Log.
        // 5) Error Log.
        //
        // This test will disable all pulldown selections except Event Log and then verify all slections are not selectable except Event Log.
        // 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ActivityDenyAccessTest_ActivityPulldownVisible_ViewOnlyEventLog()
        {
            int WaitTimeForElement = 3; // Timeout for calls that use waiting.

            Console.WriteLine("    \nSetup security page for non-admin user given NO access to Activity selections except Event Log. Verify Activity Status is not there and Event Log is.");

            // Set deny access for the activity pulldown (as admin) and save.
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Activity')]"));
            driver.FindElement(By.XPath("//li/a[.='Activity']"));
            driver.FindElement(By.XPath("//li/a[.='Activity']")).Click();
            driver.FindElement(By.XPath("//tr[th='Activity']/th/div[div[contains(.,'Deny')]]/input[@type='checkbox']"));
            driver.FindElement(By.XPath("//tr[th='Activity']/th/div[div[contains(.,'Deny')]]/input[@type='checkbox']")).Click();
            // Grant event log.
            driver.FindElement(By.XPath("(//input[@name='grant'])[34]"));
            driver.FindElement(By.XPath("(//input[@name='grant'])[34]")).Click();
            cm.SaveSecurityRole(driver);

            // Logout admin.
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin, select Activity pulldown, and check grant access is only given to Reports.
            Console.WriteLine("    Login as non-admin, select Activity pulldown, and check grant access for all pulldown selections.");
            cm.LogIntoMdm(driver, regularUser, password, url);

            cm.WaitForElement(driver, By.LinkText("Activity"), 10);
            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            // Verify the ony selection is Event Log. Verify Activity status is not there. All other selections have been checked for no presense in previous test.
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Activity Status"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Event Log"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }
    }
}
