using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Messaging;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Messaging
{
    class NotificationAdministrationUT : BaseUnitTest
    {
        NotificationAdministration notificationAdminstration;

        [TestFixtureSetUp]
        public void init()
        {
            notificationAdminstration = new NotificationAdministration();
            AddActionClassesToList(notificationAdminstration);
        }

        [SetUp]
        public void SetUpBase()
        {
            notificationAdminstration.Login();
        }
        [Test]
        public void NotificationAdminstrationSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                notificationAdminstration.NotificationAdministrationFunctionality();
            });

        }

    }

}