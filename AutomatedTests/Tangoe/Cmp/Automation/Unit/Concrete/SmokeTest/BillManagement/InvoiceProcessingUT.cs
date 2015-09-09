using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement
{
    class InvoiceProcessingUT : BaseUnitTest
    {
        InvoiceProcessing invoiceProcessing;
      
        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            invoiceProcessing = new InvoiceProcessing();
            AddActionClassesToList(invoiceProcessing);

        }

        [SetUp]
        public void SetupBase()
        {
            invoiceProcessing.Login();
        }



        [Test]
        public void InvoiceFunctionality()
        {
            ExecuteTest(() =>
            {
                invoiceProcessing.invoiceprocessing();

            }
            );

        }
    }
}
