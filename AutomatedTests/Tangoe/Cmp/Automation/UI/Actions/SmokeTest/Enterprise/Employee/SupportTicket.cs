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


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise.Employee
{
    class SupportTicket : BaseActions
    {
        //Create Ticket
        public void SupportTicketFunctionality()
        {
            GoToMain("Enterprise");
            retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
            retryingFindClickk(".//*[@id='mnuEmployees_HelpDeskTickets']");
            Thread.Sleep(2000);
            AddSupportTicket();
            Thread.Sleep(2000);
            UpdateTicket();
            Deletion();
        }

        //Edit the Created Ticket
        public void UpdateTicket()
        {
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();

            Thread.Sleep(5000);
         //   GoToMain("Enterprise");
         //   retryingFindClickk(".//*[@id='mnuEnterprise_Employees']");
         //   retryingFindClickk(".//*[@id='mnuEmployees_HelpDeskTickets']");
         //   Thread.Sleep(2000);
            ClickSubmitButton_SupportTicket();
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("HELPDESKTICKETS");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("TICKETLIST");
            BrowserDriver.Instance.Driver.FindElement(By.Name("openTicketButton")).Click();
            Thread.Sleep(2000);
            EditTicket();
            Thread.Sleep(2000);
        }

        //Delete the create ticket
        public void Deletion()
        {
            SwitchToContent();
            Delete();
           
        }


        //Add Function
        public void AddSupportTicket()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.SwitchTo().Frame("HELPDESKTICKETS");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("TICKETLIST");
            BrowserDriver.Instance.Driver.FindElement(By.Name("newTicketButton")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('supportTicketSubject').value='Ticket1'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('supportTicketDescription').value='Able to place Calls'");
            BrowserDriver.Instance.Driver.FindElement(By.Name("saveTicketButton")).Click();
            Thread.Sleep(2000);
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='New']")).Click();
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('supportTicketDescription').value='Support description'");
           SwitchToPopUps();
           IWebElement elemen = BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ticketsResponsesFormDV']/div/input[1]"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("arguments[0].click();", elemen);

            Thread.Sleep(2000);
            SwitchToPopUps();
            IWebElement eleme = BrowserDriver.Instance.Driver.FindElement(By.XPath(".//*[@id='ticketsResponsesFormDV']/div/input[2]"));
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("arguments[0].click();", eleme);
            Console.WriteLine("Support Ticket Created Successfully");

        }

        //Update method
        public void EditTicket()
        {
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('supportTicketDescription').value='Edit Support description'");
            BrowserDriver.Instance.Driver.FindElement(By.Name("submitTicket")).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.FindElement(By.Name("closeWindow")).Click();
            Console.WriteLine("Support Ticket Edited Successfully");           
        }

        //Delete Method
        public void Delete()
        {
            BrowserDriver.Instance.Driver.SwitchTo().Frame("HELPDESKTICKETS");
            BrowserDriver.Instance.Driver.SwitchTo().Frame("TICKETLIST");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg){return true;};");

            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Thread.Sleep(2000);
      //      BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
      //      BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
          //  IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
         //   alert.Dismiss();
            Console.WriteLine("Support Ticket Deleted Successfully");
        }

        public void ClickSubmitButton_SupportTicket()
        {
            BrowserDriver.Instance.Driver.SwitchTo().Frame("CONTENT");
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.Id("HELPDESKTICKETS"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@value='Submit']")).Click();
            Thread.Sleep(2000);
        }

    }
}
