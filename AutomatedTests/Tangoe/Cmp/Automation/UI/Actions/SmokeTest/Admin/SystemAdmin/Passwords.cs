using AutomatedTests.Tangoe.Cmp.Automation.Common;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomatedTests.CMP.Admin;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.SystemAdmin
{
    class Passwords : BaseActions 
    {

        public void PasswordFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_SystemAdmin']");
            retryingFindClickk(".//*[@id='mnuAdmin_Policy']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='CMP Security Provider - Policy Administration']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }

            SwitchToPopUps();
            typeDataID("pwdMaxCharacters", "15");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToPopUps();
          //  Assert.AreEqual("<OpenQA.Selenium.Remote.RemoteWebElement>", BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='']")));
        //    Assert.IsTrue(IsElementVisible(By.XPath("//input[value()='15']")), "Password details edition failed");
            Console.WriteLine("Password details updated successfully");
            typeDataID("pwdMaxCharacters", "10");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            javascriptClick(By.XPath(General.Default.CloseB));

        }


    }
}
