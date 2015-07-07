// Revision History
//
// Bob Lichtenfels - 11/24/12 - Created. This base class is for testing certain types of secruity roles. It currently instantiates 
//                              CommonMethods and verificationErrors classes to be used by the test classes that inherit from 
//                              it. CommonMethods is an existing class that has methods for WebDriver actions. VerificationErrors 
//                              is a StringBuilder class that is created in this base class. This base class inherits from the 
//                              Setup base class where MDM admin login is provided and XML config information is read in from a 
//                              config file. The information read in from the config file is used by this base class and inherting 
//                              test classes.
// Bob Lichtenfels - 11/24/12 - Added TeardownTest method and checked into correct folder in Webdriver project.
// Bob Lichtenfels - 2/3/13  -  Added SelectTabs_SetAccessLevel_Save and UpdateExistingSecuritySettings.
// Bob Lichtenfels - 4/6/13  -  Added commented timer code into setup and teardown. Add try/catch around delete security role.
// Bob Lichtenfels - 4/6/13  -  Added EnableSecurityRolesPulldown
// 
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumTests;  // Allows to instantiate CommonMethods.
using System.Threading;
using System.Text;
using System.IO;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_configuration_state.Security_Roles
{
    public class SecurityRoleBase : Setup
    {

        public CommonMethods cm = new CommonMethods();
        public StringBuilder VerificationErrors = new StringBuilder();

        // Need these until can read in config file.
        public string roleName = "delete me";
        public string roleAssignment = "sn=wert";

        [SetUp]
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // As Admin:
        // 1) Open security role list page and delete any existing roles with the same name as roleName variable.
        // 2) Start a new security role using variables roleName and roleAssignment.
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetupTest()
        {
            Console.WriteLine("\nRunning Setup Test In Base Class...");

            //StreamWriter writerSetup = new StreamWriter("C:\\LichPublic\\SetupTime.txt", true);
            //DateTime StartupStart = DateTime.UtcNow;

            // May not need this because VerificationErrors is instantiated at beginning of each test run, but, this doesn't hurt.
            VerificationErrors.Clear(); 
            
            // Delete existing security role(s) if they exist.
            cm.DeleteExistingSecurityRole(driver, roleName, 15);

            // Add and setup admin security role for editing.
            //Console.WriteLine("    Add and setup security role for editing as admin.");
            cm.StartNewSecurityRoleWithNameAndQueryUpdateOne(driver, 10, roleName, roleAssignment);
            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();

            //DateTime StartupEnd = DateTime.UtcNow;
            //writerSetup.WriteLine("Measured time Setup: " + (StartupEnd - StartupStart).TotalSeconds + " seconds");
            //writerSetup.Close();
            
            Console.WriteLine("Running Setup Test In Base Class Complete...");
        }

        [TearDown]
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // As Admin:
        // 1) Open security role list page and delete any existing roles with the same name as roleName variable.
        // 2) Sign out and stop webdriver.
        // 3) Check to see if there were any errors (using an assert statement).
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void TeardownTest()
        {
            try
            {
                Console.WriteLine("\nRunning Teardown Test In Base Class...");

                //StreamWriter WriterTearDown = new StreamWriter("C:\\LichPublic\\TeardownTime.txt", true);
                //DateTime TeardownStart = DateTime.UtcNow;
                
                Console.WriteLine("    Login as admin and delete any security role added if present.");
                cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
                driver.FindElement(By.LinkText("Sign Out")).Click();
                cm.LogIntoMdm(driver, user, password, url);

                Console.WriteLine("    Select security roles in pulldown.");
                cm.WaitForElement(driver, By.LinkText("Security"), 10);
                driver.FindElement(By.LinkText("Security"));
                driver.FindElement(By.LinkText("Security")).Click();
                cm.WaitForElement(driver, By.LinkText("Security Roles"), 10);
                driver.FindElement(By.LinkText("Security Roles")).Click();

                Console.WriteLine("    Delete security role if needed.");

                // Try/Catch in case delete fails. 
                try
                {
                    Common.DeleteSecurityRole(driver, roleName);
                }
                catch (AssertionException e)
                {
                    Console.WriteLine("    Try catch fail in Common.DeleteSecurityRole method called from TeardownTest. Error is {0}", e.Message);
                }

                // Signout.
                Console.WriteLine("    Signout and stop webdriver.");
                cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
                driver.FindElement(By.LinkText("Sign Out")).Click();

                //DateTime TeardownEnd = DateTime.UtcNow;
                //WriterTearDown.WriteLine("Measured time TearDown: " + (TeardownEnd - TeardownStart).TotalSeconds + " seconds");
                //WriterTearDown.Close();
                driver.Quit();
            }

            catch (Exception)
            {
                Console.WriteLine("    Fail In TeardownTest method. Exception caught.");
                driver.Quit(); // If get error, still try to shut everyting down.                
            }
            Assert.AreEqual("", VerificationErrors.ToString());
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // This is used for selecting a single checkbox. The parameters are limited in their type. See Parameters list further below.
        //
        // This is used to setup security role settings. It is assumed the security role page is opened, the edit
        // permission command button has been selected, and admin is the user.
        // Select the permissions tab, the tab under the permissons tab, set access level, and 
        // save security role if requested.
        //
        // Parameters:
        // PermissionsTabToSelect (Xpath) - the permissions tab to select.
        // NextLevelTabToSelect (Link Text) - Selection found under the permissions tab.
        // AccessLevel (Xpath) - access level setting (one checkbox).
        // Timeout (int) - optional for setting amount of time to wait for elements.
        //
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SelectTabs_SetAccessLevel_Save(string PermissionsTabToSelect, string NextLevelTabToSelect, string AccessLevel, int Timeout = 10)
        {
            Console.WriteLine("    Base Class: Select tabs, access level, set access, and save security role that is already open.");

            // Select permissions tab.
            cm.WaitForElement(driver, By.XPath(PermissionsTabToSelect), Timeout);
            driver.FindElement(By.XPath(PermissionsTabToSelect));
            driver.FindElement(By.XPath(PermissionsTabToSelect)).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText(NextLevelTabToSelect));
            driver.FindElement(By.LinkText(NextLevelTabToSelect));
            driver.FindElement(By.LinkText(NextLevelTabToSelect)).Click();

            // Set access level.
            cm.WaitForElement(driver, By.XPath(AccessLevel), Timeout);
            driver.FindElement(By.XPath(AccessLevel));
            driver.FindElement(By.XPath(AccessLevel)).Click();

            // Save security role and log out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), Timeout);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), Timeout);
            driver.FindElement(By.LinkText("Sign Out")).Click();
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Assume we are at the login page and want to set one checkbox somewhere in the rolename security role page. 
        //
        // This is going to login as admin, open the security role rolename, and then select a checkbox according to
        // the parameters sent in. This is for changing an existing security role on the fly.
        //
        // Parameters:
        // PermissionsTabToSelect (Xpath) - the permissions tab to select.
        // NextLevelTabToSelect - Selection found under the permissions tab.
        // AccessLevel - access level setting (one checkbox).
        //
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UpdateExistingSecuritySettings(string PermissionsTabToSelect, string NextLevelTabToSelect, string AccessLevel)
        {
            int SleepTime = 11;

            Console.WriteLine("    Base Class: Update Existing Security Role Page by logging in as admin, selecting security role, editing, and saving.");            

            // Login as admin.
            driver.FindElement(By.Id("userNameTextBox")).SendKeys(user);
            driver.FindElement(By.Id("passwordTextBox")).SendKeys(password);
            driver.FindElement(By.Id("loginBtn")).Click();
            Common.WaitForElement(driver, By.ClassName("breadcrumbs"), SleepTime);
            
            // Go to secuity roles page and open existing role.
            cm.WaitForElement(driver, By.LinkText("Security"), SleepTime);
            driver.FindElement(By.LinkText("Security"));
            driver.FindElement(By.LinkText("Security")).Click();
            cm.WaitForElement(driver, By.LinkText("Security Roles"), SleepTime);
            driver.FindElement(By.LinkText("Security Roles"));
            driver.FindElement(By.LinkText("Security Roles")).Click();
            Thread.Sleep(SleepTime);

            cm.WaitForElement(driver, By.LinkText("Security"), SleepTime);
            cm.WaitForElement(driver, By.LinkText("delete me"), SleepTime);
            driver.FindElement(By.LinkText("delete me"));
            driver.FindElement(By.LinkText("delete me")).Click();

            // Now select the checkbox to be set by calling method below. Method below selects checkbox, saves security role, and logs out.
            SelectTabs_SetAccessLevel_Save(PermissionsTabToSelect, NextLevelTabToSelect, AccessLevel);
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // This makes settings in sercurity page to enable the security roles pulldown. It assumes the security roles page is open.
        //
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void EnableSecurityRolesPulldown(int WaitTimeForElement)
        {
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
        }
    }
}
