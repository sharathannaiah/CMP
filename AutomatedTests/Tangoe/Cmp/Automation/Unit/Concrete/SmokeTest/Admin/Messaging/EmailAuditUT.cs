using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Messaging;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Messaging
{
    class EmailAuditUT :BaseUnitTest
    {

        EmailAudit emailAudit;

        [TestFixtureSetUp]
        public void init()
        {
            emailAudit = new EmailAudit();
            AddActionClassesToList(emailAudit);
        }

        [SetUp]
        public void SetupBase()
        {
            emailAudit.Login();
        }

        [Test]
        public void EmailAuditSmokeFunctionality()
        {
            ExecuteTest(() =>
                {
                    emailAudit.EmailAuditFunctionality();
                });
        }

    }
}
