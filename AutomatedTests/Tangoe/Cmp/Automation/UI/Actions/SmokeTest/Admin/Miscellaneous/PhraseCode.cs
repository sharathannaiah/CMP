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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous
{
    class PhraseCode : BaseActions
    {
        public void PhraseCodesFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            retryingFindClickk(".//*[@id='mnuPhraseCodeMaintenance']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Phrase Code Maintenance']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");

            }
            if (true)
            {
                AddPhraseCode();
                SearchPhrasecode();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Phrase code added']")), "Adding phrase code failed");
                Console.WriteLine("Phrase code added successfully");
            }
            else
            {
                Console.WriteLine("Phrase code addition  failed");
            }

            if (true)
            {
                SearchPhrasecode();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Change']")), "Adding phrase code failed");
                Console.WriteLine("Phrase code Search successful");
            }
            else
            {
                Console.WriteLine("Phrase code Search  failed");
            }
            if (true)
            {
                EditPhraseCode();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Phrase code Edited']")), "Adding phrase code failed");
                Console.WriteLine("Phrase code edited successful");
            }
            else
            {
                Console.WriteLine("Phrase code edition  failed");
            }

            if (true)
            {
                DeletePhraseCode();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='Phrase code edited']")), "Adding phrase code failed");
                Console.WriteLine("Phrase code deleted successfully");
            }
            else
            {
                Console.WriteLine("Phrase code deletion  failed");
            }

        }

        public void AddPhraseCode()
        { 
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.AddB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
         //   new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("phraseCode"))).SelectByText("AT&T");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('carrierId')[0].selectedIndex='6'");
              typeDataID("phraseCode", "AB123"+RandomNumbergeneratorL());
              ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('categoryId')[0].selectedIndex='2'");
          //    new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("categoryId"))).SelectByText("Change");
              typeDataName("description", "Phrase code added");
              retryingFindClick(By.XPath(General.Default.SaveB));
              Thread.Sleep(2000);
        }

        public void SearchPhrasecode()
        {
            SwitchToContent();
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("carrierId"))).SelectByText("AT&T");
            //new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("CategoryLUIId"))).SelectByText("Change");
            typeDataName("phraseCode", "AB");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
        //    BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.ResetB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
        }

        public void EditPhraseCode()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
            javascriptClick(By.XPath("//div[text()='Phrase code added']"));
            typeDataName("description", "Phrase code Edited");
            javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(2000);
            SwitchToContent();

        }
            public void DeletePhraseCode()
            {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
            javascriptClick(By.XPath("//div[text()='Phrase code Edited']"));
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_PHRASECODELIST");
            javascriptClick(By.XPath(General.Default.RemoveB));
            Thread.Sleep(2000);
            SwitchToContent();
            }
}
}
