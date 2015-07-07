using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.GMM_Android_Security_Roles
{
    public class Security : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting New Security Role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, BESPlatform);
        }

        [Test]
        public void PolicyProfilesFull()
        {
            driver.FindElement(By.LinkText("Security")).Click();
            driver.FindElement(By.XPath("//tr[td='Policies']/td/input[@name='full']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void PolicyProfilesRead()
        {
            driver.FindElement(By.LinkText("Security")).Click();
            driver.FindElement(By.XPath("//tr[td='Policies']/td/input[@name='read only']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void PolicyProfilesNoAccess()
        {
            driver.FindElement(By.LinkText("Security")).Click();
            driver.FindElement(By.XPath("//tr[td='Policies']/td/input[@name='No access']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void PolicyAssignmentAndroidFull()
        {

            driver.FindElement(By.LinkText("Security")).Click();
            driver.FindElement(By.LinkText("Policy Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Android']/td/input[@name='full']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void PolicyAssignmentAndroidRead()
        {
            driver.FindElement(By.LinkText("Security")).Click();
            driver.FindElement(By.LinkText("Policy Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Android']/td/input[@name='Read only']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }


        [Test]
        public void PolicyAssignmentAndroidNoAccess()
        {
            driver.FindElement(By.LinkText("Security")).Click();
            driver.FindElement(By.LinkText("Policy Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Android']/td/input[@name='No access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

    }
}
