using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace AutomatedTests.WebDriver.Fully_Automated_Tests.GMM_Android_Security_Roles
{
    public class AndroidDeviceActions : Setup
    {
        [SetUp]
        public void SetupTest()
        {
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting New Security Role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, GMMPlatform);

        }

        [Test]
        public void LockDeviceGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Android Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Lock Device']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Good Mobile Messaging Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Regenerate Good OTA PIN']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Wipe Good Mobile Messaging data']/td/input[@name='grant']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            System.Threading.Thread.Sleep(6000);
            LoginOut(driver);
           LogIntoMDM(driver, regularUser);


            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 50);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                System.Threading.Thread.Sleep(5000);// Added code to make browser wait.
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 10);
                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                if (Common.IsElementVisible(driver, By.LinkText("Lock Device")))
                {
                    Console.WriteLine("Test case FAILED. Lock Device shouldn't be available.");
                }
            
            }catch (NoSuchElementException)
            {
                Console.WriteLine("Lock Device command wasn't found, success");
            }


            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        
    
        [Test]
        
        public void ResetDevicePasswordGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Android Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Reset Device Password']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Good Mobile Messaging Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Regenerate Good OTA PIN']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Wipe Good Mobile Messaging data']/td/input[@name='grant']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            System.Threading.Thread.Sleep(6000);//Making browser to wait after clicking on save button . 
            LoginOut(driver);
            LogIntoMDM(driver, regularUser);
            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                System.Threading.Thread.Sleep(9000);// Added code to make the browser wait.
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 10);

                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                if (Common.IsElementVisible(driver, By.LinkText("Reset Device Password")));
                    Console.WriteLine("Test case FAILED. Reset Device Password shouldn't be available.");
                }
            
            catch (NoSuchElementException)
            {
                Console.WriteLine("Reset Device Password command wasn't found, success");
            }


            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }


        [Test]
        public void WipeTouchdownDataGrant()
        {
            driver.FindElement(By.LinkText("User Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User List']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Access To User Profiles']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Android Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Wipe TouchDown Data']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("Good Mobile Messaging Device Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Regenerate Good OTA PIN']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//tr[td='Wipe Good Mobile Messaging data']/td/input[@name='grant']")).Click();
            //save the Security Role
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            System.Threading.Thread.Sleep(6000);//Making browser to wait after clicking on save button
            LoginOut(driver);
            LogIntoMDM(driver, regularUser);


            try
            {
                string value = driver.FindElement(By.XPath("//a[.='User List']")).GetAttribute("webpage").ToString();
                Common.GoToMenu(driver, value);
                Common.WaitForElement(driver, By.XPath("//a[.='" + regularUserLastName + "']"), 30);
                driver.FindElement(By.XPath("//a[.='" + regularUserLastName + "']")).Click();
                System.Threading.Thread.Sleep(9000);// Added code to make the browser wait.
                Common.WaitForElement(driver, By.XPath("//*[@automationname='userDetail']"), 10);
                //ask if there is  a device or not
                driver.FindElement(By.XPath("//button[contains(.,'Device Actions')]")).Click();
                if (Common.IsElementVisible(driver, By.LinkText("Wipe TouchDown Data")));
                    Console.WriteLine("Test case FAILED. Wipe Touchdown Data shouldn't be available.");
                }
            
            catch (NoSuchElementException)
            {
                Console.WriteLine("Lock Device command wasn't found, success");
            }


            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
    } 
}
