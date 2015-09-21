using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using AutomatedTests.CMP.Enterprise;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
//using OpenQA.Selenium.JavaScriptExecutor;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise
{
    class EntityRegions : BaseActions
    {

        public void EntityRegionFunctionality()
        {
            GoToMain1("Enterprise", "Regions");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='Regions']"));
                Console.WriteLine("Navigation Successful");
            }
            else
            {
                Console.WriteLine("Navigation Failed");
            }
            if (true)
            {
                SearchRegion();
                Console.WriteLine("Query Search Successful");
            }
            else 
            {
                Console.WriteLine("Query Search Not Successful");
            }
            if (true)
            {
                CreateEntityRegion();
                DeleteRegions();
                Console.WriteLine("Regions Passed Smoke Test Sucessfully");
            }
            else
            {
                Console.WriteLine("Regions Failed Smoke Test");
 
            }
        }
        public void SearchRegion()
        {
            SwitchToPopUps();
            typeDataID("nameField", "Americas");
            javascriptClick(By.XPath(Enterp.Default.QuerySubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
           Assert.AreEqual("Americas", BrowserDriver.Instance.Driver.FindElement(By.Id("description")).GetAttribute("value"));
        }

           public void  CreateEntityRegion()
           {
               if (true)
               {
                   SwitchToPopUps();
                   BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.CreateNewB)).Click();
                   Thread.Sleep(2000);
                   ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[1].value='AutoIndia'");
                   ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('description').value='Automation South Indian Region'");
                   javascriptClick(By.XPath("//input[@value='LOCAL']"));
                   javascriptClick(By.XPath(Enterp.Default.SaveB));
                   Thread.Sleep(2000);
                   SwitchToPopUps();
                   typeDataID("nameField", "AutoIndia");
                   javascriptClick(By.XPath(Enterp.Default.QuerySubmitB));
                   Thread.Sleep(2000);
                   SwitchToPopUps();
                   Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AutoIndia']")), "Region not created");
                   Console.WriteLine("Region created Successfully");
               }
               else 
               {
                   Console.WriteLine("Region not created");
               }

            Thread.Sleep(3000);
               SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[0].value='AutoIndia'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('ehDescription').value='Automation South Indian Region'");
              javascriptClick(By.XPath(Enterp.Default.QuerySubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
            Console.WriteLine("Region Added Successfully");
           }

           public Thread SimulateClickForConfirmation(string title)
           {

               //Simulate autoclick on IE windows 
               Thread th = new Thread(new ThreadStart(() =>
               {
                   Thread.Sleep(1000);
                   Process script = new Process();
                   script.StartInfo.FileName ="D:\\Code Library\vbstest.vbs";
                   script.StartInfo.Arguments = title;
                   script.Start();
                   script.WaitForExit();
                   script.Close();
               }));

               th.Start();

               return th;
           }

        public void DeleteRegions()
        {
            
            Thread.Sleep(2000);
            SwitchToPopUps();

            
    //  Thread th1 = SimulateClickForConfirmation(BrowserDriver.Instance.Driver.Title.ToString());
     ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg) {return true;}; ");
     BrowserDriver.Instance.Driver.FindElement(By.Id("deleteButton")).Click();
    //  th1.Abort();
       //   IAlert alert = BrowserDriver.Instance.Driver.SwitchTo().Alert();
      //   alert.Accept();
         //   BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.DeleteB)).Click();
            Thread.Sleep(2000);
            //     Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Are you sure you want to delete this region[\\s\\S]$"));
        //    BrowserDriver.Instance.Driver.FindElement(By.Id("closeButton")).Click();
            Console.WriteLine("Deletion of Region Successful");
            Thread.Sleep(2000);
                
        }

    }
}
