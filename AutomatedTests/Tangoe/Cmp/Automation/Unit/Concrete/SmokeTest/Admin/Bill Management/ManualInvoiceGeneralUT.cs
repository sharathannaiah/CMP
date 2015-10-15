using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class ManualInvoiceGeneralUT : BaseUnitTest
    {

        ManualInvoiceGeneral manualInvoiceGeneral;

        //pre
          [TestFixtureSetUp]
        public void init()
        {
            manualInvoiceGeneral = new ManualInvoiceGeneral();
            AddActionClassesToList(manualInvoiceGeneral);
        }

        [SetUp]
        public void SetUpBase()
        {
            manualInvoiceGeneral.Login();
        }
        [Test]
        public void ManualInvoiceGeneralSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                manualInvoiceGeneral.ManualInvoiceFunctionality();
            });

        }

    }
}
