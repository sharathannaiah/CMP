using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class AllocationApprovalRulesUT : BaseUnitTest
    {

        AllocationApprovalRules allocationApprovalRules;
        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            allocationApprovalRules = new AllocationApprovalRules();
            AddActionClassesToList(allocationApprovalRules);

        }

        [SetUp]
        public void SetupBase()
        {
            allocationApprovalRules.Login();
        }



        [Test]
        public void AllocationApprovalFunctionality()
        {
            ExecuteTest(() =>
            {
                allocationApprovalRules.AllocationApprovalRulesFunctionality();

            });

        }
    }
}
