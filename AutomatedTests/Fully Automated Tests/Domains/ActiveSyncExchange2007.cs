// Revision History
//
// Michael McAfee - 8/22/12 - Created class
//
// Michael McAfee - 8/23/12 - Replaced SetUpDefaultExchange2003Domain call with SetUpGenericExchangeDomain call
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

namespace SeleniumTests.FullyAutomatedTests.Domains
{
    [TestFixture]
    public class ActiveSyncExchange2007
    {
        CommonMethods cm = new CommonMethods();

        private ISelenium selenium;
        private StringBuilder verificationErrors;

        public enum EnmKeys
        {
            browserString,
            browserUrl,
            adminUserName,
            password,
            sleepTime,
            waitForPageToLoad,
            connectorUsername,
            connectorHostName
        }

        string browserString;   //type of browser (firefox, internet explorer, etc.)
        string browserUrl;  //MDM server
        string adminUserName;
        string password;
        string waitForPageToLoad;
        string connectorUsername;   //Exchange 2007 Connector Admin
        string connectorHostName;  //Exchange 2007 Connector Hostname
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
            connectorUsername = strings[EnmKeys.connectorUsername.ToString()];
            connectorHostName = strings[EnmKeys.connectorHostName.ToString()];
            sleepTime = ints[EnmKeys.sleepTime.ToString()];

            selenium = new DefaultSelenium("localhost", 4444, browserString, browserUrl);
            selenium.Start();
            verificationErrors = new StringBuilder();
            selenium.SetTimeout(waitForPageToLoad);

            cm.LogIntoMdm(selenium, adminUserName, password);

            cm.ConfigureMdmToUse(selenium, "ActiveSync");
        }

        [Test]
        public void SetUpExchange2007ActiveSyncDomain()
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user can set up the ActiveSync domain to be Exchange 2007.
        // TC
        // ////////////////////////////////////////////////////////////////////////////////////////////////////// 
        {
            cm.SetUpGenericExchangeDomain(selenium, "2007", connectorUsername, connectorHostName, String.Empty, String.Empty, password, sleepTime);

            //verify the domain saved
            try
            {
                Assert.AreEqual(connectorHostName, selenium.GetText("//table[@id='ctl00_MainContent_dgDomains']/tbody/tr[td='Microsoft ActiveSync']/td[4]"));
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