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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management
{
    class GLNumber: BaseActions

    {
        public void GLNumberFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAdmin_BillMgmt']");
            retryingFindClickk(".//*[@id='mnuAcctng_glNumberConfigModal']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='GL Number Configuration']"));
                Console.WriteLine("Navigation Successful");
            }

            if (NewGLNumber())
            {

                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='AB GLName']")), "GL Number configuration creation failed");
                Console.WriteLine("GL Number configuration created successfully");
                javascriptClick(By.XPath("//span[text()='AB GLName']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                typeDataName("configurationName", "Edited ABGLName");
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Edited ABGLName']")), "GLNumber edition failed");
                Console.WriteLine("GLNumber edition successful");
                javascriptClick(By.XPath(General.Default.CloseB));
                Console.WriteLine("Admin --> Bill Management --> GL number formatting deleted successfully");
            }


            //if (DeleteGLNumber())
            //{
            //    Thread.Sleep(2000);
            //    SwitchToPopUps();
            //    Assert.IsFalse(IsElementVisible(By.XPath("//span[text()='Edited GLNumber']")), "GL Number configuration deletion failed");
            //    Console.WriteLine("GLNumber configuration deletion successful");
            //    Console.WriteLine("Admin --> Bill Management --> GL number formatting deleted successfully");

            //}
        }

        public Boolean NewGLNumber()
        {
            SwitchToPopUps();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
            typeDataName("configurationName", "AB GLName");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.OKB)).Click();
            Thread.Sleep(2000);
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
            BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
            SwitchToPopUps();
            return true;
        }


        public Boolean DeleteGLNumber()
        {
            SwitchToPopUps();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.confirm = function(deleteGLNumberConfiguration) {return true;};");
            javascriptClick(By.XPath(General.Default.DeleteB));
            Thread.Sleep(2000);
            return true;
        }

             public void AddGLSection()

             
             {
                javascriptClick(By.XPath("//span[text()='Edited ABGLName']"));
                Thread.Sleep(2000);
                SwitchToPopUps();
                javascriptClick(By.XPath(General.Default.AddB));
                typeDataID("sectionName", "ABGL");
                BrowserDriver.Instance.Driver.FindElement(By.Id("sectionLength")).Click();
                typeDataName("sectionLength", "9");
                BrowserDriver.Instance.Driver.FindElement(By.Id("sectionLength")).Click();
                javascriptClick(By.XPath(General.Default.SaveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='ABGL']")), "Adding GLNumber failed");
                Console.WriteLine("GL Number added successfully");
                javascriptClick(By.XPath(General.Default.RemoveB));
                Thread.Sleep(2000);
                SwitchToPopUps();
                Assert.IsFalse(IsElementVisible(By.XPath("//td[text()='ABGL']")), "Removing GLNumber failed");
                Console.WriteLine("GL Number deleted successfully");
            
}
    }
}
