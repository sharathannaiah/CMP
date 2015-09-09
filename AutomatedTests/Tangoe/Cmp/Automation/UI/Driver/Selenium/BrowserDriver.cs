using System;
using System.Reflection;
using AutomatedTests.Tangoe.Cmp.Automation.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.IE;

namespace AutomatedTests.Tangoe.Cmp.Automation.UI.Driver.Selenium
{
    /// <summary>
    /// Singleton implementation of the Selenium IWebDriver. The type of the driver should be specified
    /// in the seleniumDriver property in the config file. The full package name of the driver should be
    /// specified or loading it will fail.
    /// </summary>
    public sealed class BrowserDriver
    {
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }
        
        private static readonly Lazy<BrowserDriver> lazy = new Lazy<BrowserDriver>(() => new BrowserDriver());

        public static BrowserDriver Instance { get { return lazy.Value; } }

        /// <summary>
        /// Read two properties: 
        ///     DriverAssembly which is the name of the Assembly containing the driver class
        ///     DriverType which is the full name of the driver to load
        /// Create an instance of the driver and use it for the tests
        /// </summary>
        private BrowserDriver()
        {

            String driverType = TestProperties.Instance.GetPropertyByName(TestProperty.seleniumDriver);
            //  String driverType = TestProperties.Instance.GetPropertyByName(TestProperty.seleniumDriver);
            String driverAssembly = TestProperties.Instance.GetPropertyByName(TestProperty.seleniumDriverAssembly);
            Assembly assembly = Assembly.Load(driverAssembly);
            Type t = assembly.GetType(driverType);


            if (driverType == "OpenQA.Selenium.IE.InternetExplorerDriver")
            {
                InternetExplorerOptions options = new InternetExplorerOptions();

                options.EnableNativeEvents = false;
                options.EnablePersistentHover = false;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.RequireWindowFocus = true;
              
              //  options.EnablePersistentHover = true;
                
                options.EnsureCleanSession = true;

                //options.UnexpectedAlertBehavior = "dismiss";
                options.IgnoreZoomLevel = true;

                //DesiredCapabilities capabilities = new DesiredCapabilities();
                //capabilities = DesiredCapabilities.InternetExplorer();
                //capabilities.SetCapability("INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS", true);

                driver = (IWebDriver)Activator.CreateInstance(t, new object[] { options });
            }
            else
            {
                driver = (IWebDriver)Activator.CreateInstance(t);
            }






            //if (driverType == "OpenQA.Selenium.IE.InternetExplorerDriver")
            //{
            //    InternetExplorerOptions options = new InternetExplorerOptions();
            //    options.EnableNativeEvents = false;
            //    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            //    //Clean the session before launching the browser
            //    options.EnsureCleanSession = true;

            //    DesiredCapabilities capabilities = new DesiredCapabilities();
            //    capabilities = DesiredCapabilities.InternetExplorer();
            //    capabilities.SetCapability("enablePersistentHover", false);
            //    capabilities.SetCapability("nativeEvents", false);
            //    capabilities.SetCapability("INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS", true);
            //    capabilities.SetCapability("ignoreProtectedModeSettings", "0");
            //    capabilities.SetCapability(CapabilityType.BrowserName, "iexplore");
            //    capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            //    capabilities.SetCapability(CapabilityType.Version, "11.0");
            //    capabilities.SetCapability(CapabilityType.HasNativeEvents, "false");


            //}


            //    String driverAssembly = TestProperties.Instance.GetPropertyByName(TestProperty.seleniumDriverAssembly);
            //    Assembly assembly = Assembly.Load(driverAssembly);
            //    Type t = assembly.GetType(driverType);
            //    driver = (IWebDriver)Activator.CreateInstance(t);

            //}

        }

    }
}
