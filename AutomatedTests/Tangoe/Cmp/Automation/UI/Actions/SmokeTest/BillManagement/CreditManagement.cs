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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement
{
    class CreditManagement: BaseActions
    {
        public void CreateCredit()
        {
            GoToMain("Bill Managemnent");
            retryingFindClickk(".//*[@id='mnuBilling_CreditManage']");
            Thread.Sleep(2000);
            SwitchToContent();
           
        }
    }
}
