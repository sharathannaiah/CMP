// Revision History
//
// Michael McAfee - 8/23/12 - Created class, did not complete
// 
// Michael McAfee - 8/24/12 - Continued work on the class, completed first version, added test methods
// 
// Michael McAfee - 8/28/12 - Debugged class
// 
// Michael McAfee - 8/29/12 - Added test cases to method notes
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

namespace SeleniumTests.FullyAutomatedTests.NoEmailWindowsPhoneNotActivated.SecurityRoles
{
    [TestFixture]
    public class DevicesGeneralDeviceActions
    {
        CommonMethods cm = new CommonMethods();

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
            regularUserLastName,
            regularUserFirstName,
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
        string regularUserLastName;
        string regularUserFirstName;
        string waitForPageToLoad;
        int sleepTime;

        String device;

        [SetUp]
        public void SetupTest()
        {
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
            regularUserLastName = strings[EnmKeys.regularUserLastName.ToString()];
            regularUserFirstName = strings[EnmKeys.regularUserFirstName.ToString()];
            waitForPageToLoad = strings[EnmKeys.waitForPageToLoad.ToString()];
            sleepTime = ints[EnmKeys.sleepTime.ToString()];

            selenium = new DefaultSelenium("localhost", 4444, browserString, browserUrl);
            selenium.Start();
            verificationErrors = new StringBuilder();
            selenium.SetTimeout(waitForPageToLoad);

            // log into MDM
            cm.LogIntoMdm(selenium, adminUserName, password);

            // verify MDM is set up to use no email midleware
            cm.ConfigureMdmToUse(selenium, "NoService");

            // verify MDM is set up to use Windows Phone
            cm.ConfigureMdmToUse(selenium, "ClientPlatforms_4");

            // verify user is added to Users list
            selenium.Click("link=User List");
            selenium.WaitForPageToLoad("30000");
            if (selenium.IsElementPresent("link=" + regularUserLastName + ", " + regularUserFirstName))
            {
            }
            else
            {
                selenium.Click("css=a.add-user-btn-large");
                for (int second = 0; ; second++)
                {
                    if (second >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (selenium.IsElementPresent("id=lastNameAddUserSearchText")) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }
                selenium.Type("id=lastNameAddUserSearchText", regularUserLastName);
                selenium.Type("id=firstNameAdduserSearchText", regularUserFirstName);
                selenium.Click("//div[@id='addUserListFeature']/div[2]/div/div/form/button");
                for (int second = 0; ; second++)
                {
                    if (second >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (selenium.IsElementPresent("link=" + regularUserLastName + ", " + regularUserFirstName)) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }
                selenium.Click("link=" + regularUserLastName + ", " + regularUserFirstName);
                for (int second = 0; ; second++)
                {
                    if (second >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (selenium.IsElementPresent("//span[@class=\"viewportTitle featureTitle\"][.='User Profile']")) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }
            }

            // add Windows Phone to user
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            selenium.Click("css=a.add-device-btn-large");
            Thread.Sleep(sleepTime);
            selenium.Select("id=Platform", "label=Windows Phone");
            selenium.Select("id=Vendor", "index=1");
            Thread.Sleep(sleepTime);
            selenium.Select("id=mergeddevice", "index=1");

            // Store the text of the device type in a variable to be used later
            device = selenium.GetSelectedLabel("id=mergeddevice");
            selenium.Click("css=button.tangoeBtn.tangoeBtn-primary");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (selenium.IsElementPresent("//div[.='" + device + "']")) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }


            // set up security role
            cm.DeleteExistingSecurityRole(selenium, roleName, sleepTime);

            cm.StartNewSecurityRoleWithNameAndQuery(selenium, sleepTime, roleName, roleAssignment);

            selenium.Click("name=isAdminProfileChkBx");
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to View Profiles and Policies is still not able to click the MDM Profiles tab.
        // TC5665
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewProfilesAndPoliciesGrantTest()
        {

            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='View Profiles and Policies']/td/input[@name='grant'])");

            cm.SaveSecurityRole(selenium);

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Log in as a user affected by the security role
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to user profile
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            // Make sure the Windows Phone is selected
            selenium.Click("//table[@id='DeviceSelectionList']/tbody/tr[td='" + device + "']/td[2]");

            // Verify tab for MDM Profiles is present but disabled
            try
            {
                Assert.IsTrue(selenium.IsElementPresent("//li[@class=\"ui-state-default ui-corner-top ui-state-disabled\"]/a[. = 'MDM Profiles']"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to View Alerts is still not able to click the Notifications tab.
        // TC5666
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewAlertsGrantTest()
        {

            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='View Alerts']/td/input[@name='grant'])");

            cm.SaveSecurityRole(selenium);

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Log in as a user affected by the security role
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to user profile
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            // Make sure the Windows Phone is selected
            selenium.Click("//table[@id='DeviceSelectionList']/tbody/tr[td='" + device + "']/td[2]");

            // Verify tab for Notifications is present but disabled
            try
            {
                Assert.IsTrue(selenium.IsElementPresent("//li[@class=\"ui-state-default ui-corner-top ui-state-disabled\"]/a[. = 'Notifications']"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to View Applications is still not able to click the Applications tab.
        // TC5667
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewApplicationsGrantTest()
        {

            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='View Applications']/td/input[@name='grant'])");

            cm.SaveSecurityRole(selenium);

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Log in as a user affected by the security role
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to user profile
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            // Make sure the Windows Phone is selected
            selenium.Click("//table[@id='DeviceSelectionList']/tbody/tr[td='" + device + "']/td[2]");

            // Verify tab for Applications is present but disabled
            try
            {
                Assert.IsTrue(selenium.IsElementPresent("//li[@class=\"ui-state-default ui-corner-top ui-state-disabled\"]/a[. = 'Applications']"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to View Usage is still not able to click the Usage tab.
        // TC5668
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewUsageGrantTest()
        {

            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='View Usage']/td/input[@name='grant'])");

            cm.SaveSecurityRole(selenium);

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Log in as a user affected by the security role
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to user profile
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            // Make sure the Windows Phone is selected
            selenium.Click("//table[@id='DeviceSelectionList']/tbody/tr[td='" + device + "']/td[2]");

            // Verify tab for Usage is present but disabled
            try
            {
                Assert.IsTrue(selenium.IsElementPresent("//li[@class=\"ui-state-default ui-corner-top ui-state-disabled\"]/a[. = 'Usage']"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Locate Device still does not have the Locate Device action available in Device Actions.
        // TC5669
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void LocateDeviceGrantTest()
        {

            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='Locate Device']/td/input[@name='grant'])");

            cm.SaveSecurityRole(selenium);

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Log in as a user affected by the security role
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to user profile
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            // Make sure the Windows Phone is selected
            selenium.Click("//table[@id='DeviceSelectionList']/tbody/tr[td='" + device + "']/td[2]");

            //bring down the Device Action list
            selenium.Click("//div[@id='deviceActionDropDownBtn']/button");

            // Verify action for Locate Device is not present
            try
            {
                Assert.IsFalse(selenium.IsElementPresent("link=Locate Device"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Add/Delete/Change Devices has access to Add Device button and Delete and Change Device actions.
        // TC5670
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddDeleteChangeDevicesGrantTest()
        {

            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='Add/Delete/Change Devices']/td/input[@name='grant'])");

            cm.SaveSecurityRole(selenium);

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Log in as a user affected by the security role
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to user profile
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            // Make sure the Windows Phone is selected
            selenium.Click("//table[@id='DeviceSelectionList']/tbody/tr[td='" + device + "']/td[2]");

            // Verify the Add Devices button is available
            try
            {
                Assert.IsTrue(selenium.IsElementPresent("css=a.add-device-btn-large"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            //bring down the Device Action list
            selenium.Click("//div[@id='deviceActionDropDownBtn']/button");

            // Verify action for Delete Device is present
            try
            {
                Assert.IsTrue(selenium.IsElementPresent("link=Delete Device"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
           
            // Verify action for Delete Device is present
            try
            {
                Assert.IsTrue(selenium.IsElementPresent("link=Change Device"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Add/Delete/Change Devices has no access to Add Device button or Delete or Change Device actions.
        // TC5670
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddDeleteChangeDevicesDenyTest()
        {

            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='Add/Delete/Change Devices']/td/input[@name='deny'])");

            cm.SaveSecurityRole(selenium);

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Log in as a user affected by the security role
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to user profile
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            // Make sure the Windows Phone is selected
            selenium.Click("//table[@id='DeviceSelectionList']/tbody/tr[td='" + device + "']/td[2]");

            // Verify the Add Devices button is not available
            try
            {
                Assert.IsFalse(selenium.IsElementPresent("css=a.add-device-btn-large"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            //bring down the Device Action list
            selenium.Click("//div[@id='deviceActionDropDownBtn']/button");

            // Verify action for Delete Device is not present
            try
            {
                Assert.IsFalse(selenium.IsElementPresent("link=Delete Device"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            // Verify action for Delete Device is not present
            try
            {
                Assert.IsFalse(selenium.IsElementPresent("link=Change Device"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Wipe Device still does not have the Wipe Device action available in Device Actions.
        // TC5671
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void WipeDeviceGrantTest()
        {

            selenium.Click("xpath=(//tr[td='Access To User Profiles']/td/input[@name='grant'])");
            selenium.Click("link=Page Access");
            selenium.Click("xpath=(//tr[td='Access To User List']/td/input[@name='full'])");
            selenium.Click("link=General Device Actions");
            selenium.Click("xpath=(//tr[td='Wipe Device']/td/input[@name='grant'])");

            cm.SaveSecurityRole(selenium);

            selenium.Click("link=Sign Out");
            selenium.WaitForPageToLoad("30000");

            // Log in as a user affected by the security role
            cm.LogIntoMdm(selenium, regularUserName, password);

            // Go to user profile
            cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            // Make sure the Windows Phone is selected
            selenium.Click("//table[@id='DeviceSelectionList']/tbody/tr[td='" + device + "']/td[2]");

            //bring down the Device Action list
            selenium.Click("//div[@id='deviceActionDropDownBtn']/button");

            // Verify action for Locate Device is not present
            try
            {
                Assert.IsFalse(selenium.IsElementPresent("link=Wipe Device"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {

                selenium.Click("link=Sign Out");
                selenium.WaitForPageToLoad("30000");

                // log into MDM as administrator
                cm.LogIntoMdm(selenium, adminUserName, password);

                // delete user
                cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

                selenium.Click("//div[@id='userActionDropDownBtn']/button");
                selenium.Click("link=Delete User");
                selenium.Click("//button[@type='button']");
                Thread.Sleep(sleepTime);

                // delete security role
                selenium.Click("link=Security Roles");
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(5000);

                cm.DeleteSecurityRole(selenium, roleName);

                selenium.Click("link=Sign Out");
                selenium.WaitForPageToLoad("30000");

                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
