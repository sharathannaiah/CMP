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
using AutomatedTests.CMP.Admin;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Contracts
{
    class ContractTerms : BaseActions
    {
        public void ContractTermsFunctions() 
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_ContractAdmin']");
            retryingFindClickk(".//*[@id='mnuContractTerms']");
            WaitForElementToVisible(By.XPath("//td[text()='Terms']"));
            Console.WriteLine("Navigation Successful");
            CreateTerms();


        }

    }
}
