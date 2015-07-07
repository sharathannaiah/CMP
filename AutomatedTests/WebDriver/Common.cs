using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Rally.RestApi;
using Rally.RestApi.Response;

namespace AutomatedTests.WebDriver
{
    //This class is about general and common methods for all classes. The class is static so you don't need to create an instance to call it.
    //Also this class allow to split the common methods and make the code reliable.
    static class Common
    {

        //// NAVIGATION //////
        //// ********************* /////
        public static void GoToMenu(IWebDriver driver, string value)
        {
            string menu = System.Configuration.ConfigurationManager.AppSettings["menu"];
            string method = System.Configuration.ConfigurationManager.AppSettings["method"];
            string type = System.Configuration.ConfigurationManager.AppSettings["type"];            
            IWebElement element = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(menu + method + value + type);
            //Console.WriteLine(menu + method + value + type);
            //how to navigate the menu using javascript through c# : $viewmodel.navigate('/MDM/Admin/Navigation/NewNavigateToPage', { method: \"post\", webpage: webpage, type: null})
            //                                                       $viewmodel.navigate('/MDM/Admin/Navigation/NewNavigateToPage'), { method: "post", webpage: 1063, type: type })           
        }

        //in some point of time, MDM changed his code of Javascript to go throught the menus, don't delete this method. Jose
        public static void GoToMenu(IWebDriver driver, string value, string type)
        {
            string menu = System.Configuration.ConfigurationManager.AppSettings["menu"];
            string method = System.Configuration.ConfigurationManager.AppSettings["method"];
            string typeattr = ", type: ";
            IWebElement element = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(menu + method + value + typeattr + type + "})");

        }
        //// DEVICES - USERS //////
        //// ********************* /////
        public static void AddDevice(IWebDriver driver, string platform, string device, string password)
        {            
            try
            {                
                driver.FindElement(By.XPath("//*[@automationname='tangoeBtnAddDevice']")).Click();
                //driver.FindElement(By.CssSelector(".tangoeGrid-fullRowSelect.tangoeGrid-activeRow"));
                Console.WriteLine("ADD DEVICE BUTTON CLICKED!!!");
                WaitForElement(driver, By.Id("Platform"), 30);
                new SelectElement(driver.FindElement(By.Id("Platform"))).SelectByText(platform);
                new SelectElement(driver.FindElement(By.Id("Vendor"))).SelectByText("AT&T");
                new SelectElement(driver.FindElement(By.Id("mergeddevice"))).SelectByText(device);
                //"mergeddevice"
                WaitForElement(driver, By.Id("EAPassword"), 10);
                driver.FindElement(By.Id("EAPassword")).SendKeys(password);
                driver.FindElement(By.Id("EAPasswordConfirm")).SendKeys(password);
                Console.WriteLine("FIELDS CAN BE EDITED!!!");
                driver.FindElement(By.XPath(".//*[@id='setCLForm']/div[4]/button[1]")).Click();
                Console.WriteLine("SAVE BUTTON WAS CLICKED!!!");
                WaitForElement(driver, By.CssSelector(".tangoeGrid-fullRowSelect.tangoeGrid-activeRow"), 20);
                              
            }
            catch (TimeoutException e)
            {                
                System.Console.WriteLine("TimeoutException: " + e.Message);
                Assert.Fail(e.Message); 
            }
            catch (NoSuchElementException e)
            {
                System.Console.WriteLine("NoSuchElementException: " + e.Message);
                Assert.Fail(e.Message);                
                //System.Console.WriteLine("TimeoutException: " + e.Message);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("unhandled exception: " + e.Message);
                Assert.Fail(e.Message);
            }        
        }

