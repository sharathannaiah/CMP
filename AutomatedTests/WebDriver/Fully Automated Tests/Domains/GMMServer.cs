using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Domains
{
    [TestFixture]
    public class GMMServer : Setup
    {
        [Test]
        public void AddGMMServer()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                string value = driver.FindElement(By.XPath("//a[.='Servers']")).GetAttribute("webpage").ToString();
                //new Login().GoToMenu(driver, value);                
                Console.WriteLine(value);
                Common.GoToMenu(driver, value);

                wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath("//a[.='Add GMM Server']"));
                });
                driver.FindElement(By.XPath(".//*[@id='ctl00_MainContent_lnkAddServerGMM']")).Click();
                wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath(".//*[@id='ctl00_MainContent_ddlDomain']"));
                });
                //driver.Navigate().
                new SelectElement(driver.FindElement(By.XPath(".//*[@id='ctl00_MainContent_ddlDomain']"))).SelectByText(GMMName);

                driver.FindElement(By.XPath("//*[@id='ctl00_MainContent_txtMaxUserCount']")).SendKeys(MaxUser);
                driver.FindElement(By.XPath("//a[.='Save']")).Click();
                //Verify
                wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath(".//*[@id='ctl00_MainContent_dgServers']"));
                });

                //Assert.AreEqual(GMMName, driver.FindElement(By.XPath(".//*[@id='ctl00_MainContent_dgServers']/tbody/tr[2]/td[3]")).Text);
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
