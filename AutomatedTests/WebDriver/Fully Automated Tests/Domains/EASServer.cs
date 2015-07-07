using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Domains
{
    [TestFixture]
    public class EASServer : Setup
    {
        [Test]
        public void AddEASServer()
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
                Common.WaitForElement(driver, By.Id("rdoServerMEA"), 10);
                driver.FindElement(By.Id("rdoServerMEA")).Click();
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                Common.WaitForElement(driver, By.Id("ddlServerName"), 30);
                driver.FindElement(By.Id("ddlServerName")).Clear();
                driver.FindElement(By.Id("ddlServerName")).SendKeys(EAS2010ServerFQDN);
                driver.FindElement(By.Id("ddlActiveSyncServerName")).Clear();
                driver.FindElement(By.Id("ddlActiveSyncServerName")).SendKeys(EAS2010ServerName);
                driver.FindElement(By.Id("maxUserCount")).Clear();
                driver.FindElement(By.Id("maxUserCount")).SendKeys(MaxUser);
                driver.FindElement(By.CssSelector("button.tangoeBtn.tangoeBtn-primary")).Click();
                Common.WaitForElement(driver, By.CssSelector("td.ui-notificationbar-message"), 30);
                Assert.GreaterOrEqual(driver.FindElement(By.CssSelector("td.ui-notificationbar-message")).Text, "Success Saving Active Sync Server");

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
