// Revision History
//
// Michael McAfee - 8/10/12 - Created
// 
// Michael McAfee - 8/17/12 - Added associated test cases in comments for each test method
// 
// Michael McAfee - 8/21/12 - Renamed the namespace and class so nUnit will group better, put in Fully Automated Tests/Security Roles folder
// 
// Michael McAfee - 8/23/12 - Add namespace level: NoConfiguration
// 
// Michael McAfee - 10/11/12 - Converted to WebDriver
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
    public class ConfigurationAdministrationCustomizationAndSelfService : SecurityRolesTest
    {
        //CommonMethods cm = new CommonMethods();

        //private IWebDriver driver;
        //private StringBuilder verificationErrors;
        //private string baseURL;

        //// EnmKeys will retrieve these values from the local config.xml file.
        //public enum EnmKeys
        //{
        //    browserString,
        //    browserUrl,
        //    adminUserName,
        //    password,
        //    roleName,
        //    roleAssignment,
        //    regularUserName,
        //    sleepTime,
        //    waitForPageToLoad
        //}

        //string browserString;   //type of browser (firefox, internet explorer, etc.)
        //string browserUrl;  //MDM server
        //string adminUserName;
        //string password;
        //string roleName;    //name of the security role that will be created
        //string roleAssignment;  //LDAP query syntax used to determine who gets the security role
        //string regularUserName; //user who belongs to the security role
        //string waitForPageToLoad;
        //int sleepTime;

        [SetUp]
        public void GiveProfilesFullAccessPermissions()
        {
            //// load config file values (NOTE: When adding a config file like this, make sure that you right click on it > Properties > Copy to Output Directory > Always
            //XDocument config = XDocument.Load("config.xml");

            //// create string dictionary
            //Dictionary<string, string> strings = new Dictionary<string, string>();

            //// loop through config file and add to dictionary
            //foreach (XElement elm in config.Descendants("string"))
            //{
            //    strings.Add(elm.Descendants("key").First().Value, elm.Descendants("value").First().Value);
            //}

            //// ints
            //Dictionary<string, int> ints = new Dictionary<string, int>();

            //// loop through config file and add to dictionary
            //foreach (XElement elm in config.Descendants("int"))
            //{
            //    ints.Add(elm.Descendants("key").First().Value, Convert.ToInt32(elm.Descendants("value").First().Value));
            //}

            //browserString = strings[EnmKeys.browserString.ToString()];
            //browserUrl = strings[EnmKeys.browserUrl.ToString()];
            //adminUserName = strings[EnmKeys.adminUserName.ToString()];
            //password = strings[EnmKeys.password.ToString()];
            //roleName = strings[EnmKeys.roleName.ToString()];
            //roleAssignment = strings[EnmKeys.roleAssignment.ToString()];
            //regularUserName = strings[EnmKeys.regularUserName.ToString()];
            //waitForPageToLoad = strings[EnmKeys.waitForPageToLoad.ToString()];
            //sleepTime = ints[EnmKeys.sleepTime.ToString()];

            //driver = new InternetExplorerDriver();
            //baseURL = browserUrl;
            //verificationErrors = new StringBuilder();

            //// set up security role
            //cm.LogIntoMdm(driver, adminUserName, password, baseURL);

            //cm.WaitForElement(driver, By.XPath("//a[.='Security Roles']"));

            //cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);

            //cm.StartNewSecurityRoleWithNameAndQuery(driver, sleepTime, roleName, roleAssignment);

            //driver.FindElement(By.Name("isAdminProfileChkBx")).Click();

            //  Give all functions full access in the Customization and Self-service tab

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[.='Configuration Administration']")).Click();
            cm.WaitForElement(driver, By.LinkText("Customization and Self-service"));
            driver.FindElement(By.LinkText("Customization and Self-service")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Customization and Self-service']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']")).Click();
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with full access to all Customization and Self-Service pages is able to edit info on those pages.
        // TC5631
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CustomizationAndSelfServiceAllFullAccessTest()
        {

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            // verify full access to User Interface
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("User Interface")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Save.");
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Cancel.");
            }

            // verify full access to Devices
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.XPath("//li/a[.='Devices']")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.ClassName("add-device-btn-large")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Add Device.");
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//div/a[not(@style=\"display: none;\")][@class=\"delete-btn-small\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Delete button.");
            }

            // verify full access to Page Content
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Android Client Installation Email")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='Android Client Installation Email']"));

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Save.");
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Reset.");
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            cm.WaitForElement(driver, By.LinkText("BlackBerry Activation Email"));
            driver.FindElement(By.LinkText("BlackBerry Activation Email")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='BlackBerry Activation Email']"));

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Save.");
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Cancel.");
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Delete Account")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Save.");
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry New Device Activation")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Reset Activation Password")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Reset Device Password")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Wipe Device Data")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Wipe Device Data Confirmation")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("End User Terms and Conditions")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("GMM Activation Email")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("iOS Payload Automatically Removed")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("iPhone Client Activation Email")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Liability Corporate Liable Description")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Liability Individual Liable Description")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Multiple Unactivated Devices Email")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Unmatched Device Imported from Command")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("User Welcome Page")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Windows Mobile Client Installation Email")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Windows Phone 7 Client Installation E-mail")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            // verify full access to Error Messages
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Error Messages")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            // verify full access to Wireless Carriers
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Wireless Carriers")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkNewVendor")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkDelete")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            // verify full access to Activation Instructions
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Activation Instructions")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkDeleteCollection")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkAddCollection")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to User Interface page can access the page but cannot edit info on the page.
        // TC5632
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UserInterfaceReadAccessTest()
        {
            driver.FindElement(By.XPath("//tr[td='User Interface']/td//input[@name='read']")).Click();

            // verify read access to User Interface
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("User Interface")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to User Interface page can not access the page.
        // TC5632
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UserInterfaceNoAccessTest()
        {
            driver.FindElement(By.XPath("//tr[td='User Interface']/td//input[@name='none']")).Click();

            // verify no access to User Interface
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("User Interface")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Devices page can access the page but cannot edit info on the page.
        // TC5633
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DevicesReadAccessTest()
        {
            driver.FindElement(By.XPath("//tr[td='Devices']/td//input[@name='read']")).Click();

            // verify read access to Devices
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Devices")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.CssSelector("a.add-device-btn-large")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//div/a[@style=\"display: none;\"][@class=\"delete-btn-small\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to Devices page can not access the page.
        // TC5633
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DevicesNoAccessTest()
        {
            driver.FindElement(By.XPath("//tr[td='Devices']/td//input[@name='none']")).Click();

            // verify no access to Devices
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Devices")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Page Content page can access the page but cannot edit info on the page.
        // TC5634
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void PageContentReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Page Content']/td//input[@name='read']")).Click();

            // verify read access to Environment Settings
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Android Client Installation Email")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='Android Client Installation Email']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Activation Email")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='BlackBerry Activation Email']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Delete Account")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='BlackBerry Delete Account']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry New Device Activation")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='BlackBerry New Device Activation']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Reset Activation Password")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='BlackBerry Reset Activation Password']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Reset Device Password")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='BlackBerry Reset Device Password']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Wipe Device Data")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='BlackBerry Wipe Device Data']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("BlackBerry Wipe Device Data Confirmation")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='BlackBerry Wipe Device Data Confirmation']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("End User Terms and Conditions")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='End User Terms and Conditions']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("GMM Activation Email")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='GMM Activation Email']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("iOS Payload Automatically Removed")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='iOS Payload Automatically Removed']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("iPhone Client Activation Email")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='iPhone Client Activation Email']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Liability Corporate Liable Description")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='Liability Corporate Liable Description']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Liability Individual Liable Description")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='Liability Individual Liable Description']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Multiple Unactivated Devices Email")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='Multiple Unactivated Devices Email']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Unmatched Device Imported from Command")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='Unmatched Device Imported from Command']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("User Welcome Page")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='User Welcome Page']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Windows Mobile Client Installation Email")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='Windows Mobile Client Installation Email']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Page Content")).Click();
            driver.FindElement(By.LinkText("Windows Phone 7 Client Installation E-mail")).Click();
            cm.WaitForElement(driver, By.XPath("//span[.='Windows Phone 7 Client Installation E-mail']"));

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to Page Content page can not access the page.
        // TC5634
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void PageContentNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Page Content']/td//input[@name='none']")).Click();

            // verify no access to Page Content
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Page Content")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Error Messages page can access the page but cannot edit info on the page.
        // TC5635
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ErrorMessagesReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Error Messages']/td//input[@name='read']")).Click();

            // verify read access to Error Messages
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Error Messages")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkSave")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkCancel")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to Error Messages page can not access the page.
        // TC5635
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ErrorMessagesNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Error Messages']/td//input[@name='none']")).Click();

            // verify no access to Error Messages
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();


            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Error Messages")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Wireless Carriers page can access the page but cannot edit info on the page.
        // TC5636
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void WirelessCarriersReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Wireless Carriers']/td//input[@name='read']")).Click();

            // verify read access to Wireless Carriers
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Wireless Carriers")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkNewVendor")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkDelete")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }


        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to Wireless Carriers page can not access the page.
        // TC5636
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void WirelessCarriersNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Wireless Carriers']/td//input[@name='none']")).Click();

            // verify no access to Wireless Carriers
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Wireless Carriers")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Activation Instructions page can access the page but cannot edit info on the page.
        // TC5637
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ActivationInstructionsReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Activation Instructions']/td//input[@name='read']")).Click();

            // verify read access to Activation Instructions
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Activation Instructions")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkDeleteCollection")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkAddCollection")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }


        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to Activation Instructions page can not access the page.
        // TC5637
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ActivationInstructionsNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Activation Instructions']/td//input[@name='none']")).Click();

            // verify no access to Activation Instructions
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Activation Instructions")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        //[TearDown]
        //public void TeardownTest()
        //{
        //    try
        //    {

        //        driver.FindElement(By.LinkText("Sign Out")).Click();

        //        cm.LogIntoMdm(driver, adminUserName, password, baseURL);

        //        cm.WaitForElement(driver, By.XPath("//a[.='Security Roles']"));

        //        driver.FindElement(By.LinkText("Security"));
        //        driver.FindElement(By.LinkText("Security")).Click();
        //        driver.FindElement(By.LinkText("Security Roles")).Click();
        //        Thread.Sleep(5000);

        //        cm.DeleteSecurityRole(driver, roleName);

        //        driver.FindElement(By.LinkText("Sign Out")).Click();

        //        driver.Quit();
        //    }
        //    catch (Exception)
        //    {
        //        // Ignore errors if unable to close the browser
        //    }
        //    Assert.AreEqual("", verificationErrors.ToString());
        //}
    }
}
