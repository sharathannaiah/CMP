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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous
{
    class Contacts : BaseActions
    {

        public void CreateReq()
        {
            

            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            //Navigate to Employee Explorerk
            retryingFindClickk(".//*[@id='mnuAdmin_Contacts']");
            Thread.Sleep(2000);
            SwitchIndideFrame();

           // SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.Name("newContacts")).Click();
            Thread.Sleep(2000);
            IWebElement ele2 = BrowserDriver.Instance.Driver.FindElement(By.Id("CONTACT"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele2);
            CreateContactWithManditoryFields("Test", "TestLast", "Employee Contact");

            ClickOnNotificationsTab();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            SwitchIndideFrame();
            

        }

        public void EditList(string Name)
        {

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            SwitchIndideFrame();

            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//div[normalize-space()='" + Name + "'])[1]")).Click();
            Thread.Sleep(6000);
        }


        public void DeleteContact(string Name)
        {
            // ClickSubmitButton_Contacts();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            SwitchIndideFrame();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("(//div[normalize-space()='" + Name + "'])[1]")).Click();
            Thread.Sleep(8000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
            alert.Dismiss();
        }



        public void SwitchIndideFrame()
        {
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.Id("ADMINCONTACTS"));//ADMIN_CONTACTLIST
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);

            IWebElement ele2 = BrowserDriver.Instance.Driver.FindElement(By.Id("ADMIN_CONTACTLIST"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele2);
            Thread.Sleep(2000);


        }

        public void CreateContactWithManditoryFields(string Firstname, string Lastname, string ContactType)
        {

            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@name='firstName']")).SendKeys(Firstname + RandomNumbergeneratorL());
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@name='lastName']")).SendKeys(Lastname + RandomNumbergeneratorL());
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath("//select[@name='contactTypeId']"))).SelectByText(ContactType);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            Thread.Sleep(5000);

        }

        public void ClickOnNotificationsTab()
        {

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            SwitchIndideFrame();
            BrowserDriver.Instance.Driver.FindElement(By.Id("notifications")).Click();
            //BrowserDriver.Instance.Driver.FindElement(By.Id("notifications")).Click();
        }



        public void SelectAnyEvent(string Eventname)
        {
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//td[@title='" + Eventname + "']/preceding-sibling::td/descendant::input"));
        }



        public int RandomNumbergeneratorL()
        {

            Random random = new Random();

            int randomNumber = random.Next(0, 10000);

            return randomNumber;




        }

        public void CreateContactWithManditoryFieldss(string Firstname, string Lastname, string ContactType)
        {

            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@name='firstName']")).SendKeys(Firstname + RandomNumbergeneratorL());
            //firstName

          //  typeDataName("firstName", "FirstName" + ranNum);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@name='lastName']")).SendKeys(Lastname + RandomNumbergeneratorL());
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.XPath("//select[@name='contactTypeId']"))).SelectByText(ContactType);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            Thread.Sleep(5000);

        }

    }
}
