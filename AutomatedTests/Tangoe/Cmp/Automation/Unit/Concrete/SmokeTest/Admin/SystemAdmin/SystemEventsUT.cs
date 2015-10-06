using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.SystemAdmin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.SystemAdmin
{
    class SystemEventsUT : BaseUnitTest
    {
        SystemEvents systemUnits;

           //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            systemUnits = new SystemEvents();
            AddActionClassesToList(systemUnits);

        }

        [SetUp]
        public void SetupBase()
        {
            systemUnits.Login();
        }



        [Test]
        public void MonitorUserFunctionality()
        {
            ExecuteTest(() =>
            {
                systemUnits.SystemEventsFunctionality();
            }
            );

        }

    }
}