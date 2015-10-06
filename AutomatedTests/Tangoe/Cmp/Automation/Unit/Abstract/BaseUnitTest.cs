using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using AutomatedTests.Tangoe.Cmp.Automation.Common;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract
{
    /// <summary>
    /// This is the base class for all unit tests. It should contain all methods that are commonly used in all tests
    /// </summary>
    abstract class BaseUnitTest
    {

        #region Internal Properties & Constructors

        /// <summary>
        /// List of UI Action classes that will be used to set the execution context (FAT or PAT)
        /// </summary>
        private List<IBaseAction> UIActionClasses;

        /// <summary>
        /// Default Constructor will now initializa the list of UI action controllers
        /// </summary>
        protected BaseUnitTest()
        {
            UIActionClasses = new List<IBaseAction>();
        }

        #endregion
        
        #region Test Mode Setup Methods

        /// <summary>
        /// Adds an action class to the list. This list will be used to set the execution mode from the test context
        /// </summary>
        /// <param name="actionClass"></param>
        protected void AddActionClassesToList(IBaseAction actionClass)
        {
            UIActionClasses.Add(actionClass);
        }

        /// <summary>
        /// Checks the TestContext to see if a category is assigned to a test
        /// </summary>
        /// <param name="category">The category as assigned to a test using the CategoryAttribute</param>
        /// <returns>True if the category is assigned to a test, false otherwise</returns>
        private bool TestInMode(string category)
        {
            return ((ArrayList)TestContext.CurrentContext.Test.Properties["_CATEGORIES"]).Contains(category);
        }

        /// <summary>
        /// Checks if the current test has the FAT category
        /// </summary>
        /// <returns>True if the FAT category is assigned to a test, false otherwise</returns>
        private bool IsFATTest()
        {
            return TestInMode("FAT");
        }

        /// <summary>
        /// Checks if the current test has the PAT category
        /// </summary>
        /// <returns>True if the PAT category is assigned to a test, false otherwise</returns>
        private bool IsPATTest()
        {
            return TestInMode("PAT");
        }

        #endregion

        #region Common Unit Methods

        /// <summary>
        /// Common setup method for all tets. This method will make sure that the execution mode is set for 
        /// all action classes before executing each test.
        /// </summary>
        [SetUp]
        public void SetUpTest()
        {
            foreach (IBaseAction actionClass in UIActionClasses)
            {
                if (actionClass != null)
                {
                    if (IsFATTest() && IsPATTest())
                    {
                        actionClass.SetExecutionMode(Common.ExecutionMode.PAT_AND_FAT);
                    }
                    else if (IsFATTest())
                    {
                        actionClass.SetExecutionMode(Common.ExecutionMode.FAT);
                    }
                    else if (IsPATTest())
                    {
                        actionClass.SetExecutionMode(Common.ExecutionMode.PAT);
                    }
                    else
                    {
                        //If both categories were not set, then default to both
                        actionClass.SetExecutionMode(Common.ExecutionMode.PAT_AND_FAT);
                    }
                }
            }
        }

        /// <summary>
        /// Common SetUp method for all test fixtures. The code that you add here will be called once before each 
        /// TestFixture class that is derived from this class. Based on NUnit's inheritance structure, the TestFixtureSetUp
        /// method of the derived classed will be called AFTER the TestFixtureSetUp method of the base class.
        /// </summary>
        [TestFixtureSetUp]
        public void FixtureSetupBase()
        {
        }

        /// <summary>
        /// Common TearDown method for all test fixtures. The code that you add here will be called once after each 
        /// TestFixture class that is derived from this class. Based on NUnit's inheritance structure, the TestFixtureTearDown
        /// method of the derived classed will be called BEFORE the TestFixtureTearDown methave a quod of the base class.
        /// </summary>
        [TestFixtureTearDown]
        public void FixtureTearDownBase()
        {
        }

        /// <summary>
        /// Common SetUp method for all tests. The code that you add here will be called before each Test in all 
        /// TestFixture classes that are derived from this class. Based on NUnit's inheritance structure, the SetUp
        /// method of the derived classed will be called AFTER the SetUp method of the base class.
        /// </summary>
        [SetUp]
        public void SetupBase()
        {
            
                       
        }

        /// <summary>
        /// Common TestDown method for all tests. The code that you add here will be called after each Test in all 
        /// TestFixture classes that are derived from this class. Based on NUnit's inheritance structure, the TearDown
        /// method of the derived classed will be called BEFORE the TearDown method of the base class.
        /// </summary>
        [TearDown]
        public void TearDownBase()
        {
            
        }

        #endregion

        #region Common Properties & Methods

        /// <summary>
        /// Wrapper for all methods. This is to avoid duplicating the exception handling in each test method
        /// </summary>
        /// <param name="action">The test to execute</param>
        /// <example>
        /// [Test]
        /// public void UserProfileGrant()
        /// {
        /// ExecuteTest(() =>
        /// {
        /// role.UserProfileAndPolicies_Grant();
        /// }
        /// );
        /// }
        /// </example>
        protected void ExecuteTest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format(@"{0}{1}{2}{3}", e.GetType().ToString(), Environment.NewLine, e.Message, e.StackTrace));
            }
        }

        /// <summary>
        /// Wrapper for all methods. This is to avoid duplicating the exception handling in each test method.
        /// The test will fail when the first action fails.
        /// </summary>
        /// <param name="actions">List of tests to execute</param>
        /// <example>
        /// [Test]
        /// public void TransferFundsListWrapped()
        /// {
        /// List<Action> actions = new List<Action>();
        /// actions.Add(() => this.Test1());
        /// actions.Add(() => this.Test1());
        /// this.ExecuteTests(actions);
        /// }
        /// </example>
        protected void ExecuteTests(IEnumerable<Action> actions)
        {
            try
            {
                foreach (Action action in actions)
                {
                    action();
                }
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format(@"{0}{1}{2}{3}", e.GetType().ToString(), Environment.NewLine, e.Message, e.StackTrace));
            }
        }

        /// <summary>
        /// Wrapper for all methods. This is to avoid duplicating the exception handling in each test method.
        /// The test will keep running until all actions are ran. It'll fail if one of the tests failed.
        /// </summary>
        /// <param name="actions">List of tests to execute</param>
        /// <example>
        /// [Test]
        /// public void TransferFundsListWrapped()
        /// {
        /// List<Action> actions = new List<Action>();
        /// actions.Add(() => this.Test1());
        /// actions.Add(() => this.Test1());
        /// this.ExecuteAllTests(actions);
        /// }
        /// </example>
        protected void ExecuteAllTests(IEnumerable<Action> actions)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Action action in actions)
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    sb.AppendLine(string.Format(@"{0}{1}{2}", e.GetType().ToString(), Environment.NewLine, e.StackTrace));
                }
            }

            if (sb.Length > 0)
            {
                Assert.Fail(sb.ToString());
            }
        }

        /// <summary>
        /// Include in this method all the setup that has to be done before each test fixture
        /// </summary>
        //public BESSecurityRoleActions role;
        //public GMMSecurityRoleActions gmmRole;



        #endregion

    }
}

