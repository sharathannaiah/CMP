using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Domains
{
    [TestFixture]
    public class BESServer : Setup
    {
        [Test]
        public void AddBESServer()
        {
            try
            {
                //comment the below line if u are gonna run in single mode w/ pre requesites.
                base.Login();
                string value = driver.FindElement(By.XPath("//a[.='Servers']")).GetAttribute("webpage").ToString();
                //new Login().GoToMenu(driver, value);                
                Console.WriteLine(value);
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.CssSelector("a.add-server-btn-large"), 30);
                driver.FindElement(By.CssSelector("a.add-server-btn-large")).Click();
                Common.WaitForElement(driver, By.Id("rdoServerBB"), 10);
                driver.FindElement(By.Id("rdoServerBB")).Click();
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                Common.WaitForElement(driver, By.Id("domainNameCombo"), 30);
                new SelectElement(driver.FindElement(By.Id("domainNameCombo"))).SelectByText(BESName);                
                //driver.Navigate().Refresh();
                Common.WaitForElement(driver, By.Id("serverNameCombo"), 30);
                new SelectElement(driver.FindElement(By.Id("serverNameCombo"))).SelectByText(BESName);
                driver.FindElement(By.Id("maxNumberOfUsersText")).SendKeys(MaxUser);
                driver.FindElement(By.Id("hostNameText")).SendKeys(BESName);
                driver.FindElement(By.CssSelector("button.tangoeBtn.tangoeBtn-primary")).Click();
                driver.FindElement(By.CssSelector("a.breadcrumlink.ignoreReadOnlyPermission")).Click();
                Common.WaitForElement(driver, By.XPath("//a[.='" + BESName + "']"), 30);
                Assert.AreEqual(BESName, driver.FindElement(By.XPath("//a[.='" + BESName + "']")).Text);
            }
            catch (NoSuchElementException e)
            {
                System.Console.WriteLine("NoSuchElementException: " + e.Message);
                Assert.Fail(e.Message);
            }
            catch (InvalidSelectorException e)
            {
                System.Console.WriteLine("InvalidSelectorException: " + e.Message);
                Assert.Fail(e.Message);
            }
            catch (TimeoutException e)
            {
                System.Console.WriteLine("TimeoutException: " + e.Message);
                Assert.Fail(e.Message);
            }
            catch (NUnit.Framework.AssertionException e)
            {
                System.Console.WriteLine("Nunit Assertion verify: " + e.Message);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("General Exception: " + e.Message);
                Assert.Fail(e.Message);
            }
        }

        
    }
}
