using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class DataProductUT : BaseUnitTest
    {
        DataProduct dataProduct;

        //pre
        [TestFixtureSetUp]
        public void init()
        {
            dataProduct = new DataProduct();
            AddActionClassesToList(dataProduct);
        }

        [SetUp]
        public void SetUpBase()
        {
            dataProduct.Login();
        }
        [Test]
        public void DataProductSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                dataProduct.DataProductFunctionality();
            });

        }

    }
}