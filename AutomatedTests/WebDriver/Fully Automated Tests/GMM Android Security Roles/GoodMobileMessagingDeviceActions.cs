using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.GMM_Android_Security_Roles
{
    public class GoodMobileMessagingDeviceActions : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting New Security Role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, BESPlatform);
        }

        [Test]
        public void RegeneratePINGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Good Mobile Messaging Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Regenerate Good OTA PIN']/td/input[@name='grant']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            LoginOut(driver);
            LogIntoMDM(driver, regularUser);


            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //ask if there is  a device or not
                if (!Common.IsElementVisible(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']")))
                {
                    driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                    driver.FindElement(By.LinkText("Regenerate Good OTA PIN")).Click();
                    Common.WaitForElement(driver, By.XPath("//button[@type='button']"), 10);
                    driver.FindElement(By.XPath("//button[@type='button']")).Click();
                    Console.WriteLine("Regenerate Good OTA PIN is available. Success");
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [Test]
        public void RegeneratePINDeny()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Good Mobile Messaging Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Regenerate Good OTA PIN']/td/input[@name='deny']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            LoginOut(driver);
            LogIntoMDM(driver, regularUser);


            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //ask if there is  a device or not
                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                if (Common.IsElementVisible(driver, By.LinkText("Regenerate Good OTA PIN")))
                    Assert.Fail("Test case FAILED: REgenerate OTA PIN command was found.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Regenerate Good OTA PIN IS NOT available. Success");
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        [Test]
        public void WipeGMMDataGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Good Mobile Messaging Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Wipe Good Mobile Messaging data']/td/input[@name='deny']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            LoginOut(driver);
            LogIntoMDM(driver, regularUser);


            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //ask if there is  a device or not
                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                if (Common.IsElementVisible(driver, By.LinkText("Wipe Good Mobile Messaging data")))
                    Assert.Fail("Test case FAILED: Wipe Good Mobile Messaging data command was found and it's a non activated device. Shouldn't be shown.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Wipe Good Mobile Messaging data IS NOT available. Success");
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