        public static void AddGMMDevice(IWebDriver driver, string platform, string device)
        {
            try
            {
                driver.FindElement(By.XPath("//*[@automationname='tangoeBtnAddDevice']")).Click();
                //driver.FindElement(By.CssSelector(".tangoeGrid-fullRowSelect.tangoeGrid-activeRow"));
                Console.WriteLine("ADD DEVICE BUTTON CLICKED!!!");
                WaitForElement(driver, By.Id("Platform"), 30);
                new SelectElement(driver.FindElement(By.Id("Platform"))).SelectByText(platform);
                new SelectElement(driver.FindElement(By.Id("Vendor"))).SelectByText("AT&T");
                new SelectElement(driver.FindElement(By.Id("mergeddevice"))).SelectByText(device);
                //"mergeddevice"               
                Console.WriteLine("FIELDS CAN BE EDITED!!!");
                WaitForElement(driver, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), 30);
                driver.FindElement(By.CssSelector("button.tangoeBtn.tangoeBtn-primary")).Click();
                Console.WriteLine("SAVE BUTTON WAS CLICKED!!!");
                WaitForElement(driver, By.CssSelector(".tangoeGrid-fullRowSelect.tangoeGrid-activeRow"), 20);

            }
            catch (TimeoutException e)
            {
                System.Console.WriteLine("TimeoutException: " + e.Message);
                Assert.Fail(e.Message);
            }
            catch (NoSuchElementException e)
            {
                System.Console.WriteLine("NoSuchElementException: " + e.Message);
                Assert.Fail(e.Message);
                //System.Console.WriteLine("TimeoutException: " + e.Message);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("unhandled exception: " + e.Message);
                Assert.Fail(e.Message);
            }
        }

        public static void AddUser(IWebDriver driver, string regularUserLastName, string regularUser)
        {            
            //add user
            string user = regularUser.Substring(1, regularUser.Length - 1);
            WaitForElement(driver, By.ClassName("import-user-large"), 30);           
            driver.FindElement(By.ClassName("import-user-large")).Click();
            // send "a" letter to add user
            WaitForElement(driver, By.XPath(".//*[@id='lastNameAddUserSearchText']"), 30);
            driver.FindElement(By.XPath(".//*[@id='lastNameAddUserSearchText']")).SendKeys(user);
            //search
            driver.FindElement(By.XPath(".//*[@id='addUserListFeature']/div[2]/div[1]/div/form/button[1]")).Click();
            //select
            WaitForElement(driver, By.ClassName("users"), 30);
            //add
            //driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
        }

