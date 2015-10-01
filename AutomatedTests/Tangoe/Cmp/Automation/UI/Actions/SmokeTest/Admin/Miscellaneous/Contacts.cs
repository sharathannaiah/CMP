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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous
{
    class Contacts : BaseActions
    {

        public void ContactsFunctionality()
        {

            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnu_Misc']");
            //Navigate to Employee Explorerk
            retryingFindClickk(".//*[@id='mnuAdmin_Contacts']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Contacts']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }
            
           
            if (true)
            {
                SearchContact();
                CreateReq();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='External']")), "Contact Request not created");
                Console.WriteLine("Contact created successfully");
            }
            else 
            {
                Console.WriteLine("Contact creation  failed");
            }
            if (true)
            {
                AddNotification();
                Console.WriteLine("Notification added successfully");
            }
            else
            {
                Console.WriteLine("Notification not added successfully");
            }

            if (true)
            {
                AddEntity();
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ACS']")), "Entity not added");
                Console.WriteLine("Entity Added Successfully");
            }
            else
            {
                Console.WriteLine("Entity addtion failed");
            
            }
            if (true)
            {
                DeleteEntity();
                Thread.Sleep(2000);
                SwitchIndideFrame();
                IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.Id("ENTITIES"));
                BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='ACS']")), "Entity not deleted");
                Console.WriteLine("Entity Deleted Successfully");
                Console.WriteLine("Admin --> Miscellaneous --> Contacts passed smoke test Successfully");
            }

            else
            {
                Console.WriteLine("Entity deletion failed");

            }

        }
      
    
        public void CreateReq()
        {
            SwitchIndideFrame();
            BrowserDriver.Instance.Driver.FindElement(By.Name("newContacts")).Click();
            Thread.Sleep(2000);
            IWebElement ele2 = BrowserDriver.Instance.Driver.FindElement(By.Id("CONTACT"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele2);
            CreateContactWithManditoryFields("Test", "TestLast", "Employee Contact");
            SwitchIndideFrame();
        }

        public void SearchContact()
        {
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMINCONTACTS");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("contactTypeId"))).SelectByText("Employee Contact");
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            Thread.Sleep(2000);
            SwitchIndideFrame();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Employee Contact']")), "Search  failed");
            Console.WriteLine("Search Successful");
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
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
          BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMINCONTACTS");//ADMIN_CONTACTLIST
          BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTACTLIST");
            Thread.Sleep(2000);


        }

        public void CreateContactWithManditoryFields(string Firstname, string Lastname, string ContactType)
        {
          typeDataName("firstName", "Firstname" +RandomNumbergeneratorL());
          typeDataName("lastName", "LastName" + RandomNumbergeneratorL());
          ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('contactTypeId')[0].selectedIndex='2'");

          javascriptClick(By.XPath(General.Default.SaveB));
            Thread.Sleep(5000);

        }

        public void ClickOnNotificationsTab()
        {

            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            SwitchIndideFrame();
            BrowserDriver.Instance.Driver.FindElement(By.Id("notifications")).Click();
            Thread.Sleep(2000);
            SwitchIndideFrame();
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

        public void AddNotification()
        {
            ClickOnNotificationsTab();
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMINCONTACTS");//ADMIN_CONTACTLIST
            BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_CONTACTLIST");
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.Id("NOTIFICATIONS"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
         //   BrowserDriver.Instance.Driver.SwitchTo().Frame("NOTIFICATIONS");
            Thread.Sleep(2000);
            javascriptClick(By.CssSelector("input.multiSelectRow"));
            javascriptClick(By.XPath(General.Default.SaveB));

        }
        public void AddEntity()
        {
            SwitchIndideFrame();
            javascriptClick(By.Id("entities"));
            Thread.Sleep(2000);
            SwitchIndideFrame();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.Id("ENTITIES"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            javascriptClick(By.XPath(General.Default.AddB));
            Thread.Sleep(3000);
            SearchQuery("entityName","ACS");
            Thread.Sleep(2000);
            javascriptClick(By.CssSelector("input.multiSelectRow"));
            javascriptClick(By.XPath(General.Default.OKB));
            Thread.Sleep(2000);
            SwitchIndideFrame();
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);

        }

        public void DeleteEntity()
        {
            SwitchIndideFrame();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.Id("ENTITIES"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) { return true; }");
            javascriptClick(By.XPath(General.Default.RemoveB));
            
        }

    }
}
