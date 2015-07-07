using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.GMM_Android_Security_Roles
{
    public class PageAccess : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting New Security Role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, GMMPlatform);

        }

        [Test]
        public void PageAccessFull()
        {
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Server Assignment']/td/input[@name='full']")).Click();
            driver.FindElement(By.LinkText("Configuration Administration")).Click();
            driver.FindElement(By.LinkText("Wireless Services")).Click();
            driver.FindElement(By.XPath("//tr[td='Domains']/td/input[@name='full']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To Servers']/td/input[@name='full']")).Click();
            driver.FindElement(By.XPath("//tr[td='Service Options']/td/input[@name='full']")).Click(); 
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            LoginOut(driver);
            LogIntoMDM(driver, regularUser);

            try
            {
                string value = driver.FindElement(By.XPath("//a[.='Good Mobile Messaging']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.ClassName("add-rule-btn-large"), 20);
                Console.WriteLine("Access to Application Push!");
                //verify that some elements are editable when you had already allowed "full access"
                Common.WaitForElement(driver, By.XPath("//*[.='Rule']"), 20);
                driver.FindElement(By.XPath(".//*[@id='ViewPort']/header/ul/li/div/a")).Click();
                Common.WaitForElement(driver, By.XPath(".//*[@id='ruleCriteriaForm']/div[1]"), 30);
                Assert.AreEqual("Rule", driver.FindElement(By.XPath("//*[.='Rule']")).Text);
                driver.FindElement(By.Id("txtDescript")).SendKeys("Test rule");
                new SelectElement(driver.FindElement(By.Id("ddlDomainName"))).SelectByText("GMM");
                new SelectElement(driver.FindElement(By.Id("ddlResult"))).SelectByText("QAMDM-GOOD1");
                driver.FindElement(By.Id("cbApplyToAll")).Click();
                driver.FindElement(By.Id("undefined_txtLdapFreeform")).SendKeys("sn=" + regularUser);



            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [Test]
        public void PageAccessRead()
        {
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Server Assignment']/td/input[@name='full']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='read access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }

        [Test]
        public void PageAccessNoAccess()
        {
            driver.FindElement(By.LinkText("Page Access")).Click();
            driver.FindElement(By.XPath("//tr[td='Server Assignment']/td/input[@name='full']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='no access']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
        }
    }
}
