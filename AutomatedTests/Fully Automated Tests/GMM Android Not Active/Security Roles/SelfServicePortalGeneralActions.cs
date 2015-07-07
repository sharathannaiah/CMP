// Revision History
//
// Michael McAfee - 8/27/12 - Created class
// 
// Michael McAfee - 8/29/12 - Created AddDeviceGrantTest method, did not complete
// 
// Michael McAfee - 10/17/12 - Converted to WebDriver, finished AddDeviceGrantTest, added AddDeviceDenyTest,
//                              DeleteDeviceGrantTest, DeleteDeviceDenyTest, ShowDeviceDetailsGrantTest,
//                              ShowDeviceDetailsDenyTest, ChangeDeviceGrantTest, ChangeDeviceDenyTest,
//                              ResendClientInstallationEmailGrantTest, ResendClientInstallationEmailDenyTest
// 
// Michael McAfee - 10/17/12 - Added StepThroughActivationInstructionsAgainGrantTest, StepThroughActivationInstructionsAgainDenyTest

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

namespace SeleniumTests.FullyAutomatedTests.GmmAndroidNotActive.SecurityRoles
{
    [TestFixture]
    public class SelfServicePortalGeneralActions
    {
        CommonMethods cm = new CommonMethods();

        //private ISelenium selenium;
        //private StringBuilder verificationErrors;
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        SelectElement select;

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

            //selenium = new DefaultSelenium("localhost", 4444, browserString, browserUrl);
            //selenium.Start();
            //verificationErrors = new StringBuilder();
            //selenium.SetTimeout(waitForPageToLoad);
            driver = new InternetExplorerDriver();
            baseURL = browserUrl;
            verificationErrors = new StringBuilder();

            //// log into MDM
            //cm.LogIntoMdm(selenium, adminUserName, password);
            cm.LogIntoMdm(driver, adminUserName, password, baseURL);

            //// verify MDM is set up to use GMM midleware
            //cm.ConfigureMdmToUse(selenium, "GoodMobile");
            cm.ConfigureMdmToUse(driver, "GoodMobile");

            //// verify MDM is set up to use Android
            //cm.ConfigureMdmToUse(selenium, "ClientPlatforms_2");
            cm.ConfigureMdmToUse(driver, "ClientPlatforms_2");

            //// verify user is added to Users list
            //selenium.Click("link=User List");
            //selenium.WaitForPageToLoad("30000");
            //if (selenium.IsElementPresent("link=" + regularUserLastName + ", " + regularUserFirstName))
            //{
            //}
            //else
            //{
            //    selenium.Click("css=a.import-user-large");
            //    for (int second = 0; ; second++)
            //    {
            //        if (second >= 60) Assert.Fail("timeout");
            //        try
            //        {
            //            if (selenium.IsElementPresent("id=lastNameAddUserSearchText")) break;
            //        }
            //        catch (Exception)
            //        { }
            //        Thread.Sleep(1000);
            //    }
            //    selenium.Type("id=lastNameAddUserSearchText", regularUserLastName);
            //    selenium.Type("id=firstNameAdduserSearchText", regularUserFirstName);
            //    selenium.Click("//div[@id='addUserListFeature']/div[2]/div/div/form/button");
            //    selenium.Click("link=" + regularUserLastName + ", " + regularUserFirstName);
            //    selenium.WaitForPageToLoad("30000");
            //}
            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("User List")).Click();
            Thread.Sleep(sleepTime);

            if (cm.IsElementPresent(driver, By.LinkText(regularUserLastName + ", " + regularUserFirstName)))
            {
                //cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

                //driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();
                //driver.FindElement(By.LinkText("Delete User")).Click();
                //driver.FindElement(By.XPath("//button[@type='button']")).Click();
                //Thread.Sleep(sleepTime);
                cm.DeleteUser(driver, regularUserLastName, regularUserFirstName, sleepTime);
            }

            driver.FindElement(By.CssSelector("a.import-user-large")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (cm.IsElementPresent(driver, By.Id("lastNameAddUserSearchText")))
                    {
                        break;
                    }
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.Id("lastNameAddUserSearchText")).Clear();
            driver.FindElement(By.Id("lastNameAddUserSearchText")).SendKeys(regularUserLastName);
            driver.FindElement(By.Id("firstNameAdduserSearchText")).Clear();
            driver.FindElement(By.Id("firstNameAdduserSearchText")).SendKeys(regularUserFirstName);
            driver.FindElement(By.XPath("//div[@id='addUserListFeature']/div[2]/div/div/form/button")).Click();
            Thread.Sleep(sleepTime);
            driver.FindElement(By.LinkText(regularUserLastName + ", " + regularUserFirstName)).Click();
            Thread.Sleep(sleepTime);


