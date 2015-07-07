using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.GMM_Android_Security_Roles
{
    public class Applications : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting New Security Role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, BESPlatform);
        }


        [Test]
        public void EnterpriseApplicationPortalCollectionFull()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Enterprise Application Portal Collections']/td/input[@name='full access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void EnterpriseApplicationPortalCollectionReadAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Enterprise Application Portal Collections']/td/input[@name='Read access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void EnterpriseApplicationPortalCollectionNoAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Enterprise Application Portal Collections']/td/input[@name='No Access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }


        [Test]
        public void EnterpriseApplicationPortalConfigurationFullAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Enterprise Application Portal Configuration']/td/input[@name='full access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void EnterpriseApplicationPortalConfigurationReadAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Enterprise Application Portal Configuration']/td/input[@name='Read access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void EnterpriseApplicationPortalConfigurationNoAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Enterprise Application Portal Configuration']/td/input[@name='no access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void ApplicationPushFullAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='full access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void ApplicationPushReadAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='Read access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }
            
        [Test]
        public void ApplicationPushNoAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Push']/td/input[@name='No access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void ApplicationRemoveFullAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='full access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void ApplicationRemoveReadAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='read access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void ApplicationRemoveNoAccess()
        {

            driver.FindElement(By.LinkText("Applications")).Click();
            driver.FindElement(By.LinkText("Assignment")).Click();
            driver.FindElement(By.XPath("//tr[td='Application Remove']/td/input[@name='No access']")).Click();
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }
    }
}
