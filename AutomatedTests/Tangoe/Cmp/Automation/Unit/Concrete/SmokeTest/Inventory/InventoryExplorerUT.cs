using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Inventory;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Inventory
{
    class InventoryExplorerUT :BaseUnitTest
    {
        InventoryExplorer inventoryExplorer;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            inventoryExplorer = new InventoryExplorer();
            AddActionClassesToList(inventoryExplorer);

        }

        [SetUp]
        public void SetupBase()
        {
            inventoryExplorer.Login();
        }



        [Test]
        public void InventoryExplorerFunctionality()
        {
            ExecuteTest(() =>
            {
                inventoryExplorer.InventorySmokeFunctionality();

            }
            );

        }
    }
}
