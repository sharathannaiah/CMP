using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class ManualInvoiceDataUT : BaseUnitTest
    {

        ManualInvoiceData manualInvoiceData;

        //pre
          [TestFixtureSetUp]
        public void init()
        {
            manualInvoiceData = new ManualInvoiceData();
            AddActionClassesToList(manualInvoiceData);
        }

        [SetUp]
        public void SetUpBase()
        {
            manualInvoiceData.Login();
        }
        [Test]
        public void ManualInvoiceDataSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                manualInvoiceData.ManualInvoiceDataFunctionality();
            });

        }

    }
}