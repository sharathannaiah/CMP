﻿// Revision History
//
// Michael McAfee - 8/13/12 - Created
// 
// Michael McAfee - 8/17/12 - Added associated test cases in comments for each test method
// 
// Michael McAfee - 8/21/12 - Renamed the namespace and class so nUnit will group better, put in Fully Automated Tests/Security Roles folder
// 
// Michael McAfee - 8/23/12 - Add namespace level: NoConfiguration
// 
// Michael McAfee - 10/12/12 - Converted to WebDriver
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
    public class ConfigurationAdministrationTasks
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
            baseURL = browserUrl;
            verificationErrors = new StringBuilder();

            // set up security role
            cm.LogIntoMdm(driver, adminUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[.='Security Roles']"));

            cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);

            cm.StartNewSecurityRoleWithNameAndQuery(driver, sleepTime, roleName, roleAssignment);

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[.='Configuration Administration']")).Click();
            cm.WaitForElement(driver, By.LinkText("Tasks"));
            driver.FindElement(By.LinkText("Tasks")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']")).Click();
        
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with full access to all Tasks pages is able to edit info on those pages.
        // TC5638
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void TasksAllFullAccessTest()
        {

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            // verify full access to MDM Server

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Rules Enforcement")).Click();

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

            // verify full access to Processing

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));

            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Processing")).Click();

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
        
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Rules Enforcement page can access the page but cannot edit info on the page.
        // TC5639
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void RulesEnforcementReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Rules Enforcement']/td//input[@name='read']")).Click();

            // verify read access to User Interface
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Rules Enforcement")).Click();

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
        // Verify user with no access to Rules Enforcement page can not access the page.
        // TC5639
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void RulesEnforcementNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Rules Enforcement']/td//input[@name='none']")).Click();

            // verify no access to User Interface
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Rules Enforcement")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Processing page can access the page but cannot edit info on the page.
        // TC5640
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ProcessingReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Processing']/td//input[@name='read']")).Click();

            // verify read access to User Interface
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Processing")).Click();

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
        // Verify user with no access to Processing page can not access the page.
        // TC5640
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ProcessingNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Processing']/td//input[@name='none']")).Click();

            // verify no access to User Interface
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Processing")));
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
