using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.SystemAdmin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.SystemAdmin
{
    class PropertiesUT : BaseUnitTest
    {

        Properties properties;
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            properties = new Properties();
            AddActionClassesToList(properties);

        }

        [SetUp]
        public void SetupBase()
        {
            properties.Login();
        }



        [Test]
        public void UserDefinedTranscationFunction()
        {
            ExecuteTest(() =>
            {
                properties.PropertiesFunctionality();
            }
            );

        }

    }
}