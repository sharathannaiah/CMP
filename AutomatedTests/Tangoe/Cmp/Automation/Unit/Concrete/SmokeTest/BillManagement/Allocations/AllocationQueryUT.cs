using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement.Allocations;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement.Allocations
{
    class AllocationQueryUT :BaseUnitTest
    {
       
       AllocationQuery allocationQuery;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            allocationQuery = new AllocationQuery();
            AddActionClassesToList(allocationQuery);

        }

        [SetUp]
        public void SetupBase()
        {
            allocationQuery.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                allocationQuery.AllocationQueryy();

            }
            );

        }
    
 }
    }
