// Revision History
//
// Michael McAfee - 10/23/12 - Created class
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using System.Threading;


namespace SeleniumTests.FullyAutomatedTests.AnyConfiguration.SecurityRoles
{
    //This is the Super class called "SecurityRolesTest." This class provides methods and configuration which are common for any test in the Security Roles folder.
    //This includes Setup and TearDown for nUnit tests.

    public class SecurityRolesTest
    {
        public CommonMethods cm = new CommonMethods();

        public IWebDriver driver;
        public StringBuilder verificationErrors;
        public string baseURL;

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

        public string browserString;   //type of browser (firefox, internet explorer, etc.)
        public string browserUrl;  //MDM server
        public string adminUserName;
        public string password;
        public string roleName;    //name of the security role that will be created
        public string roleAssignment;  //LDAP query syntax used to determine who gets the security role
        public string regularUserName; //user who belongs to the security role
        public string waitForPageToLoad;
        public int sleepTime;

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

            cm.LogIntoMdm(driver, adminUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[.='Security Roles']"));

            cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);

            cm.StartNewSecurityRoleWithNameAndQuery(driver, sleepTime, roleName, roleAssignment);

            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
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

                cm.DeleteExistingSecurityRole(driver, roleName, sleepTime);

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
