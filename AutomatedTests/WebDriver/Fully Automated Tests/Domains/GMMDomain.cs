using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;



namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Domains
{
    [TestFixture]
    public class GMMDomain : Setup
    {
        [Test]
        public void AddGMMDomain()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));


                string value = driver.FindElement(By.XPath("//a[.='Domains']")).GetAttribute("webpage").ToString();

                //driver.FindElement(By.XPath("//a[.='Domains']")).Click();
                Common.GoToMenu(driver, value);
                // Access to domains page 
                wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath("//*[@id='ctl00_MainContent_lnkAddGMMDomain']"));
                });

                driver.FindElement(By.XPath("//*[@id='ctl00_MainContent_lnkAddGMMDomain']")).Click();

                wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.Id("ctl00_MainContent_txtDomainName"));
                });
                driver.FindElement(By.Id("ctl00_MainContent_txtDomainName")).SendKeys(GMMName);
                driver.FindElement(By.Id("ctl00_MainContent_txtGMMURL")).SendKeys(GMMHttp);
                driver.FindElement(By.Id("ctl00_MainContent_txtGmmUsername")).SendKeys(GMMUser);
                driver.FindElement(By.Id("ctl00_MainContent_txtGmmPassword")).SendKeys(password);
                driver.FindElement(By.Id("ctl00_MainContent_lnkSave")).Click();
                //verify
                wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath(".//*[@id='ctl00_MainContent_dgDomains']/tbody/tr[2]/td[3]"));
                });
                Assert.AreEqual(GMMName, driver.FindElement(By.XPath(".//*[@id='ctl00_MainContent_dgDomains']/tbody/tr[2]/td[3]")).Text);
            }
            catch (NoSuchElementException e)
            {
                //handling exception
                if (!driver.FindElement(By.XPath("//a[.='Servers']")).Displayed)
                {
                    //Common.EnableWirelessServices(driver, );
                    System.Console.WriteLine("NoSuchElementException: " + e.Message);
                    //Assert.Fail(e.Message);
                }
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
