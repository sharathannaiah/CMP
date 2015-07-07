using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.Domains
{
    
    public class BESDomain : Setup
    {
    [Test]
        public void AddBESDomain()
        {

            try
            {
                //this line will call to the login method of the super class
                //base.Login();
                string value = driver.FindElement(By.XPath("//a[.='Domains']")).GetAttribute("webpage").ToString();
                Console.WriteLine(value);
                //driver.FindElement(By.XPath("//a[.='Domains']")).Click();
                Common.GoToMenu(driver, value);
                // Access to domains page 
                Common.WaitForElement(driver, By.ClassName("add-domain-btn-large"), 30);
                driver.FindElement(By.ClassName("add-domain-btn-large")).Click();
                Common.WaitForElement(driver, By.Id("rdBlackBerryDomain"), 15);
                driver.FindElement(By.Id("rdBlackBerryDomain")).Click();
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                Common.WaitForElement(driver, By.Id("txtDomainName"), 30);
                driver.FindElement(By.Id("txtDomainName")).SendKeys(BESName);
                new SelectElement(driver.FindElement(By.XPath(".//*[@id='selBesVersion']"))).SelectByText(BESVersion);

                driver.FindElement(By.Id("rdBasAuthenticationRdo")).Click();
                driver.FindElement(By.Id("txtBASWebServicesURL")).SendKeys(BESHttp);
                driver.FindElement(By.Id("txtBASAdministratorUserName")).SendKeys(BESUser);
                driver.FindElement(By.Id("txtBASAdministratorPassword")).SendKeys(password);
                driver.FindElement(By.Id("txtSQLServerAddress")).SendKeys(SQLServer);
                driver.FindElement(By.Id("txtBESManagementDatabaseName")).SendKeys(BESMgmt);
                driver.FindElement(By.Id("txtReadOnlyDatabaseUsername")).SendKeys(DBUser);
                driver.FindElement(By.Id("txtBESAdministratorPassword")).SendKeys(password);
                //save
                driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
                Common.WaitForElement(driver, By.CssSelector("button.tangoeBtn.tangoeBtn-primary"), 30);
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.ClassName("add-domain-btn-large"), 15);
                //
               // Assert.AreEqual(BESName, driver.FindElement(By.XPath("//a[.='" + BESName + "']")).Text);
                //driver.FindElement(By.XPath("//button[@type='button']")).Click();
                //Common.WaitForElement(driver, By.ClassName("add-domain-btn-large"), 30);                    
                //Assert.AreEqual(BESName, driver.FindElement(By.XPath(".//*[@id='ctl00_MainContent_dgDomains']/tbody/tr[2]/td[3]")).Text);
                Common.CreateTestCaseWork("Add BES Domain");
                Common.CreateTestCaseResult("Add BES Domain", "PASS");
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
