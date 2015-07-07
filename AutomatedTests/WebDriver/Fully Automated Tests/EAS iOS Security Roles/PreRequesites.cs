using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Domains;


namespace AutomatedTests.WebDriver.Fully_Automated_Tests.EAS_iOS_Security_Roles
{
    public class A_Before_Run : Setup
    {
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Activating Wireless Services for EAS");
            //Common.EnableWirelessServices(driver, EASPlatform, EASPlatformClient);
            Common.EnableWirelessServices(driver, EASPlatform, EASPlatformClient);
            new EASDomain().AddEASDomain();
            new EASServer().AddEASServer();
        }

       
        [Test]
        public void SetPreRequesitesForEAS()
        {
            /*
            //driver.SwitchTo
            Console.WriteLine("++++++++++++ Set User +++++++++++++++++");
             * */
            Common.SetRegularUser(driver, regularUserLastName, regularUser);
            Console.WriteLine("++++++++++++ Add Device +++++++++++++++");
            Common.AddDevice(driver, EASPlatform, EASPlatformClient, password);
            //Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("continue");
            //Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser);
            //driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
             /* */
        }

        [TearDown]
        public void TearDown()
        {
            //Run after any test            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            driver.FindElement(By.XPath("//*[@id='metaNav']/ul/li[1]/a")).Click();
            Console.WriteLine("Logging out MDM");
            wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("userNameTextBox"));
            });
            driver.Quit();
        }

    }
}
