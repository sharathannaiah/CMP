using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver.Fully_Automated_Tests.BES_Security_Roles
{
    public class SelfServiceDeviceActions : Setup
    {
        [SetUp]
        public void SetupTest()
        {            
            Common.DeleteSecurityRole(driver, regularUserLastName);
            Console.WriteLine("starting new sec role");
            Common.StartNewSecurityRoleWithNameAndQuery(driver, regularUserLastName, regularUser, BESPlatform);               
        }

        [Test]
        public void AddDevice_Grant()
        {
            driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            driver.FindElement(By.LinkText("BlackBerry Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Add BlackBerry Device']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);
            try
            {
                driver.FindElement(By.XPath("//*[@automationname='Self Service']")).Click();
                /*Common.WaitForElement(driver, By.XPath(".//*[@id='addDeviceBtn']"), 15);
                driver.FindElement(By.XPath("//*[@id='addDeviceBtn']")).Click();*/
                Common.WaitForElement(driver, By.XPath("//*[@automationname='platformSelect']"), 30);
                new SelectElement(driver.FindElement(By.XPath("//*[@automationname='platformSelect']"))).SelectByText(BESPlatform);
                new SelectElement(driver.FindElement(By.XPath("//*[@automationname='vendorSelect']"))).SelectByText(BESCarrier);
                new SelectElement(driver.FindElement(By.XPath("//*[@automationname='deviceSelect']"))).SelectByText(BESDevice);
                driver.FindElement(By.XPath("//*[@automationname='continueBtn']")).Click();
                Common.WaitForElement(driver, By.Id("passwordTxtBx"), 15);
                driver.FindElement(By.Id("passwordTxtBx")).SendKeys(password);
                driver.FindElement(By.Id("confirmPasswordTxtBx")).SendKeys(password);
                driver.FindElement(By.XPath("//*[@class='btnTangoe']")).Click();
                Console.WriteLine("Add Device action is granted for SSP");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }           
            
        }

        [Test]
        public void AddDevice_Deny()
        {
            driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            driver.FindElement(By.LinkText("BlackBerry Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Add BlackBerry Device']/td/input[@name='deny']")).Click();
            driver.FindElement(By.XPath("//button[contains(.,'Save')]")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
           
            LogIntoMDM(driver, regularUser);
            driver.FindElement(By.XPath("//*[@automationname='Self Service']")).Click();
            try
            {
                Common.WaitForElement(driver, By.XPath("//*[@automationname='platformSelect']"), 30);
                //this option "BlackBerry" should not be showed if the deny action works well.
                new SelectElement(driver.FindElement(By.XPath("//*[@automationname='platformSelect']"))).SelectByText(BESPlatform);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Add Device action is denied for BlackBerry devices, test success!");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
             
        [Test]
        public void ShowUsage_Grant()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            driver.FindElement(By.XPath("(//input[@name='isAdminProfileChkBx'])[2]")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            WebDriverWait waitTwo = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            waitTwo.Until<IWebElement>((d) =>
            {
                return d.FindElement((By.XPath(".//*[@id='categoryId_52221394569']/div[2]/table[1]/thead/tr/th[2]")));
            });
            driver.FindElement(By.XPath("//tr[td='Show Usage Information']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();

            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);

            driver.FindElement(By.LinkText("Plans & Usage")).Click();
            WebDriverWait waitThree = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            waitTwo.Until<IWebElement>((d) =>
            {
                return d.FindElement((By.XPath(".//*[@id='deviceUsage']")));
            });


            Console.WriteLine("Device Usage found, success!");
        }


        [Test]
        public void DeleteDevice_Grant()
        {
            driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            driver.FindElement(By.XPath("//tr[td='Delete Device']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);
            driver.FindElement(By.XPath("//*[@automationname='Self Service']")).Click();
            try
            {
                driver.FindElement(By.LinkText("Delete Device")).Click();
                Common.WaitForElement(driver, By.XPath("//button[@type='button']"), 10);
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                Common.WaitForElement(driver, By.XPath(".//*[@id='addDeviceBtn']"), 15);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    
        [Test]
        public void DeleteDevice_Deny()
        {
            driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            driver.FindElement(By.XPath("//tr[td='Delete Device']/td/input[@name='deny']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);
            driver.FindElement(By.XPath("//*[@automationname='Self Service']")).Click();
            try
            {
                driver.FindElement(By.LinkText("Delete Device")).Click();                
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void ShowDeviceDetails_Grant()
        {
            driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            driver.FindElement(By.XPath("//tr[td='Show Device Details']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);
            driver.FindElement(By.XPath("//*[@automationname='Self Service']")).Click();
            try
            {
                driver.FindElement(By.LinkText("Device Details")).Click();
                Common.WaitForElement(driver, By.XPath("//button[@type='button']"), 10);
                driver.FindElement(By.XPath("//button[@type='button']")).Click();              
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
         public void ShowDeviceDetails_Deny()
         {
             driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
             driver.FindElement(By.LinkText("Self-service Portal")).Click();
             driver.FindElement(By.XPath("//tr[td='Show Device Details']/td/input[@name='deny']")).Click();
             driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
             Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
             LoginOut(driver);

             LogIntoMDM(driver, regularUser);
             driver.FindElement(By.XPath("//*[@automationname='Self Service']")).Click();
             try
             {
                 driver.FindElement(By.LinkText("Device Details")).Click();                 
             }
             catch (Exception)
             {
                 Console.WriteLine(" Show device for BES was not show, test success!!");
             }
         }
                
        [Test]
        // a device must be added before run this test grant/deny
        public void ChangeDevice_Grant()
        {
            driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();            
            driver.FindElement(By.XPath("//tr[td='Change Device']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            LogIntoMDM(driver, regularUser);
            try
            {
                driver.FindElement(By.XPath("//*[@automationname='Self Service']")).Click();
                driver.FindElement(By.Id("changeDeviceBtn")).Click(); 
                Common.WaitForElement(driver, By.XPath("//button[@type='button']"), 10);
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                Common.WaitForElement(driver, By.XPath("//*[@automationname='platformSelect']"), 30);
                new SelectElement(driver.FindElement(By.XPath("//*[@automationname='platformSelect']")));
                Console.WriteLine("Add Device action granted, success!");
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void ChangeDevice_Deny()
        {

            driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            driver.FindElement(By.XPath("//tr[td='Change Device']/td/input[@name='deny']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);
            LogIntoMDM(driver, regularUser);
            driver.FindElement(By.XPath("//*[@automationname='Self Service']")).Click();
            // the try block should throw an exception(no such element exception) to warranted that the change device button was not found as expected for deny access.
            try
            {                
                driver.FindElement(By.Id("changeDeviceBtn")).Click();
            }
               
            catch (NoSuchElementException)
            {
                Console.WriteLine("Change Device Button wasn't found, success!");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        
        [Test]
        public void SetDeviceLiability_Deny()
        {
            
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            WebDriverWait waitTwo = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            
            driver.FindElement(By.XPath("//tr[td='Set Device Liability']/td/input[@name='deny']")).Click();
            driver.FindElement(By.LinkText("BlackBerry Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Add BlackBerry Device']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();

            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);
            new SelectElement(driver.FindElement(By.CssSelector("select"))).SelectByText("BlackBerry");
            new SelectElement(driver.FindElement(By.XPath("//table[@id='selectDeviceForm']/tbody/tr[2]/td/select"))).SelectByText("AT&T");
            new SelectElement(driver.FindElement(By.XPath("//table[@id='selectDeviceForm']/tbody/tr[3]/td/select"))).SelectByText("BlackBerry 8700");
            driver.FindElement(By.CssSelector("input.btnTangoe")).Click();
            driver.FindElement(By.Id("indLbRadio")).Click();
            try
            {
                driver.FindElement(By.Id("indLbRadiov"));

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Liability Can't be set, success!");
            }
            
        }

        [Test]
        public void SetDeviceLiability_Grant()
        {
            driver.FindElement(By.CssSelector("button.tangoeBtn.ignoreReadOnlyPermission")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();           
            driver.FindElement(By.XPath("//tr[td='Set Device Liability']/td/input[@name='grant']")).Click();
            driver.FindElement(By.LinkText("BlackBerry Actions")).Click();
            driver.FindElement(By.XPath("//tr[td='Add BlackBerry Device']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();
            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);                
            driver.FindElement(By.Id("indLbRadio")).Click();
            Console.WriteLine("Liability can be set, success!");
        }

   

        [Test]

        public void StepThroughActivationInstructionsAgain_Deny()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            driver.FindElement(By.XPath("(//input[@name='isAdminProfileChkBx'])[2]")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            WebDriverWait waitTwo = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            waitTwo.Until<IWebElement>((d) =>
            {
                return d.FindElement((By.XPath(".//*[@id='categoryId_52221394569']/div[2]/table[1]/thead/tr/th[2]")));
            });
            driver.FindElement(By.XPath("//tr[td='Step through Activation Instructions Again']/td/input[@name='deny']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();

            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);

            try
            {
                driver.FindElement(By.LinkText("View Activation Instructions"));

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("View Activation Instructions Button wasn't found, success!");
            }
            
        }

        [Test]

        public void StepThroughActivationInstructionsAgain_Grant()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            driver.FindElement(By.XPath("(//input[@name='isAdminProfileChkBx'])[2]")).Click();
            driver.FindElement(By.LinkText("Self-service Portal")).Click();
            WebDriverWait waitTwo = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            waitTwo.Until<IWebElement>((d) =>
            {
                return d.FindElement((By.XPath(".//*[@id='categoryId_52221394569']/div[2]/table[1]/thead/tr/th[2]")));
            });
            driver.FindElement(By.XPath("//tr[td='Step through Activation Instructions Again']/td/input[@name='grant']")).Click();
            driver.FindElement(By.XPath("//*[@automationname='tangoeBtnSave']")).Click();

            Common.WaitForElement(driver, By.XPath("//tr[td='" + regularUserLastName + "']/td/input[@type='checkbox']"), 30);
            LoginOut(driver);

            LogIntoMDM(driver, regularUser);

            driver.FindElement(By.LinkText("View Activation Instructions")).Click();
            WebDriverWait waitThree = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            waitTwo.Until<IWebElement>((d) =>
            {
                return d.FindElement((By.XPath(".//*[@id='activationInstructionsParent']")));
            });
            driver.FindElement(By.Id("nextStepBtn")).Click();
            driver.FindElement(By.CssSelector("td..firepath-matching-node")).Click();
            driver.FindElement(By.LinkText("View Activation Instructions")).Click();
            driver.FindElement(By.Id("nextStepBtn")).Click();
            driver.FindElement(By.Id("nextStepBtn")).Click();
            driver.FindElement(By.Id("nextStepBtn")).Click();
            driver.FindElement(By.Id("finalStepBtn")).Click();


            Console.WriteLine("Activation Instructions successfully viewed, success!");

        }

}
}

