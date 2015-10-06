// Revision History
//
// Michael McAfee - 8/10/12 - Added comments, added DeleteExistingTestPolicies method
// Bob Lichtenfels - 10/14/12 Made these changes:
//                   1) Changed method WaitForElement - added optional parameter waitTime to be able to set wait to something 
//                      other than 60 second default.
//                   2) In method SaveSecurityRole (WebDriver method) added wait for element at beginning of method.
//                   3) In method DeleteSecurityRole (WebDriver method) added wait for element before each click.
//                   4) In method DeleteExistingSecurityRole (WebDriver method) added wait for element before each click.
// Bob Lichtenfels - 10/21/12 - Added methodS StartNewSecurityRoleWithNameAndQueryUpdateOne and SaveSecurityRoleUpdatedOne for
//                              the changes made to the security role page. 
// Bob Lichtenfels - 11/10/12 - Checked in VerifyElementEnabled and VerifyElementPresentAndDisplayed.
// Bob Lichtenfels - 11/18/12 - Checked in VerifyTextBoxEditable.
// Bob Lichtenfels - 11/24/12 - Enabled (un-commented) Console.WriteLine in VerifyElementEnabled, VerifyElementPresentAndDisplayed, 
//                              and VerifyTextBoxEditable.
// Bob Lichtenfels - 1/11/13  - Added debug timeout method DebugTimeout.
// Bob Lichtenfels - 2/3/13   - Removed some of the console messages in StartNewSecurityRoleWithNameAndQueryUpdateOne.
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

namespace SeleniumTests
{
    public class CommonMethods
    {
        public bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description:
        // This method will do a Thread.Sleep timeout and also display a message before the sleep starts 
        // if a message has been sent to the method.
        // Parameters:
        // 1) NumSecondsToWait                - Number of seconds for Thread.Sleep to timeout.
        // 2) MessageToShowConsole (optional) - Message to show before timeout starts.
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DebugTimeout(int NumSecondsToWait, string MessageToShowConsole = "")
        {
            Console.WriteLine("    Timeout for {0} seconds: {1} ", NumSecondsToWait, MessageToShowConsole);
            NumSecondsToWait *= 1000;
            Thread.Sleep(NumSecondsToWait);
        }


        //public void WaitForElement(IWebDriver driver, By by, int waitTime = 60)
        //{
        //    for (int second = 0; ; second++)
        //    {
        //        if (second >= waitTime) Assert.Fail("timeout");
        //        try
        //        {
        //            if (IsElementPresent(driver, by))
        //            {
        //                Thread.Sleep(1000);
        //                break;
        //            }
        //        }
        //        catch (Exception)
        //        { }
        //        Thread.Sleep(1000);
        //    }
        //}

