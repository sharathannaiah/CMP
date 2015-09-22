using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Messaging;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Messaging
{
    class EmailInBoundAuditUT : BaseUnitTest
    {
        EmailInBoundAudit emailInBoundAudit;

         [TestFixtureSetUp]
        public void init()
        {
            emailInBoundAudit = new EmailInBoundAudit();
            AddActionClassesToList(emailInBoundAudit);
        }

        [SetUp]
        public void SetupBase()
        {
            emailInBoundAudit.Login();
        }

        [Test]
        public void EmailInBoundAuditSmokeFunctionality()
        {
            ExecuteTest(() =>
                {
                    emailInBoundAudit.EmailInBoundAuditSmokeFunctionality();
                });
        }

    }
}
    
