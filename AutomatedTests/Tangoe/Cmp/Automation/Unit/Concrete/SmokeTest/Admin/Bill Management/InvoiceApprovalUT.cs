using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class InvoiceApprovalUT : BaseUnitTest
    {

        InvoiceApproval invoiceApproval;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            invoiceApproval = new InvoiceApproval();
            AddActionClassesToList(invoiceApproval);

        }

        [SetUp]
        public void SetupBase()
        {
            invoiceApproval.Login();
        }



        [Test]
        public void InvoiceApprovalFunctionality()
        {
            ExecuteTest(() =>
            {
                invoiceApproval.InvoiceApprovalFunctionality();

            }
            );

        }
    }
}
