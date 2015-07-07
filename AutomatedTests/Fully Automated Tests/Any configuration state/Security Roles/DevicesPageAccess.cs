// Revision History
//
// Michael McAfee - 8/10/12 - Added comments, moved common beginnings of methods into SetupTest method, moved common endings of methods into TeardownTest method
// 
// Michael McAfee - 8/17/12 - Fixed a typo in the name of the PageAccessAllFullAccessTest method, added associated test cases in comments for each test method
// 
// Michael McAfee - 8/21/12 - Renamed the namespace and class so nUnit will group better, put in Fully Automated Tests/Security Roles folder
// 
// Michael McAfee - 8/23/12 - Add namespace level: NoConfiguration
// 
// Michael McAfee - 10/16/12 - Converted to WebDriver
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
    public class DevicesPageAccess
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

            cm.WaitForElement(driver, By.LinkText("Page Access"));
            driver.FindElement(By.LinkText("Page Access")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[th='Page Access']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Page Access']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']")).Click();

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with full access to all devices pages is able to edit info on those pages.
        // TC5613
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void PageAccessAllFullAccessTest()
        {


            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            // verify full access to MDM Server

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Device List")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.CssSelector("div.searchControls > a.add-btn-small")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Add.");
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.Id("filterOnOffTab")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//a[not(@style=\"display: none;\")][@title=\"Add a New Filter View\" ]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Add a New Filter View.");
                verificationErrors.Append(e.Message);
            }

            // verify full access to User List
            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("User List")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.CssSelector("a.import-user-large")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Add User.");
                verificationErrors.Append(e.Message);
            }

            // verify full access to Broadcast Messages
            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Broadcast Messages")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnNewBroadcastMessage")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to New Broadcast Message.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnDeleteBroadcastMessage")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Delete Broadcast Message.");
                verificationErrors.Append(e.Message);
            }

            // verify full access to Carrier Plans
            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Carrier Plans")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnAddPlan")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Add Plan.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnCopyPlan")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Copy Plan.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnDeletePlan")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Delete Plan.");
                verificationErrors.Append(e.Message);
            }

            // verify full access to Alert Center
            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Alert Center")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkClearAlerts")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Clear Alerts.");
                verificationErrors.Append(e.Message);
            }

            // verify full access to Liability Management
            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Liability Management")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//button[not(@disabled=\"disabled\")][.='Upload']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Upload.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//button[not(@disabled=\"disabled\")][.='Export current assignments to CSV']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Export current assignments to CSV.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[not(@disabled=\"disabled\") ]][.='Not set']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Not Set.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[not(@disabled=\"disabled\") ]][.='Individual Liable (disables ability to ask for liability status)']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Individual Liable (disables ability to ask for liability status).");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[not(@disabled=\"disabled\") ]][.='Individual Liable (disables ability to ask for liability status)']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Individual Liable (disables ability to ask for liability status).");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[not(@disabled=\"disabled\") ]][.=\"Ask for a device's liability status when it is added to MDM via the admin or self-service portal\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Ask for a device's liability status when it is added to MDM via the admin or self-service portal.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[not(@disabled=\"disabled\") ]][.=\"Ask for a device's liability status when it is added to MDM via the admin or self-service portal\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Ask for a device's liability status when it is added to MDM via the admin or self-service portal.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[not(@disabled=\"disabled\") ]][.=' Track usage for Corporate Liable devices']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Track usage for Corporate Liable devices.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[not(@disabled=\"disabled\") ]][.=' Track usage for devices where the liability status is unknown']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Track usage for devices where the liability status is unknown.");
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//button[not(@disabled=\"disabled\")][.='Save']")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append("Did not have access to Save.");
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to carrier plans page can access the page but cannot edit info on the page.
        // TC5614
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CarrierPlansReadAccessTest()
        {
            driver.FindElement(By.XPath("//tr[td='Carrier Plans']/td/input[@name='read']")).Click();

            // verify read access to Carrier Plans
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Carrier Plans")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnAddPlan")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnCopyPlan")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnDeletePlan")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to carrier plans page can not access the page.
        // TC5614
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CarrierPlansNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Carrier Plans']/td/input[@name='none']")).Click();

            // verify no access to User Interface
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Carrier Plans")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to user list page can access the page but cannot edit info on the page.
        // TC5615
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToUserListReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read']")).Click();

            // verify read access to Carrier Plans
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("User List")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.CssSelector("a.add-user-btn-large")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to user list page can not access the page.
        // TC5615
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToUserListNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='none']")).Click();

            // verify no access to User List
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("User List")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to alert center page can access the page but cannot edit info on the page.
        // TC5616
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AlertCenterReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Alert Center']/td/input[@name='read']")).Click();

            // verify read access to Alert Center
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Alert Center")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_lnkClearAlerts")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to alert center page can not access the page.
        // TC5616
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AlertCenterNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Alert Center']/td/input[@name='none']")).Click();

            // verify no access to Alert Center
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Alert Center")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to device list page can access the page but cannot edit info on the page.
        // TC5617
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToDeviceListReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access to Device List']/td/input[@name='read']")).Click();

            // verify read access to Device List
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Device List")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.CssSelector("div.searchControls &gt; a.add-btn-small")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.Id("filterOnOffTab")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//a[@style=\"display: none;\"][@title=\"Add a New Filter View\" ]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to device list page can not access the page.
        // TC5617
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AccessToDeviceListNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Access to Device List']/td/input[@name='none']")).Click();

            // verify no access to Device List
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Device List")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to broadcast messages page can access the page but cannot edit info on the page.
        // TC5618
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BroadcastMessagesReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Broadcast Messages']/td/input[@name='read']")).Click();

            // verify read access to Broadcast Messages
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Broadcast Messages")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnNewBroadcastMessage")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.Id("ctl00_MainContent_btnDeleteBroadcastMessage")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to broadcast messages page can not access the page.
        // TC5618
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BroadcastMessagesNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Broadcast Messages']/td/input[@name='none']")).Click();

            // verify no access to Broadcast Messages
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Broadcast Messages")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with read access to liability management page can access the page but cannot edit info on the page.
        // TC5619
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void LiabilityManagementReadAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Liability Management']/td/input[@name='read']")).Click();

            // verify read access to Liability Management
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            driver.FindElement(By.LinkText("Liability Management")).Click();

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//button[@disabled=\"disabled\" ][.=\"Upload\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//button[@disabled=\"disabled\" ][.=\"Export current assignments to CSV\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[@disabled=\"disabled\" ]][.=\"Not set\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[@disabled=\"disabled\" ]][.=\"Individual Liable (disables ability to ask for liability status)\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[@disabled=\"disabled\" ]][.=\"Corporate Liable (disables ability to ask for liability status)\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[@disabled=\"disabled\" ]][.=\"Ask for a device's liability status when it is added to MDM via the admin or self-service portal\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[@disabled=\"disabled\" ]][.=\" Track usage for Individual Liable devices\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[@disabled=\"disabled\" ]][.=\" Track usage for Corporate Liable devices\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//label[input[@disabled=\"disabled\" ]][.=\" Track usage for devices where the liability status is unknown\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            try
            {
                Assert.IsTrue(cm.IsElementPresent(driver, By.XPath("//button[@disabled=\"disabled\" ][.=\"Save\"]")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify user with no access to liability management page can not access the page.
        // TC5619
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void LiabilityManagementNoAccessTest()
        {

            driver.FindElement(By.XPath("//tr[td='Liability Management']/td/input[@name='none']")).Click();

            // verify no access to Liability Management
            cm.SaveSecurityRole(driver);

            driver.FindElement(By.LinkText("Sign Out")).Click();

            cm.LogIntoMdm(driver, regularUserName, password, baseURL);

            cm.WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();

            try
            {
                Assert.IsFalse(cm.IsElementPresent(driver, By.LinkText("Liability Management")));
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
