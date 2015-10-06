// Revision History
//
// Bob Lichtenfels - 9/14/12 - Created and checked in Setup/Teardown, variable assignments, and one test method shell.
// Bob Lichtenfels - 9/15/12 - Initial setup for SecurityPolicyAssignmnetFullAccessTest, SecurityPolicyAssignmnetreadAccessTest, 
//                             and add helper methods.
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

namespace SeleniumTests.FullyAutomatedTests.AnyConfiguration.SecurityRoles
{

    [TestFixture]
    class SecurityPolicyAssignment
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

            selenium = new DefaultSelenium("localhost", 4444, browserString, browserUrl);
            selenium.Start();
            verificationErrors = new StringBuilder();
            selenium.SetTimeout(waitForPageToLoad);

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
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check full access for non-admin user:
        // 1) Ios Activation Blocking Page.
        // 2) Device Blocking Filters.
        // 3) Quarantined List.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void  SecurityPolicyAssignmnetFullAccessTest()
        {
            Console.WriteLine("\nRunning full access for non-admin user to access blocking pages.");
            // TODO: Select top check-box - find how to do.
            Console.WriteLine("    Setup security page for non-admin user to allow them full access to device blocking pages.");






            //// Setup security page for non-admin user for full access for all security Access control.
            //selenium.Click("xpath=(//li/a[.='Security'])");
            //selenium.Click("link=Access Control");
            //selenium.Click("xpath=(//tr[td='Security Roles']/td/input[@name='full'])");
            //selenium.Click("xpath=(//tr[td='iOS Activation Blocking']/td/input[@name='full'])");
            //selenium.Click("xpath=(//tr[td='Quarantined List']/td/input[@name='full'])");
            //selenium.Click("xpath=(//tr[td='Device Blocking Servers']/td/input[@name='full'])");
            //selenium.Click("xpath=(//tr[td='Device Blocking Filters']/td/input[@name='full'])");

            // Save security role and log out.
            Console.WriteLine("    Save security role, log out, and login as non-admin user.");
            cm.SaveSecurityRole(selenium);
            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Login as the non-admin user.
            cm.LogIntoMdm(selenium, regularUserName, password);
            selenium.WaitForPageToLoad("30000");

            // ////////////////////////////////
            Console.WriteLine("    Check iOS Activation Blocking page for full access as non-admin user.");
            // ////////////////////////////////

            // Go to the iOS Activation Blocking page.
            selenium.Click("link=iOS Activation Blocking"); 
            selenium.WaitForPageToLoad("30000");

            // verify some check boxes and the pull-down.
            VerifyEditableStatus(true, "id=ctl00_MainContent_gvBlockedDevices_ctl02_cbxBlocked");
            VerifyEditableStatus(true, "id=ctl00_MainContent_gvBlockedDevices_ctl06_cbxBlocked");
            VerifyEditableStatus(true, "id=ctl00_MainContent_gvBlockedDevices_ctl11_cbxBlocked");
            VerifyEditableStatus(true, "id=ctl00_MainContent_gvBlockedDevices_ctl18_cbxBlocked");
            VerifyEditableStatus(true, "id=ctl00_MainContent_gvBlockedDevices_ctl22_cbxBlocked");
            VerifyEditableStatus(true, "id=ctl00_MainContent_ddlOsVersions"); // Pulldown.

            // ////////////////////////////////
            Console.WriteLine("    Check Quarantined List page for full access as non-admin user.");
            // ////////////////////////////////

            selenium.Click("link=Quarantine List"); // Go to list page.
            selenium.WaitForPageToLoad("30000");

            VerifyEditableStatus(true, "id=BlockedRB");
            VerifyEditableStatus(true, "id=QuarantinedRB");
            VerifyEditableStatus(true, "id=searchText");

            // Enter some text in search box and verify search button can be used by searching for "Clear search" text.
            selenium.Type("id=searchText", "test");
            selenium.Click("//div[@id='userListFeature']/div/div/div/form/button");
            VerifyTextPresent(true, "Clear search");

            // ////////////////////////////////
            Console.WriteLine("    Check Device Blocking Filters page for full access as non-admin user.");
            // ////////////////////////////////

            selenium.Click("link=Device Blocking Filters");
            selenium.WaitForPageToLoad("30000");

            // With Read Access  -- NOT FOUND --- THIS SHOULD BE VerifyElementPresent WITH READ ONLY
            
            // Device platform filters section on iOS Activation Blocking page checkboxes.
            VerifyElementPresent(true, "id=ctl00_MainContent_dgAsacDeviceTypes_ctl04_cbxSelected");
            VerifyElementPresent(true, "id=ctl00_MainContent_dgAsacDeviceTypes_ctl05_cbxSelected");
            VerifyElementPresent(true, "id=ctl00_MainContent_dgAsacDeviceTypes_ctl06_cbxSelected");
            VerifyElementPresent(true, "id=ctl00_MainContent_dgAsacDeviceTypes_ctl07_cbxSelected");
            VerifyElementPresent(true, "id=ctl00_MainContent_dgAsacDeviceTypes_ctl08_cbxSelected");
            VerifyElementPresent(true, "id=ctl00_MainContent_dgAsacDeviceTypes_ctl09_cbxSelected");
            VerifyElementPresent(true, "id=ctl00_MainContent_dgAsacDeviceTypes_ctl10_cbxSelected");
            VerifyElementPresent(true, "id=ctl00_MainContent_dgAsacDeviceTypes_ctl11_cbxSelected");

            // Make a complete selection in device platform filters section on iOS Activation Blocking page - set a pulldown value
            selenium.Select("id=ctl00_MainContent_dgAsacDeviceTypes_ctl05_ddlDeviceActions", "label=Allowed");
            selenium.Click("css=#ctl00_MainContent_dgAsacDeviceTypes_ctl05_ddlDeviceActions > option[value=\"Allow\"]");

            // Device platform filters section on iOS Activation Blocking page command buttons at top are there.
            VerifyElementPresent(true, "id=ctl00_MainContent_lnkAddAsacDeviceType");
            VerifyElementPresent(true, "id=ctl00_MainContent_lnkDeleteAsacDeviceType");

            // Rest of code below -   check random sections of page for full access.

            //  MDM Client Not Present Filter - pulldown
            VerifyEditableStatus(true, "id=ctl00_MainContent_ddlMdmClientNotPresent");
            
            //   Device Model Filters - check command buttons.
            VerifyElementPresent(true,"id=ctl00_MainContent_lnkAddAsacDeviceModel");
            VerifyElementPresent(true, "id=ctl00_MainContent_lnkDeleteAsacDeviceModel");
            
            // Application Present Filters - check command buttons.
            VerifyElementPresent(true, "id=ctl00_MainContent_lnkDeleteInstalledApps");
            VerifyElementPresent(true, "id=ctl00_MainContent_lnkAddInstalledApps");

            // iOS Exchange Payload Options checkbox.
            VerifyEditableStatus(true, "id=ctl00_MainContent_cbxRemoveExchangeWhenIosDeviceBlocked");

            // Notifications Checkboxes - these checkboxes get grayed out with read access so check for editable.
            VerifyEditableStatus(true, "id=ctl00_MainContent_cbxEmailUserWhenAllowed");
            //selenium.Click("id=ctl00_MainContent_cbxCcAllowed");
            VerifyEditableStatus(true, "id=ctl00_MainContent_cbxCcAllowed");
            //selenium.Click("id=ctl00_MainContent_cbxEmailUserWhenBlocked");
            VerifyEditableStatus(true, "id=ctl00_MainContent_cbxEmailUserWhenBlocked");
            //selenium.Click("id=ctl00_MainContent_cbxCcBlocked");
            VerifyEditableStatus(true, "id=ctl00_MainContent_cbxCcBlocked");
            //selenium.Click("id=ctl00_MainContent_cbxEmailUserWhenQuarantined");
            VerifyEditableStatus(true, "id=ctl00_MainContent_cbxEmailUserWhenQuarantined");
            //selenium.Click("id=ctl00_MainContent_cbxCcQuarantined");
            VerifyEditableStatus(true, "id=ctl00_MainContent_cbxCcQuarantined");
            //selenium.Type("id=ctl00_MainContent_txtCcQuarantined", ",,,,,,,,");
            VerifyEditableStatus(true, "id=ctl00_MainContent_txtCcQuarantined");
            //selenium.Type("id=ctl00_MainContent_txtCcBlocked", ",,,");
            VerifyEditableStatus(true, "id=ctl00_MainContent_txtCcBlocked");
            //selenium.Type("id=ctl00_MainContent_txtCcAllowed", ",,,");

            // Save command button at bottom of page.
            VerifyElementPresent(true, "id=ctl00_MainContent_lnkSaveFilters");            
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Check read access for non-admin user:
        // 1) Ios Activation Blocking Page.
        // 2) Device Blocking Filters.
        // 3) Quarantined List.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SecurityPolicyAssignmnetReadAccessTest()
        {
            Console.WriteLine("\n*** Running read access for non-admin user for device blocking pages.");
            // TODO: Select top check-box - find how to do.
            Console.WriteLine("    Setup security page for non-admin user to allow them full access to device blocking pages.");

            // Setup security page for non-admin user for full access for all security Access control.
            selenium.Click("xpath=(//li/a[.='Security'])");
            selenium.Click("link=Access Control");
            selenium.Click("xpath=(//tr[td='Security Roles']/td/input[@name='read'])");
            selenium.Click("xpath=(//tr[td='iOS Activation Blocking']/td/input[@name='read'])");
            selenium.Click("xpath=(//tr[td='Quarantined List']/td/input[@name='read'])");
            selenium.Click("xpath=(//tr[td='Device Blocking Servers']/td/input[@name='read'])");
            selenium.Click("xpath=(//tr[td='Device Blocking Filters']/td/input[@name='read'])");

            // Save security role and log out.
            Console.WriteLine("    Save security role, log out, and login as non-admin user.");
            cm.SaveSecurityRole(selenium);
            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Login as the non-admin user.
            cm.LogIntoMdm(selenium, regularUserName, password);
            selenium.WaitForPageToLoad("30000");

            // Go to the iOS Activation Blocking page.
            selenium.Click("link=iOS Activation Blocking");
            selenium.WaitForPageToLoad("30000");

            // Verify some check boxes are not there and the pull-down is not editable.
            VerifyElementPresent(false, "id=ctl00_MainContent_gvBlockedDevices_ctl02_cbxBlocked");
            VerifyElementPresent(false, "id=ctl00_MainContent_gvBlockedDevices_ctl06_cbxBlocked");
            VerifyElementPresent(false, "id=ctl00_MainContent_gvBlockedDevices_ctl11_cbxBlocked");
            VerifyElementPresent(false, "id=ctl00_MainContent_gvBlockedDevices_ctl18_cbxBlocked");
            VerifyElementPresent(false, "id=ctl00_MainContent_gvBlockedDevices_ctl22_cbxBlocked");
            VerifyEditableStatus(false, "id=ctl00_MainContent_ddlOsVersions"); // Pulldown.


        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Console.WriteLine("\nRunning Teardown Test ...");

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
        // This verifies whether an item passed to this method is editable/non-editable.
        // The item and expected result (editable/non-editable) are passed to the method.
        // ////////////////////////////////////////////////////////////////////////////////////
        void VerifyEditableStatus(bool ExpectedStatus, string ItemToSelect)
        {
            try
            {
                Assert.AreEqual(ExpectedStatus, selenium.IsEditable(ItemToSelect));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("Fail " + ItemToSelect);
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
                Console.WriteLine("Fail In Verify text Present. Item=" + TextToFind);
                verificationErrors.Append(e.Message);
            }
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
                Console.WriteLine("Fail in verify Element Present. Item=" + ItemToSelect);
                verificationErrors.Append(e.Message);
            }
        }
    }
}
