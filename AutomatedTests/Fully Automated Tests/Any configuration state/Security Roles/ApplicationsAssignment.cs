// Revision History
//
// Michael McAfee - 8/17/12 - Created test class
// 
// Michael McAfee - 8/21/12 - Renamed the namespace and class so nUnit will group better, put in Fully Automated Tests/Security Roles folder
// 
// Michael McAfee - 8/23/12 - Add namespace level: NoConfiguration
// 
// Michael McAfee - 9/27/12 - Converted class to use WebDriver
// 
// Michael McAfee - 10/23/12 - Set up ApplicationsAssignment to inherit from SecurityRolesTest, removed duplications
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
    public class ApplicationsAssignment : SecurityRolesTest
    {
        [SetUp]

        public void GiveProfilesFullAccessPermissions()
        {
            //  Give all functions full access in the Profiles tab

            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Applications')]"));

            driver.FindElement(By.XPath("//li/a[.='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            driver.FindElement(By.XPath("//tr[th='Profiles']/th/div[div[contains(.,'Full Access')]]/input")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with full access to Application Push page can access the page and edit info on the page.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ApplicationPushFullAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that full access to Application Push page is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Applications"));

            driver.FindElement(By.LinkText("Applications"));
            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Application Push/Install")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//a[@class=\"add-rule-btn-large\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Add Rule.");
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Application Push page can access the page but not edit info on the page.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ApplicationPushReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='read']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that read access to Application Push page is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Applications"));

            driver.FindElement(By.LinkText("Applications"));
            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Application Push/Install")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.XPath("//a[@class=\"add-rule-btn-large\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Had access to Add Rule.");
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to Application Push page cannot access the page.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ApplicationPushNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='none']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();
            // verify that no access to Application Push page is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Applications"));

            driver.FindElement(By.LinkText("Applications"));
            driver.FindElement(By.LinkText("Applications")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Application Push/Install")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Had access to Application Push/Install.");
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with full access to Application Remove page can access the page and edit info on the page.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ApplicationRemoveFullAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='full']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that full access to Application Remove page is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Applications"));

            driver.FindElement(By.LinkText("Applications"));
            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Application Remove/Uninstall")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//a[@class=\"add-rule-btn-large\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Did not have access to Add Rule.");
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to Application Remove page can access the page but not edit info on the page.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ApplicationRemoveReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='read']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that read access to Application Remove page is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Applications"));

            driver.FindElement(By.LinkText("Applications"));
            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Application Remove/Uninstall")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.XPath("//a[@class=\"add-rule-btn-large\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Had access to Add Rule.");
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to Application Remove page cannot access the page.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ApplicationRemoveNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='none']")).Click();

            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            // verify that no access to Application Remove page is granted
            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.LinkText("Applications"));

            driver.FindElement(By.LinkText("Applications"));
            driver.FindElement(By.LinkText("Applications")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Application Remove/Uninstall")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                verificationErrors.Append("Had access to Application Remove/Uninstall.");
            }
        }
    }
}
