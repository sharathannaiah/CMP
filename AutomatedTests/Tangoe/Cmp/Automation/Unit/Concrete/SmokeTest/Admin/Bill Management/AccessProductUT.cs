using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class AccessProductUT : BaseUnitTest
    {

        AccessProduct accessProduct;

         //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            accessProduct = new AccessProduct();
            AddActionClassesToList(accessProduct);

        }

        [SetUp]
        public void SetupBase()
        {
            accessProduct.Login();
        }



        [Test]
        public void AccessProductFunctionality()
        {
            ExecuteTest(() =>
            {
                accessProduct.AccessProductFunctionality();

            });

        }
    }
}
