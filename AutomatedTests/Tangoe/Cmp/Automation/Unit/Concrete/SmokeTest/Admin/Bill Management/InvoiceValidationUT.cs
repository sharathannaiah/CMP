using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class InvoiceValidationUT : BaseUnitTest
    {

        InvoiceValidation invoiceValidation;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            invoiceValidation = new InvoiceValidation();
            AddActionClassesToList(invoiceValidation);

        }

        [SetUp]
        public void SetupBase()
        {
            invoiceValidation.Login();
        }



        [Test]
        public void InvoiceValidationFunctionality()
        {
            ExecuteTest(() =>
            {
                invoiceValidation.InvoiceApprovalFunctionality();

            }
            );

        }
    }
}
