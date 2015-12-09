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
           //     ModalTest();
            }

        }

        public void ModalTest()
        {
           // IWebDriver driver = new InternetExplorerDriver();
            BrowserDriver.Instance.Driver.Url = "https://developer.mozilla.org/samples/domref/showModalDialog.html";

            // Get current window handle for switching back after closing the dialog
            string originalHandle = BrowserDriver.Instance.Driver.CurrentWindowHandle;
            IWebElement element = BrowserDriver.Instance.Driver.FindElement(By.TagName("input"));
            element.Click();

            // Wait for the number of window handles to be greater than 1, or a timeout.
            // In Java, this would be something like the following:
            //
            //   long timeoutEnd = System.currentTimeMillis() + 5000;
            //   while (driver.getWindowHandles().size() == 1 && System.currentTimeMillis() < timeoutEnd) {
            //     Thread.sleep(100);
            //   }
            DateTime timeoutEnd = DateTime.Now.Add(TimeSpan.FromSeconds(5));
            while (BrowserDriver.Instance.Driver.WindowHandles.Count == 1 && DateTime.Now < timeoutEnd)
            {
                System.Threading.Thread.Sleep(100);
            }

            // Loop through all window handles, finding the first one that isn't
            // the original window handle, and switching to it. Note that in Java,
            // this would be something like:
            // 
            //   for (string handle : driver.getWindowHandles()) {
            //     if (!handle.equals(originalHandle)) {
            //       driver.switchTo().window(handle);
            //       break;
            //     }
            //   }
            foreach (string handle in BrowserDriver.Instance.Driver.WindowHandles)
            {
                if (handle != originalHandle)
                {
                    BrowserDriver.Instance.Driver.SwitchTo().Window(handle);
                    break;
                }
            }

            // If we've gotten to this point without switching windows, this will
            // throw an exception.
            string textBoxValue = BrowserDriver.Instance.Driver.FindElement(By.Id("foo")).GetAttribute("value");

            // This is an NUnit test case, so we'll Assert here. Java would be similar
            // using either JUnit or TestNG.
            Assert.AreEqual("Dialog value...", textBoxValue);

            // Close the popup, and switch back to the original window.
            BrowserDriver.Instance.Driver.Close();
            BrowserDriver.Instance.Driver.SwitchTo().Window(originalHandle);

            // This page throws a JavaScript alert() when the dialog is closed,
            // so handle that dialog.
            BrowserDriver.Instance.Driver.SwitchTo().Alert().Accept();

            // Quit the driver
        //    BrowserDriver.Instance.Driver.Quit();
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

