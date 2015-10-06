// Revision History
//
// Michael McAfee - 8/21/12 - Created class
//
// Michael McAfee - 8/22/12 - Replaced code with ConfigureMdmToUseActiveSyncWirelessService call
//
// Michael McAfee - 8/23/12 - Replaced SetUpDefaultExchange2003Domain call with SetUpGenericExchangeDomain call
//
// Michael McAfee - 10/10/12 - Converted to WebDriver
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

namespace SeleniumTests.FullyAutomatedTests.Domains
{
    [TestFixture]
    public class ActiveSyncExchange2003
    {
        CommonMethods cm = new CommonMethods();

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        public enum EnmKeys
        {
            browserString,
            browserUrl,
            adminUserName,
            password,
            sleepTime,
            waitForPageToLoad
        }

        string browserString;   //type of browser (firefox, internet explorer, etc.)
        string browserUrl;  //MDM server
        string adminUserName;
        string password;
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
            waitForPageToLoad = strings[EnmKeys.waitForPageToLoad.ToString()];
            sleepTime = ints[EnmKeys.sleepTime.ToString()];

            driver = new InternetExplorerDriver();
            baseURL = browserUrl;
            verificationErrors = new StringBuilder();

            cm.LogIntoMdm(driver, adminUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//a[.='MDM Server']"));

            cm.ConfigureMdmToUse(driver, "ActiveSync");
        }

        [Test]
        public void SetUpExchange2003ActiveSyncDomain()
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user can set up the ActiveSync domain to be Exchange 2003.
        // TC
        // ////////////////////////////////////////////////////////////////////////////////////////////////////// 
        {
            cm.SetUpGenericExchangeDomain(driver, "2003", String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, sleepTime);

            //verify the domain saved
            try
            {
                Assert.AreEqual("unassigned", driver.FindElement(By.XPath("//table[@id='ctl00_MainContent_dgDomains']/tbody/tr[td='Microsoft ActiveSync']/td[4]")).Text);
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