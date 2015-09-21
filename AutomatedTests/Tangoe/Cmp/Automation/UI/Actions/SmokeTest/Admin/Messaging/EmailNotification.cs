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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Messaging
{
    class EmailNotification : BaseActions
    {
        public void EmailNotificationFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Messaging']");
            retryingFindClickk(".//*[@id='mnuAdmin_Email_Notifications']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Email Notifications']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            
            }
        }
            public void SaveEmailNotification()
            {
            SwitchToPopUps();
                SelectfromDropdown("ehNotificationEventId","1");
                javascriptClick(By.LinkText("test test"));
                javascriptClick(By.XPath("//select[@value='1000072']"));
                javascriptClick(By.XPath("//select[@value='100002']"));
                javascriptClick(By.LinkText("cmp Adminstrator"));

            }
        }
    }

