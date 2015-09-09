using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise.Employee;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Enterprise.Employee
{
    class SupportTicketUT : BaseUnitTest
    {
        SupportTicket supportTickets;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            supportTickets = new SupportTicket();
            AddActionClassesToList(supportTickets);

        }

        [SetUp]
        public void SetupBase()
        {
            supportTickets.Login();
        }



        [Test]
        public void CreateTicket()
        {
            ExecuteTest(() =>
            {
                supportTickets.SupportTicketFunctionality();
            });

        }

        //[Test]
        //public void Update()
        //{
        //    ExecuteTest(() =>
        //        {
        //            supportTickets.UpdateTicket();
        //        });
        //}

        //[Test]
        //public void Delete()
        //{
        //    ExecuteTest(() =>
        //        {
        //            supportTickets.Deletion();
        //        });
        //}
    }
}