        // Jose. THIS IS CHANGED SO CAN USE IN OLD CLASSES. Also took out static.
        public void WaitForElement(IWebDriver driver, By by, int timeout = 15)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(by);
                });
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        /*
        public void LogIntoMdm(ISelenium selenium, string userName, string password)
        // Log into MDM using the name and passsword parameters.
        {
            selenium.Open("/MDM");
            selenium.Type("id=userNameTextBox", userName);
            selenium.Type("id=passwordTextBox", password);
            selenium.Click("id=loginBtn");
            selenium.WaitForPageToLoad("30000");
        }
        */

        public void LogIntoMdm(IWebDriver driver, string userName, string password, string baseURL, bool isSelfServicePortal = false)
        // Log into MDM using the name and passsword parameters.
        {
            driver.Navigate().GoToUrl(baseURL + "/MDM");
            WaitForElement(driver, By.Id("userNameTextBox"));
            driver.FindElement(By.Id("userNameTextBox")).Clear();
            driver.FindElement(By.Id("userNameTextBox")).SendKeys(userName);
            WaitForElement(driver, By.Id("passwordTextBox"));
            driver.FindElement(By.Id("passwordTextBox")).Clear();
            driver.FindElement(By.Id("passwordTextBox")).SendKeys(password);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("loginBtn")).Click();
            // I add the next line because it seems that trying to do stuff right after the login
            // was causing an infinite spinner.  Waiting for the breadcrumbs to be generated first
            // seemed to solve the issue.  Probably a timing issue.
            if (isSelfServicePortal)
            {
                WaitForElement(driver, By.Id("accountSummaryDevice"));
            }
            else
            {
                WaitForElement(driver, By.ClassName("breadcrumbs"));
            }
        }

        /*
        public void StartNewSecurityRoleWithNameAndQuery(ISelenium selenium, int sleepTime, string roleName, string roleAssignment)
        // Click the Add Security Role icon, fill in the name and LDAP syntax using the parameters.
        {
            selenium.Click("css=a.add-security-large");
            Thread.Sleep(sleepTime);
            selenium.Type("id=roleNameTextBox", roleName);
            selenium.Type("id=roleAssignmentTextBox", roleAssignment);
        }
        */
        public void StartNewSecurityRoleWithNameAndQuery(IWebDriver driver, int sleepTime, string roleName, string roleAssignment)
        // Click the Add Security Role icon, fill in the name and LDAP syntax using the parameters.
        {
            WaitForElement(driver, By.CssSelector("a.add-security-large"));
            driver.FindElement(By.CssSelector("a.add-security-large")).Click();
            WaitForElement(driver, By.Id("roleNameTextBox"));
            driver.FindElement(By.Id("roleNameTextBox")).Clear();
            driver.FindElement(By.Id("roleNameTextBox")).SendKeys(roleName);
            driver.FindElement(By.XPath("//button[contains(.,'Edit Assignment')]")).Click();
            driver.FindElement(By.Id("roleAssignmentTextBox_txtLdapFreeform")).Clear();
            driver.FindElement(By.Id("roleAssignmentTextBox_txtLdapFreeform")).SendKeys(roleAssignment);
            driver.FindElement(By.XPath("//button[contains(.,'Edit Permissions')]")).Click();
        }


        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
        // Click the Add Security Role icon, fill in the name and LDAP syntax using the parameters, set the page back to the
        // point where the permissions can be edited, and leave the page opened in this state.
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
        public void StartNewSecurityRoleWithNameAndQueryUpdateOne(IWebDriver driver, int sleepTime, string roleName, string roleAssignment)
        {
            // Start New Role by selecting large element to add a security role.
            Console.WriteLine("    Start NEW security role page.");            
            WaitForElement(driver, By.CssSelector("a.add-security-large"), 15);
            driver.FindElement(By.CssSelector("a.add-security-large"));
            driver.FindElement(By.CssSelector("a.add-security-large")).Click();
            Thread.Sleep(500);
            //Console.WriteLine("    Finish selecting security role.");

            // Clear name text box and enter role name.
            WaitForElement(driver, By.Id("roleNameTextBox"), 15);
            driver.FindElement(By.Id("roleNameTextBox")).Clear();
            driver.FindElement(By.Id("roleNameTextBox")).SendKeys(roleName);
            Thread.Sleep(500);
            //Console.WriteLine("    Finish Clear name text box");

            // Select Ldap query.
            WaitForElement(driver, By.XPath("//*[@automationname='tangoeBtnAssignment']"), 15);
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnAssignment']"));
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnAssignment']")).Click();
            Thread.Sleep(500);
            //Console.WriteLine("    Finish Ldap query");

            // Enter Ldap query.
            WaitForElement(driver, By.Id("undefined_txtLdapFreeform"), 15);
            driver.FindElement(By.Id("undefined_txtLdapFreeform"));
            driver.FindElement(By.Id("undefined_txtLdapFreeform")).Clear();
            driver.FindElement(By.Id("undefined_txtLdapFreeform")).SendKeys(roleAssignment);
            Thread.Sleep(500);
            //Console.WriteLine("    Finish entering Ldap query");
            
            // Set security role page back to edit permissions by selecting edit permissions command button.
            WaitForElement(driver, By.XPath("//*[@automationname='tangoeBtnPermission']"), 5);
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnPermission']"));
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnPermission']")).Click();
            // Pre-automation tag code left in for for reference - first tag used in AnyConfigState->SecurityRoles tests.
            //driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission"));
            //driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            Thread.Sleep(500);
            Console.WriteLine("    Set security role page back to where the permissions can be edited and LEAVE OPEN.");
        }

        /*
        public void SaveSecurityRole(ISelenium selenium)
        // Click Save and then verify the success message appears.
        {
            selenium.Click("//form[@id='securityRoleForm']/div[2]/div/div[3]/button");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (selenium.IsTextPresent("Security Role was successfully added."))
                    {
                        break;
                    }
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }
        */
        public void SaveSecurityRole(IWebDriver driver)
        // Click Save and then verify the success message appears.
        {
            driver.FindElement(By.XPath("//button[contains(.,'Save')]")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (driver.PageSource.Contains("Security Role was successfully added."))  ;

                    {
                        break;
                    }
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        public void SaveSecurityRoleUpdatedOne(IWebDriver driver)
        // Click Save and then verify the success message appears.
        {
            WaitForElement(driver, By.XPath("//form[@id='securityRoleForm']/div[2]/div/div[4]/button"), 30); 
            driver.FindElement(By.XPath("//form[@id='securityRoleForm']/div[2]/div/div[4]/button")).Click(); 
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (driver.PageSource.Contains("Security Role was successfully added.")) ;

                    {
                        break;
                    }
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }




        /*
        public void DeleteSecurityRole(ISelenium selenium, string roleName)
        // Click the checkbox next to the name from the parameter.  Click the delete icon.  Click the OK button in the confirmation dialog.
        {
            selenium.Click("xpath=(//tr[td='" + roleName + "']/td/input[@type='checkbox'])");
            selenium.Click("css=a.delete-btn-small");
            selenium.Click("//button[@type='button']");
        }
        */
        
        public void DeleteSecurityRole(IWebDriver driver, string roleName)
        // Click the checkbox next to the name from the parameter.  Click the delete icon.  Click the OK button in the confirmation dialog.
        {
            WaitForElement(driver, By.XPath("//tr[td='" + roleName + "']/td/input[@type='checkbox']")); 
            driver.FindElement(By.XPath("//tr[td='" + roleName + "']/td/input[@type='checkbox']")).Click();
            WaitForElement(driver, By.CssSelector("a.delete-btn-small"));
            driver.FindElement(By.CssSelector("a.delete-btn-small")).Click();
            WaitForElement(driver, By.XPath("//button[@type='button']")); 
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }

        /*
        public void GoToUserProfile(ISelenium selenium, string regularUserLastName, string regularUserFirstName, int sleepTime)
        // Go to the User List.  When the link based on the last name and first name from parameters is present, click on that link.
        {
            selenium.Click("link=User List");
            selenium.WaitForPageToLoad("30000");

            selenium.Type("id=searchText", regularUserLastName);
            selenium.Click("//div[@id='userListFeature']/div/div/div/form/button");

            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (selenium.IsElementPresent("link=" + regularUserLastName + ", " + regularUserFirstName))
                    {
                        break;
                    }
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            selenium.Click("link=" + regularUserLastName + ", " + regularUserFirstName);
            Thread.Sleep(sleepTime);
        }
        */

        public void GoToUserProfile(IWebDriver driver, string regularUserLastName, string regularUserFirstName, int sleepTime)
        // Go to the User List.  When the link based on the last name and first name from parameters is present, click on that link.
        {
            WaitForElement(driver, By.XPath("//li/div/a[contains(text(),'Devices')]"));

            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]"));
            driver.FindElement(By.XPath("//li/div/a[contains(text(),'Devices')]")).Click();
            
            driver.FindElement(By.LinkText("User List")).Click();
            WaitForElement(driver, By.Id("searchText"));

            driver.FindElement(By.Id("searchText")).Clear();
            driver.FindElement(By.Id("searchText")).SendKeys(regularUserLastName);
            WaitForElement(driver, By.XPath("//div[@id='userListFeature']/div/div/div/form/button"));
            driver.FindElement(By.XPath("//div[@id='userListFeature']/div/div/div/form/button")).Click();

            WaitForElement(driver, By.LinkText(regularUserLastName + ", " + regularUserFirstName));
            driver.FindElement(By.LinkText(regularUserLastName + ", " + regularUserFirstName)).Click();
            Thread.Sleep(sleepTime);
        }

        /*
        public void DeleteExistingSecurityRole(ISelenium selenium, string roleName, int sleepTime)
        // Remove any security roles with the specified name.
        {
            // Open security role page and delete any existing roles with name roleName.
            Console.WriteLine("    Delete existing security role if found.");
            selenium.Click("link=Security Roles");
            selenium.WaitForPageToLoad("30000");
            Thread.Sleep(sleepTime);
            while (selenium.IsTextPresent(roleName))
            {
                DeleteSecurityRole(selenium, roleName);
                Thread.Sleep(sleepTime);
            }

        }
        */
        
        public void DeleteExistingSecurityRole(IWebDriver driver, string roleName, int sleepTime)
        // Remove any security roles with the specified name.
        {
            Console.WriteLine("    Delete any existing security role(s) with specified name found in config file.");
            WaitForElement(driver, By.LinkText("Security"), 30); 
            driver.FindElement(By.LinkText("Security"));
            driver.FindElement(By.LinkText("Security")).Click();
            WaitForElement(driver, By.LinkText("Security Roles"), 30);
            driver.FindElement(By.LinkText("Security Roles"));
            driver.FindElement(By.LinkText("Security Roles")).Click();
            Thread.Sleep(sleepTime);
            while (driver.FindElement(By.TagName("body")).Text.Contains(roleName))
            {
                DeleteSecurityRole(driver, roleName);
                Thread.Sleep(sleepTime);
            }

        }

        /*
        public void SetUpGenericExchangeDomain(ISelenium selenium, string exchangeVersion, string connectorUsername, string connectorHostName, string remoteUrl, string remoteUsername, string password, int sleepTime)
        // Set up the ActiveSync domain 
        // Depending on which version of Exchange is desired, different fields will be filled in
        {

            // Click Domains ----------------------------
            selenium.Click("link=Domains");
            selenium.WaitForPageToLoad("30000");

            // Click ActiveSync Domain ----------------------------
            selenium.Click("link=Microsoft ActiveSync");
            selenium.WaitForPageToLoad("30000");

            // if the domain is already set to the specified Exchange version
            if (selenium.GetSelectedLabel("id=ctl00_MainContent_ddlExchangeVersion") == exchangeVersion)

            // do nothing
            // MDM is already set to the desired Exchange version
            { }
            else
            {

                // set the domain to be the specified Exchange version
                selenium.Select("id=ctl00_MainContent_ddlExchangeVersion", "label=" + exchangeVersion);
                Thread.Sleep(sleepTime);

                if ((exchangeVersion == "2007") || (exchangeVersion == "Mixed"))
                {
                    // configure Exchange 2007 Remote PowerShell Configuration
                    selenium.Type("id=ctl00_MainContent_txtConnectorUsername", connectorUsername);
                    selenium.Type("id=ctl00_MainContent_txtConnectorPassword", password);
                    selenium.Type("id=ctl00_MainContent_txtConnectorHostName", connectorHostName);
                }

                if ((exchangeVersion == "2010") || (exchangeVersion == "Mixed"))
                {
                    // configure Exchange 2010 Remote PowerShell Configuration
                    selenium.Type("id=ctl00_MainContent_txtRemoteUrl", remoteUrl);
                    selenium.Type("id=ctl00_MainContent_txtRemoteUsername", remoteUsername);
                    selenium.Type("id=ctl00_MainContent_txtRemotePassword", password);
                }
            }

            // save the domain
            selenium.Click("id=ctl00_MainContent_lnkSave");
            selenium.WaitForPageToLoad("30000");
        }
        */

        public void SetUpGenericExchangeDomain(IWebDriver driver, string exchangeVersion, string connectorUsername, string connectorHostName, string remoteUrl, string remoteUsername, string password, int sleepTime)
        // Set up the ActiveSync domain 
        // Depending on which version of Exchange is desired, different fields will be filled in
        {

            // Click Domains ----------------------------
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("Domains")).Click();

            // Click ActiveSync Domain ----------------------------
            WaitForElement(driver, By.XPath("//a[.='Microsoft ActiveSync']"));
            driver.FindElement(By.LinkText("Microsoft ActiveSync")).Click();
            WaitForElement(driver, By.Id("ctl00_MainContent_ddlExchangeVersion"));

            // if the domain is already set to the specified Exchange version
            if (driver.FindElement(By.XPath("//select[@id='ctl00_MainContent_ddlExchangeVersion']/option[@selected='selected']")).Text == exchangeVersion)

            // do nothing
            // MDM is already set to the desired Exchange version
            { }
            else
            {

                // set the domain to be the specified Exchange version
                SelectElement select = new SelectElement(driver.FindElement(By.Id("ctl00_MainContent_ddlExchangeVersion")));
                select.SelectByText(exchangeVersion);
                Thread.Sleep(sleepTime);

                if ((exchangeVersion == "2007") || (exchangeVersion == "Mixed"))
                {
                    // configure Exchange 2007 Remote PowerShell Configuration
                    driver.FindElement(By.Id("ctl00_MainContent_txtConnectorUsername")).Clear();
                    driver.FindElement(By.Id("ctl00_MainContent_txtConnectorUsername")).SendKeys(connectorUsername);
                    driver.FindElement(By.Id("ctl00_MainContent_txtConnectorPassword")).Clear();
                    driver.FindElement(By.Id("ctl00_MainContent_txtConnectorPassword")).SendKeys(password);
                    driver.FindElement(By.Id("ctl00_MainContent_txtConnectorHostName")).Clear();
                    driver.FindElement(By.Id("ctl00_MainContent_txtConnectorHostName")).SendKeys(connectorHostName);
                }

                if ((exchangeVersion == "2010") || (exchangeVersion == "Mixed"))
                {
                    // configure Exchange 2010 Remote PowerShell Configuration
                    driver.FindElement(By.Id("ctl00_MainContent_txtRemoteUrl")).Clear();
                    driver.FindElement(By.Id("ctl00_MainContent_txtRemoteUrl")).SendKeys(remoteUrl);
                    driver.FindElement(By.Id("ctl00_MainContent_txtRemoteUsername")).Clear();
                    driver.FindElement(By.Id("ctl00_MainContent_txtRemoteUsername")).SendKeys(remoteUsername);
                    driver.FindElement(By.Id("ctl00_MainContent_txtRemotePassword")).Clear();
                    driver.FindElement(By.Id("ctl00_MainContent_txtRemotePassword")).SendKeys(password);
                }
            }

            // save the domain
            driver.FindElement(By.Id("ctl00_MainContent_lnkSave")).Click();
            //Thread.Sleep(sleepTime);
            //try
            //{
            //    driver.SwitchTo().Alert().Accept();
            //}
            //catch (Exception e)
            //{
            //    // no alert
            //}
        }

        /*
        public void CreateGenericActiveSyncServer(ISelenium selenium, string serverName, string maxUserCount)
        // Go to Servers page.  If the ActiveSync server does not already exist, click the Add ActiveSync Server button, 
        //  fill in required fields and then click the Save button.
        {
            selenium.Click("link=Servers");
            selenium.WaitForPageToLoad("30000");

            // if the Server Name already exists, either on its own or with "(Default)" appended to it
            if (selenium.IsElementPresent("//table[@id='ctl00_MainContent_dgServers']/tbody/tr[td='Microsoft ActiveSync']/td/a[.='" + serverName + "']") || selenium.IsElementPresent("//table[@id='ctl00_MainContent_dgServers']/tbody/tr[td='Microsoft ActiveSync']/td/a[.='" + serverName + " (Default)']"))

            // do nothing, because it's obvious an ActiveSync server can be created
            { }
            else
            {

                // click Add ActiveSync server button
                selenium.Click("id=ctl00_MainContent_lnkAddServerActiveSync");
                selenium.WaitForPageToLoad("30000");

                // fill in required fields
                selenium.Type("id=ctl00_MainContent_txtServerName", serverName);
                selenium.Type("id=ctl00_MainContent_txtMaxUserCount", maxUserCount);

                // click Save button
                selenium.Click("id=ctl00_MainContent_lnkSave");
                selenium.WaitForPageToLoad("30000");
            }
        }
        */
        
        /*
        public void ConfigureMdmToUse(ISelenium selenium, string option)
        // Check MDM Server page to see if desired box is checked.
        // If so, do nothing.
        //  If not, check the box and save the settings.
        {
            // go to MDM Server page
            selenium.Click("link=MDM Server");
            selenium.WaitForPageToLoad("30000");

            // if box is checked
            if (selenium.IsChecked("id=ctl00_MainContent_cbx" + option))

            // do nothing
            { }
            else
            {

                //  click the wireless service box
                selenium.Click("id=ctl00_MainContent_cbx" + option);

                //  click the Save button
                selenium.Click("id=ctl00_MainContent_lnkSave");

                // wait for the message that configuration was saved successfully
                selenium.WaitForPageToLoad("30000");
                for (int second = 0; ; second++)
                {
                    if (second >= 60) Assert.Fail("timeout");
                    try
                    {
                        if ("Configuration saved successfully" == selenium.GetText("id=ctl00_MainContent_mbxMessage_divMessages")) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }
            }
        }
        */
        
        public void ConfigureMdmToUse(IWebDriver driver, string option)
        // Check MDM Server page to see if desired box is checked.
        // If so, do nothing.
        //  If not, check the box and save the settings.    }
        {
            // go to MDM Server page
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            driver.FindElement(By.LinkText("MDM Server")).Click();
            WaitForElement(driver, By.Id("ctl00_MainContent_cbx" + option));

            // if box is checked
            if (driver.FindElement(By.Id("ctl00_MainContent_cbx" + option)).Selected)

            // do nothing
            { }
            else
            {

                //  click the wireless service box
                driver.FindElement(By.Id("ctl00_MainContent_cbx" + option)).Click();

                //  click the Save button
                driver.FindElement(By.Id("ctl00_MainContent_lnkSave")).Click();

                // wait for the message that configuration was saved successfully
                for (int second = 0; ; second++)
                {
                    if (second >= 60) Assert.Fail("timeout");
                    try
                    {
                        if ("Configuration saved successfully" == driver.FindElement(By.Id("ctl00_MainContent_mbxMessage_divMessages")).Text) break;
                    }
                    catch (Exception)
                    { }
                    Thread.Sleep(1000);
                }
            }
        }

        public void DeleteUser(IWebDriver driver, string regularUserLastName, string regularUserFirstName, int sleepTime)
        {
            GoToUserProfile(driver, regularUserLastName, regularUserFirstName, sleepTime);

            driver.FindElement(By.XPath("//div[@id='userActionDropDownBtn']/button")).Click();
            driver.FindElement(By.LinkText("Delete User")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Thread.Sleep(sleepTime);
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description:
        // This method verifies whether an item passed in is enabled or not enabled, as long as it exists 
        // on the page. The element passed in is expacted to be found. It does not stop the flow of the 
        // test class calling it. It indicates a failure by adding a failure message text to the 
        // passed-by-ref input string "verificationErrors". 
        //
        // Parameters:
        // 1) ExpectedStatus      - Present and displayed or not present and displayed.
        // 2) By                  - The item.
        // 3) VerificationErrors  - Passed by ref for logging errors to error string.
        // 4) Driver              - Web driver handle.
        // 5) WaitTime            - How long to wait for the element to be found.
        // 6) LogError (optional) - Whether to log the eror to the NUnit console (true will log the error).
        // 
        // Return: 
        // False if expected status is not what is expected and True if expected status is what is expected.
        // 
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool VerifyElementEnabled(bool ExpectedStatus, By by, ref StringBuilder verificationErrors, IWebDriver driver, int WaitTime, bool LogError = false)
        {
            Console.WriteLine("    Check element enabled.");
            try
            {
                WaitForElement(driver, by, WaitTime); // Wait time to avoid intermittent results.
            }
            catch (AssertionException e)
            {
                if (LogError) // If get here there's something wrong. The element is first expected to be found.
                {
                    Console.WriteLine("    !Fail in VerifyElementEnabled. Element was expected to be found but was not. Can not be complete check. Raising a fail. Item=" + by.ToString());
                }
                verificationErrors.Append(e.Message);
                return false;
            }
            try
            {
                IWebElement IWeb = driver.FindElement(by);
                Assert.AreEqual(ExpectedStatus, IWeb.Enabled);
            }
            // If get here the expected status is not what is expected. Error will be added to verificationErrors string.
            catch (AssertionException e)
            {
                if (LogError)
                {
                    if (ExpectedStatus == true)
                    {
                        Console.WriteLine("    !Fail in VerifyElementEnabled. Selection expected to be enabled but is NOT enabled. Item = " + by.ToString());
                    }
                    else
                    {
                        Console.WriteLine("    !Fail in VerifyElementEnabled. Selection expected to NOT be enabled but it is. Item = " + by.ToString());
                    }
                }
                verificationErrors.Append(e.Message);
                return false;
            }
            return true; // No error.
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description:
        // This method verifies whether an item passed to it is present and displayed. It does not stop the 
        // flow of the test class calling it. It indicates a failure by addding failure message text to the 
        // passed-by-ref input string "verificationErrors". 
        //
        // Parameters:
        // 1) ExpectedStatus     - Present and displayed or not present and displayed.
        // 2) By                 - The item.
        // 3) VerificationErrors - Passed by ref for logging errors to error string.
        // 4) Driver             - Web driver handle.
        // 5) WaitTime           - How long to wait for the element to be found.
        // 6) LogError           - Whether to log the eror to the NUnit console (true will log the error).
        // 
        // Return: 
        // False if expected status is not what is expected and True if expected status is what is expected.
        // 
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool VerifyElementPresentAndDisplayed(bool ExpectedStatus, By by, ref StringBuilder verificationErrors, IWebDriver driver, int WaitTime, bool LogError = false)
        {
            Console.WriteLine("    VerifyElementPresentAndDisplayed");
            try
            {
                WaitForElement(driver, by, WaitTime);
            }
            catch (Exception e)
            {
                // If get here the wait above didn't find the element. It's not present.
                if (ExpectedStatus == true) // If it's supposed to be present this is an error.
                {
                    if (LogError == true)
                    {
                        Console.WriteLine("    !Fail in VerifyElementPresentAndDisplayed. Item is expected to be present and is not. Item = " + by.ToString());
                    }
                    verificationErrors.Append(e.Message);
                    return false;
                }
                return true; // Expected status is false (element not present). Return without creating/logging an error.
            }
            try
            {
                // Element has been found (is present). See if it's displayed status matches what's expected.
                IWebElement IWeb = driver.FindElement(by);
                Assert.AreEqual(ExpectedStatus, IWeb.Displayed);
            }
            catch (AssertionException e)
            {
                // If get here, displayed status does not match what's expected. Log correct error.
                if (LogError == true)
                {
                    if (ExpectedStatus == true)
                    {
                        Console.WriteLine("    !Fail in VerifyElementPresentAndDisplayed. Selection expected to be displayed but is not. Item = " + by.ToString());
                    }
                    else
                    {
                        Console.WriteLine("    !Fail in VerifyElementPresentAndDisplayed. Selection expected to not be displayed but is displayed. Item = " + by.ToString());
                    }
                }
                verificationErrors.Append(e.Message);
                return false;
            }
            return true; // No failure for displayed status.
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description:
        // This method verifies whether a text box is editable or not editable. It does not stop the flow of 
        // the test class calling it. It indicates a failure by addding failure message text to the 
        // passed-by-ref input string "verificationErrors". 
        //
        // Parameters:
        // 1) ExpectedStatus      - Present and displayed or not present and displayed.
        // 2) By                  - The item.
        // 3) VerificationErrors  - Passed by ref for logging errors to error string.
        // 4) Driver              - Web driver handle.
        // 5) WaitTime            - How long to wait for the element to be found.
        // 6) LogError (optional) - Whether to log the eror to the NUnit console (true will log the error).
        // 
        // Return: 
        // False if expected status is not what is expected and True if expected status is what is expected.
        // 
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool VerifyTextBoxEditable(bool ExpectedStatus, By by, ref StringBuilder verificationErrors, IWebDriver driver, int WaitTime, string textToWrite, bool LogError = false)
        {
            Console.WriteLine("    Is Check textbox editable.");
            try // Item passed in should be there. If not, something is wrong to start with.
            {
                WaitForElement(driver, by, WaitTime);
            }
            catch (AssertionException e)
            {
                Console.WriteLine("    !Fail in VerifyTextBoxEditable. Selection that is expected to be present is NOT present. Can not be complete check. Raising a fail. Item = " + by.ToString());
                verificationErrors.Append(e.Message);
                return false;
            }

            try // Try to enter the role name
            {
                IWebElement IWeb = driver.FindElement(by);
                IWeb.SendKeys(textToWrite);
            }
            catch (Exception e)
            {
                // If arrive in this catch, element SendKeys failed because the text box is not editable.
                if (ExpectedStatus == true) // If text box is expected to be editable this is a fail.
                {
                    if (LogError)
                    {
                        Console.WriteLine("    !Fail in VerifyTextBoxEditable. Text box should be editable. Item = " + by.ToString());
                    }
                    verificationErrors.Append(e.Message);
                    return false;
                }
                return true; // Have verified the possible cases with text box not being editable.
            }
            if (ExpectedStatus == false)  // If get here the text box is editable. If caller expects it to NOT be editable there is an error.
            {
                if (LogError)
                {
                    Console.WriteLine("    !Fail in VerifyTextBoxEditable. Text box should NOT be editable. Item = " + by.ToString());
                }
                verificationErrors.Append("!Fail in VerifyTextBoxEditable. Text box should NOT be editable. Item = " + by.ToString());
                return false;
            }
            return true;
        }
    }
}
