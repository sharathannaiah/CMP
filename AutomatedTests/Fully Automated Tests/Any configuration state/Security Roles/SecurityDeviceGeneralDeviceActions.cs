// Revision History
//
// Michael McAfee  - 8/23/12 - Add namespace level: NoConfiguration
// Bob Lichtenfels - 8/25/12 - Check in current work for doing security set to grant.
// Bob Lichtenfels - 8/27/12 - Check in test for all except checking disabled tabs in user device profile.
// Bob Lichtenfels - 8/30/12 - Finished AddRegularUserIfNeeded method for environment not using no mail only.
// Bob Lichtenfels - 9/1/12 -  Changed AddRegularUserIfNeeded method to AddRegularUser
// Bob Lichtenfels - 9/2/12 -  Added xpath checks for checking enabled/disbaled tabs in device profile. Add more log info for Nunit display.
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
using AutomatedTests.WebDriver.Fully_Automated_Tests; // bladd - use jose add user.


namespace SeleniumTests.FullyAutomatedTests.AnyConfiguration.SecurityRoles
{
    [TestFixture]
    class SecurityDeviceGeneralDeviceActions
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
            waitForPageToLoad,
            regularUserLastName,
            regularUserFirstName
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
        string regularUserLastName;
        string regularUserFirstName;
        StringBuilder linkToUserNameToSelect;
        StringBuilder linkToAdminNameToFind;
        // If methods that pause for text present or elements present fail, close selenium as soon as TeardownTest is reached.
        bool hasTestRunCorrectly = true; 


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
            regularUserFirstName = strings[EnmKeys.regularUserFirstName.ToString()];
            regularUserLastName = strings[EnmKeys.regularUserLastName.ToString()];

            linkToUserNameToSelect = new StringBuilder("");
            linkToUserNameToSelect.Append(regularUserLastName + ", " + regularUserFirstName);

            string debug = linkToUserNameToSelect.ToString();

            driver = new InternetExplorerDriver();

            //driver = new InternetExplorerDriver();  
            baseURL = browserUrl;

            verificationErrors = new StringBuilder();

            cm.LogIntoMdm(driver, adminUserName, password, baseURL); 

            // See if user to be used is in user list. If not, add them and an Android device.
            AddRegularUser();
            return; // bladd

            // Login, delete any security roles that have the same name as the name being used to test,
            // open up security role page, and set it to admin.