/// <summary>
/// This class is intended to be outside the namespace so that NUnit runs it before running any
/// Test Fixture class. This is a kind of global init for all test fixtures. It is used to read
/// the build number from MDM's login page and save it to a file
/// </summary>
[SetUpFixture]
public class GlobalSetup
{
    //private static bool haveBuildNumer = false;
    //[SetUp]
    //public void GetBuildNumber()
    //{
    //    Console.WriteLine(@"haveBuildNumer: {0}", haveBuildNumer);

    //    //Get the path to the file where we will save the build number
    //    string buildNumberFile = TestProperties.Instance.GetPropertyByName(TestProperty.buildNumberFile);
    //    FileInfo fi = new FileInfo(buildNumberFile);

    //    //if the directory doesn't exist, create it
    //    if (!Directory.Exists(fi.DirectoryName))
    //    {
    //        Console.WriteLine(@"GetBuildNumber - Creating Directory {0}", fi.DirectoryName);
    //        Directory.CreateDirectory(fi.DirectoryName);
    //    }

    //    //if this is the first time we run it, get the build number from MDM's login page
    //    if (!haveBuildNumer)
    //    {
    //        string buildNumber = BaseActions.GetBuildNumberFromLandingPage();

    //        Console.WriteLine(@"buildNumber: {0}", buildNumber);
    //        File.WriteAllText(buildNumberFile, buildNumber);

    //        //Change it to true so we don't parse it again
    //        haveBuildNumer = true;
       // }
    }
