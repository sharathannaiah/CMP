using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Inventory;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Inventory
{
    class ProductSpeedUT : BaseUnitTest
    {
        ProductSpeed productSpeed;

        [TestFixtureSetUp]
        public void init()
        {
            productSpeed = new ProductSpeed();
            AddActionClassesToList(productSpeed);

        }

        [SetUp]
        public void SetupBase()
        {
            productSpeed.Login();
        }

        [Test]
        public void ProductSpeedFuncctionality()
        {

            ExecuteTest(() =>
            {
                productSpeed.ProductSpeedFunctionality();
            });

        }
    }
}