            //// add Android using GMM to user
            //cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);
            //cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            //selenium.Click("css=a.add-device-btn-large");
            //selenium.Select("id=Platform", "label=Android");
            //selenium.Select("id=Vendor", "index=1");
            //selenium.Select("id=mergeddevice", "index=1");
            //selenium.Select("id=ComplexServices", "label=Good Mobile");
            driver.FindElement(By.CssSelector("a.add-device-btn-large")).Click();
            cm.WaitForElement(driver, By.Id("Platform"));
            select = new SelectElement(driver.FindElement(By.Id("Platform")));
            select.SelectByText("Android");

            select = new SelectElement(driver.FindElement(By.Id("Vendor")));
            select.SelectByIndex(1);

            select = new SelectElement(driver.FindElement(By.Id("mergeddevice")));
            select.SelectByIndex(1);
            device = select.SelectedOption.Text;

            select = new SelectElement(driver.FindElement(By.Id("ComplexServices")));
            select.SelectByText("Good Mobile");

            //// Store the text of the device type in a variable to be used later
            //device = selenium.GetSelectedLabel("id=mergeddevice");

            //selenium.Click("css=button.tangoeBtn.tangoeBtn-primary");
            driver.FindElement(By.CssSelector("button.tangoeBtn.tangoeBtn-primary")).Click();

            //// set up security role
            //cm.DeleteExistingSecurityRole(selenium, roleName, sleepTime);

            //cm.StartNewSecurityRoleWithNameAndQuery(selenium, sleepTime, roleName, roleAssignment);

            //selenium.Click("//input[@name='isAdminProfileChkBx'][@value='0']");

