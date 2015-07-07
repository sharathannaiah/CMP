using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise
{
    class EntityRegions : BaseActions
    {

        public void EntityRegion()
        {
            GoToMain("Enterprise");
            BrowserDriver.Instance.Driver.FindElement(By.Id("mnuEnterprise_Region")).Click();
            Thread.Sleep(2000);
            //BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("1");
            // BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_FRAME_DIALOG");
            BrowserDriver.Instance.Driver.FindElement(By.Id("new")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='nameField'])[2]")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='nameField'])[2]")).SendKeys("India");
            BrowserDriver.Instance.Driver.FindElement(By.Id("description")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.Id("description")).SendKeys("India");
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='geographyType'])[3]")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("saveRegionButton")).Click();

            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_FRAME_DIALOG");

            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='India']")).Click();
            Assert.AreEqual("India", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='India']")).Text);
            Console.WriteLine("Region Added Successfully");
            // BrowserDriver.Instance.Driver.FindElement(By.XPath("//table[@id='JColResizer3']/tbody/tr[4]/td[2]/div/nobr/div")).Click();
            BrowserDriver.Instance.Driver.FindElement(By.Id("deleteButton")).Click();
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            //     Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Are you sure you want to delete this region[\\s\\S]$"));
            BrowserDriver.Instance.Driver.FindElement(By.Id("closeButton")).Click();
            Console.WriteLine("Deletion of Region Successful");
            BrowserDriver.Instance.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
        }

    }
}
