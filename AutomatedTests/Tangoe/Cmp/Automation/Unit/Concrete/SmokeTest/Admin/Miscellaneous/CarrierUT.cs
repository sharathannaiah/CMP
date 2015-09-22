using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class CarrierUT :BaseUnitTest
    {
        Carrier carrier;

        [TestFixtureSetUp]
        public void init()
        {
            carrier = new Carrier();
            AddActionClassesToList(carrier);
        }

        [SetUp]
        public void SetupBase()
        {
            carrier.Login();
        }

        [Test]
        public void CarrierSmokeTestFunctionality()
        {
            ExecuteTest(() =>
                {
                    carrier.CarrierSmokeFunctionality();
                });
        }
    }
}
