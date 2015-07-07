// Revision History
//
// Bob Lichtenfels - 3/30/13 -  Checked in these methods:
//                              UserActionsDenyAccessTest
//                              UserActionsDenyUserList
//                              UserActionsGrantAccessTest
//                              UserActionsGrantUserListOnlyTest
// 

using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests; // Allows instantiatiation of CommonMethods.
using System.Threading;
using System.Text.RegularExpressions;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Any_configuration_state.Security_Roles; // Need to get base class inheritance to work.

// Using from when class was created.
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_Configuration_State.Security_Roles
{
    [TestFixture]
    class DevicesUserActions : SecurityRoleBase
    {

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies grant access for the following selections found in a non-admin user's user profile.
        // Selections found under Devices->UserList.
        //
        // Access To User List
        // Access To User Profiles
        // User Based Device Blocking
        // Delete User
        // View User Histories
        // View Security Roles and Permissions     
        // Change Language and Culture
        // Wipe EAS Devices
        // Create Standalone Users
        // Edit Standalone User account details
        // Reset user password / send password reset email            
        //
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UserActionsGrantAccessTest()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user to have grant access to user actions in non-admin user's user profile and MDM user list.");

            // Asssume security role page is open to correct spot Devices->UserActions.
            // Set security to give non-admin user grant access to all of the Devices->UserActions.
            driver.FindElement(By.CssSelector("input.hideWhenReadOnlyPermission")).Click();

            // Save role and sign out
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as non-admin user.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Go to the non-admin's user profile.
            Common.GoToUserProfile(driver);

            // Check that this is a user profile for the logged in non-admin user.
            driver.PageSource.Contains("User Detail"); // Is user detail page.
            driver.PageSource.Contains(regularUser); // Non-admin user is there.

            // * Delete user
            // * Wipe EAS Devices, 
            // * Change language and culture.
            // Select user dropdown and check for delete user, Wipe EAS Devices, 
            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Delete User"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Wipe EAS Devices"), ref VerificationErrors, driver, WaitTimeForElement, true);
            // Below, there is no security for this.
            // cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Override Rule Assignments"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Change user's language and culture"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Shut off pulldown for user actions.
            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();

            // * Permissions
            // * Security Roles
            // * User History
            // Verify History, Permissions, and Security Roles command buttons are present and enabled.
            // TEST NOTE: Also could check for element present and displayed. Left commented code for this below.
            //            The Permissions, Security Roles, and Security Roles command buttons are not present when security is set to deny and are present when security is set to grant.
            cm.VerifyElementEnabled(true, By.CssSelector("div.contentBox-content.vertical-space-children > div.tangoeBtn-container > button.tangoeBtn"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//div[@id='DetailsSection']/div/div/div/div[2]/div[3]/button[2]"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//div[@id='DetailsSection']/div/div/div/div[2]/div[3]/button[3]"), ref VerificationErrors, driver, WaitTimeForElement, true);
            //cm.VerifyElementPresentAndDisplayed(true, By.CssSelector("div.contentBox-content.vertical-space-children > div.tangoeBtn-container > button.tangoeBtn"), ref VerificationErrors, driver, WaitTimeForElement, true);
            //cm.VerifyElementPresentAndDisplayed(true, By.XPath("//div[@id='DetailsSection']/div/div/div/div[2]/div[3]/button[2]") , ref VerificationErrors, driver, WaitTimeForElement, true);
            //cm.VerifyElementPresentAndDisplayed(true, By.XPath("//div[@id='DetailsSection']/div/div/div/div[2]/div[3]/button[3]"), ref VerificationErrors, driver, WaitTimeForElement, true);


            Console.WriteLine("    \nGo back to user list to check non-admin user can create and edit a  standalone user.");
            // Go back to MDM user list.
            string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
            Common.GoToMenu(driver, value);

            // * Create Standalone Users
            // * Edit Standalone Users
            // Verify non-admin user can select add standalone user and can save standalone user.
            cm.VerifyElementEnabled(true, By.CssSelector("a.add-user-btn-large"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Select to add a standalone user and verify the standalone user page is editable.
            cm.WaitForElement(driver, By.CssSelector("a.add-user-btn-large"), WaitTimeForElement);
            driver.FindElement(By.CssSelector("a.add-user-btn-large"));
            driver.FindElement(By.CssSelector("a.add-user-btn-large")).Click();

            // Verify editable text box can be used.
            cm.VerifyTextBoxEditable(true, By.Id("username"), ref VerificationErrors, driver, WaitTimeForElement, "Dummy Test Text", true);

            // Now enter password.
            cm.WaitForElement(driver, By.Id("tempPassword"), WaitTimeForElement);
            driver.FindElement(By.Id("tempPassword"));
            driver.FindElement(By.Id("tempPassword")).SendKeys("This is a temp password");
            
            // Now see if save button in enabled.
            cm.VerifyElementEnabled(true, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This verifies deny access for the following selections found in a non-admin user's user profile.
        // Selections found under Devices->UserList.
        //
        // Access To User List
        // Access To User Profiles
        // User Based Device Blocking
        // Delete User
        // View User Histories
        // View Security Roles and Permissions     
        // Change Language and Culture
        // Wipe EAS Devices
        // Create Standalone Users
        // Edit Standalone User account details
        // Reset user password / send password reset email            
        //
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UserActionsDenyAccessTest()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user to be denied access to all selections under user actions in non-admin user's user profile.");

            // Asssume security role page is open to correct spot Devices->UserActions.
            // Set security to give non-admin user deny access to all of the Devices->UserActions.
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[5]")).Click();

            // Give non-admin user access to Access To User List and Access To User Profiles so user profile can be opened.
            driver.FindElement(By.Name("grant")).Click();
            driver.FindElement(By.XPath("(//input[@name='grant'])[2]")).Click();

            // Save role and sign out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as non-admin user.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Go to the non-admin's user profile.
            Common.GoToUserProfile(driver);

            // Check that this is a user profile for the logged in non-admin user.
            driver.PageSource.Contains("User Detail"); // Is user detail page.
            driver.PageSource.Contains(regularUser); // Non-admin user is there.

            // * Delete user
            // * Wipe EAS Devices
            // * Change language and culture.
            // Select user dropdown and check for delete user, Wipe EAS Devices, 
            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Delete User"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Wipe EAS Devices"), ref VerificationErrors, driver, WaitTimeForElement, true);
            // Below, there is no security for this.
            // cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Override Rule Assignments"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Change user's language and culture"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Shut off pulldown for user actions.
            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();

            // * Permissions 
            // * Security Roles
            // * History
            // Verify History, Permissions, and Security Roles command buttons are not present and not displayed.
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("div.contentBox-content.vertical-space-children > div.tangoeBtn-container > button.tangoeBtn"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.XPath("//div[@id='DetailsSection']/div/div/div/div[2]/div[3]/button[2]"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.XPath("//div[@id='DetailsSection']/div/div/div/div[2]/div[3]/button[3]"), ref VerificationErrors, driver, WaitTimeForElement, true);

            Console.WriteLine("    \nGo back to user list to check non-admin user can NOT select standalone user.");
            // Go back to MDM user list.
            string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
            Common.GoToMenu(driver, value);

            // * Create Standalone Users
            // * Edit Standalone Users
            // Verify non-admin user can NOT select add standalone user.
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.add-user-btn-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify security role for Devices pulldown with no access does not show Devices selection.
        // Enable security pulldown and verify that can be used.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UserActionsDenyUserList()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user to be denied access to user actions and allow access to Activity pulldown (this allows non-admin user to see MDM admin page).");

            // Asssume security role page is open to correct spot Devices->UserActions.
            // Set security to give non-admin user deny access to all of the Devices->UserActions.
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[5]")).Click(); // Don't display devices selection.
            // Below - used to verify if devices selection is shown, test will fail.
            // driver.FindElement(By.CssSelector("input.hideWhenReadOnlyPermission")).Click();  // Yes display devices selection.

            // Set full access (grant) for the activity pulldown so non-admin user can log in.
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Activity')]"));
            driver.FindElement(By.XPath("//li/a[.='Activity']"));
            driver.FindElement(By.XPath("//li/a[.='Activity']")).Click();
            driver.FindElement(By.XPath("//tr[th='Activity']/th/div[div[contains(.,'Grant')]]/input[@type='checkbox']")).Click();

            // Save role and sign out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin and select devices pulldown and activity.
            cm.LogIntoMdm(driver, regularUser, password, url);

            cm.WaitForElement(driver, By.LinkText("Activity"), 10);
            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            // Verify user can see the Error Log in activity pulldown.
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Error Log"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Verify user can't select/see devices pulldown.
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Devices"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // This verifies the security setting that only allows pulldown Devices->User List to see the user list and 
        // not access user profiles.
        // 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UserActionsGrantUserListOnlyTest()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("    \nSetup security page for non-admin user to have grant access to user actions in non-admin user's user profile and MDM user list.");

            // Asssume security role page is open to correct spot Devices->UserActions.
            // Set security to give non-admin user deny access to all of the Devices->UserActions.
            driver.FindElement(By.XPath("(//input[@type='checkbox'])[5]")).Click(); // bladd

            // Now only select to allow access to user list for non-admin user. 
            driver.FindElement(By.Name("grant")).Click(); // bladd
            
            // Save role and sign out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin and select devices pulldown and user list.
            cm.LogIntoMdm(driver, regularUser, password, url);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            
            cm.WaitForElement(driver, By.LinkText("User List"));
            driver.FindElement(By.LinkText("User List"));
            driver.FindElement(By.LinkText("User List")).Click();

            Console.WriteLine("    Verify {0} can NOT get to his user profile", regularUserLastName);
            // Use try/catch to verify selecting non-admin user will cause failure because access to user profile is denied.
            // Tried using element present/displayed/enabled - was not definitive.
            try
            {
                // Attempt to look for and select profile for non-admin user.
                cm.WaitForElement(driver, By.LinkText(regularUserLastName), WaitTimeForElement);                
                driver.FindElement(By.LinkText("Wert, Igor"));
                driver.FindElement(By.LinkText("Wert, Igor")).Click();
            }
            catch
            {
                return; // Could not select. This is expected, return.
            }

            // Shouldn't get here. We were able to select the non-admin user's profile. This is an error.
            Console.WriteLine("    !Failure. Have been able to select user non-admin user and get to the user profile. This should not be allowed.");
            VerificationErrors.Append("!Failure. Should not have been able to select user profile for non-admin user. ");        
        }
    }
}
