﻿using AutomatedTests.Tangoe.Cmp.Automation.Common;
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
            retryingFindClickk(".//*[@id='mnu_Localization']");
            retryingFindClickk(".//*[@id='mnuBaseTextTransformation']");
            if (true)
            {
                    BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                    WaitForElementToVisible(By.XPath("//td[text()='User Defined Translation']"));
                    Console.WriteLine("Navigation Successful");
                    Thread.Sleep(2000);
                    SwitchToPopUps();
                    BrowserDriver.Instance.Driver.SwitchTo().Frame("DETAILS_FRAME");
                    javascriptClick(By.XPath(General.Default.CloseB));
                    Console.WriteLine("User Defined Transcations passed smoked Test Successfully");
                }
            else
            {
                    Console.WriteLine("Navigation Unsuccessful");
            }

            }
        }
    }

