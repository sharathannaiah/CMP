// Revision History
//
// Bob Lichtenfels - 8/9/12  - Created and checked in. Added AccessToSecurityRolesFullAccessTest and AccessToSecurityRolesReadAccessTest with helper methods.
// Michael McAfee -  8/10/12 - removed unused variables
// Bob Lichtenfels - 8/11/12 - Refactored to make this test class like the other security role test classes. Used Xpath in some places to check for
//                             for presence and non-presence of elements. Added try-catch around areas that give intermittent failures.
//                             Removed helper methods that are no longer needed.
// Bob Lichtenfels - 8/17/12 - Refactored after code review with Michael. Currently have two methods. One for all Full Access and one for all Read Access.
// Bob Lichtenfels - 8/21/12 - Finished the two methods and aded a helper method. The methods check full and read access of security roles page for non-admin user.
// Michael McAfee - 8/21/12 -  Renamed the namespace and class so nUnit will group better, put in Fully Automated Tests/Security Roles folder
// Bob Lichtenfels - 8/22/12 - Added no access test.
// Michael McAfee - 8/23/12 -  Add namespace level: NoConfiguration
// Bob Lichtenfels - 8/22/12 - Added logging to helper method at bottom of file.
// Bob Lichtenfels - 8/28/12 - Added different type of wait to Full Access test.
// Bob Lichtenfels - 9/3/12 -  Changed method for no access - allow full access to Policy Assignment instead of full access to 
//                             Policy Profiles. Policy Profiles has been assigned an index instead of "link=".
// Bob Lichtenfels - 9/9/12 -  Changed SecurityAccessControlNoAccessTest to not rely on Android device being selected in MDM server page.
//
//
// Notes before moving to Webdriver folder - final quick testing - comment the following setup test:
// cm.LogIntoMdm(driver, adminUserName, password, baseURL); 
// cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);
// cm.StartNewSecurityRoleWithNameAndQueryUpdateOne(driver, sleepTime, roleName, roleAssignment);
// driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
// In test class - Comment everything up to this comment point: ==>> // Login as the non-admin user.


// 
//
//


using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;

namespace SeleniumTests.FullyAutomatedTests.AnyConfiguration.SecurityRoles
{

    [TestFixture]
    class SecurityAccessControl
    {

        IWebDriver driver; 
        private string baseURL; 


        SeleniumTests.CommonMethods cm = new CommonMethods();

        private ISelenium selenium;
        private StringBuilder verificationErrors;
        // EnmKeys will retrieve these values from the local config.xml file.
        public enum EnmKeys
        {
            browserString,
            browserUrl,
            adminUserName,
            password,
            roleName,
            roleAssignment,
            regularUserName,
            sleepTime,
            waitForPageToLoad
        }

        string browserString;   //type of browser (firefox, internet explorer, etc.)
        string browserUrl;  //MDM server
        string adminUserName;
        string password;
        string roleName;    //name of the security role that will be created
        string roleAssignment;  //LDAP query syntax used to determine who gets the security role
        string regularUserName; //user who belongs to the security role
        string waitForPageToLoad;
        int sleepTime;

        [SetUp]
        public void SetupTest()
        {
            Console.WriteLine("\nRunning Setup Test ...");

            // load config file values (NOTE: When adding a config file like this, make sure that you right click on it > Properties > Copy to Output Directory > Always
            XDocument config = XDocument.Load("config.xml");
            // create string dictionary
            Dictionary<string, string> strings = new Dictionary<string, string>();
            // loop through config file and add to dictionary
            foreach (XElement elm in config.Descendants("string"))
            {
                strings.Add(elm.Descendants("key").First().Value, elm.Descendants("value").First().Value);
            }

            // ints
            Dictionary<string, int> ints = new Dictionary<string, int>();
            // loop through config file and add to dictionary
            foreach (XElement elm in config.Descendants("int"))
            {
                ints.Add(elm.Descendants("key").First().Value, Convert.ToInt32(elm.Descendants("value").First().Value));
            }

            browserString = strings[EnmKeys.browserString.ToString()];
            browserUrl = strings[EnmKeys.browserUrl.ToString()];
            adminUserName = strings[EnmKeys.adminUserName.ToString()];
            password = strings[EnmKeys.password.ToString()];
            roleName = strings[EnmKeys.roleName.ToString()];
            roleAssignment = strings[EnmKeys.roleAssignment.ToString()];
            regularUserName = strings[EnmKeys.regularUserName.ToString()];
            waitForPageToLoad = strings[EnmKeys.waitForPageToLoad.ToString()];
            sleepTime = ints[EnmKeys.sleepTime.ToString()];

            driver = new InternetExplorerDriver();
            
            //driver = new InternetExplorerDriver();  
            baseURL = browserUrl;

            verificationErrors = new StringBuilder();

            // Login, delete any security roles that have the same name as the name being used to test,
            // open up security role page, and set it to admin.
            cm.LogIntoMdm(driver, adminUserName, password, baseURL);  

            //Console.WriteLine("    Delete any existing security roles.");
            cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);

