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
using System.Diagnostics;
using System.Windows.Forms;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Assurance
{
    class InstallAssurance : BaseActions
    {

        public void AssuranceFunctionality()
        {
            GoToMain("Admin");
            retryingFindClickk(".//*[@id='mnuAssurance_testUpdates']");
            retryingFindClickk(".//*[@id='mnuAssurance_inst']");
            if (true)
            {
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                WaitForElementToVisible(By.XPath("//td[text()='CMP Assurance Test Installation']"));
                Console.WriteLine("Navigation Successful");
                SwitchToPopUps();
                BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
             //   InstallAssuranceFile();
                javascriptClick(By.XPath(General.Default.CancelB));
              Thread.Sleep(2000);
                Console.WriteLine("Admin --> Assurance --> Install Test passed smoke test successfully");
            }

        }

        }

      //  public void InstallAssuranceFile()
       // {
        //    SwitchToPopUps();
        //    BrowserDriver.Instance.Driver.SwitchTo().Frame("MAIN");
        //    BrowserDriver.Instance.Driver.FindElement(By.Name("uploadFile")).Click();
        //    Thread.Sleep(2000);
           // System.Windows.Forms.SendKeys.SendWait("D:\\CMP Automation 6-10-2015\\AutomatedTests\\External\\TangoeContractExpirationNotification");
          //  Process p = System.Diagnostics.Process.Start(txt_Browse.Text + "\\File Upload", DocFileName);
           // p.WaitForExit();

         //   typeDataName("url", "Yoo");
          //  typeDataName("uploadFile", "Yoo");
            //   Process p = System.Diagnostics.Process.Start("D:\\CMP Automation 6-10-2015\\AutomatedTests\\External\\Browser.exe");



          //  p.WaitForExit();
         //   SendKeys.SendWait(@"D:\CMP Automation 6-10-2015\AutomatedTests\External\TangoeContractExpirationNotification.jar");
           // SendKeys.SendWait(@"{Enter}");
            // Process proc = System.Runtime.getRuntime().exec("C:\\Documents and Settings\\nirkumar\\Desktop\\Browse.exe");
            // System.Runtime.getRuntime().exec("rundll32 url.dll,FileProtocolHandler " + "C:\\Documents and Settings\\new.exe"); 

     //
}

