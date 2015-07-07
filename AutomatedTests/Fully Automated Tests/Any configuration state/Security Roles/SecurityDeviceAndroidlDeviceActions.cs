// Revision History
//
// Bob Lichtenfels - 8/31/12 - Created initial class.
// Bob Lichtenfels - 9/1/12  - Put tests into test method.
// Bob Lichtenfels - 9/8/12  - Imported updated helper methods.
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

// namespace AutomatedTests.Fully_Automated_Tests.Any_configuration_state.Security_Roles
namespace SeleniumTests.FullyAutomatedTests.AnyConfiguration.SecurityRoles
{
    [TestFixture]
    class SecurityDeviceAndroidlDeviceActions
    {

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
        string regularUserLastName;
        string regularUserFirstName;
        int sleepTime;
        StringBuilder linkToUserNameToSelect;
        // If methods that pause for text present or elements present fail, close selenium as soon as TeardownTest is reached.
        bool hasTestRunCorrectly = true;

        [SetUp]
        public void SetupTest()
        {
            Console.WriteLine("Running Setup Test ...");

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
            linkToUserNameToSelect.Append("link=" + regularUserLastName + ", " + regularUserFirstName);

            selenium = new DefaultSelenium("localhost", 4444, browserString, browserUrl);
            selenium.Start();
            verificationErrors = new StringBuilder();
            selenium.SetTimeout(waitForPageToLoad);

            cm.LogIntoMdm(selenium, adminUserName, password);
            // See if user to be used is in user list. If not, add them and an Android device.
            AddRegularUser();
            Console.WriteLine("\nSign out.");
            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");
            Console.WriteLine("Sign out done.");

            // Login, delete any security roles that have the same name as the name being used to test,
            // open up security role page, and set it to admin.
            Console.WriteLine("\nDelete any existing security roles from previous tests and startup new security role.");
            cm.LogIntoMdm(selenium, adminUserName, password);
            cm.DeleteExistingSecurityRole(selenium, roleName, sleepTime);
            cm.StartNewSecurityRoleWithNameAndQuery(selenium, sleepTime, roleName, roleAssignment);
            selenium.Click("name=isAdminProfileChkBx");
            Console.WriteLine("Existing security role deletion and startup complete.");
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////            // 
        // With Android device actions set to grant - verify the following:
        // 1) Verify expected pull down options are selectable - delete and change device selections
        // 2) Then verify Lock Device, Reset Device Password, and Wipe Touchdown Data are not selectable because 
        //    device is not activated.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SecurityDeviceAndroidDeviceActionsGrantAccess()
        {
            Console.WriteLine("Running grant access for General Android Device Actions - settings to allow.");

            // TO DO: Select top check-box - find how to do.
            // Setup security page for non-admin user to allow them full access to a device profile.
            Console.WriteLine("    Setup security page for non-admin user to allow them full access to a device profile.");
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
            Console.WriteLine("    Save security role, log out, log in as non-admin, and verify selectable/non-selectable items.\n");
            cm.SaveSecurityRole(selenium);
            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Login as the non-admin user.
            cm.LogIntoMdm(selenium, regularUserName, password);
            selenium.WaitForPageToLoad("30000");

            // Go to the users's Android device profile.
            selenium.Click("link=User List");
            selenium.WaitForPageToLoad("30000");
            PauseForItemSelect(linkToUserNameToSelect.ToString());
            selenium.Click(linkToUserNameToSelect.ToString());
            Thread.Sleep(5000); // Wait for device profile to load.
            
            // //////////////////////////////////////////////////////////////////////////////////////////////////////////            // 
            // 1) Verify expected pull down options are selectable - delete and change device selections
            // 2) Then verify Lock Device, Reset Device Password, and Wipe Touchdown Data are not selectable.
            // //////////////////////////////////////////////////////////////////////////////////////////////////////////

            PauseForItemSelect("//div[@id='deviceActionDropDownBtn']/button"); // Wait for drop down button.
            selenium.Click("//div[@id='deviceActionDropDownBtn']/button"); // Select drop down button.
            PauseForItemSelect("link=Change Device"); // Wait for pulldown item.
            VerifyElementPresent(true, "link=Change Device"); // Is selectable.
            VerifyElementPresent(true, "link=Delete Device"); // Is selectable.

           // Verify lock device, reset device password, and wipe touchdone data are not selectable.
            VerifyElementPresent(false, "link=Lock Device"); // Not selectable. 
            VerifyElementPresent(false, "link=Reset Device Password"); // Not selectable.  
            VerifyElementPresent(false, "link=Wipe Touchdown Data"); // Not selectable.  
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Console.WriteLine("Running Teardown Test ...");

                if (!hasTestRunCorrectly) // Something has gone wrong. Expected items are not found on page loads. close out.
                {
                    selenium.Stop();
                }

                selenium.Click("link=Sign Out");
                selenium.WaitForPageToLoad("30000");

                // As admin, delete any security role used by this test.
                cm.LogIntoMdm(selenium, adminUserName, password);
                selenium.Click("link=Security Roles");
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(5000);
                cm.DeleteSecurityRole(selenium, roleName);

                // Signout.
                selenium.Click("link=Sign Out");
                selenium.WaitForPageToLoad("30000");
                Console.WriteLine("Teardown test stopping selenium.\n");
                selenium.Stop();
            }

            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        // ////////////////////////////////////////////////////////////////////////////////////
        // This will delete a user if they exist and then add them and an Android device.
        // ////////////////////////////////////////////////////////////////////////////////////
        void AddRegularUser()
        {
            Console.WriteLine("  Start AddRegularUser method - delete existing user, add new user, and add Android device to user.");

            selenium.Click("link=User List"); // Go to user list.
            selenium.WaitForPageToLoad("30000");
            PausePageRefresh();
            Thread.Sleep(sleepTime);

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

        // ////////////////////////////////////////////////////////////////////////////////////
        // Wait for an item to be present. Pass in the item to wait for.
        // ////////////////////////////////////////////////////////////////////////////////////
        void PauseForItemSelect(string ItemToSelect, string MoreDetail = "")
        {
            for (int second = 0; ; second++)
            {
                if (second >= 15)
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
                if (second >= 15)
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
            for (int x = 0; x<3; x++ )
            {
                if(!selenium.IsTextPresent(textToFind))
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

    }
}
