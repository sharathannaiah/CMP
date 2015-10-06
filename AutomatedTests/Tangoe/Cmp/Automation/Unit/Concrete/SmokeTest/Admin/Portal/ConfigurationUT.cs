using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Portal;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Portal
{
    class ConfigurationUT : BaseUnitTest
    {
        Configuration configuration;
       
        [TestFixtureSetUp]
        public void init()
        {
            configuration = new Configuration();
            AddActionClassesToList(configuration);
        }

        [SetUp]
        public void SetupBase()
        {
            configuration.Login();
        }

        [Test]
        public void ConfigurationSmokeTestFunctionality()
        {
            ExecuteTest(() =>
            {
                configuration.ConfigurationFunctionality();
            });
        }
    }
}