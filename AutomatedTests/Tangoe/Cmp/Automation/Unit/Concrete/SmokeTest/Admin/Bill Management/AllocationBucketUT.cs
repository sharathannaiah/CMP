using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class AllocationBucketUT : BaseUnitTest
    {
        AllocationBucket allocationBucket;

        //pre
        [TestFixtureSetUp]
        public void init()
        {
            allocationBucket = new AllocationBucket();
            AddActionClassesToList(allocationBucket);
        }

        [SetUp]
        public void SetUpBase()
        {
            allocationBucket.Login();
        }
        [Test]
        public void AllocationBucketSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                allocationBucket.AllocationBucketFunctionality();
            });

        }
    }
}
   
