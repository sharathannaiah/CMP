using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.BES_Security_Roles
{
    public class GeneralDeviceActions : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting new sec role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, BESPlatform);
        }


        [Test]
        public void UserProfileAndPolicies_Grant()
        {                      
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"),30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);                   
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //select MDM group to joke the system making clickeable details tab
                Console.WriteLine("Access to User Profile Granted!");
                //driver.FindElement(By.XPath(".//*[@id='deviceDetailsTabs']/ul/li[6]/a")).Click();
                //driver.FindElement(By.XPath(".//*[@id='deviceDetailsTabs']/ul/li[1]/a")).Click();
                Console.WriteLine("Access to User Details Granted!");
                Assert.AreEqual("User Detail", driver.FindElement(By.XPath("//*[@automationname='userDetail']")).Text);
                Assert.AreEqual("Update Details", driver.FindElement(By.CssSelector(".tangoeBtn.tangoeBtn-small.pull-right")).Text);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void ViewAlerts_Grant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click(); 
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='View Alerts']/td/input[@name='grant']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"),30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);                
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                Console.WriteLine("Access to User Details Granted!");
                Assert.AreEqual("User Detail", driver.FindElement(By.XPath("//*[@automationname='userDetail']")).Text);
                driver.FindElement(By.XPath(".//*[@automationname='notificationTab']")).Click();
                Console.WriteLine(driver.FindElement(By.Id("notificationTab")).Text);
                Assert.AreNotEqual("This user has no recent Device Notifications in the system.", driver.FindElement(By.Id("notificationTab")).Text);
                //Assert.AreEqual("Notifications", driver.FindElement(By.XPath("//*[@automationname='userDetail']")).Text);
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void ViewAplications_Grant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click(); 
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='View Applications']/td/input[@name='grant']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Thread.Sleep(2000);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //select MDM group to joke the system making clickeable details tab
                Console.WriteLine("Access to User Profile Granted!");
                //driver.FindElement(By.XPath(".//*[@id='deviceDetailsTabs']/ul/li[6]/a")).Click();
                //driver.FindElement(By.XPath(".//*[@id='deviceDetailsTabs']/ul/li[1]/a")).Click();
                Console.WriteLine("Access to User Details Granted!");
                Assert.AreEqual("User Detail", driver.FindElement(By.XPath("//*[@automationname='userDetail']")).Text);
                //this checkbox should be appear only if there is some application to show up.
                if (!Common.IsElementVisible(driver, By.Id("ShowSystemAppsChkbx")))
                {
                    Console.WriteLine("No applications were shown!!");

                }
                else
                {
                    Assert.Fail("The Application option is showed");
                }
            }     
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void ViewUsage_Grant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='View Usage']/td/input[@name='grant']")).Click();
            //save the sec role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Thread.Sleep(2000);
                driver.Navigate().Refresh();
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                Console.WriteLine("Access to User Profile Granted!");
                Console.WriteLine("Access to User Details Granted!");
                Assert.AreEqual("User Detail", driver.FindElement(By.XPath("//*[@automationname='userDetail']")).Text);
                driver.FindElement(By.XPath(".//*[@automationname='usageTab']")).Click();
                //this check if the "Vendor" field is loaded under Usage tab.
                if (Common.IsElementVisible(driver, By.XPath(".//*[@id='usageTab']/div[1]/div[1]/label")))
                {
                    Assert.Fail("*** The Usage Device option is available ***");
                }                
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void WipeDevice_Grant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Wipe Device']/td/input[@name='grant']")).Click();
            //save 
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);                
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //select MDM group to joke the system making clickeable details tab
                Console.WriteLine("Access to User Profile Granted!");
                driver.FindElement(By.XPath(".//*[@id='deviceActionDropDownBtn']/button")).Click();
                Console.WriteLine("Access to User Details Granted!");
                Assert.AreEqual("User Detail", driver.FindElement(By.XPath("//*[@automationname='userDetail']")).Text);
                //verify if the locate device option is available to select.
                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                if(Common.IsElementVisible(driver, By.XPath("//button[contains(.,'Wipe Device')]")))
                {
                    Assert.Fail("*** The Locate Device option is available ***");
                }                
                //driver.FindElement(By.XPath("//button[contains(.,'Reset Enterprise Activation Password')]")).Click();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
                
        [Test]
        public void AddDevice_Grant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Add/Delete/Change Devices']/td/input[@name='grant']")).Click();            
            //save 
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //ask if there is  a device or not
                if (!Common.IsElementVisible(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']")))
                {
                    driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                    driver.FindElement(By.LinkText("Delete Device")).Click();
                    Common.WaitForElement(driver, By.XPath("//button[@type='button']"), 10);
                    driver.FindElement(By.XPath("//button[@type='button']")).Click();
                    Thread.Sleep(2000);
                    Common.WaitForElement(driver, By.ClassName("breadcrumbs"), 30);
                    Common.GoToMenu(driver, value);
                    Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                    driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                    //this sleep time is to be sure that the device which was deleted has been deleted from BES server too after 1 minute.
                    Thread.Sleep(60000);
                }
               
                Common.AddDevice(driver, BESPlatform, BESDevice, password);
                Console.WriteLine("Access to User Profile Granted!");
                Console.WriteLine("A device has been created!");                
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void AddDevice_Deny()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Add/Delete/Change Devices']/td/input[@name='deny']")).Click();
            //save 
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //ask if there is  a device or not
                if (Common.IsElementVisible(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']")) || Common.IsElementVisible(driver, By.XPath(".//*[@title='Add device']")))
                {
                    Assert.Fail("the add device option is available");
                }
                Console.WriteLine("Add device option is denied, test succesfull!");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void DeleteDevice_Grant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Add/Delete/Change Devices']/td/input[@name='grant']")).Click();
            //save 
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //ask if there is  a device or not
                if (Common.IsElementVisible(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']")))
                {
                    Common.AddDevice(driver, BESPlatform, BESDevice, password);
                }                
                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                driver.FindElement(By.LinkText("Delete Device")).Click();
                Common.WaitForElement(driver, By.XPath("//button[@type='button']"), 10);
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                Console.WriteLine("The device has been deleted.");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [Test]
        public void DeleteDevice_Deny()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Add/Delete/Change Devices']/td/input[@name='deny']")).Click();
            //save 
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            // a device must be added to the user as pre condition
            string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
            Common.GoToMenu(driver, value);
            Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
            Common.WaitForElement(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']"), 30);
            //ask if there is  a device or not
            if (Common.IsElementVisible(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']")))
            {
                Common.AddDevice(driver, BESPlatform, BESDevice, password);
            }
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //verify if the delete device is deny 
                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                if( Common.IsElementVisible( driver, By.LinkText("Delete Device")) )
                {
                    Assert.Fail("The Deny test to delete device is failed");
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [Test]
        public void ChangeDevice_Grant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Add/Delete/Change Devices']/td/input[@name='grant']")).Click();
            //save 
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //ask if there is  a device or not
                if (!Common.IsElementVisible(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']")))
                {
                    driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                    driver.FindElement(By.LinkText("Lock Device")).Click();
                    Common.WaitForElement(driver, By.XPath("//button[@type='button']"), 10);
                    driver.FindElement(By.XPath("//button[@type='button']")).Click();
                    Thread.Sleep(2000);
                }
                Common.AddDevice(driver, BESPlatform, BESDevice, password);               
                Console.WriteLine("The device has been changed!");
            }
                
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void ChangeDevice_Deny()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("General Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='View Profiles and Policies']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Add/Delete/Change Devices']/td/input[@name='deny']")).Click();
            //save 
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            // a device must be added to the user as pre condition
            string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
            Common.GoToMenu(driver, value);
            Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
            Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
            //ask if there is  a device or not
            if (Common.IsElementVisible(driver, By.XPath("//*[@automationname='tangoeBtnAddDevice']")))
            {
                Common.AddDevice(driver, BESPlatform, BESDevice, password);
            }
            LoginOut(driver);
            //go to security role with that user
            LogIntoMDM(driver, regularUser);
            // verify if the user has allow access to user profile page.
            try
            {
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 30);
                //verify if the delete device is deny 
                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                if (Common.IsElementVisible(driver, By.LinkText("Change Device")))
                {
                    Assert.Fail("The Deny test to change device is failed");
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
    }
}
