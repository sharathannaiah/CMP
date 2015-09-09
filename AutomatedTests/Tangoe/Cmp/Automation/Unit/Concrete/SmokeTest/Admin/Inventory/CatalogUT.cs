using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Inventory;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Inventory
{
    class CatalogUT : BaseUnitTest
    {

        Catalog catalog;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            catalog = new Catalog();
            AddActionClassesToList(catalog);

        }

        [SetUp]
        public void SetupBase()
        {
            catalog.Login();
        }



        [Test]
        public void CatalogFunction()
        {
            ExecuteTest(() =>
            {
                catalog.CatalogFunctionality();
            }
            );

        }

    }
}