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

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_Configuration_State
{
    public class DevicesUserActions : SecurityRoleBase
    {

        CommonMethods cm = new CommonMethods();
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        // EnmKeys will retrieve these values from the local config.xml file.
       
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
            // save
            driver.FindElement(By.XPath("//form[@id='securityRoleForm']/div[2]/div/div[4]/button")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                Common.GoToUserProfile(driver);
                Console.WriteLine("Access to User Profile Granted!");                
                Assert.AreEqual("User Detail", driver.FindElement(By.XPath(".//*[@id='DetailsSection']/div/div[1]/div[1]/div[1]")).Text);
                Console.WriteLine("Access to User Details Granted!");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
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

            driver.FindElement(By.XPath("//form[@id='securityRoleForm']/div[2]/div/div[4]/button")).Click();
            
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to User Profile page is denied
            cm.LogIntoMdm(driver, regularUser, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();

            driver.FindElement(By.LinkText("User List")).Click();
            cm.WaitForElement(driver, By.XPath("//table[@id='UserList']/tbody/tr/td[2]/span"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText(regularUserLastName)));
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
            cm.LogIntoMdm(driver, regularUser, password, baseURL);

            Common.GoToUserProfile(driver);
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
            cm.LogIntoMdm(driver, regularUser, password, baseURL);

            Common.GoToUserProfile(driver);
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
            cm.LogIntoMdm(driver, regularUser, password, baseURL);

            Common.GoToUserProfile(driver);
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
            cm.LogIntoMdm(driver, regularUser, password, baseURL);
            Common.GoToUserProfile(driver);

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
            cm.LogIntoMdm(driver, regularUser, password, baseURL);

            Common.GoToUserProfile(driver);

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
            LogIntoMDM(driver, regularUser);

            Common.GoToUserProfile(driver);

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
            LogIntoMDM(driver, regularUser);

            Common.GoToUserProfile(driver);
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
            LogIntoMDM(driver, regularUser);

            Common.GoToUserProfile(driver);
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

        
    }
}