            Console.WriteLine("    Startup new security role.");
            cm.StartNewSecurityRoleWithNameAndQueryUpdateOne(driver, sleepTime, roleName, roleAssignment);
            
            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
            Console.WriteLine("    Existing security role deletion complete. New security role has been created and is ready/open for editimg.\n");
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check full access for Security roles page with non-admin user.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SecurityAccessControlFullAccessTest()
        {
            int WaitTimeForElement = 5;
            
            Console.WriteLine("\nRunning full access for Security Roles page.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for full access for security list and security page.");
            cm.WaitForElement(driver, By.XPath("//li/a[.='Security']"), 10);
            driver.FindElement(By.XPath("//li/a[.='Security']")).Click();
            cm.WaitForElement(driver, (By.LinkText("Access Control")), 10);
            driver.FindElement(By.LinkText("Access Control")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[td='Security Roles']/td/input[@name='full']"), 10);
            driver.FindElement(By.XPath("//tr[td='Security Roles']/td/input[@name='full']")).Click();

            // Save security role and log out.
            Console.WriteLine("    Save security role and log out.");
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), 10);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            Console.WriteLine("Are we signed out !!!!!!!!!!!!!! ."); // bladd
            Thread.Sleep(20000);
            
            // Login as the non-admin user.
            Console.WriteLine("    Log in as non-admin user and check full access security.");
            cm.LogIntoMdm(driver, regularUserName, password,baseURL);
            cm.WaitForElement(driver, By.LinkText("Security"), 15);
            driver.FindElement(By.LinkText("Security"));
            driver.FindElement(By.LinkText("Security")).Click();
            cm.WaitForElement(driver, By.LinkText("Security Roles"), 15);
            driver.FindElement(By.LinkText("Security Roles"));
            driver.FindElement(By.LinkText("Security Roles")).Click();
            Console.WriteLine("    Finished opening security role page.");

