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
using AutomatedTests.CMP.Enterprise;
using AutomatedTests.CMP.Admin;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.EmployeePortal
{
    class EmployeeLogin : BaseActions
    {
        public void EmployeeLoginn()
        {

      //    Navigation("Enterprise", ".//*[@id='mnuEnterprise_Employees']", ".//*[@id='mnuEmployees_Explorer']", "//div[text()='Employee Management']");
            Console.WriteLine("Employee --> Explorer Navigation successful");
            BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            javascriptClick(By.XPath(".//*[@id='utilLogOff']"));
            Thread.Sleep(2000);


            //    if (CreateEmployee() == true)
            //    {
            //        SwitchToContent();
            //        EmployeeSearch("AB", "Automation");
            //        Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='AB']")), "Employee Creation Failed");
            //        Console.WriteLine("Employee Created Successfully");
            //    }

            //if (CreateEmployeeLogin("Employee123") == true)
            //{
            //    SwitchToContent();
            //    BrowserDriver.Instance.Driver.SwitchTo().Frame("QUERYUSERS");
            //    typeDataName("nameField", "AB1");
            //    BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
            //    Thread.Sleep(3000);
            //    SwitchToContent();
            //    BrowserDriver.Instance.Driver.SwitchTo().Frame("ADMIN_EXPLORER");
            //    Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Employee123']")), "Creation of Employee Login failed");
            //    Console.WriteLine("Employee Portal Login Created");
            //}

            //if (CheckConfiguration() == true)
            //{
            //    Console.WriteLine("Configuration settings are saved for Employee Portal Login");
            //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //    javascriptClick(By.XPath(".//*[@id='utilLogOff']"));
            //    Thread.Sleep(2000);
            //}


            //if (EmployeeAdminLogin() == true)
            //{

            //    Console.WriteLine("Employee Admin Login Successful");
            //    AcceptInventory();
            //    //Assert.IsTrue(IsElementVisible(By.XPath("//div[text()='Active']")), "Accepting Inventory failed");
            //    Console.WriteLine("Accepting Inventory Successful");
               
            //}

            //if (AssignEmployee() == true)
            //{
            //    BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
            //    javascriptClick(By.XPath(".//*[@id='utilLogOff']"));
            //    Console.WriteLine("Assigned new inventory to Employee AB1 Successfully");
            //}

            if (EmployeePortalLogin() == true)
            {
                Console.WriteLine("Employee AB1 Logged in Successfully");
                
            }
        }

        public Boolean CreateEmployee()
        
            {
                SwitchToContent();
                BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.CreateNewB)).Click();
                Thread.Sleep(3000);
                SwitchToContent();
                Assert.IsTrue(IsElementVisible(By.Id("tabEmployee")), "Unable to display create new entity details table");
                BrowserDriver.Instance.Driver.SwitchTo().Frame("EMPLOYEE");
                System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
                int random = rand.Next(1, 100000000);
                typeDataName("employeeIdentifier", "12345" + RandomNumbergeneratorL());
                typeDataName("firstName", "AB");
                typeDataName("lastName", "Automation");
                ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('contactTypeId')[0].selectedIndex = 1;");
                BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.SaveB)).Click();
                BrowserDriver.Instance.Driver.SwitchTo().ActiveElement();
                Thread.Sleep(4000);
                return true; 
            

        }
          public void EmployeeSearch(String text, String lastName)
        {
            SwitchToContent();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('firstName')[0].value='"+ text +"'");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.ResetB)).Click();
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('firstName')[0].value='" + text + "'");
            ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("document.getElementsByName('lastName')[0].value='" + lastName + "'");
            BrowserDriver.Instance.Driver.FindElement(By.Name("employeeIdentifier")).Clear();
            BrowserDriver.Instance.Driver.FindElement(By.XPath(Enterp.Default.QuerySubmitB)).Click();
            Thread.Sleep(5000);
            SwitchToContent();
            Assert.IsTrue(IsElementVisible(By.XPath("//div[.='"+ text +"']")), "Employee Search failed");
        }

          public Boolean CreateEmployeeLogin(String LoginID)
          {
              BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
              Navigation("Admin", ".//*[@id='mnuAdmin_SystemAdmin']", ".//*[@id='mnuAdmin_Security']", "//div[text()='Select User/Group']");
              Console.WriteLine("System Admin --> Users and Groups Navigation successful");  
              SwitchToContent();
              IWebElement admin = BrowserDriver.Instance.Driver.FindElement(By.Id("ADMIN_EXPLORER"));
              BrowserDriver.Instance.Driver.SwitchTo().Frame(admin);
              BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.NewB)).Click(); 
              Thread.Sleep(2000); 
            BrowserDriver.Instance.Driver.SwitchTo().Frame("GENERAL");
            typeDataName("logonId", LoginID);
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("providerId"))).SelectByText("CMP Native Security");
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("contactTypeId"))).SelectByText("Employee Contact");
            typeDataName("password", "12345");
            typeDataName("passwordRetype", "12345");
            javascriptClick(By.Name("masterAdministrator"));
            typeDataName("phone1", "777");
          //  javascriptClick(By.XPath("//input[@name='createContact'])[2]"));
            typeDataID("dtControlcontactIdRef", "AB Automation");
            Thread.Sleep(4000);
            typeDataName("firstName", "AB1");
            typeDataName("lastName", "Automation"+RandomNumbergeneratorL());
            new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("contactTypeId"))).SelectByText("Employee Contact");
            BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
            Thread.Sleep(2000);
               return true;
          }

          public void Navigation(String Menu, String Submenu, String Submenu1, String Title) 
          {
              GoToMain(Menu);
              retryingFindClickk(Submenu);
              retryingFindClickk(Submenu1);
              if (true)
              {
                  SwitchToContent();
                  WaitForElementToVisible(By.XPath(Title));
                  Assert.IsTrue(IsElementVisible(By.XPath(Title)), "Navigation failed");
                  Thread.Sleep(2000);
              }
          }
          public void Navigation1(String Menu, String Submenu, String Submenu1, String Title)
          {
              GoToMain(Menu);
              retryingFindClickk(Submenu);
              retryingFindClickk(Submenu1);
              if (true)
              {
                  WaitForElementToVisible(By.XPath(Title));
                  Assert.IsTrue(IsElementVisible(By.XPath(Title)), "Navigation failed");
                  Thread.Sleep(2000);
              }
          }

              public Boolean CheckConfiguration()
              {
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  Navigation1("Admin", ".//*[@id='mnu_Portal']", ".//*[@id='mnuEmployeePortal_Config']", "//div[text()='Configuration']");
                  SwitchToContent();
                  javascriptClick(By.Id("tab2"));
                  Thread.Sleep(2000);
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("REGISTRATION_CONFIGURATION");
                  IWebElement element = BrowserDriver.Instance.Driver.FindElement(By.Id("allowExistingUsersRegistration"));
                  if (!element.Selected)
                  {
                      element.Click();
                      ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.alert =  function(msg) {return true;};");
                      javascriptClick(By.XPath(General.Default.SaveB));
                      Thread.Sleep(2000); 
                  }

                  SwitchToContent();
                  javascriptClick(By.Id("tab3"));
                  Thread.Sleep(2000);
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("EXPENSE_CONFIGURATION");
                  IWebElement element4 = BrowserDriver.Instance.Driver.FindElement(By.Id("dataHandling"));
                  if (!element4.Selected)
                  {
                      element4.Click();
                      ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.alert =  function(msg) {return true;};");
                      javascriptClick(By.XPath(General.Default.SaveB));
                      Thread.Sleep(2000);
                  }

                  IWebElement element1 = BrowserDriver.Instance.Driver.FindElement(By.Id("productHandling"));
                  if (!element1.Selected)
                  {
                      element1.Click();
                      ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.alert =  function(msg) {return true;};");
                      javascriptClick(By.XPath(General.Default.SaveB));
                      Thread.Sleep(2000);
                  }

                  IWebElement element2 = BrowserDriver.Instance.Driver.FindElement(By.Id("inventoryHandling"));
                  if (!element2.Selected)
                  {
                      element2.Click();
                      ((IJavaScriptExecutor)BrowserDriver.Instance.Driver).ExecuteScript("window.alert =  function(msg) {return true;};");
                      javascriptClick(By.XPath(General.Default.SaveB));
                      Thread.Sleep(2000);
                  }
                  return true;
              }


              public Boolean EmployeeAdminLogin()
              {
                  Thread.Sleep(4000);
                  Login1();
                  return true;
                  
              }

              public void AcceptInventory()
              {
                  GoToMain("Inventory");
                  retryingFindClickk(".//*[@id='mnuInventory_DiscoverInventory']");
                  Thread.Sleep(2000);
                  SwitchToContent();
                  new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Name("inventoryType"))).SelectByText("Wireless");
               //   SelectfromDropdownByName("inventoryType", "10");
                  Thread.Sleep(4000);
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
                  BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                  Thread.Sleep(4000);
                  SwitchToContent();
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                  javascriptClick(By.CssSelector("input.multiSelectRow"));
                  BrowserDriver.Instance.Driver.FindElement(By.Id("acceptButton")).Click();
                  Thread.Sleep(3000);
                  SwitchToPopUps(); 
                  retryingFindClick(By.Id("nextButton"));
                  Thread.Sleep(4000);
                  SelectfromDropdownByName("flexibleMappingSource", "0");
                  retryingFindClick(By.Id("nextButton"));
                  Thread.Sleep(3000);
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  IWebElement ele = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd1 iframe"));
                  BrowserDriver.Instance.Driver.SwitchTo().Frame(ele);
                  //   Assert.IsTrue(IsElementVisible(By.XPath("//td[text()='Accepted OTHER']")), "Accept failed");
                  // BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                  //    BrowserDriver.Instance.Driver.SwitchTo().Frame("OTHER_GENERAL");
                  Thread.Sleep(4000);
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("WIRELESS_GENERAL");
                //  SelectfromDropdownByName("typeLookupId", "1");
                  IWebElement dropDownListBox = BrowserDriver.Instance.Driver.FindElement(By.Name("typeLookupId"));
                  SelectElement clickThis = new SelectElement(dropDownListBox);              
                  clickThis.SelectByText("Cellular");
                  Thread.Sleep(2000);
                  typeDataName("phoneNumber", "7777777"+RandomNumbergeneratorL());
                  retryingFindClick(By.XPath(General.Default.SaveB));
                  Thread.Sleep(4000);
                  SwitchToContent();
                  BrowserDriver.Instance.Driver.Navigate().Refresh();
                  Thread.Sleep(2000);
             //     javascriptClick(By.XPath(General.Default.CloseB));

              }


              public Boolean AssignEmployee()
              {
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  GoToMain("Inventory");
                  retryingFindClickk(".//*[@id='mnuInventory_ExplorerServices']");
                  Thread.Sleep(3000);
                  SwitchToContent();
                  new SelectElement(BrowserDriver.Instance.Driver.FindElement(By.Id("inventoryType"))).SelectByText("Wireless");
                  SelectfromDropdownByText("inventoryType", "Wireless");
                  Thread.Sleep(3000);
                  SwitchToContent();
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("INV_QUERY_FRAME");
                  typeDataName("phoneNumberPattern", "7777777");
                  BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SubmitB)).Click();
                  Thread.Sleep(3000); 
                  SwitchToContent();
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                  javascriptClick(By.Id("tab3"));
                  Thread.Sleep(2000);
                  SwitchToContent();
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("WIRELESS_EMPLOYEES");
                  javascriptClick(By.XPath(General.Default.AddB));
                  Thread.Sleep(3000);
                  SwitchToPopUps();
                  javascriptClick(By.Id("imgLookupemployeeId"));
                  Thread.Sleep(5000);
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  IWebElement ele1 = BrowserDriver.Instance.Driver.FindElement(By.CssSelector("#dWnd2 iframe"));
                  BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
                  typeDataName("firstName", "AB1");
                  Thread.Sleep(1000);
                  javascriptClick(By.XPath(General.Default.SubmitB));
                  Thread.Sleep(5000);
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.SwitchTo().Frame(ele1);
                  javascriptClick(By.XPath(General.Default.OKB)); 
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  SwitchToPopUps();
                  typeDataID("dtControleffectiveDate", "01/01/2005");
                  Thread.Sleep(1000);
                  javascriptClick(By.XPath(General.Default.OKB));
                  Thread.Sleep(4000);
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  SwitchToContent();
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                  javascriptClick(By.Id("tab1"));
                  Thread.Sleep(3000);
                  SwitchToContent();
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("INVENTORY_EXPLORER");
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("WIRELESS_GENERAL");
                  typeDataName("phoneNumber", "7777777777");
                  IWebElement dropDownListBox = BrowserDriver.Instance.Driver.FindElement(By.Name("typeLookupId"));
                  SelectElement clickThis = new SelectElement(dropDownListBox);              
                  clickThis.SelectByText("Cellular"); 
                  BrowserDriver.Instance.Driver.FindElement(By.XPath(General.Default.SaveB)).Click();
                  return true; 
              }

              public Boolean EmployeePortalLogin()
              {
                  LoginEmployeePortal();
                  SwitchToContent();
                  BrowserDriver.Instance.Driver.SwitchTo().Frame("billingHublet");
                  Assert.IsTrue(IsElementVisible(By.XPath("//span[text()='Cellular']")), "Employee Portal Billing Assignment failed");
                  BrowserDriver.Instance.Driver.SwitchTo().DefaultContent();
                  BrowserDriver.Instance.Driver.FindElement(By.Id("billingnav")).Click();
                  return true;
              }

          }
    }

