using AutomatedTests.Tangoe.Cmp.Automation.Common;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using AutomatedTests.CMP.Enterprise;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.EmployeePortal
{
    class EmployeeLogin : BaseActions
    {
        public void EmployeeLoginn()
        {
            GoToMain("Enterprise");
           retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
            retryingFindClickk(".//*[@id='mnuEmployees_Explorer']");
            
            {
                SwitchToContent();
                WaitForElementToVisible(By.XPath("//div[text()='Employee Management']"));
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Employee Management']")), "Navigation failed");
                Console.WriteLine("Navigation successful");
            }
        }

    }
}
