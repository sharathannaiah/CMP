using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Domains;

// we need to create one of this class for every group of tasks. That replaces the Base Sec. Role Class and let the code less prone to error.
namespace AutomatedTests.WebDriver.Fully_Automated_Tests.BES_Security_Roles
{
    public class A_Before_Run : Setup
    {
        //This method is on charge of enable wireless and client platform, then add the proper domain and server.
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Activating Wireless Services for BB");
            /*string value = driver.FindElement(By.XPath("//a[.='MDM Server']")).GetAttribute("webpage").ToString();
            //flag = true;            
            Common.GoToMenu(driver, value);
            driver.FindElement(By.XPath("//a[.='Domains']"));*/
            Common.EnableWirelessServices(driver, BESPlatform, BESPlatform);
            Console.WriteLine("+++++++++++++ Adding BES Domain +++++++++++++++++");
            new BESDomain().AddBESDomain();
            Console.WriteLine("+++++++++++++ Adding BES Server +++++++++++++++++");
            new BESServer().AddBESServer();
        }
                
        // So you need to add a known user to the AD previous set on AutomatedTest.config then add the specific device that you need.
        [Test]
        public void SetPreConditionsForBES()
        {
            //driver.SwitchTo
            Console.WriteLine("++++++++++++ Set User +++++++++++++++++");
            Common.SetRegularUser(driver, regularUserLastName, regularUser);
            Console.WriteLine("++++++++++++ Add Device +++++++++++++++");
            Common.AddDevice(driver, BESPlatform, BESDevice, password);
            //Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("continue");
            //Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser);
            //driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
        }

        //Just a login out to finish the pre-reqs. 
        //I detected some issues when the driver try to find the sign out button, so I added a new autom. attribute for this on the next build 13.1
        [TearDown]
        public void TearDown()
        {
            //Run after any test            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            driver.FindElement(By.XPath("//a[.='Sign Out']")).Click();
            Console.WriteLine("Logging out MDM");
            wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("userNameTextBox"));
            });
            driver.Quit();
        }
    }
}
