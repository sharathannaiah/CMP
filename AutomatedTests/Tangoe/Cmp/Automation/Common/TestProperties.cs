using System;

namespace AutomatedTests.Tangoe.Cmp.Automation.Common
{

    #region properties enum
    
    /// <summary>
    /// This enum exposes an entry for each key in the application's config file
    /// Make sure to add the property using the same case of the key in the config file
    /// </summary>
    public enum TestProperty
    {
        timeout,

        //Login Admin
        path,
        baseURL,
        user,
        password,
        SQLServer,
        DBUser,
        employeeURL, 


        //Entity Creation
        entityName,
        siteId, 
        npanxx,
        businessHours,
        date,
        ldn,
        phone1,
        phone2,
        fax,
        street1,
        street2,
        street3,
        city,
        pincode,

        //Demarc
        building,
        floor,
        suite,
        room,
        department,

        //Employee Details
        firstName,
        lastName,

        //Entity Type
        typeName,
        typeDescription,


        
        
        

        //JMeter Command
        JMeterCommand,
        
        //Javascript internal pages
        menu,
        method,
        type,

        //Common
        maxUser,
        savedOK,
        seleniumDriver,
        seleniumDriverAssembly,
        outputPath,
        buildNumberFile,

    }

    #endregion

   
  

   
   
    #region Execution Mode enum
    public enum ExecutionMode
    {
        PAT,
        FAT,
        PAT_AND_FAT
    }
    #endregion

    public sealed class TestProperties
    {
        /// <summary>
        /// Defines Default Timeout seconds - to be used if the config file key is missing
        /// </summary>
        private static int DEFAULT_TIMEOUT = 30;


        #region singleton methods
        private static readonly Lazy<TestProperties> lazy = new Lazy<TestProperties>(() => new TestProperties());
        public static TestProperties Instance { get { return lazy.Value; } }

        private TestProperties() { }

        #endregion

        #region public methods
        /// <summary>
        /// Gets a value for a key in the property file
        /// </summary>
        /// <param name="propertyName">Key of the property in the config file</param>
        /// <returns>the value of the key in the property file</returns>
        public String GetPropertyByName(TestProperty propertyName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[propertyName.ToString()];
        }

        /// <summary>
        /// Gets the timeout in seconds from the config file
        /// </summary>
        /// <returns>The timeout value in seconds</returns>
        public int GetTimeoutSeconds()
        {
            String timeout = GetPropertyByName(TestProperty.timeout);
            try
            {
                return int.Parse(timeout);
            }
            catch (Exception)
            {
                //Default to 30 if we can't parse from config file
                return DEFAULT_TIMEOUT;
            }
        }

        #endregion
    }
}