            Console.WriteLine("    Verify add and delete selections for security roles list are present.");
            cm.VerifyElementPresentAndDisplayed(true, By.CssSelector("a.add-security-large"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(true, By.CssSelector("a.delete-btn-small"), ref verificationErrors, driver, WaitTimeForElement, true);

            // Open a security role and verify it is editable.
            Console.WriteLine("    Open a security role and verify it is editable.");
            cm.WaitForElement(driver, By.LinkText("delete me"), 10);
            driver.FindElement(By.LinkText("delete me"));            
            driver.FindElement(By.LinkText("delete me")).Click();

            // Check role name textbox.
            cm.VerifyTextBoxEditable(true, By.Id("roleNameTextBox"), ref verificationErrors, driver, WaitTimeForElement, roleName, true);
            
            // Assume we are looking at Devices->User Actions. Verify some editable checkboxes in Devices->UserActions.
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Access To User Profiles']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Change Language and Culture']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Change Language and Culture']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);
 
            // Verify some editable checkboxes in Activity. First select activity tab.
            cm.WaitForElement(driver, By.LinkText("Activity"), 10);
            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Activity Status']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Activity Status']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Error Log']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Error Log']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);

            // Verify some editable checkboxes in MDM Clients. First select MDM clients tab.
            cm.WaitForElement(driver, By.LinkText("MDM Clients"), 10);
            driver.FindElement(By.LinkText("MDM Clients"));
            driver.FindElement(By.LinkText("MDM Clients")).Click();

            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Access to Enterprise Application Portal']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("//tr[td='Access to Enterprise Application Portal']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);

            // Go to role assignment text box and check readonly.
            cm.WaitForElement(driver, By.XPath("//button[contains(.,'Edit Assignment')]"), 15);
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]"));
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]")).Click();

            cm.VerifyTextBoxEditable(true, By.Id("undefined_txtLdapFreeform"), ref verificationErrors, driver, WaitTimeForElement, roleName, true);            

            Console.WriteLine("Have reached the end of full access test for Security Roles page **************.");
        }
 
        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check read access for Security roles page with non-admin user.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SecurityAccessControlReadAccessTest()
        {
            int WaitTimeForElement = 5;

            Console.WriteLine("\nRunning read access for Security Roles page.");

            // Setup security page for non-admin user for full access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for full access for security list and security page.");
            cm.WaitForElement(driver, By.XPath("//li/a[.='Security']"), 10);
            driver.FindElement(By.XPath("//li/a[.='Security']")).Click();
            cm.WaitForElement(driver, By.LinkText("Access Control"), 10);
            driver.FindElement(By.LinkText("Access Control")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[td='Security Roles']/td/input[@name='read']"), 10);
            driver.FindElement(By.XPath("//tr[td='Security Roles']/td/input[@name='read']")).Click(); //

            // Save security role and log out.
            Console.WriteLine("    Save security role and log out.");
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), 10);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            Console.WriteLine("Are we signed out !!!!!!!!!!!!!! ."); // bladd
            Thread.Sleep(20000);

            // Login as the non-admin user.
            Console.WriteLine("    Log in as non-admin user and check full access security.");
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);
            cm.WaitForElement(driver, By.LinkText("Security"), 15);
            driver.FindElement(By.LinkText("Security"));
            driver.FindElement(By.LinkText("Security")).Click();
            cm.WaitForElement(driver, By.LinkText("Security Roles"), 15);
            driver.FindElement(By.LinkText("Security Roles"));
            driver.FindElement(By.LinkText("Security Roles")).Click();
            Console.WriteLine("    Finished opening security role page.");

            Console.WriteLine("    Verify add and delete selections for security roles list are present.");
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.add-security-large"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.delete-btn-small"), ref verificationErrors, driver, WaitTimeForElement, true);

            // Open a security role and verify it is editable.
            Console.WriteLine("    Open a security role and verify it is editable.");
            cm.WaitForElement(driver, By.LinkText("delete me"), 10);
            driver.FindElement(By.LinkText("delete me"));
            driver.FindElement(By.LinkText("delete me")).Click();

            // Check role name textbox.
            cm.VerifyTextBoxEditable(false, By.Id("roleNameTextBox"), ref verificationErrors, driver, WaitTimeForElement, roleName, true);

            // Assume we are looking at Devices->User Actions. Verify some editable checkboxes in Devices->UserActions.
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Access To User Profiles']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Change Language and Culture']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Change Language and Culture']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);

            // Verify some editable checkboxes in Activity. First select activity tab.
            cm.WaitForElement(driver, By.LinkText("Activity"), 10);
            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Activity Status']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Activity Status']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Error Log']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Error Log']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);

            // Verify some editable checkboxes in MDM Clients. First select MDM clients tab.
            cm.WaitForElement(driver, By.LinkText("MDM Clients"), 10);
            driver.FindElement(By.LinkText("MDM Clients"));
            driver.FindElement(By.LinkText("MDM Clients")).Click();

            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Access to Enterprise Application Portal']/td/input[@name='grant']"), ref verificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.XPath("//tr[td='Access to Enterprise Application Portal']/td/input[@name='deny']"), ref verificationErrors, driver, WaitTimeForElement, true);

            // Go to role assignment text box and check readonly.
            cm.WaitForElement(driver, By.XPath("//button[contains(.,'Edit Assignment')]"), 15);
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]"));
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]")).Click();

            cm.VerifyTextBoxEditable(false, By.Id("undefined_txtLdapFreeform"), ref verificationErrors, driver, WaitTimeForElement, roleName, true);

            Console.WriteLine("Have reached the end of full access test for Security Roles page **************.");
        }


        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check no access for Security roles page with non-admin user.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SecurityAccessControlNoAccessTest()
        {
            int WaitTimeForElement = 5;
            
            Console.WriteLine("\nRunning no access for Security Roles page.");
            
            // Setup security page for non-admin user for no access for all security Access control.
            Console.WriteLine("    Setup security page for non-admin user for read access for all security Access control.");
            cm.WaitForElement(driver, By.XPath("//li/a[.='Security']"), 10);
            driver.FindElement(By.XPath("//li/a[.='Security']")).Click();
            cm.WaitForElement(driver, By.LinkText("Access Control"), 10);
            driver.FindElement(By.LinkText("Access Control")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[td='Security Roles']/td/input[@name='none']"), 10);
            driver.FindElement(By.XPath("//tr[td='Security Roles']/td/input[@name='none']")).Click();

            // Give non-admin user some access to event log so MDM comes up in admin page when they log in.
            Console.WriteLine("    Give non-admin user some access to event log so MDM comes up in admin page when they log in.");
            
            cm.WaitForElement(driver, By.XPath("//li/a[.='Activity']"), 10);
            driver.FindElement(By.XPath("//li/a[.='Activity']")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[td='Event Log']/td/input[@name='grant']"), 10);
            driver.FindElement(By.XPath("//tr[td='Event Log']/td/input[@name='grant']")).Click();

            // Save security role and log out.
            Console.WriteLine("    Save security role and log out.");
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            Console.WriteLine("Are we signed out !!!!!!!!!!!!!! ."); // bladd
            Thread.Sleep(20000);

            // Login as the non-admin user and check security selection on admin page is not present.
            Console.WriteLine("    Login as the non-admin user and check security selection on admin page is not present.");
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Security"), ref verificationErrors, driver, WaitTimeForElement, true);

            Console.WriteLine("Have reached the end of no access test for Security Roles page.");        
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Console.WriteLine("\nRunning Teardown Test ...");





                //Console.WriteLine("    Login as admin and delete any security role added if present.");
                //cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
                //driver.FindElement(By.LinkText("Sign Out")).Click();
                //cm.LogIntoMdm(driver, adminUserName, password, baseURL);

                //Console.WriteLine("    Select security roles in pulldown.");
                //cm.WaitForElement(driver, By.LinkText("Security"), 10);
                //driver.FindElement(By.LinkText("Security"));
                //driver.FindElement(By.LinkText("Security")).Click();
                //cm.WaitForElement(driver, By.LinkText("Security Roles"), 10);
                //driver.FindElement(By.LinkText("Security Roles")).Click();
                
                //Thread.Sleep(1000);

                //Console.WriteLine("    Delete security role if needed.");
                //cm.DeleteSecurityRole(driver, roleName);
                
                //// Signout.
                //Console.WriteLine("    Signout and stop webdriver.");
                //cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
                //driver.FindElement(By.LinkText("Sign Out")).Click();
                
                //driver.Quit();
            }

            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Console.WriteLine("    Checking for Verification Errors DONE."); // bladd
            Assert.AreEqual("", verificationErrors.ToString());
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description:
        // DO!! ***************************************************************************
        // This method verifies whether an item passed in is enbabled or not enabled. It does not stop the flow 
        // of the test class calling it. It indicates a failure by addding failure message text to the 
        // passed-by-ref input string "verificationErrors". 
        //
        // Parameters:
        // 1) ExpectedStatus      - Present and displayed or not present and displayed.
        // 2) By                  - The item.
        // 3) VerificationErrors  - Passed by ref for logging errors to error string.
        // 4) Driver              - Web driver handle.
        // 5) LogError (optional) - Whether to log the eror to the NUnit console (true will log the error).
        // 6) WaitTime (optional) - How long to wait for the element to be found.
        // 
        // Return: 
        // False if expected status is not what is expected and True if expected status is what is expected.
        // 
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool VerifyTextBoxEditable(bool ExpectedStatus, By by, ref StringBuilder verificationErrors, IWebDriver driver, int WaitTime, bool LogError = false)        
        {
            Console.WriteLine("    Is Check textbox editable.");
            try // Item passed in should be there. If not, something is wrong to start with.
            {
                cm.WaitForElement(driver, by, WaitTime);
            }
            catch (AssertionException e)
            {
                Console.WriteLine("    !Fail in VerifyTextBoxEditable. Selection that is expected to be present is NOT present. Can not be complete check. Raising a fail. Item = " + by.ToString());
                verificationErrors.Append(e.Message);
                return false;
            }
            
            try // Try to enter the role name
            {
                IWebElement IWeb = driver.FindElement(by);
                IWeb.SendKeys(roleName);
            }
            catch (Exception e)
            {
                // If arrive in this catch, element SendKeys failed because the text box is not editable.
                if (ExpectedStatus == true) // If text box is expected to be editable this is a fail.
                {
                    if (LogError)
                    {
                        Console.WriteLine("    !Fail in VerifyTextBoxEditable. Text box should be editable. Item = " + by.ToString());
                    }
                    verificationErrors.Append(e.Message);
                    return false;
                }
                return true; // Have verified the possible cases with text box not being editable.
            }
            if (ExpectedStatus == false)  // If get here the text box is editable. If caller expects it to NOT be editable there is an error.
            {
                if (LogError)
                {
                    Console.WriteLine("    !Fail in VerifyTextBoxEditable. Text box should NOT be editable. Item = " + by.ToString());
                }
                verificationErrors.Append("!Fail in VerifyTextBoxEditable. Text box should NOT be editable. Item = " + by.ToString());
                return false;
            }
            return true;
        }
    }
}
