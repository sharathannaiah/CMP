using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement;



namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement
{
    class CostCenterManagementUT :BaseUnitTest
    {

        CostCenterManagement costCenterManagement;


        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            costCenterManagement = new CostCenterManagement();
            AddActionClassesToList(costCenterManagement);

        }

        [SetUp]
        public void SetupBase()
        {
            costCenterManagement.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                costCenterManagement.CostCenterManagementt();

            }
            );

        }
    }
}