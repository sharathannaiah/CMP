using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Inventory;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Inventory
{
    class InventoryDiscoveryUT :BaseUnitTest
    {

        InventoryDiscovery inventoryDiscovery;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            inventoryDiscovery = new InventoryDiscovery();
            AddActionClassesToList(inventoryDiscovery);

        }

        [SetUp]
        public void SetupBase()
        {
            inventoryDiscovery.Login();
        }



        [Test]
        public void InventoryDiscoveryFunctionality()
        {
            ExecuteTest(() =>
            {
                inventoryDiscovery.InventoryDiscoveryFunctionality();

            }
            );

        }
    }
}
