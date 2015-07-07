using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.GMM_Android_Security_Roles
{
    public class GMMGeneralDeviceActions : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting New Security Role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, BESPlatform);
        }
        [Test]
        public void UserProfileAndPoliciesGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();

            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);                   
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath(".//*[@id='DeviceSelectionSection']/div[2]/div/div[2]/button"), 30);
                //select MDM group to joke the system making clickeable details tab
                Console.WriteLine("Access to User Profile Granted!");
                //driver.FindElement(By.XPath(".//*[@id='deviceDetailsTabs']/ul/li[6]/a")).Click();
                //driver.FindElement(By.XPath(".//*[@id='deviceDetailsTabs']/ul/li[1]/a")).Click();
                Console.WriteLine("Access to User Details Granted!");
                Assert.AreEqual("User Detail", driver.FindElement(By.XPath(".//*[@id='DetailsSection']/div/div[1]/div[1]/div[1]")).Text);
                Assert.AreEqual("Update Details", driver.FindElement(By.CssSelector(".tangoeBtn.tangoeBtn-small.pull-right")).Text);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        

        [Test]
        public void ViewAlertsGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("View Alerts")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void ViewApplicationsGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("View Applications")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void ViewUsageGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("View Applications")).Click();
            driver.FindElement(By.XPath("//tr[td='View Usage']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void LocateDeviceGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("View Applications")).Click();
            driver.FindElement(By.XPath("//tr[td='Locate Device']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void AddDeleteChangeDevicesGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("View Applications")).Click();
            driver.FindElement(By.XPath("//tr[td='Add/Delete/Change Devices']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void AddDeleteChangeDevicesDeny()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("View Applications")).Click();
            driver.FindElement(By.XPath("//tr[td='Add/Delete/Change Devices']/td/input[@name='deny']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();

            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath(".//*[@id='DeviceSelectionSection']/div[2]/div/div[2]/button"), 30);
                //ask if there is  a device or not
                if (Common.IsElementVisible(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']")) || Common.IsElementVisible(driver, By.XPath(".//*[@title='Add device']")))
                {
                    Assert.Fail("the add device option is available");
                }
                Console.WriteLine("Add device option is denied, test succesfull!");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [Test]
        public void WipeDeviceGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("View Applications")).Click();
            driver.FindElement(By.XPath("//tr[td='Wipe Device']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        }
       
}