            Console.WriteLine("    Delete any existing security roles.");
            cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);

            Console.WriteLine("    Add new security role.");
            cm.StartNewSecurityRoleWithNameAndQuery(driver, sleepTime, roleName, roleAssignment);

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
            Console.WriteLine("    Existing security role deletion and startup complete.\n");

        }

        [Test]
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Set general device actions to allow and check device actions in device profile.
        // Set general device actions to deny and check device actions in device profile.
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SecurityDeviceGeneralDeviceActionsGrantDenyAccess()
        {

            return;
            
            Console.WriteLine("\n*** Running grant access for General Device Actions - settings to allow.");
            // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // General device actions - settings to allow.
            // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            // TODO: Select top check-box - find how to do.

            Console.WriteLine("    Setup security page for non-admin user to allow them full access to a device profile.");
            // Setup security page for non-admin user to allow them full access to a device profile.
            selenium.Click("link=General Device Actions");

            selenium.Click("xpath=(//tr[td='View Profiles and Policies']/td/input[@name='grant'])");
            selenium.Click("xpath=(//tr[td='View Alerts']/td/input[@name='grant'])");
            selenium.Click("xpath=(//tr[td='View Applications']/td/input[@name='grant'])");
            selenium.Click("xpath=(//tr[td='View Usage']/td/input[@name='grant'])");
            selenium.Click("xpath=(//tr[td='Locate Device']/td/input[@name='grant'])");
            selenium.Click("xpath=(//tr[td='Add/Delete/Change Devices']/td/input[@name='grant'])");
            selenium.Click("xpath=(//tr[td='Wipe Device']/td/input[@name='grant'])");
            
            selenium.Click("link=User Actions");
            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");

            // Save security role and log out.
            cm.SaveSecurityRole(selenium);
            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Login as the non-admin user.
            cm.LogIntoMdm(selenium, regularUserName, password);
            selenium.WaitForPageToLoad("30000");

            // Select user list.
            selenium.Click("link=User List");
            selenium.WaitForPageToLoad("30000");
            // Select user name.
            PauseForItemSelect(linkToUserNameToSelect.ToString());
            selenium.Click(linkToUserNameToSelect.ToString());

            // Pause for page to load. 
            PauseForItemSelect("//div[@id='deviceActionDropDownBtn']/button"); // Wait for device button.
            PauseForTextFind("Details"); // Wait for devices tab (should be present, even though device not activated).
            PauseForItemSelect("xpath=(//li[@class='ui-state-default ui-corner-top ui-tabs-selected ui-state-active'][a='Details'])");

            // Even with pauses above - still need more of a wait.
            Thread.Sleep(3000);

            Console.WriteLine("    Start check for device profile tabs after wait.");

            // Verify device profile tabs reflects correct state of tabs.
            // Details are selectable.
            VerifyElementPresent(true, "xpath=(//li[@class='ui-state-default ui-corner-top ui-tabs-selected ui-state-active'][a='Details'])");
            // Application, Notifications, Usage, MDM Profiles, and Certificates, are not selectable.
            VerifyElementPresent(true, "xpath=(//li[@class='ui-state-default ui-corner-top ui-state-disabled'][a='Applications'])"); // pass
            VerifyElementPresent(true, "xpath=(//li[@class='ui-state-default ui-corner-top ui-state-disabled'][a='Notifications'])"); // pass
            VerifyElementPresent(true, "xpath=(//li[@class='ui-state-default ui-corner-top ui-state-disabled'][a='Usage'])"); // pass
            VerifyElementPresent(true, "xpath=(//li[@class='ui-state-default ui-corner-top ui-state-disabled'][a='MDM Profiles'])"); // pass
            VerifyElementPresent(true, "xpath=(//li[@class='ui-state-default ui-corner-top ui-state-disabled'][a='Certificates'])"); // pass
            
            // Select device actions and verify delete and change device selections are available and wipe device is not.
            Console.WriteLine("    Select device actions and verify delete and change device selections are available and wipe device is not.");            
            selenium.Click("//div[@id='deviceActionDropDownBtn']/button");
            PauseForItemSelect("link=Change Device");
            VerifyElementPresent(true, "link=Change Device");
            VerifyElementPresent(true, "link=Delete Device");
            
            // Android is not activated. Should be no wipe device, even though security page for non-admin user allows full access 
            // to a device profile.
            VerifyElementPresent(false, "link=Wipe Device");

            // Verify can add a device by selecting add device.
            Console.WriteLine("    Verify can add a device by selecting add device and verifying text.");            
            selenium.Click("css=a.add-device-btn-large");
            PauseForTextFind("Add Device");

            // Thread.Sleep(3000); // TODO: some sort of wait.
            VerifyTextPresent(true, "Add Device");
            VerifyTextPresent(true, "Add a new device to a user's account");

            // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // General device actions - settings to deny.
            // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\n*** Running grant access for General Device Actions - settings to deny.");
            Console.WriteLine("    Sign out, log back in as admin, go to the existing secutity role and set Add, delete, and Change Device to deny.");
            
            // Sign out, log back in, go to the existing secutity role and set Add, delete, and Change Device to deny.
            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");
            cm.LogIntoMdm(selenium, adminUserName, password);
            selenium.Click("link=Security Roles");            
            PauseForItemSelect("link=delete me");
            selenium.Click("link=delete me");
            PauseForItemSelect("link=General Device Actions");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='Add/Delete/Change Devices']/td/input[@name='deny'])");

            // Save security role and log out.
            selenium.Click("//form[@id='securityRoleForm']/div[2]/div/div[3]/button");
            PauseForTextFind("Security Role was successfully updated");

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            Console.WriteLine("    Login as regular user, go to the users's Android device profile and verify Change Device, Delete device, and Add Device are not present.");
            
            // Login as the non-admin user.
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to the users's Android device profile.
            selenium.Click("link=User List");
            selenium.WaitForPageToLoad("30000");
            PauseForItemSelect(linkToUserNameToSelect.ToString());
            selenium.Click(linkToUserNameToSelect.ToString());
            // Verify change device and delete device are not selectable.
            VerifyElementPresent(false, "link=Change Device");
            VerifyElementPresent(false, "link=Delete Device");
            // Verify add device is not present.
            // selenium.Click("css=a.add-device-btn-large");
            VerifyElementPresent(false,"css=a.add-device-btn-large");
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Console.WriteLine("\nRunning Teardown Test ...");

                Console.WriteLine("    Login as admin and delete any security role added if present.");
                cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
                driver.FindElement(By.LinkText("Sign Out")).Click();
                cm.LogIntoMdm(driver, adminUserName, password, baseURL);

                Console.WriteLine("    Select security roles in pulldown.");
                cm.WaitForElement(driver, By.LinkText("Security"), 10);
                driver.FindElement(By.LinkText("Security"));
                driver.FindElement(By.LinkText("Security")).Click();
                cm.WaitForElement(driver, By.LinkText("Security Roles"), 10);
                driver.FindElement(By.LinkText("Security Roles")).Click();

                Thread.Sleep(1000);

                Console.WriteLine("    Delete security role if needed.");
                cm.DeleteSecurityRole(driver, roleName);

                // Signout.
                Console.WriteLine("    Signout and stop webdriver.");
                cm.WaitForElement(driver, By.LinkText("Sign Out"), 10);
                driver.FindElement(By.LinkText("Sign Out")).Click();

                driver.Quit();
            }

            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Console.WriteLine("    Checking for Verification Errors.");
            Assert.AreEqual("", verificationErrors.ToString());
        }

        


        // ////////////////////////////////////////////////////////////////////////////////////
        // This verifies whether an item passed to this method is present.
        // The item and expected result (present or not) are passed to the method.
        // ////////////////////////////////////////////////////////////////////////////////////
        void VerifyElementPresent(bool ExpectedStatus, string ItemToSelect)
        {
            try
            {
                Assert.AreEqual(ExpectedStatus, selenium.IsElementPresent(ItemToSelect));
            }
            catch (AssertionException e)
            {
                hasTestRunCorrectly = false;
                Console.WriteLine("Fail in verify Element Present. Item=" + ItemToSelect); 
                verificationErrors.Append(e.Message);
            }
        }

        // ////////////////////////////////////////////////////////////////////////////////////
        // This verifies whether text passed to this method is present.
        // The item and expected result (text present) are passed to the method.
        // ////////////////////////////////////////////////////////////////////////////////////
        void VerifyTextPresent(bool ExpectedStatus, string TextToFind)
        {
            try
            {
                Assert.AreEqual(ExpectedStatus, selenium.IsTextPresent(TextToFind));
            }
            catch (AssertionException e)
            {
                hasTestRunCorrectly = false;
                Console.WriteLine("Fail In Verify text Present. Item=" + TextToFind); 
                verificationErrors.Append(e.Message);
            }
        }

        // ////////////////////////////////////////////////////////////////////////////////////
        // This will delete a user if they exist and then add them and an Android device.
        // ////////////////////////////////////////////////////////////////////////////////////
        void AddRegularUser() // bladd
        {
            Console.WriteLine("  Start AddRegularUser method - delete existing user, add new user, and add Android device to user.");

            Thread.Sleep(10000);

            // Get to the point where the user list page is open
            cm.WaitForElement(driver, By.LinkText("Devices"), 15);
            driver.FindElement(By.LinkText("Devices")).Click();
            cm.WaitForElement(driver, By.LinkText("User List"), 15);
            driver.FindElement(By.LinkText("User List")).Click();

            if (VerifyElementPresentReturnBool(By.LinkText(linkToUserNameToSelect.ToString())))
            {
                Console.WriteLine("    Existing user found. Remove existing user.");

                // from mdm login
                cm.WaitForElement(driver, By.Id("searchText"), 15);                
                Console.WriteLine("    FOUND --- wait for where are we  - looking for search text");
                Thread.Sleep(500);

                driver.FindElement(By.Id("searchText")).Clear();
                driver.FindElement(By.Id("searchText")).SendKeys(regularUserLastName + " " + regularUserFirstName);
                Console.WriteLine("    Did name get entered??");
                Thread.Sleep(500);
                cm.WaitForElement(driver,By.XPath("//div[@id='userListFeature']/div/div/div/form/button"),10);                
                driver.FindElement(By.XPath("//div[@id='userListFeature']/div/div/div/form/button"));
                // Needed to do click twice to get search for user to work. At some point time it may only take one click.
                try 
                {
                    driver.FindElement(By.XPath("//div[@id='userListFeature']/div/div/div/form/button")).Click();
                    driver.FindElement(By.XPath("//div[@id='userListFeature']/div/div/div/form/button")).Click();
                }
                catch (Exception) // Catch no error.
                { }
                
                Console.WriteLine("    Has search finished? Is user ");
                Thread.Sleep(10000);

                // ***************************************************************************
                // Example web driver from mdm login - need to setup user search/delete.
                //WaitForElement(driver, By.Id("userNameTextBox"));
                //driver.FindElement(By.Id("userNameTextBox")).Clear();
                //driver.FindElement(By.Id("userNameTextBox")).SendKeys(userName);
                //WaitForElement(driver, By.Id("passwordTextBox"));
                //driver.FindElement(By.Id("passwordTextBox")).Clear();
                //driver.FindElement(By.Id("passwordTextBox")).SendKeys(password);
                // ***************************************************************************                
                
                // ORIGINAL CODE...
                //selenium.Type("id=searchText", regularUserLastName + " " + regularUserFirstName);
                //selenium.Click("//div[@id='userListFeature']/div/div/div/form/button");
                //PauseForItemSelect("css=input[type=\"checkbox\"]");
                //selenium.Click("css=input[type=\"checkbox\"]");
                //selenium.Click("css=a.delete-btn-small");
                //selenium.Click("//button[@type='button']");
                //Console.WriteLine("    Existing user removed successfully.");
            }
            else
            {
                Console.WriteLine("  Existing user not found. ");                        
            }

            return;

            Thread.Sleep(10000);

            //if (VerifyElementPresent
                //IsElementPresent(linkToUserNameToSelect.ToString())) // If user is on the list delete them.






            
            //selenium.Click("link=User List"); // Go to user list.
            //selenium.WaitForPageToLoad("30000");
            //PausePageRefresh();
            //Thread.Sleep(sleepTime);

            if (selenium.IsElementPresent(linkToUserNameToSelect.ToString())) // If user is on the list delete them.
            {
                Console.WriteLine("    Remove existing user.");
                selenium.Type("id=searchText", regularUserLastName + " " + regularUserFirstName);
                selenium.Click("//div[@id='userListFeature']/div/div/div/form/button");
                PauseForItemSelect("css=input[type=\"checkbox\"]");
                selenium.Click("css=input[type=\"checkbox\"]");
                selenium.Click("css=a.delete-btn-small");
                selenium.Click("//button[@type='button']");
                Console.WriteLine("    Existing user removed successfully.");
            }
            else
            {
                Console.WriteLine("    Existing user not found. Pausing for 15 seconds.");
                Thread.Sleep(15000);
            }

            // Select add user button.
            Console.WriteLine("    Add user and Android device.");
            PauseForItemSelect("css=a.import-user-large", "Add User Button"); // Wait and then select add user button.
            // selenium.Click("css=a.add-user-btn-large"); // 12.2
            selenium.Click("css=a.import-user-large"); // 12.3

            // Enter last/first name.
            PauseForItemSelect("id=lastNameAddUserSearchText", "Last name text box");
            selenium.Type("id=lastNameAddUserSearchText", regularUserLastName);
            PauseForItemSelect("id=firstNameAdduserSearchText", "First name text box");
            selenium.Type("id=firstNameAdduserSearchText", regularUserFirstName);
            Thread.Sleep(3000);

            // Select search button.
            //PauseForItemSelect("//div[@id='addUserListFeature']/div[2]/div/div/form/button", "Search Botton");
            selenium.Click("//div[@id='addUserListFeature']/div[2]/div/div/form/button");
            Thread.Sleep(3000);

            // Checkbox user name.
            //PauseForItemSelect("css=input.users", "Username checkbox");
            selenium.Click("css=input.users");

            // Select add selected button.
            PauseForItemSelect("//div[@id='addUserListFeature']/div[2]/div/div/form/button[2]", "Add selected button");
            selenium.Click("//div[@id='addUserListFeature']/div[2]/div/div/form/button[2]");

            // Wait for add device button and select.
            Thread.Sleep(3000);
            PauseForItemSelect("//div[@id='DeviceSelectionSection']/div[2]/div/div[2]/button", "Add device in device profile");
            selenium.Click("//div[@id='DeviceSelectionSection']/div[2]/div/div[2]/button"); // Select add device button.
            Thread.Sleep(5000); // Wait for device profile to load.

            PauseForItemSelect("id=Platform", "Device platform");
            Thread.Sleep(1000);
            selenium.Select("id=Platform", "label=Android");
            PauseForItemSelect("id=Vendor", "Vendor (carrier)");
            Thread.Sleep(1000);
            selenium.Select("id=Vendor", "label=AT&T");
            PauseForItemSelect("id=mergeddevice", "Device");
            Thread.Sleep(1000);
            selenium.Select("id=mergeddevice", "label=Dell Streak 5");
            selenium.Click("css=button.tangoeBtn.tangoeBtn-primary");
            // PauseForTextFind("Dell Streak 5", "Check that model name has been added."); // Not effective.
            Thread.Sleep(3000); // Wait for page to save.

            Console.WriteLine("    User and Android device added successfully.");
            Console.WriteLine("  AddRegularUser method complete.");
        }

        // bladd
        // ////////////////////////////////////////////////////////////////////////////////////////
        // This verifies whether an item passed to this method is present and returns true/false.
        // ////////////////////////////////////////////////////////////////////////////////////////
        bool VerifyElementPresentReturnBool(By by)
        {
            try // Wait time to avoid intermittent results.
            {
                cm.WaitForElement(driver, by, 20);
            }
            catch (AssertionException e)
            {
                // If arrive in this catch element has not found.
                return false;
            }
            return true;
        }        

        // ////////////////////////////////////////////////////////////////////////////////////
        // Wait for an item to be present. Pass in the item to wait for.
        // ////////////////////////////////////////////////////////////////////////////////////
        void PauseForItemSelect(string ItemToSelect, string MoreDetail = "")
        {
            for (int second = 0; ; second++)
            {
                if (second >= 30)
                {
                    hasTestRunCorrectly = false;
                    Console.WriteLine("Failed Pause For Item Select:" + ItemToSelect + " " + MoreDetail);  
                    Assert.Fail("timeout in PauseForItemSelect with item" + ItemToSelect);
                }
                try
                {
                    if (selenium.IsElementPresent(ItemToSelect)) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        // ////////////////////////////////////////////////////////////////////////////////////
        // Wait for text to be present. Pass in the text to wait for.
        // ////////////////////////////////////////////////////////////////////////////////////
        void PauseForTextFind(string textToFind, string MoreDetail = "")
        {
            for (int second = 0; ; second++)
            {
                if (second >= 30)
                {
                    hasTestRunCorrectly = false;
                    Console.WriteLine("Failed PauseForTextFind:" + textToFind + " " + MoreDetail); 
                    Assert.Fail("timeout in PauseForTextFind with item" + textToFind);
                }
                try
                {
                    if (selenium.IsTextPresent(textToFind)) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }


        // ////////////////////////////////////////////////////////////////////////////////////
        // Refresh page if expected text is not found.
        // ////////////////////////////////////////////////////////////////////////////////////
        void PausePageRefresh(string textToFind = "")
        {

            Console.WriteLine("    Start Refresh Method");
            /*
            for (int x = 0; x < 3; x++)
            {
                if (!selenium.IsTextPresent(textToFind))
                {
                    selenium.Refresh();
                    selenium.WaitForPageToLoad("30000");
                    Thread.Sleep(1000);
                }

            }
            */
            selenium.Refresh();
            selenium.WaitForPageToLoad("30000");
            Console.WriteLine("    Page Refresh Method Done.");
        }

    }
}
