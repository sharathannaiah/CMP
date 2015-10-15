using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class PaymentUT : BaseUnitTest
    {

        Payment payment;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            payment = new Payment();
            AddActionClassesToList(payment);

        }

        [SetUp]
        public void SetupBase()
        {
            payment.Login();
        }



        [Test]
        public void PaymentFunctionality()
        {
            ExecuteTest(() =>
            {
                payment.PaymentFunctionality();

            }
            );

        }
    }
}