// Revision History
//
// Michael McAfee - 8/21/12 - Created class
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

namespace SeleniumTests.FullyAutomatedTests.Servers
{
    [TestFixture]
    public class ActiveSyncServer
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
            remoteUrl,
            remoteUsername,
            serverName,
            maxUserCount
        }

        string browserString;   //type of browser (firefox, internet explorer, etc.)
        string browserUrl;  //MDM server
        string adminUserName;
        string password;
        string waitForPageToLoad;
        string serverName;  //The FQDN of the mail server 
        string maxUserCount;  //The maximum number of users that can be assigned to this server
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
            serverName = strings[EnmKeys.serverName.ToString()];
            maxUserCount = strings[EnmKeys.maxUserCount.ToString()];
            sleepTime = ints[EnmKeys.sleepTime.ToString()];

            selenium = new DefaultSelenium("localhost", 4444, browserString, browserUrl);
            selenium.Start();
            verificationErrors = new StringBuilder();
            selenium.SetTimeout(waitForPageToLoad);

            cm.LogIntoMdm(selenium, adminUserName, password);
        }

        [Test]
        public void CreateActiveSyncServer()
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user can create an ActiveSync server.
        // TC
        // ////////////////////////////////////////////////////////////////////////////////////////////////////// 
        {

            cm.CreateGenericActiveSyncServer(selenium, serverName, maxUserCount);

            // verify server appears in list
            try
            {
                Assert.IsTrue((selenium.IsElementPresent("//table[@id='ctl00_MainContent_dgServers']/tbody/tr[td='Microsoft ActiveSync']/td/a[.='" + serverName + "']")) || (selenium.IsElementPresent("//table[@id='ctl00_MainContent_dgServers']/tbody/tr[td='Microsoft ActiveSync']/td/a[.='" + serverName + " (Default)']")));
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