        public static void SetRegularUser(IWebDriver driver, string regularUserLastName, string regularUser)
        {            
            string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
            //Boolean present;
            Console.WriteLine(value);
            GoToMenu(driver, value);            
            WaitForElement(driver, By.Id("ContinuousElement"), 30);
            //this check if the user is not added to the user list.
            //Console.WriteLine(driver.FindElements(By.XPath("//a[.='" + regularUserLastName + "']")).Count.ToString());
            //present = driver.FindElements(By.XPath("//a[.='" + regularUserLastName + "']")).Count > 0;
            //Console.WriteLine(present.ToString());
            //if (!present)            {
                Console.WriteLine(regularUser.Substring(1, regularUser.Length - 1));
                AddUser(driver, regularUserLastName, regularUser);
            driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
            WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);            
        }
        // it's very common repeat the following code to go to the user profile, so i put the code into a method to reduce the numbers of lines in a test.
        public static void GoToUserProfile(IWebDriver driver)
        {
            string regularUserLastName = System.Configuration.ConfigurationManager.AppSettings["regularUserLastName"];
            string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
            GoToMenu(driver, value);            
            WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
            driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
            WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
        }

        public static void WaitForElement(IWebDriver driver, By by, int timeout)
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
        //// SECURITY ROLE SECTION //////
        //// ********************* /////
        public static void StartNewSecurityRoleWithNameAndQuery(IWebDriver driver, string roleName, string roleAssignment, string platform)
        // Click the Add Security Role icon, fill in the name and LDAP syntax using the parameters.
        {           
            GoToMenu(driver, driver.FindElement(By.XPath("//a[.='Security Roles']")).GetAttribute("webpage").ToString());            
            WaitForElement(driver, By.ClassName("add-security-large"), 30);
            //WaitForElement(driver, By.CssSelector("a.add-security-large"));
            driver.FindElement(By.ClassName("add-security-large")).Click();
            WaitForElement(driver, By.Id("roleNameTextBox"),30);
            System.Threading.Thread.Sleep(3000);
        //driver.Navigate().Refresh();
            driver.FindElement(By.Id("roleNameTextBox")).Clear();
            driver.FindElement(By.Id("roleNameTextBox")).SendKeys(roleName);
            driver.FindElement(By.XPath("//input[@name='isAdminProfileChkBx']")).Click();
            driver.FindElement(By.XPath("//div[@id='LdapMDMGroupSection']/div[2]/div/button")).Click();
           // driver.FindElement(By.Id("undefined_txtLdapFreeform")).Clear();
          //  driver.FindElement(By.Id("undefined_txtLdapFreeform")).SendKeys("sn=" + roleAssignment.Substring(1, roleAssignment.Length - 1));
            driver.FindElement(By.Id("roleAssignmentTextBox_txtLdapFreeform")).Clear();//Changed id for the script 
            driver.FindElement(By.Id("roleAssignmentTextBox_txtLdapFreeform")).SendKeys("sn=" + roleAssignment.Substring(1, roleAssignment.Length - 1));


            driver.FindElement(By.XPath("//div[@id='securityGeneralInfoControlContainer']/div[3]/button")).Click();            
          //  EnableDefaultPlatformRole(driver, platform);            
        }

        public static void DeleteSecurityRole(IWebDriver driver, string roleName)
        // Click the checkbox next to the name from the parameter.  Click the delete icon.  Click the OK button in the confirmation dialog.
        {
            try
            {
                Console.WriteLine("Entering Delete Security Role method...");
                GoToMenu(driver, driver.FindElement(By.XPath("//a[.='Security Roles']")).GetAttribute("webpage").ToString());                
                //WaitForElement(driver, By.XPath(".//*[@id='ViewPort']/header/ul/li/div/a"), 30);   
                WaitForElement(driver, By.CssSelector(".add-security-large"), 20);
                while (driver.FindElement(By.TagName("body")).Text.Contains(roleName))
                {
                    driver.FindElement(By.XPath("//tr[td='" + roleName + "']/td/input[@type='checkbox']")).Click();
                    driver.FindElement(By.CssSelector("a.delete-btn-small")).Click();
                    //driver.FindElement(By.XPath("//button[@type='button']")).Click();
                    driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();// Changed locator
                    System.Threading.Thread.Sleep(4000);

                    /*wait.Until<Boolean>((d) =>
                    {
                        return d.FindElement(By.ClassName("ui-notificationbar-message")).Equals("Selected Roles have been deleted."); 
                    });*/
                    Console.WriteLine("Sec. Role deleted!!");
                    //WaitForElement(driver, By.ClassName("ui-notificationbar-message")).Equals("Selected Roles have been deleted."), 30);   
                }

            }
            catch (TimeoutException e)
            {
                //driver.Navigate().Refresh();
                System.Console.WriteLine("TimeoutException: " + e.Message);
                //Assert.Fail(e.Message);
            }
            catch (NoSuchElementException e)
            {
                System.Console.WriteLine("NoSuchElementException: " + e.Message);
                Assert.Fail(e.Message);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("unhandled exception: " + e.Message);
                Assert.Fail(e.Message);

            }

        }
        // I add these method in order to show some options when the test do a click under "device actions" button on the user profile, just to make some sense to the test.
        public static void EnableDefaultPlatformRole(IWebDriver driver, string platform)
        {
            switch (platform)
            {
                case "BlackBerry":
                    driver.FindElement(By.LinkText("BlackBerry Device Actions")).Click();
                    //WaitForElement(driver, By.XPath(".//*[@automationname='grant']"), 10);
                    driver.FindElement(By.XPath("//tr[td='Reset Enterprise Activation Password']/td/input[@name='grant']")).Click();
                    //driver.FindElement(By.XPath(".//*[@automationname='grant']"));
                    break;

                case "GoodMobile":
                    driver.FindElement(By.LinkText("Good Mobile Messaging Device Actions")).Click();
                    driver.FindElement(By.XPath("(//input[@type='checkbox'])[66]")).Click();
                    break;

                case "iOS":
                    driver.FindElement(By.LinkText("iOS Device Actions")).Click();
                    driver.FindElement(By.XPath("(//input[@type='checkbox'])[72]")).Click();
                    break;

                case "Android":
                    driver.FindElement(By.LinkText("Android Device Actions")).Click();
                    driver.FindElement(By.XPath("(//input[@type='checkbox'])[48]")).Click();
                    break;

            }

        }
        //// WIRELESS SERVICES //////
        //// ********************* /////
        // I add the last parameter in order to select the specific platform and wireless, now we got the automationname attribute ;)
        public static void EnableWirelessServices(IWebDriver driver, string wirelessService, string clientPlatform)
        {            
            string value = driver.FindElement(By.XPath(".//*[@id='mainNav']/ul/li[6]/table/tbody/tr/td[1]/ul/li[1]/a")).GetAttribute("webpage").ToString();
            //new Login().GoToMenu(driver, value);            
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]"));
            driver.FindElement(By.XPath("//a[img[@alt=\"Configuration/Administration\"]]")).Click();
            WaitForElement(driver, By.LinkText("MDM Server"), 30);
            driver.FindElement(By.LinkText("MDM Server")).Click();
            WaitForElement(driver, By.Id("brandedLogo"), 30);            
            //Wireless    
            WirelessServices(driver, wirelessService);
            ClientPlatform(driver, clientPlatform);
            //Save
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            WaitForElement(driver, By.XPath("//a[.='Domains']"), 30);            
            Console.WriteLine("Wireless Services set to enabled were saved");
        }
        //used by EnableWirelessServices
        private static void WirelessServices(IWebDriver driver, string wirelessService)
        {
            switch (wirelessService)
            {
                case "GoodMobile":
                    driver.FindElement(By.XPath("//input[@automationname='Good Mobile Messaging']")).Click();
                    break;
                
                case "BlackBerry":
                    driver.FindElement(By.XPath("//input[@automationname='BlackBerry Enterprise Server']")).Click();
                    break;

                case "ActiveSync":
                    driver.FindElement(By.XPath("//input[@automationname='Microsoft Active Sync']")).Click();
                    break;                

                case "NoMail":
                    driver.FindElement(By.XPath("//input[@automationname='Devices without mail integration']")).Click();
                    break;

                case "Divide":
                    driver.FindElement(By.XPath("//input[@automationname='Enterproid Divide']")).Click();
                    break;

                default:
                    break;
            }
        }
        //used by EnableWirelessServices
        private static void ClientPlatform(IWebDriver driver, string clientPlatform)
        {
            switch (clientPlatform)
            {
                case "Android":
                    driver.FindElement(By.XPath("//input[@automationname='Android']")).Click();
                    break;

                case "BlackBerry":
                    driver.FindElement(By.XPath("//input[@automationname='BlackBerry']")).Click();
                    break;                             

                case "WinPhone":
                    driver.FindElement(By.XPath("//input[@automationname='Windows Phone']")).Click();
                    break;

                case "WinMo":
                    driver.FindElement(By.XPath("//input[@automationname='Windows Mobile']")).Click();
                    break;

                case "Apple":
                    driver.FindElement(By.XPath("//input[@automationname='Apple iOS']")).Click();
                    break;

                default:
                    break;
            }
        }

        public static bool IsElementVisible(IWebDriver driver, By by)
        {
            IWebElement element = null;
            try
            {
                // Is the element on the HTML code?
                 element = driver.FindElement(by);
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            // the element is displayed & enabled for the user?
            return element.Displayed && element.Enabled;
        }

        #region Rally 
        //// RALLY SECTION //////
        //// ********************* /////
        //Initializes the thread that will create a test case
        public static void CreateTestCase(string testcase)
        {
            Console.WriteLine("CreateTestCase method");
            Thread t = new Thread(() => CreateTestCaseWork(testcase));
            t.Start();
            Console.WriteLine("Starting thread");
        }

        //Creates the test case
        public static void CreateTestCaseWork(string testcase)
        {
            Console.WriteLine("CreateTestCaseWork method");
            string rallyUser = System.Configuration.ConfigurationManager.AppSettings["rallyUser"];
            string rallyPassword = System.Configuration.ConfigurationManager.AppSettings["rallyPassword"];
            string workspaceRef = "https://rally1.rallydev.com/slm/webservice/1.40/workspace/144782102.js";
            //Log into rally
            RallyRestApi restApi = new RallyRestApi(rallyUser, rallyPassword, "https://rally1.rallydev.com", "1.40");

            try
            {
                //Search to see if this test case already exists, if it does, we don't want to create another one so do nothing

                Request request = new Request("testcase");
                request.Fetch = new List<string>
                {
                    "Name",
                    "ObjectID",
                };

                request.Query = new Query("Name", Query.Operator.Equals, testcase);
                QueryResult queryResult = restApi.Query(request);

                var result = queryResult.Results.First();
                var objectID = result["ObjectID"];
                Console.WriteLine("Found the test case: " + result["Name"] + " " + result["ObjectID"]);
            }

            catch (InvalidOperationException e)
            {
                //If the test case doesn't exist, then we need to create it
                DynamicJsonObject toCreate = new DynamicJsonObject();
                toCreate["Name"] = testcase;
                toCreate["Method"] = "Automated";
                CreateResult createResult = restApi.Create(workspaceRef, "testcase", toCreate);

                Console.WriteLine("Created testcase: " + testcase);

            }
        }

        //Initializes the thread that will create a test case result
        public static void CreateTestCaseResult(string testcase, string result)
        {
            Console.WriteLine("CreateTestCaseResult");
            Thread t = new Thread(() => CreateTestCaseResultWork(testcase, result));
            t.Start();
            Console.WriteLine("Starting thread");
        }

        //Creates the test case result
        public static void CreateTestCaseResultWork(string testcase, string result)
        {
            string rallyUser = System.Configuration.ConfigurationManager.AppSettings["rallyUser"];
            string rallyPassword = System.Configuration.ConfigurationManager.AppSettings["rallyPassword"];
            string build = System.Configuration.ConfigurationManager.AppSettings["build"];
            string workspaceRef = "https://rally1.rallydev.com/slm/webservice/1.40/workspace/144782102.js";
            //Log into rally
            RallyRestApi restApi = new RallyRestApi(rallyUser, rallyPassword, "https://rally1.rallydev.com", "1.40");

            try
            {
                //Search to see if this test case exists

                Request request = new Request("testcase");
                request.Fetch = new List<string>
                {
                    "Name",
                    "ObjectID",
                };

                request.Query = new Query("Name", Query.Operator.Equals, testcase);
                QueryResult queryResult = restApi.Query(request);

                var result2 = queryResult.Results.First();
                var objectID = result2["ObjectID"];
                Console.WriteLine("Found the test case: " + result2["Name"] + " " + result2["ObjectID"]);

                //Create the test case result object
                DynamicJsonObject newTCResult = new DynamicJsonObject();
                newTCResult["Date"] = DateTime.UtcNow.ToString("o");
                newTCResult["TestCase"] = objectID;
                newTCResult["Build"] = build;
                newTCResult["Verdict"] = result;

                CreateResult cr = restApi.Create(workspaceRef, "TestCaseResult", newTCResult);
                Console.WriteLine("Created test case result");
            }

            catch (InvalidOperationException e)
            {
                //If the test case doesn't exist, then we need to create it
                Console.WriteLine("Cannot find the test case: " + testcase);


            }
        }

        //Initializes the thread that will create a test case result
        public static void CreateTestCaseResult(string testcase, string result, string notes)
        {
            Console.WriteLine("CreateTestCaseResult");
            Thread t = new Thread(() => CreateTestCaseResultWork(testcase, result, notes));
            t.Start();
            Console.WriteLine("Starting thread");
        }

        public static void CreateTestCaseResultWork(string testcase, string result, string notes)
        {
            string rallyUser = System.Configuration.ConfigurationManager.AppSettings["rallyUser"];
            string rallyPassword = System.Configuration.ConfigurationManager.AppSettings["rallyPassword"];
            string build = System.Configuration.ConfigurationManager.AppSettings["build"];
            string workspaceRef = "https://rally1.rallydev.com/slm/webservice/1.40/workspace/144782102.js";
            //Log into rally
            RallyRestApi restApi = new RallyRestApi(rallyUser, rallyPassword, "https://rally1.rallydev.com", "1.40");

            try
            {
                //Search to see if this test case exists

                Request request = new Request("testcase");
                request.Fetch = new List<string>
                {
                    "Name",
                    "ObjectID",
                };

                request.Query = new Query("Name", Query.Operator.Equals, testcase);
                QueryResult queryResult = restApi.Query(request);

                var result2 = queryResult.Results.First();
                var objectID = result2["ObjectID"];
                Console.WriteLine("Found the test case: " + result2["Name"] + " " + result2["ObjectID"]);

                //Create the test case result object
                DynamicJsonObject newTCResult = new DynamicJsonObject();
                newTCResult["Date"] = DateTime.UtcNow.ToString("o");
                newTCResult["TestCase"] = objectID;
                newTCResult["Notes"] = notes;
                newTCResult["Build"] = build;
                newTCResult["Verdict"] = result;

                CreateResult cr = restApi.Create(workspaceRef, "TestCaseResult", newTCResult);
                Console.WriteLine("Created test case result");
            }

            catch (InvalidOperationException e)
            {
                //If the test case doesn't exist, then we need to create it
                Console.WriteLine("Cannot find the test case: " + testcase);


            }
        }
        #endregion
    }
}