using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class BillImportUT : BaseUnitTest
    {
        BillImport billImport;

         //pre
        [TestFixtureSetUp]
        public void init()
        {
            billImport = new BillImport();
            AddActionClassesToList(billImport);
        }

        [SetUp]
        public void SetUpBase()
        {
            billImport.Login();
        }
        [Test]
        public void BillImportSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                billImport.BillImportFunctionality();
            });

        }

    }
}