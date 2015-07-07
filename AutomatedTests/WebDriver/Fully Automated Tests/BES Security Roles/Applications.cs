using System;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.BES_Security_Roles
{

    public class Applications : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting new sec role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, BESPlatform);
        }

        /// <summary>
        ///  SECURITY ROLES ACCESS FOR APPLICATION PUSH
        /// </summary>
        /// 

        [Test]
        public void A_Before_Run()
        {
            string download = System.Configuration.ConfigurationManager.AppSettings["BBApplication"];
            WebClient webClient = new WebClient();
            webClient.DownloadFile(download, @"c:\JConverter2.cod");
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            //Common.WaitForElement(driver, By.XPath("//tr[td='BlackBerry']"), 10);
            driver.FindElement(By.XPath("(//input[@name='full'])[32]")).Click();
            //driver.FindElement(By.XPath("//tr[td='BlackBerry']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("(//input[@name='full'])[35]")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            // CREATING APPLICATION
            string value = driver.FindElement(By.XPath("//a[.='BlackBerry']")).GetAttribute("webpage").ToString();
            Common.GoToMenu(driver, value);
            driver.FindElement(By.LinkText("BlackBerry")).Click();
            Common.WaitForElement(driver, By.CssSelector("a.add-application-btn-large"), 10);
            driver.FindElement(By.CssSelector("a.add-application-btn-large")).Click();
            // type | id=ApplicationNameText | BES Application
            driver.FindElement(By.Id("ApplicationNameText")).Clear();
            driver.FindElement(By.Id("ApplicationNameText")).SendKeys("BES Application");
            // type | id=VersionText | 1.0
            driver.FindElement(By.Id("VersionText")).Clear();
            driver.FindElement(By.Id("VersionText")).SendKeys("1.0");
            // type | id=DescriptionText | some bes application
            driver.FindElement(By.Id("DescriptionText")).Clear();
            driver.FindElement(By.Id("DescriptionText")).SendKeys("some bes application");
            // click | css=button.tangoeBtn.tangoeBtn-primary | 
            driver.FindElement(By.CssSelector("button.tangoeBtn.tangoeBtn-primary")).Click();
            // click | link=Upload new File | 
            driver.FindElement(By.LinkText("Upload new File")).Click();
            // type | id=fileUpload | C:\Users\jgrimalt\Documents\DSC01159.JPG
            driver.FindElement(By.Id("fileUpload")).Clear();
            driver.FindElement(By.Id("fileUpload")).SendKeys("C:\\JConverter2.cod");
            // click | id=fakeAjaxUploadButton | 
            driver.FindElement(By.Id("fakeAjaxUploadButton")).Click();
            // click | id=ajaxUploadButton | 
            driver.FindElement(By.Id("ajaxUploadButton")).Click();
        }

        [Test]
        public void PUSH_FullAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            //Common.WaitForElement(driver, By.XPath("//tr[td='BlackBerry']"), 10);
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[2]/input")).Click();
            //driver.FindElement(By.XPath("//tr[td='BlackBerry']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='full']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='Application Push/Install']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                // click on add button to access the app push role page
                Common.WaitForElement(driver, By.ClassName("add-rule-btn-large"), 20);
                driver.FindElement(By.ClassName("add-rule-btn-large")).Click();
                Common.WaitForElement(driver, By.Id("ddlClientPlatform"), 30);                
                Console.WriteLine("Access to Application Push!");
                //verify that some elements are editable when u had already allowed "full access"
                Common.WaitForElement(driver, By.XPath("//*[.='Rule']"), 20);
                Assert.AreEqual("Rule", driver.FindElement(By.XPath("//*[.='Rule']")).Text);
                driver.FindElement(By.Id("txtDescript")).SendKeys("Test rule");
                new SelectElement(driver.FindElement(By.Id("ddlClientPlatform"))).SelectByText(BESPlatform);
                new SelectElement(driver.FindElement(By.Id("ddlResult"))).SelectByText(BESApplicationName + ": 1.0");
                driver.FindElement(By.Id("cbApplyToAll")).Click();
                driver.FindElement(By.Id("undefined_txtLdapFreeform")).SendKeys("sn=" + regularUser);
                driver.FindElement(By.Id("cbxBesServerStats")).Click();
                Console.WriteLine("filling the criteria's fields with valid attributes for BES...");
                new SelectElement(driver.FindElement(By.Id("ddlAttributes"))).SelectByText("BES Server");
                new SelectElement(driver.FindElement(By.Id("ddlOperators"))).SelectByText("Contains");
                driver.FindElement(By.Id("txtSmartphoneCriteriaValue")).SendKeys("6");
                //use of automationname attribute to add a criteria
                driver.FindElement(By.XPath("//*[@automationname='addDeviceCriteria']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='tangoeBtnSave']"), 10);
                driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
                //driver.FindElement(By.ClassName("add-btn-small")).Click();
                Console.WriteLine("Application Push creation is allowed for full access");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void PUSH_ReadAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='BlackBerry']"), 10);
            Common.IsElementVisible(driver, By.XPath("//tr[td='BlackBerry']"));
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[3]/input")).Click();
            //driver.FindElement(By.XPath("//tr[td='BlackBerry']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='read']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='Application Push/Install']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.ClassName("tangoeBtn"), 15);
                driver.FindElement(By.Id("SingleUserInfoText")).SendKeys(regularUser);                
                //verify that some elements are editable when u had already allowed "full access"
                
                if (Common.IsElementVisible(driver, By.ClassName("add-rule-btn-large")))
                    Assert.Fail("The add rule button element is available");
                Console.WriteLine("Application Push is configured for read access");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [Test]
        public void PUSH_DenyAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='BlackBerry']"), 10);
            Common.IsElementVisible(driver, By.XPath("//tr[td='BlackBerry']"));
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[3]/input")).Click();
            //driver.FindElement(By.XPath("//tr[td='BlackBerry']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='none']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                driver.FindElement(By.XPath("//a[.='Application Push/Install']")).GetAttribute("webpage").ToString();
               
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Application Push is configured for DENY access");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        ///////// SECURITY ROLES FOR APPLICATION REMOVE

        [Test]
        public void REMOVE_FullAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            //Common.WaitForElement(driver, By.XPath("//tr[td='BlackBerry']"), 10);
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[2]/input")).Click();
            //driver.FindElement(By.XPath("//tr[td='BlackBerry']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='full']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='Application Remove/Uninstall']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                // click on add button to access the app push role page
                Common.WaitForElement(driver, By.ClassName("add-rule-btn-large"), 20);
                driver.FindElement(By.ClassName("add-rule-btn-large")).Click();
                Common.WaitForElement(driver, By.Id("ddlClientPlatform"), 30);
                Console.WriteLine("Access to Application Push!");
                //verify that some elements are editable when u had already allowed "full access"
                Common.WaitForElement(driver, By.XPath("//*[.='Rule']"), 20);
                Assert.AreEqual("Rule", driver.FindElement(By.XPath("//*[.='Rule']")).Text);
                driver.FindElement(By.Id("txtDescript")).SendKeys("Test rule");
                new SelectElement(driver.FindElement(By.Id("ddlClientPlatform"))).SelectByText(BESPlatform);
                driver.FindElement(By.Id("cbApplyToAll")).Click();
                driver.FindElement(By.Id("undefined_txtLdapFreeform")).SendKeys("sn=" + regularUser);
                driver.FindElement(By.Id("cbxBesServerStats")).Click();
                Console.WriteLine("filling the criteria's fields with valid attributes for BES...");
                new SelectElement(driver.FindElement(By.Id("ddlAttributes"))).SelectByText("BES Server");
                new SelectElement(driver.FindElement(By.Id("ddlOperators"))).SelectByText("Contains");
                driver.FindElement(By.Id("txtSmartphoneCriteriaValue")).SendKeys("6");
                driver.FindElement(By.XPath("//*[@automationname='addDeviceCriteria']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='tangoeBtnSave']"), 10);
                driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
                //driver.FindElement(By.ClassName("add-btn-small")).Click();
                Console.WriteLine("Application Remove creation is allowed for full access");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void REMOVE_ReadAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='BlackBerry']"), 10);
            Common.IsElementVisible(driver, By.XPath("//tr[td='BlackBerry']"));
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[3]/input")).Click();
            //driver.FindElement(By.XPath("//tr[td='BlackBerry']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='read']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='Application Remove/Uninstall']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.ClassName("tangoeBtn"), 15);
                driver.FindElement(By.Id("SingleUserInfoText")).SendKeys(regularUser);
                //verify that some elements are editable when u had already allowed "full access"

                if (Common.IsElementVisible(driver, By.ClassName("add-rule-btn-large")))
                    Assert.Fail("The add rule button element is available");
                Console.WriteLine("Application Remove is configured for read access");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void REMOVE_DenyAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='BlackBerry']"), 10);
            Common.IsElementVisible(driver, By.XPath("//tr[td='BlackBerry']"));
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[3]/input")).Click();
            //driver.FindElement(By.XPath("//tr[td='BlackBerry']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='none']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                driver.FindElement(By.XPath("//a[.='Application Remove/Uninstall']")).GetAttribute("webpage").ToString();

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Application Remove is configured for DENY access");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    
        
        ///////  SECURITY ROLES FOR PROFILE APP

        [Test]
        public void Profile_FullAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            //AUTOMATION ATTRIBUTE IS REQUIRED
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[2]/input")).Click();            
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            //Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {                
                string value = driver.FindElement(By.XPath("//a[.='BlackBerry']")).GetAttribute("webpage").ToString();
                string valuetype = driver.FindElement(By.XPath("//a[.='BlackBerry']")).GetAttribute("type").ToString();
                //IWebElement element = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(menu + method + value + ", type: 7})");                
                Common.GoToMenu(driver, value, valuetype);
                // click on add button to access the app push role page
                Common.WaitForElement(driver, By.ClassName("delete-btn-small"), 20);
                driver.FindElement(By.ClassName("add-application-btn-large")).Click();    //.add-application-btn-large
                Common.WaitForElement(driver, By.Id("ApplicationNameText"), 30);
                Common.WaitForElement(driver, By.Id("VersionText"), 25);
                Console.WriteLine("Access to Application Push!");
                //verify that some elements are editable when u had already allowed "full access"                
                driver.FindElement(By.Id("ApplicationNameText")).SendKeys("Tangoe app");
                driver.FindElement(By.Id("VersionText")).SendKeys("1.0");
                driver.FindElement(By.Id("cbxRestartDevice")).Click();
                driver.FindElement(By.Id("DescriptionText")).SendKeys(BESPlatform + " App Test");
                /// AUTOMATION ATTRIBUTE REQUIRED FOR BUTTON SAVE
                //*[@id='BlackBerryAppForm']/div/input[@class='tangoeBtn tangoeBtn-primary']
                //driver.FindElement(By.ClassName("add-btn-small")).Click(); .tangoeBtn.tangoeBtn-primary
                Console.WriteLine("Application Remove creation is allowed for full access");
                //Assert.AreEqual("Black Berry application saved succesfully", driver.FindElement(By.CssSelector("ui-notificationbar-message")));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        [Test]
        public void Profile_ReadAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            //AUTOMATION ATTRIBUTE IS REQUIRED
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[3]/input")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            //Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='BlackBerry']")).GetAttribute("webpage").ToString();
                string valuetype = driver.FindElement(By.XPath("//a[.='BlackBerry']")).GetAttribute("type").ToString();
                //IWebElement element = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(menu + method + value + ", type: 7})");                
                Common.GoToMenu(driver, value, valuetype);
                // click on add button to access the app push role page
                Common.WaitForElement(driver, By.XPath(".//*[@id='ContinuousElement']"), 20);
                driver.FindElement(By.XPath(".//*[@id='ApplicationList']/tbody/tr/td[1]/a")).Click();
                Common.WaitForElement(driver, By.XPath(".//*[@id='ContinuousElement']"), 20);
                Common.WaitForElement(driver, By.XPath(".//*[@id='ApplicationVersionsList']/tbody/tr/td[1]/a"), 20);
                driver.FindElement(By.XPath(".//*[@id='ApplicationVersionsList']/tbody/tr/td[1]/a")).Click();
                Common.WaitForElement(driver, By.Id("ApplicationNameText"), 30);
                Common.WaitForElement(driver, By.Id("VersionText"), 25);
                Console.WriteLine("Access to Application Push!");
                //verify that some elements are editable when u had already allowed "full access"                
                driver.FindElement(By.Id("ApplicationNameText")).SendKeys("Tangoe app");
                driver.FindElement(By.Id("VersionText")).SendKeys("1.0");
                driver.FindElement(By.Id("cbxRestartDevice")).Click();
                driver.FindElement(By.Id("DescriptionText")).SendKeys(BESPlatform + " App Test");
                /// AUTOMATION ATTRIBUTE REQUIRED FOR BUTTON SAVE
                //*[@id='BlackBerryAppForm']/div/input[@class='tangoeBtn tangoeBtn-primary']
                //driver.FindElement(By.ClassName("add-btn-small")).Click(); .tangoeBtn.tangoeBtn-primary
                Console.WriteLine("Application Remove creation is allowed for full access");
                Assert.AreEqual("BlackBerry Application Details", driver.FindElement(By.CssSelector(".viewportTitle.featureTitle")).Text);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                Console.WriteLine("");
            }
        }

        [Test]
        public void Profile_DenyAccessApplication()
        {
            driver.FindElement(By.XPath("//*[@automationname='Applications']")).Click();
            driver.FindElement(By.LinkText("Profiles")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='BlackBerry']"), 10);
            Common.IsElementVisible(driver, By.XPath("//tr[td='BlackBerry']"));
            driver.FindElement(By.XPath(".//*[@id='categoryId_52220894572']/div[2]/table[1]/tbody/tr[4]/td[3]/input")).Click();
            //driver.FindElement(By.XPath("//tr[td='BlackBerry']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='none']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                driver.FindElement(By.XPath("//a[.='Application Push/Install']")).GetAttribute("webpage").ToString();

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Application Push is configured for DENY access");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        
    }
    
}
