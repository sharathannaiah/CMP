using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using AutomatedTests.WebDriver.Fully_Automated_Tests.Domains;

// we need to create one of this class for every group of tasks. That replaces the Base Sec. Role Class and let the code less prone to error.
namespace AutomatedTests.WebDriver.Fully_Automated_Tests.GMM_Android_Security_Roles
{
    public class A_Before_Run : Setup
    {


        // So you need to add a known user to the AD previous set on AutomatedTest.config then add the specific device that you need.
        [Test]
        public void SetPreConditionsForGMM()
        {
            //driver.SwitchTo
            Console.WriteLine("++++++++++++ Set User +++++++++++++++++");
            Common.SetRegularUser(driver, regularUserLastName, regularUser);
            Console.WriteLine("++++++++++++ Add Device +++++++++++++++");
            Common.AddGMMDevice(driver, GMMPlatform, GMMDevice);
            //Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("continue");
            //Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser);
            //driver.FindElement(By.Name("isAdminProfileChkBx")).Click();
        }
    }
}
