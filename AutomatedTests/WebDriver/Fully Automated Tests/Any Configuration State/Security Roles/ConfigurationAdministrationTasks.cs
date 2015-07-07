// Revision History
//
// Bob Lichtenfels - 3/30/13 -  Created. Let there be test for everything under Gear->Tasks.
// Bob Lichtenfels - 4/6/13 -   Finished Full and Read access tests.
// Bob Lichtenfels - 4/7/13 -   Add ConfigurationAdministrationSystemNoAccessTest_ViewOnlyUserSynchronization.
// Bob Lichtenfels - 4/9/13 -   Fix typo and change read access test for scheduling->history tab after defect fix.
// Bob Lichtenfels - 4/14/13 -  Finished.
// 
using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests; // Allows to instantiate CommonMethods.
using System.Threading;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Any_configuration_state.Security_Roles; // To get base class

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Any_Configuration_State.Security_Roles
{
    [TestFixture]    
    class ConfigurationAdministrationTasks : SecurityRoleBase
    {
        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify full access to the following selections found under Gear->Tasks.
        // User Sync
        // Rules Enforcement
        // Processing
        // Scheduling
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemTasksAllFullAccessTest()
        {
            int WaitTimeForElement = 5; // How long to wait when calling WaitForElement.

            Console.WriteLine("\nRunning full access for Gear->Tasks");
            Console.WriteLine("Setup full access security for Gear->Tasks and save.");
            // Asssume security role page is opened to ConfigAdmin->Tasks.
            
            // Set security to give non-admin user full access to Gear->Tasks.
            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[.='Configuration Administration']")).Click();
            cm.WaitForElement(driver, By.LinkText("Tasks"));
            driver.FindElement(By.LinkText("Tasks")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: FullAccessAll']")).Click();

            // Save role and sign out
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as non-admin user.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select tasks pulldown.
            SelectConfigurationPulldown();

            Console.WriteLine("    * Verify User Synchronization Tab.");            
            // Select User Sync in Tasks pulldown and verify can edit page.
            driver.FindElement(By.LinkText("User Synchronization"));            
            driver.FindElement(By.LinkText("User Synchronization")).Click();
            VerifyTextAndElementPresentOnPage(WaitTimeForElement, "User Synchronization", driver, ref VerificationErrors, By.Id("ctl00_MainContent_cbxASServer"));

            // Verify the EAS sync checkbox and run sync command button are enabled.
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_cbxASServer"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_lnkSyncServers"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Select tasks pulldown.
            SelectConfigurationPulldown();

            Console.WriteLine("    * Verify Rules Enforcement  Tab.");            
            // Select Rules Enforcement in Tasks pulldown and verify can edit page.
            driver.FindElement(By.LinkText("Rules Enforcement"));
            driver.FindElement(By.LinkText("Rules Enforcement")).Click();
            VerifyTextAndElementPresentOnPage(WaitTimeForElement, "Rules Enforcement", driver, ref VerificationErrors, By.Id("ctl00_MainContent_cbxEnableRetroRules"));

            // Verify retro rules checkbox, run (enforce) rules button, save button and pulldown are enabled.
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_cbxEnableRetroRules"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_lnkRunRetroRules"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_ddlManualRun"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Select tasks pulldown. 
            SelectConfigurationPulldown();

            Console.WriteLine("    * Verify Processing Tasks Tab.");            
            // Select Processing in Tasks pulldown and verify can edit page.
            driver.FindElement(By.LinkText("Processing"));
            driver.FindElement(By.LinkText("Processing")).Click();
            VerifyTextAndElementPresentOnPage(WaitTimeForElement, "Processing/Tasks", driver, ref VerificationErrors, By.LinkText("Select"));

            // Verify some links can be selected and their corresponding text box is editable.
            driver.FindElement(By.LinkText("Select"));
            driver.FindElement(By.LinkText("Select")).Click();
            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_txtValue"), ref VerificationErrors, driver, WaitTimeForElement, "Text For Test",true);
            driver.FindElement(By.XPath("(//a[contains(text(),'Select')])[8]"));
            driver.FindElement(By.XPath("(//a[contains(text(),'Select')])[8]")).Click();
            cm.VerifyTextBoxEditable(true, By.Id("ctl00_MainContent_txtValue"), ref VerificationErrors, driver, WaitTimeForElement, "Text For Test",true);
            // Verify save button is enabled.
            cm.VerifyElementEnabled(true, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);

            Console.WriteLine("    * Verify Task Scheduling Tab.");

            Console.WriteLine("    --- Status Tab.");

            // Select tasks pulldown.
            SelectConfigurationPulldown();
            
            // Select Scheduling in Tasks pulldown and verify can edit tabbed pages.
            driver.FindElement(By.LinkText("Scheduling"));
            driver.FindElement(By.LinkText("Scheduling")).Click();
            VerifyTextAndElementPresentOnPage(WaitTimeForElement, "Task Scheduling", driver, ref VerificationErrors, By.LinkText("ActiveSync Update"));

            // Verify tabs are selectable.
            cm.VerifyElementEnabled(true, By.LinkText("Status"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.LinkText("History"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.XPath("(//a[contains(text(),'Scheduling')])[2]"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // ** STATUS TAB **

            // Select status tab, EAS update, and verify add,save, delete, and pulldown selections are enabled.
            cm.WaitForElement(driver, By.LinkText("Status"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Status"));
            driver.FindElement(By.LinkText("Status")).Click();
            cm.WaitForElement(driver, By.LinkText("ActiveSync Update"), WaitTimeForElement);
            driver.FindElement(By.LinkText("ActiveSync Update"));
            driver.FindElement(By.LinkText("ActiveSync Update")).Click();
            cm.VerifyElementEnabled(true, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.CssSelector("a.add-schedule-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.CssSelector("#ScheduleListFeature > div.listFilterActions > a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("SelPriority"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Go back to main task scheduling page.
            GoBackToMainTaskSchedulingPage(WaitTimeForElement);

            // ** SCHEDULING TAB **

            Console.WriteLine("    --- Scheduling Tab.");

            // Select Scheduling tab, EAS update, and verify add, save, delete, and pulldown selections are enabled. 
            cm.WaitForElement(driver, By.XPath("(//a[contains(text(),'Scheduling')])[2]"), WaitTimeForElement);
            driver.FindElement(By.XPath("(//a[contains(text(),'Scheduling')])[2]"));
            driver.FindElement(By.XPath("(//a[contains(text(),'Scheduling')])[2]")).Click();

            cm.WaitForElement(driver, By.LinkText("ActiveSync Update"), WaitTimeForElement);
            driver.FindElement(By.CssSelector("#TaskScheduleList > tbody > tr > td > a[title=\"ActiveSync Update\"]"));
            driver.FindElement(By.CssSelector("#TaskScheduleList > tbody > tr > td > a[title=\"ActiveSync Update\"]")).Click();
            cm.VerifyElementEnabled(true, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.CssSelector("a.add-schedule-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("SelPriority"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.CssSelector("#ScheduleListFeature > div.listFilterActions > a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Go back to main task scheduling page.
            GoBackToMainTaskSchedulingPage(WaitTimeForElement);

            // ** HISTORY TAB **

            Console.WriteLine("    --- History Tab.");            
            
            // Select history tab and verify text boxes, pulldowns, delete, search, and a checkbox are enebled.
            cm.WaitForElement(driver, By.LinkText("History"), WaitTimeForElement);
            driver.FindElement(By.LinkText("History"));
            driver.FindElement(By.LinkText("History")).Click();
            // Check two text boxes are editable.
            cm.VerifyTextBoxEditable(true, By.Id("searchTaskHistoryStartDate"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(true, By.Id("searchTaskHistoryEndDate"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            // Check search button enabled.
            cm.VerifyElementEnabled(true, By.XPath("//div[@id='TaskHistoryProfileListContainer']/div/div/div/button"), ref VerificationErrors, driver, WaitTimeForElement, true);
            // Verify pulldowns editable.
            cm.VerifyElementEnabled(true, By.Id("searchTaskHistoryTask"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("searchTaskHistoryStatus"), ref VerificationErrors, driver, WaitTimeForElement, true);
            // Verify delete and a checkbox are enabled.
            cm.VerifyElementEnabled(true, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }


        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify full access to the following selections found under Gear->Tasks.
        // User Sync
        // Rules Enforcement
        // Processing
        // Scheduling
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemTasksAllReadAccessTest()
        {

            int WaitTimeForElement = 3; // How long to wait when calling WaitForElement.

            Console.WriteLine("\nRunning read access for Gear->Tasks");
            Console.WriteLine("Setup full access security for Gear->Tasks and save.");
            // Asssume security role page is opened to ConfigAdmin->Tasks.
            // Set security to give non-admin user full access to Gear->Tasks.
            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[.='Configuration Administration']")).Click();
            cm.WaitForElement(driver, By.LinkText("Tasks"));
            driver.FindElement(By.LinkText("Tasks")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: ReadAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: ReadAccessAll']")).Click();

            // Save role and sign out
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Log in as non-admin user.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select tasks pulldown.
            SelectConfigurationPulldown();

            Console.WriteLine("    * Verify User Synchronization.");
            // Select User Sync in Tasks pulldown and verify can't edit page.
            driver.FindElement(By.LinkText("User Synchronization"));
            driver.FindElement(By.LinkText("User Synchronization")).Click();
            VerifyTextAndElementPresentOnPage(WaitTimeForElement, "User Synchronization", driver, ref VerificationErrors, By.Id("ctl00_MainContent_cbxASServer"));

            // Verify the EAS sync checkbox and run sync command button are disabled.
            cm.VerifyElementEnabled(false, By.Id("ctl00_MainContent_cbxASServer"), ref VerificationErrors, driver, WaitTimeForElement, true);
            // cm.VerifyElementEnabled(false, By.Id("ctl00_MainContent_lnkSyncServers"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkSyncServers"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Select tasks pulldown.
            SelectConfigurationPulldown();

            Console.WriteLine("    * Verify Rules Enforcement.");
            // Select Rules Enforcement in Tasks pulldown and verify can edit page.
            driver.FindElement(By.LinkText("Rules Enforcement"));
            driver.FindElement(By.LinkText("Rules Enforcement")).Click();
            driver.PageSource.Contains("Rules Enforcement");
            VerifyTextAndElementPresentOnPage(WaitTimeForElement, "Rules Enforcement", driver, ref VerificationErrors, By.Id("ctl00_MainContent_cbxEnableRetroRules"));

            // Verify retro rules checkbox, run (enforce) rules button, pulldown, and save button are not enabled.
            cm.VerifyElementEnabled(false, By.Id("ctl00_MainContent_cbxEnableRetroRules"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkRunRetroRules"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.Id("ctl00_MainContent_ddlManualRun"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Select tasks pulldown. 
            SelectConfigurationPulldown();

            Console.WriteLine("    * Verify Processing Tasks.");
            // Select Processing in Tasks pulldown and verify can not edit page.
            driver.FindElement(By.LinkText("Processing"));
            driver.FindElement(By.LinkText("Processing")).Click();
            VerifyTextAndElementPresentOnPage(WaitTimeForElement, "Processing/Tasks", driver, ref VerificationErrors, By.LinkText("Select"));

            // Verify some links can be selected and their corresponding text box is not editable.
            driver.FindElement(By.LinkText("Select"));
            driver.FindElement(By.LinkText("Select")).Click();
            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_txtValue"), ref VerificationErrors, driver, WaitTimeForElement, "Text For Test", true);
            driver.FindElement(By.XPath("(//a[contains(text(),'Select')])[8]"));
            driver.FindElement(By.XPath("(//a[contains(text(),'Select')])[8]")).Click();
            cm.VerifyTextBoxEditable(false, By.Id("ctl00_MainContent_txtValue"), ref VerificationErrors, driver, WaitTimeForElement, "Text For Test", true);
            // Verify save button is gone.
            cm.VerifyElementPresentAndDisplayed(false, By.Id("ctl00_MainContent_lnkSave"), ref VerificationErrors, driver, WaitTimeForElement, true);

            Console.WriteLine("    * Verify Task Scheduling.");

            // Select tasks pulldown.
            SelectConfigurationPulldown();

            // Select Scheduling in Tasks pulldown and verify can edit tabbed pages.
            driver.FindElement(By.LinkText("Scheduling"));
            driver.FindElement(By.LinkText("Scheduling")).Click();
            VerifyTextAndElementPresentOnPage(WaitTimeForElement, "Task Scheduling", driver, ref VerificationErrors, By.LinkText("ActiveSync Update"));

            // ** STATUS TAB **

            Console.WriteLine("    --- Status Tab.");            
            
            // Select status tab, EAS update, and verify add, save, and delete selections are not visible. Verify pulldown is disabled.
            cm.WaitForElement(driver, By.LinkText("Status"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Status"));
            driver.FindElement(By.LinkText("Status")).Click();
            cm.WaitForElement(driver, By.LinkText("ActiveSync Update"), WaitTimeForElement);
            driver.FindElement(By.LinkText("ActiveSync Update"));
            driver.FindElement(By.LinkText("ActiveSync Update")).Click();
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.add-schedule-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("#ScheduleListFeature > div.listFilterActions > a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.Id("SelPriority"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Go back to main task scheduling page.
            GoBackToMainTaskSchedulingPage(WaitTimeForElement);

            // ** SCHEDULING TAB **

            Console.WriteLine("    --- Scehduling Tab.");

            // Select Scheduling tab, EAS update, and verify add, save, pulldown, and delete selections.
            cm.WaitForElement(driver, By.XPath("(//a[contains(text(),'Scheduling')])[2]"), WaitTimeForElement);
            driver.FindElement(By.XPath("(//a[contains(text(),'Scheduling')])[2]"));
            driver.FindElement(By.XPath("(//a[contains(text(),'Scheduling')])[2]")).Click();

            cm.WaitForElement(driver, By.LinkText("ActiveSync Update"), WaitTimeForElement);
            driver.FindElement(By.CssSelector("#TaskScheduleList > tbody > tr > td > a[title=\"ActiveSync Update\"]"));
            driver.FindElement(By.CssSelector("#TaskScheduleList > tbody > tr > td > a[title=\"ActiveSync Update\"]")).Click();

            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.add-schedule-large"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("#ScheduleListFeature > div.listFilterActions > a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(false, By.Id("SelPriority"), ref VerificationErrors, driver, WaitTimeForElement, true);

            // Go back to main task scheduling page.
            GoBackToMainTaskSchedulingPage(WaitTimeForElement);

            // ** HISTORY TAB **            

            Console.WriteLine("    --- History Tab.");

            // Select history tab and verify delete is not shown and al other seections (search selections) can be used.
            cm.WaitForElement(driver, By.LinkText("History"), WaitTimeForElement);
            driver.FindElement(By.LinkText("History"));
            driver.FindElement(By.LinkText("History")).Click();
            // Check two text boxes.
            cm.VerifyTextBoxEditable(true, By.Id("searchTaskHistoryStartDate"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            cm.VerifyTextBoxEditable(true, By.Id("searchTaskHistoryEndDate"), ref VerificationErrors, driver, WaitTimeForElement, "Test Text", true);
            // Check search button not enabled.
            cm.VerifyElementEnabled(true, By.XPath("//div[@id='TaskHistoryProfileListContainer']/div/div/div/button"), ref VerificationErrors, driver, WaitTimeForElement, true);
            // Check pulldowns enabled.
            cm.VerifyElementEnabled(true, By.Id("searchTaskHistoryTask"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementEnabled(true, By.Id("searchTaskHistoryStatus"), ref VerificationErrors, driver, WaitTimeForElement, true);
            // Verify delete not shown.
            cm.VerifyElementPresentAndDisplayed(false, By.CssSelector("a.delete-btn-small"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // This sets the security role for gear->tasks to show only the User Synchronization selection.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemTasksNoAccessTest_ViewOnlyUserSynchronization()
        {
            int WaitTimeForElement = 3; // Timeout for anything having a wait.

            Console.WriteLine("\nSetup security page for non-admin user to have NO access to Gear->Tasks except User Syncronization.");
            Console.WriteLine("Verify the User Syncronization selection is there and all others are not.");

            // Assuming security page is opened, set permissions for tab (GEAR->TASKS) to no access.
            // Asssume security role page is opened to ConfigAdmin->Tasks.
            // Set security to give non-admin user no access to Gear->Tasks.
            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[.='Configuration Administration']")).Click();
            cm.WaitForElement(driver, By.LinkText("Tasks"));
            driver.FindElement(By.LinkText("Tasks")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']")).Click();

            // Set selection for User Syncronization to read access.
            cm.WaitForElement(driver, By.XPath("(//input[@name='read'])[48]"));
            driver.FindElement(By.XPath("(//input[@name='read'])[48]")).Click();

            // Save security role and log out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), WaitTimeForElement);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin and verify only access to user sync.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select config pulldown.
            SelectConfigurationPulldown();

            // Verify user sync is the only selectable/visible  selection under gear->Tasks.
            // NOTE: Wait times are reduced after first call to VerifyElementPresentAndDisplayed. Once the first element  is found
            //       it's not necessary to long wait to not find the others.
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("User Synchronization"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Rules Enforcement"), ref VerificationErrors, driver, WaitTimeForElement - 2, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Processing"), ref VerificationErrors, driver, WaitTimeForElement - 2, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Scheduling"), ref VerificationErrors, driver, WaitTimeForElement - 2, true);
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // This sets the security role for gear->tasks to show only the User Synchronization selection.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemTasksNoAccessTest_ViewOnlyProcessing()
        {
            int WaitTimeForElement = 3; // Timeout for anything having a wait.

            Console.WriteLine("\nSetup security page for non-admin user to have NO access to Gear->Tasks except User Syncronization.");
            Console.WriteLine("Verify the User Syncronization selection is there and all others are not.");

            // Assuming security page is opened, set permissions for tab (GEAR->TASKS) to no access.
            // Asssume security role page is opened to ConfigAdmin->Tasks.
            // Set security to give non-admin user no access to Gear->Tasks.
            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[.='Configuration Administration']")).Click();
            cm.WaitForElement(driver, By.LinkText("Tasks"));
            driver.FindElement(By.LinkText("Tasks")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']")).Click();

            // Set selection for User Syncronization to read access.
            cm.WaitForElement(driver, By.XPath("(//input[@name='read'])[50]"));
            driver.FindElement(By.XPath("(//input[@name='read'])[50]")).Click();

            // Save security role and log out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), WaitTimeForElement);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin and verify only access to processing.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Select config pulldown.
            SelectConfigurationPulldown();

            // Verify user processing is the only selectable/visible  selection under gear->Tasks.
            // NOTE: Wait times are reduced after first call to VerifyElementPresentAndDisplayed. Once the first element  is found
            //       it's not necessary to long wait to not find the others.
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("User Synchronization"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Rules Enforcement"), ref VerificationErrors, driver, WaitTimeForElement - 2, true);
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Processing"), ref VerificationErrors, driver, WaitTimeForElement - 2, true);
            cm.VerifyElementPresentAndDisplayed(false, By.LinkText("Scheduling"), ref VerificationErrors, driver, WaitTimeForElement - 2, true);
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description:
        // This assumes the admin page is currently opened. This method selects the Configuration (Gear).
        // // /////////////////////////////////////////////////////////////////////////////////////////////////////
        void SelectConfigurationPulldown()
        {
            cm.WaitForElement(driver, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
        }

        [Test]
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify full access to the following selections found under Gear->Tasks.
        // User Sync
        // Rules Enforcement
        // Processing
        // Scheduling
        // //////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ConfigurationAdministrationSystemTasksNoAcessPulldownNotVisible()
        {
            int WaitTimeForElement = 5; // Timeout for calls to WaitForElement method.

            Console.WriteLine("\nSetup security page for non-admin user to have NO access to Gear->Tasks and access to the Security Roles selection. ");
            Console.WriteLine("Verify the Gear->Tasks pulldown is not there and Security Roles selection is there.");

            // Select permissions tab (SECURITY ROLES).
            cm.WaitForElement(driver, By.XPath("//li/a[.='Security']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//li/a[.='Security']"));
            driver.FindElement(By.XPath("//li/a[.='Security']")).Click();

            // Select tab inside permissions tab.
            cm.WaitForElement(driver, By.LinkText("Access Control"));
            driver.FindElement(By.LinkText("Access Control"));
            driver.FindElement(By.LinkText("Access Control")).Click();

            // Set access level to read.
            cm.WaitForElement(driver, By.XPath("//tr[td='Security Roles']/td/input[@name='read']"), WaitTimeForElement);
            driver.FindElement(By.XPath("//tr[td='Security Roles']/td/input[@name='read']"));
            driver.FindElement(By.XPath("//tr[td='Security Roles']/td/input[@name='read']")).Click();

            // Set permissions for tab (GEAR->TASKS) to no access.
            // Asssume security role page is opened to ConfigAdmin->Tasks.
            // Set security to give non-admin user no access to Gear->Tasks.
            driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
            cm.WaitForElement(driver, By.XPath("//li/a[contains(text(),'Configuration Administration')]"));
            driver.FindElement(By.XPath("//li/a[.='Configuration Administration']")).Click();
            cm.WaitForElement(driver, By.LinkText("Tasks"));
            driver.FindElement(By.LinkText("Tasks")).Click();
            cm.WaitForElement(driver, By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']"));
            driver.FindElement(By.XPath("//tr[th='Tasks']/th/div/input[@data-bind='visible: $root.enablePermissionSettings(), checked: NoAccessAll']")).Click();

            // Save security role and log out.
            cm.SaveSecurityRole(driver);
            cm.WaitForElement(driver, By.LinkText("Security"), WaitTimeForElement);
            cm.WaitForElement(driver, By.LinkText("Sign Out"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Sign Out")).Click();

            // Login as non-admin and verify no access to tasks (gear->Tasks) pulldown and verify access to the Activity pulldown.
            cm.LogIntoMdm(driver, regularUser, password, url);

            // Verify security activity pulldown is found and tasks pulldown is not.
            cm.VerifyElementPresentAndDisplayed(true, By.LinkText("Security"), ref VerificationErrors, driver, WaitTimeForElement, true);
            cm.VerifyElementPresentAndDisplayed(false, By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"), ref VerificationErrors, driver, WaitTimeForElement, true);
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description:
        // This assumes one of the tabbed pages in Task Scheduling is selected. This sends user back 
        // to Task Scheduling page.
        // // /////////////////////////////////////////////////////////////////////////////////////////////////////
        void GoBackToMainTaskSchedulingPage(int WaitTimeForElement)
        {
            cm.WaitForElement(driver, By.LinkText("Task Scheduling"), WaitTimeForElement);
            driver.FindElement(By.LinkText("Task Scheduling"));
            driver.FindElement(By.LinkText("Task Scheduling")).Click();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Description: This is used to verify text is present when a page is opened; the page is assumed to have just been opened.
        // It will wait for an element exists before checking for the text, if an element parameter is sent. The wait time is a 
        // parameter. If no element is sent then it uses the wait time sent in to do a thread wait and then make the check 
        // for text present.
        //
        // CAUTION: The method called in this method, PageSource.Contains, searches the web page source code. 
        // It is possible to search for the wrong text and still have method PageSource.Contains pass. It is 
        // recommended to also look for an element along with the text search.
        //
        // Parameters:
        // waitTimeForElement - Time to use for waits.
        // textToFind - Text to find on page that has been opened.
        // driver- IWebDriver.
        // verificationErrors - String builder to add erros to.
        // elementToBePresent  - Element to find if before searching for page text.
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void VerifyTextAndElementPresentOnPage(int waitTimeForElement, string textToFind, IWebDriver driver, ref StringBuilder verificationErrors, By elementToBePresent = null)
        {
            Console.WriteLine("    VerifyTextIsPresentOnPage");
            if (elementToBePresent == null) // An element to detect has not been sent.
            {
                Thread.Sleep(waitTimeForElement * 1000);
                if (!driver.PageSource.Contains(textToFind))
                {
                    Console.WriteLine("    !Fail in VerifyTextIsPresentOnPage. Failed to find expected text " + textToFind + " at page open.");
                    verificationErrors.Append("Failed to find " + textToFind + " at page open. Method is VerifyTextIsPresentOnPage.");
                }
            }
            
            if (!driver.PageSource.Contains(textToFind))
            {
                Console.WriteLine("    !Fail in VerifyTextIsPresentOnPage. Failed to find text " + textToFind + " at page open.");                
                verificationErrors.Append("Failed to find expected text " + textToFind + " at page open. Method is VerifyTextIsPresentOnPage.");
            }
        }
    }
}
