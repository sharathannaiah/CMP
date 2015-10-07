using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class AllocationsUT : BaseUnitTest
    {
        Allocations allocations;
        
        //pre
          [TestFixtureSetUp]
        public void init()
        {
            allocations = new Allocations();
            AddActionClassesToList(allocations);
        }

        [SetUp]
        public void SetUpBase()
        {
            allocations.Login();
        }
        [Test]
        public void AllocationsSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                allocations.AllocationFunctionality();
            });

        }

    }
}