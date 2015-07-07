using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace AutomatedTests.WebDriver.Fully_Automated_Tests.GMM_Android_Security_Roles
{
    public class CustomizationAndSelfService : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting New Security Role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, BESPlatform);
        }

            
        [Test]
        public void DevicesFullAccess()
        {
            driver.FindElement(By.LinkText("Configuration Administration")).Click();
            driver.FindElement(By.LinkText("Customization and Self-service")).Click();
            driver.FindElement(By.XPath("//tr[td='Devices']/td/input[@name='full access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void DevicesReadAccess()
        {

            driver.FindElement(By.LinkText("Configuration Administration")).Click();
            driver.FindElement(By.LinkText("Customization and Self-service")).Click();
            driver.FindElement(By.XPath("//tr[td='Devices']/td/input[@name='read access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void DevicesNoAccess()
        {

            driver.FindElement(By.LinkText("Configuration Administration")).Click();
            driver.FindElement(By.LinkText("Customization and Self-service")).Click();
            driver.FindElement(By.XPath("//tr[td='Devices']/td/input[@name='no access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }
    }
}