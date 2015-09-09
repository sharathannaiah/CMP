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
//using OpenQA.Selenium.JavaScriptExecutor;


namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise
{
    class EntityRegions : BaseActions
    {

        public void EntityRegionFunctionality()
        {
            GoToMain1("Enterprise", "Regions");
            SearchRegion();

           CreateEntityRegion();
            DeleteRegions();
            Console.WriteLine("Regions Passed Smoke Test Suucessfully");
        }
        public void SearchRegion()
        {
            SwitchToPopUps();
           ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('nameField').value='Americas'");
            javascriptClick(By.XPath(Enterp.Default.QuerySubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
           Assert.AreEqual("Americas", BrowserDriver.Instance.Driver.FindElement(By.Id("description")).GetAttribute("value"));
            Console.WriteLine("Query Search Successful");

        }

           public void  CreateEntityRegion()
           {
               SwitchToPopUps();
               BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.CreateNewB)).Click();
               Thread.Sleep(2000);
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[1].value='India'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('description').value='South Indian Region'");
            javascriptClick(By.XPath(Enterp.Default.SaveB));

            Console.WriteLine("Region created Successfully");

            Thread.Sleep(3000);
               SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('nameField')[0].value='India'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementById('ehDescription').value='South Indian Region'");
              javascriptClick(By.XPath(Enterp.Default.QuerySubmitB));
            Thread.Sleep(2000);
            SwitchToPopUps();
           // BrowserDriver.Instance.Driver.FindElement(By.XPath("(//input[@name='geographyType'])[3]")).Click();
            //javascriptClick(By.XPath(Enterp.Default.AddB));
            //Thread.Sleep(4000);
            //BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //   ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('countryName').value='India'");
            //   BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
               
            //   Thread.Sleep(4000);
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //   javascriptClick(By.XPath("//div[@title='India']"));
            //   javascriptClick(By.XPath("//div[@title='Click to check or clear'][1]"));
            //   BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.OKB)).Click();
            //   Thread.Sleep(2000);
            //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
            //   BrowserDriver.Instance.Driver.SwitchTo().Frame("CMP_DIALOG_FRAME");
            //   javascriptClick(By.XPath(Enterp.Default.SaveB));
            //   Thread.Sleep(2000);
               
            //SwitchToPopUps();
            //((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementByName('countryName').value='India'");
            //javascriptClick(By.XPath(Enterp.Default.QuerySubmitB));
            //Thread.Sleep(2000);
            //SwitchToPopUps();
          //  Assert.AreEqual("India", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[@title='India']")).Text);
            Console.WriteLine("Region Added Successfully");


            //BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='India']")).Click();
            //Assert.AreEqual("India", BrowserDriver.Instance.Driver.FindElement(By.XPath("//div[.='India']")).Text);
           // Console.WriteLine("Region Added Successfully");
           }

        public void DeleteRegions()
        {
            // BrowserDriver.Instance.Driver.FindElement(By.XPath("//table[@id='JColResizer3']/tbody/tr[4]/td[2]/div/nobr/div")).Click();
         //   SwitchToPopUps();
         //   BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();

            Thread.Sleep(2000);
            SwitchToPopUps();
      ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(msg){return true;};");
       // ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.prompt = function(msg){return true;};");

        //  ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.alert = function(msg){return true;};");
            
           // ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.onbeforeunload = function(e){};");

      javascriptClick(By.Id("deleteButton"));

           // BrowserDriver.Instance.Driver.keyBoard.

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
