using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement.Allocations;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement.Allocations
{
    class AllocationProcessingUT :BaseUnitTest
    {
         
 


        AllocationProcessing allocationProcessing;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            allocationProcessing = new AllocationProcessing();
            AddActionClassesToList(allocationProcessing);

        }

        [SetUp]
        public void SetupBase()
        {
            allocationProcessing.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                allocationProcessing.AllocationProccessing();

            }
            );

        }
    }
}