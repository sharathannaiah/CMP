using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Tools
{
    class HubsUT : BaseUnitTest
    {
        Hubs hubs;

           //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            hubs = new Hubs();
            AddActionClassesToList(hubs);

        }

        [SetUp]
        public void SetupBase()
        {
            hubs.Login();
        }



        [Test]
        public void HubsrFunctionality()
        {
            ExecuteTest(() =>
            {
                hubs.HubsFunctionality();
            }
            );

        }

    }
}
  