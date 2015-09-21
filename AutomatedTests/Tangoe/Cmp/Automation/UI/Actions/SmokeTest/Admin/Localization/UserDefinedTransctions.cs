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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Localization
{
    class UserDefinedTransctions : BaseActions
    {
        public void UserDefinedTranscationsFun()
        {
            GoToMain("Admin");
            retryingFindClickk("");
            retryingFindClickk(".//*[@id='mnuBaseTextTransformation']");
            if (true)
            {
                    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                    WaitForElementToVisible(By.XPath("//div[text()='User Defined Translation']"));
                    Console.WriteLine("Navigation Successful");
                }
            else
            {
                    Console.WriteLine("Navigation Unsuccessful");
            }

            }
        }
    }

