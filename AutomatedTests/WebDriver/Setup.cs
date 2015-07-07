using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTests.WebDriver
{
    //This is the Super class called "Setup", this class is the inheritance of methods and configuration which are common for any test, before and after run any test.
    //Also this class setting the initialization of the variables with the config data and allows the use of any variable on the whole project.
    public class Setup
    {
        public IWebDriver driver;
        public string url = System.Configuration.ConfigurationManager.AppSettings["baseURL"];
        public string user = System.Configuration.ConfigurationManager.AppSettings["user"];
        public string password = System.Configuration.ConfigurationManager.AppSettings["password"];
        public string SQLServer = System.Configuration.ConfigurationManager.AppSettings["SQLServer"];
        //GMM variables
        public string GMMName = System.Configuration.ConfigurationManager.AppSettings["GMMName"];
        public string GMMHttp = System.Configuration.ConfigurationManager.AppSettings["GMMHttp"];
        public string MaxUser = System.Configuration.ConfigurationManager.AppSettings["MaxUser"];
        public string GMMUser = System.Configuration.ConfigurationManager.AppSettings["GMMUser"];
        public string GMMPlatform = System.Configuration.ConfigurationManager.AppSettings["GMMPlatform"];
        public string GMMDevice = System.Configuration.ConfigurationManager.AppSettings["GMMDevice"];
        //BES variables
        public string BESName = System.Configuration.ConfigurationManager.AppSettings["BESName"];
        public string BESHttp = System.Configuration.ConfigurationManager.AppSettings["BESHttp"];
        public string BESVersion = System.Configuration.ConfigurationManager.AppSettings["BESVersion"];
        public string BESUser = System.Configuration.ConfigurationManager.AppSettings["BESUser"];
        public string BESMgmt = System.Configuration.ConfigurationManager.AppSettings["BESMgmt"];
        public string DBUser = System.Configuration.ConfigurationManager.AppSettings["DBUser"];
        public string BESPlatform = System.Configuration.ConfigurationManager.AppSettings["BESPlatform"];
        public string BESDevice = System.Configuration.ConfigurationManager.AppSettings["BESDevice"];
        public string BESCarrier = System.Configuration.ConfigurationManager.AppSettings["BESCarrier"];
        public string BESApplicationName = System.Configuration.ConfigurationManager.AppSettings["BESApplicationName"];
        //EAS vars
        public string EASPlatform = System.Configuration.ConfigurationManager.AppSettings["EASPlatform"];
        public string EASPlatformClient = System.Configuration.ConfigurationManager.AppSettings["EASPlatformClient"];
        public string EAS2010DomainServer = System.Configuration.ConfigurationManager.AppSettings["EAS2010DomainServer"];
        public string EAS2010DomainAdmin = System.Configuration.ConfigurationManager.AppSettings["EAS2010DomainAdmin"];
        public string EAS2010DomainPass = System.Configuration.ConfigurationManager.AppSettings["EAS2010DomainPass"];
        public string EAS2010ServerFQDN = System.Configuration.ConfigurationManager.AppSettings["EAS2010ServerFQDN"];
        public string EAS2010ServerName = System.Configuration.ConfigurationManager.AppSettings["EAS2010ServerName"];

        //security role's user
        public string regularUser = System.Configuration.ConfigurationManager.AppSettings["regularUser"];
        public string regularUserLastName = System.Configuration.ConfigurationManager.AppSettings["regularUserLastName"];

        [SetUp]
        public void Login()
        {
            driver = new InternetExplorerDriver();
            try
            {
                //Run before any test
                driver.Navigate().GoToUrl(url + "MDM");
                driver.FindElement(By.Id("userNameTextBox")).SendKeys(user);
                driver.FindElement(By.Id("passwordTextBox")).SendKeys(password);
                driver.FindElement(By.Id("loginBtn")).Click();
                Common.WaitForElement(driver, By.ClassName("breadcrumbs"), 30);                
            }
            catch (TimeoutException e)
            {
                System.Console.WriteLine("TimeoutException: " + e.Message);
                Assert.Fail(e.Message);
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail(e.Message);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("unhandled exception: " + e.Message);
                Assert.Fail(e.Message);
            }
        }        
        
        /*
        [TearDown]
        public void TearDown()
        {
            //Run after any test            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            driver.FindElement(By.XPath("//*[@id='metaNav']/ul/li[1]/a")).Click();
            Console.WriteLine("Logging out MDM");
            wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("userNameTextBox"));
            });
            driver.Quit();
        }*/
        // for common user
        public void LogIntoMDM(IWebDriver driver, string user)
        {            
            driver.Navigate().GoToUrl(url + "MDM");
            driver.FindElement(By.Id("userNameTextBox")).SendKeys(user);
            driver.FindElement(By.Id("passwordTextBox")).SendKeys(password);
            driver.FindElement(By.Id("loginBtn")).Click();
            Console.WriteLine("Logging in using the regular user: " + user);
            Common.WaitForElement(driver, By.ClassName("breadcrumbs"), 30);            
        }

        public void LoginOut(IWebDriver driver)
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //driver.FindElement(By.XPath("//*[@id='metaNav']/ul/li[1]/a")).Click();
            driver.FindElement(By.XPath("//a[.='Sign Out']")).Click();
            Console.WriteLine("Logging out MDM");
            //driver.FindElement(By.XPath("//a[.='Sign Out']")).Click();
            //driver.Navigate().GoToUrl(url + "MDM/Home/Logout");
            Common.WaitForElement(driver, By.Id("userNameTextBox"), 30);
        }

        
    }
}
