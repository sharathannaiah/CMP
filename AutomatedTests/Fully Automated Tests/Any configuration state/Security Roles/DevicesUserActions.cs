// Revision History
//
// Michael McAfee - 8/10/12 - Added comments, moved common beginnings of methods into SetupTest method, moved common endings of methods into TeardownTest method
// 
// Michael McAfee - 8/13/12 - Added associated test cases in comments for each test method
// 
// Michael McAfee - 8/21/12 - Renamed the namespace and class so nUnit will group better, put in Fully Automated Tests/Security Roles folder
// 
// Michael McAfee - 8/23/12 - Add namespace level: NoConfiguration
// 
// Michael McAfee - 10/17/12 - Converted to WebDriver
// 
// Michael McAfee - 10/23/12 - Removed unnecessary tests and associated variables
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
    public class DevicesUserActions
    {
        CommonMethods cm = new CommonMethods();

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

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
            regularUserLastName, //
            regularUserFirstName, //
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
        string regularUserLastName;//
        string regularUserFirstName;//
        string waitForPageToLoad;
        int sleepTime;

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
            regularUserLastName = strings[EnmKeys.regularUserLastName.ToString()];//
            regularUserFirstName = strings[EnmKeys.regularUserFirstName.ToString()];//
            waitForPageToLoad = strings[EnmKeys.waitForPageToLoad.ToString()];
            sleepTime = ints[EnmKeys.sleepTime.ToString()];

            driver = new InternetExplorerDriver();
            baseURL = browserUrl;
            verificationErrors = new StringBuilder();

            // set up security role
            cm.LogIntoMdm(driver, adminUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[.='Security Roles']"));
            cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);

            cm.StartNewSecurityRoleWithNameAndQuery(driver, sleepTime, roleName, roleAssignment);

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to user profiles is able to go to user profiles.
        // TC5577
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToUserProfilesGrantTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to User Profile page is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            try
            {
                Assert.AreEqual("User Profile", driver.FindElement(By.CssSelector("span.viewportTitle.featureTitle")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.AreEqual(regularUserFirstName + " " + regularUserLastName, driver.FindElement(By.CssSelector("span.viewportSubTitle.featureSubTitle")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.AreEqual("User Detail", driver.FindElement(By.CssSelector("div.contentBox-header")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to user profiles is not able to go to user profiles.
        // TC5577
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToUserProfilesDenyTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='deny']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to User Profile page is denied
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();

            driver.FindElement(By.LinkText("User List")).Click();
            cm.WaitForElement(driver, By.XPath("//table[@id='UserList']/tbody/tr/td[2]/span"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText(regularUserLastName + ", " + regularUserFirstName)));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Delete User function has access to that function.
        // TC5578
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteUserGrantTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Delete User']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Delete User action is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Delete User")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Delete User function can not access that function.
        // TC5578
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteUserDenyTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Delete User']/td/input[@name='deny']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Delete User action is denied
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Delete User")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to User Histories has access to that button on user profile.
        // TC5579
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewUserHistoriesGrantTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='View User Histories']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to History button is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//div[button='History']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to User Histories can not access that button on user profile.
        // TC5579
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewUserHistoriesDenyTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='View User Histories']/td/input[@name='deny']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to History button is denied
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.XPath("//div[button='History']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Security Roles and Permissions has access to that button on user profile.
        // TC5580
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewSecurityRolesAndPermissionsGrantTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='View Security Roles and Permissions']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Security Roles and Permissions is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//div[button[@data-bind=\"click: onShowPermissions, visible: options.allowRolesPermissions\"]='Permissions']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//div[button[@data-bind=\"click: onShowSecurityRoles, visible: options.allowRolesPermissions\"]='Security Roles']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }
        
        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Security Roles and Permissions can not access that button on user profile.
        // TC5580
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ViewSecurityRolesAndPermissionsDenyTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='View Security Roles and Permissions']/td/input[@name='deny']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Security Roles and Permissions is denied
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//div[button[@style=\"display: none;\"]='Permissions']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//div[button[@style=\"display: none;\"]='Security Roles']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Change Language and Culture function is able to access that function on user profile.
        // TC5581
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeLanguageAndCultureGrantTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Change Language and Culture']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Change Language and Culture is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);
            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//div[@id='userActionDropDownBtn']/ul/li[a = \"Change user's language and culture\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Change Language and Culture function is not able to access that function on user profile.
        // TC5581
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeLanguageAndCultureDenyTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Change Language and Culture']/td/input[@name='deny']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td//input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Change Language and Culture is denied
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);
            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.XPath("//div[@id='userActionDropDownBtn']/ul/li[a = \"Change user's language and culture\"]")));
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

                driver.FindElement(By.LinkText("Sign Out")).Click();
              
                // delete security role
                cm.LogIntoMdm(driver, adminUserName, password, baseURL);

                cm.WaitForElement(driver, By.XPath("//a[.='Security Roles']"));

                driver.FindElement(By.LinkText("Security"));
                driver.FindElement(By.LinkText("Security")).Click();
                driver.FindElement(By.LinkText("Security Roles")).Click();
                Thread.Sleep(5000);

                cm.DeleteSecurityRole(driver, roleName);

                driver.FindElement(By.LinkText("Sign Out")).Click();

                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
