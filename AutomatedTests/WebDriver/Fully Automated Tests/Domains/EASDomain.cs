using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Domains
{
    class EASDomain : Setup
    {
        public void AddEASDomain()
        {
            try {
                base.Login();
                string value = driver.FindElement(By.XPath("//a[.='Domains']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.LinkText("Microsoft ActiveSync"), 30);
                driver.FindElement(By.LinkText("Microsoft ActiveSync")).Click();
                Common.WaitForElement(driver, By.Id("ctl00_MainContent_ddlExchangeVersion"), 30);
                new SelectElement(driver.FindElement(By.Id("ctl00_MainContent_ddlExchangeVersion"))).SelectByText("2010");
                //driver.FindElement(By.CssSelector("option[value=\"3\"]")).Click();
                Common.WaitForElement(driver, By.Id("ctl00_MainContent_txtRemoteUrl"), 30);
                driver.FindElement(By.Id("ctl00_MainContent_txtRemoteUrl")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtRemoteUrl")).SendKeys(EAS2010DomainServer);
                driver.FindElement(By.Id("ctl00_MainContent_txtRemoteUsername")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtRemoteUsername")).SendKeys(EAS2010DomainAdmin);
                driver.FindElement(By.Id("ctl00_MainContent_txtRemotePassword")).Clear();
                driver.FindElement(By.Id("ctl00_MainContent_txtRemotePassword")).SendKeys(EAS2010DomainPass);               
                driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
                //Common.WaitForElement(driver, By.LinkText("Microsoft ActiveSync"), 30);

                //Verify that no error is raised on the Domains page, so it goes back to the domains list
                if(Common.IsElementVisible(driver, By.XPath(".//*[@id='ctl00_MainContent_mbxMessage_divMessages']")))
                Assert.Fail("the EAS Domain could not be saved");
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
