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

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Reporting
{
    class ManageCustomReports : BaseActions
    {
      public void ManageCustomReportsFunctionality()
      {
          GoToMain("Admin");
          retryingFindClickk(".//*[@id='mnu_ReportingAdmin']");
          retryingFindClickk(".//*[@id='mnuCustomReportsIntegration']");
          Thread.Sleep(2000);
          if (true)
          {
              BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
              WaitForElementToVisible(By.XPath("//td[text()='Manage Custom Reports']"));
              Console.WriteLine("Navigation Successful");
              Thread.Sleep(2000);

          }

          if (SaveButtonReport())
          {
              Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Inventory General History']")), "Saving Button Report failed");
              Console.WriteLine("Button Report saved successfully");
              javascriptClick(By.Id("tab2"));
              Thread.Sleep(2000);
              Console.WriteLine("Navigation to Cost Center Hub Reports tab successful");
              SwitchToPopUps();
              javascriptClick(By.Id("tab3"));
              Thread.Sleep(2000);
              Console.WriteLine("Navigation to Custom Reports tab successful");
              SwitchToPopUps();
              javascriptClick(By.XPath(General.Default.CloseB));
              Console.WriteLine("Admin --> Reporting --> Manage Custom Reports passed smoke test successfully");
          }

      }
        
      public Boolean SaveButtonReport()
      {
          SwitchToPopUps();
          javascriptClick(By.XPath("//div[.='Inventory General History']"));
          Thread.Sleep(2000);
          BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
          Thread.Sleep(2000);
          SwitchToPopUps();
          return true;

      }

      public Boolean SaveCostCenterHubReports()
      {
          SwitchToPopUps();
          return true;

      }
    }
}
