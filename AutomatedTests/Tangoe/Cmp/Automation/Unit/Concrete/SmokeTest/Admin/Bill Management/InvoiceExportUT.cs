using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class InvoiceExportUT : BaseUnitTest
    {

        InvoiceExport invoiceExport;

        //pre
          [TestFixtureSetUp]
        public void init()
        {
            invoiceExport = new InvoiceExport();
            AddActionClassesToList(invoiceExport);
        }

        [SetUp]
        public void SetUpBase()
        {
            invoiceExport.Login();
        }
        [Test]
        public void InvoiceExportSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                invoiceExport.InvoiceExportFunctionality();
            });

        }

    }
}