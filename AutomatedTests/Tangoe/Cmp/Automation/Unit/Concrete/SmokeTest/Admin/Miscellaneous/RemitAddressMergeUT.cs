using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Provisioning;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class RemitAddressMergeUT : BaseUnitTest
    {
        RemitAddressMerge remitAddressMerge;

        [TestFixtureSetUp]
        public void init()
        {
            remitAddressMerge = new RemitAddressMerge();
            AddActionClassesToList(remitAddressMerge);
        }

        [SetUp]
        public void SetupBase()
        {
            remitAddressMerge.Login();
        }

        [Test]
        public void RemitAddressSmokeTest()
        {
            ExecuteTest(() =>
                {
                    remitAddressMerge.RemitAddressMergeFunctionality();
                });
        }
    }
}
