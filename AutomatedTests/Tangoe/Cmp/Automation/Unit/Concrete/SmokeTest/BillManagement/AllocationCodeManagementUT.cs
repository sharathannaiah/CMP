using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement
{
    class AllocationCodeManagementUT :BaseUnitTest
    {


        AllocationCodeManagement allocationCodeManagement;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            allocationCodeManagement = new AllocationCodeManagement();
            AddActionClassesToList(allocationCodeManagement);

        }

        [SetUp]
        public void SetupBase()
        {
            allocationCodeManagement.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                allocationCodeManagement.AllocationCodeManagementt();

            }
            );

        }
    }
}