            cm.WaitForElement(driver, By.XPath("//a[.='Security Roles']"));
            cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);

            cm.StartNewSecurityRoleWithNameAndQuery(driver, sleepTime, roleName, roleAssignment);

            driver.FindElement(By.XPath("//input[@name='isAdminProfileChkBx'][@value='0']")).Click();
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Add Device sees Add a new Device button in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddDeviceGrantTest()
        {

            //selenium.Click("link=Self-service Portal");
            //selenium.Click("link=General Actions");
            //selenium.Click("xpath=(//tr[td='Add Device']/td/input[@name='grant'])");

            //cm.SaveSecurityRole(selenium);

            //selenium.Click("link=Sign Out");
            //selenium.WaitForPageToLoad("30000");

            //// Log in as a user affected by the security role
            //cm.LogIntoMdm(selenium, regularUserName, password);

            //// Go to user profile
            //cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            //// Verify button to Add a New Device is available
            //try
            //{
            //    Assert.IsTrue(selenium.IsElementPresent("id=addDeviceBtn"));
            //}
            //catch (AssertionException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Deny')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Add Device']/td/input[@name='grant']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify button to Add a New Device is available
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//input[@id='addDeviceBtn'][not(@style='display: none;')]")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Add Device Button not available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Add Device does not see Add a new Device button in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AddDeviceDenyTest()
        {

            //selenium.Click("link=Self-service Portal");
            //selenium.Click("link=General Actions");
            //selenium.Click("xpath=(//tr[td='Add Device']/td/input[@name='grant'])");

            //cm.SaveSecurityRole(selenium);

            //selenium.Click("link=Sign Out");
            //selenium.WaitForPageToLoad("30000");

            //// Log in as a user affected by the security role
            //cm.LogIntoMdm(selenium, regularUserName, password);

            //// Go to user profile
            //cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            //// Verify button to Add a New Device is available
            //try
            //{
            //    Assert.IsTrue(selenium.IsElementPresent("id=addDeviceBtn"));
            //}
            //catch (AssertionException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Grant')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Add Device']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify button to Add a New Device is not available
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//input[@id=\"addDeviceBtn\"][@style=\"display: none;\"]")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Add Device button available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Delete Device sees Delete Device link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteDeviceGrantTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Deny')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Delete Device']/td/input[@name='grant']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to Delete Device is available
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Delete Device")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Delete Device link not available.");
                verificationErrors.Append(e.Message);
            }

        }


        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Delete Device does not see Delete Device link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DeleteDeviceDenyTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Grant')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Delete Device']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to Delete Device is not available
            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Delete Device")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Delete Device link available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Show Device Details sees Device Details link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ShowDeviceDetailsGrantTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Deny')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Show Device Details']/td/input[@name='grant']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to Device Details is available
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Device Details")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Device Details link not available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Show Device Details does not see Device Details link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ShowDeviceDetailsDenyTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Grant')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Show Device Details']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to Device Details is not available
            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Device Details")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Device Details link available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Change Device sees Change Device link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeDeviceGrantTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Deny')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Change Device']/td/input[@name='grant']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to Change Device is available
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Change Device")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Change Device link not available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Change Device does not see Change Device link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeDeviceDenyTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Grant')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Change Device']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to Change Device is not available
            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Change Device")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Change Device link available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Resend Client Installation Email sees Send Client Email link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ResendClientInstallationEmailGrantTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Deny')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Resend Client Installation Email']/td/input[@name='grant']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to Send Client Email is available
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Send Client Email")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Send Client Email link not available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Resend Client Installation Email does not see Send Client Email link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ResendClientInstallationEmailDenyTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Grant')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Resend Client Installation Email']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to Send Client Email is not available
            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Send Client Email")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** Send Client Email link available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to Step through Activation Instructions Again sees View Activation Instructions link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void StepThroughActivationInstructionsAgainGrantTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Deny')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Step through Activation Instructions Again']/td/input[@name='grant']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to View Activation Instructions is available
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("View Activation Instructions")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** View Activation Instructions link not available.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to Step through Activation Instructions Again does not see View Activation Instructions link in self-service profile.
        // TC
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void StepThroughActivationInstructionsAgainDenyTest()
        {

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Self-service Portal')]"));

            driver.FindElement(By.XPath("//li/a[.='Self-service Portal']")).Click();
            driver.FindElement(By.LinkText("General Actions")).Click();
            driver.FindElement(By.XPath("//tr[th='General Actions']/th/div[div[contains(., 'Grant')]]/input[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//tr[td='Step through Activation Instructions Again']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as a user affected by the security role
            cm.LogIntoMdm(driver, regularUserName, password, baseURL, true);

            // Verify link to View Activation Instructions is not available
            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("View Activation Instructions")));
            }
            catch (AssertionException e)
            {
                Console.WriteLine("\n*** View Activation Instructions link available.");
                verificationErrors.Append(e.Message);
            }

        }
        
        [TearDown]
        public void TeardownTest()
        {
            //try
            //{

            //    selenium.Click("link=Sign Out");
            //    selenium.WaitForPageToLoad("30000");

            //    // log into MDM as administrator
            //    cm.LogIntoMdm(selenium, adminUserName, password);

            //    // delete user
            //    cm.GoToUserProfile(selenium, regularUserLastName, regularUserFirstName, sleepTime);

            //    selenium.Click("//div[@id='userActionDropDownBtn']/button");
            //    selenium.Click("link=Delete User");
            //    selenium.Click("//button[@type='button']");
            //    Thread.Sleep(sleepTime);

            //    // delete security role
            //    selenium.Click("link=Security Roles");
            //    selenium.WaitForPageToLoad("30000");
            //    Thread.Sleep(5000);

            //    cm.DeleteSecurityRole(selenium, roleName);

            //    selenium.Click("link=Sign Out");
            //    selenium.WaitForPageToLoad("30000");

            //    selenium.Stop();
            //}
            //catch (Exception)
            //{
            //    // Ignore errors if unable to close the browser
            //}
            //Assert.AreEqual("", verificationErrors.ToString());
            try
            {

                driver.FindElement(By.LinkText("Log Out")).Click();

                // log into MDM as administrator
                cm.LogIntoMdm(driver, adminUserName, password, baseURL);

                // delete user
                //cm.GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

                //driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();
                //driver.FindElement(By.LinkText("Delete User")).Click();
                //driver.FindElement(By.XPath("//button[@type='button']")).Click();
                //Thread.Sleep(sleepTime);
                cm.DeleteUser(driver, regularUserLastName, regularUserFirstName, sleepTime);

                // delete security role
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
