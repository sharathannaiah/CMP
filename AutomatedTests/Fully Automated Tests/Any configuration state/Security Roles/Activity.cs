// Revision History
//
// Michael McAfee - 8/10/12 - Added comments, moved common beginnings of methods into SetupTest method, moved common endings of methods into TeardownTest method
// 
// Michael McAfee - 8/17/12 - Added associated test cases in comments for each test method
// 
// Michael McAfee - 8/21/12 - Renamed the namespace and class so nUnit will group better, put in Fully Automated Tests/Security Roles folder
// 
// Michael McAfee - 8/23/12 - Add namespace level: NoConfiguration
// 
// Michael McAfee - 9/27/12 - Converted class to WebDriver
// 
// Michael McAfee - 10/23/12 - Set up Activity to inherit from SecurityRolesTest, removed duplications
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
    public class Activity : SecurityRolesTest
    {
        [SetUp]

        public void GrantAllActivityPermissions()
        {
            //  Grant all permissions in the Activity tab

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Activity')]"));

            driver.FindElement(By.XPath("//li/a[.='Activity']")).Click();
            driver.FindElement(By.XPath("//tr[th='Activity']/th/div[div[contains(.,'Grant')]]/input[@type='checkbox']")).Click();
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user granted access to all activity pages is able to go to those pages.
        // TC5620
        // ////////////////////////////////////////////////////////////////////////////////////////////////////// 
        public void ActivityAllGrantTest()
        {
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Activity Status page is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Activity"));

            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Activity Status")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not find Activity Status link.");
            }

            // verify that access to Reports page is granted
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Reports")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not find Reports link.");
            }

            // verify that access to Event Log page is granted
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Event Log")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not find Event Log link.");
            }

            // verify that access to Error Log page is granted
            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.LinkText("Error Log")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not find Error Log link.");
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to activity status page is not able to go to that page.
        // TC5621
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToActivityStatusDenyTest()
        {
            //  Deny Activity Status permission

            driver.FindElement(By.XPath("//tr[td='Activity Status']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            // verify that access to Activity Status page is denied
            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Activity"));

            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Activity Status")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Activity Status link available.");
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to reports page is not able to go to that page.
        // TC5622
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToReportsDenyTest()
        {

            //  Deny Reports permission

            driver.FindElement(By.XPath("//tr[td='Reports']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            // verify that access to Reports page is denied
            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Activity"));

            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Reports")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Reports link available.");
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to event log page is not able to go to that page.
        // TC5623
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToEventLogDenyTest()
        {

            //  Deny Event Log permission

            driver.FindElement(By.XPath("//tr[td='Event Log']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Event Log page is denied
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Activity"));

            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Event Log")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Event Log link available.");
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user denied access to error log page is not able to go to that page.
        // TC5624
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToErrorLogDenyTest()
        {

            //  Deny Error Log permission

            driver.FindElement(By.XPath("//tr[td='Error Log']/td/input[@name='deny']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that access to Error Log page is denied
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Activity"));

            driver.FindElement(By.LinkText("Activity"));
            driver.FindElement(By.LinkText("Activity")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Error Log")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Error Log link available.");
            }
        }
    }
}
