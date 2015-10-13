using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class InventoryAccrualUT : BaseUnitTest
    {

        InventoryAccrual inventoryaccural;
          //pre
        [TestFixtureSetUp]
        public void init()
        {
            inventoryaccural= new InventoryAccrual();
            AddActionClassesToList(inventoryaccural);
        }

        [SetUp]
        public void SetUpBase()
        {
            inventoryaccural.Login();
        }
        [Test]
        public void InventoryAccuralSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                inventoryaccural.InventroyAccrualFunctionality();
            });

        }

    }
}
   