using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using AutomatedTests.CMP.Admin;
using System;
using System.Threading;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Tools
{
    class Scheduler : BaseActions
    {
        public void SchedulerFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_Tools']");
            retryingFindClickk(".//*[@id='mnuAdmin_Scheduler']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//div[text()='Scheduler']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Unsuccessful");
            }

            if (CreateScheduler())
            {
                SearchScheduler("nameField", "AB Automation");
                Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='ISI Directory Export']")), "Scheduler creation failed");
                Console.WriteLine("Scheduler create and search successful"); 
            }

            //if (SearchScheduler("nameField","AB Automation"))
            //{
            //    Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB Automation']")), "Scheduler search failed");
            //    Console.WriteLine("Scheduler Search successful");
            //}

            if (DeleteScheduler())
            {
                Assert.IsFalse(IsElementVisible(By.XPath("//div[text()='AB Automation']")), "Scheduler deletion failed");
                Console.WriteLine("Scheduler Deletion successful");
                Console.WriteLine("Admin --> Tools --> Scheduler Passed smoke test successfully");
            }
        }


        public Boolean CreateScheduler()
        {
            SwitchToContent();
            javascriptClick(By.XPath(General.Default.NewB));
            Thread.Sleep(3000);
            SwitchToContent();
           // BrowserDriver.Instance.Driver.FindElement(By.XPath("//input[@id='nameField'])[2]")).SendKeys("AB Automation");
           ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[2].value='AB Automation'");
          ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('type')[1].selectedIndex='1'");
            javascriptClick(By.XPath(General.Default.CreateB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }

        public Boolean SearchScheduler(String type, String name)
        {
            SwitchToContent();
            typeDataName(type,name);
            javascriptClick(By.XPath(General.Default.SubmitB));
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }        
        
        public Boolean DeleteScheduler()
        {
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[text()='AB Automation']")).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.DeleteB)).Click();
            Thread.Sleep(2000);
            SwitchToContent();
            return true;
        }
    }
    }
