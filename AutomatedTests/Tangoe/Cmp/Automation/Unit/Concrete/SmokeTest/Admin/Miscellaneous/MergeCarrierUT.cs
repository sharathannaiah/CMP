using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class MergeCarrierUT : BaseUnitTest
    {
        MergeCarrier mergeCarrier;

        [TestFixtureSetUp]
        public void init()
        {
            mergeCarrier = new MergeCarrier();
            AddActionClassesToList(mergeCarrier);
        }

        [SetUp]
        public void SetupBase()
        {
            mergeCarrier.Login();
        }

        [Test]
        public void MergeCarrierFunctionality()
        {
            ExecuteTest(() =>
                {
                    mergeCarrier.MergeCarrierFunctionality();
                });
        }
    }
}
