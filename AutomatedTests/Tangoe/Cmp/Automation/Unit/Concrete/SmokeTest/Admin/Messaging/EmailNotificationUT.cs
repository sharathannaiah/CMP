using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Messaging;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Messaging
{
    class EmailNotificationUT : BaseUnitTest 

    {
        EmailNotification emailNotification;

        [TestFixtureSetUp]
        public void init()
        {
            emailNotification = new EmailNotification();
            AddActionClassesToList(emailNotification);
        }

        [SetUp]
        public void SetUpBase()
        {
            emailNotification.Login();
        }
        [Test]
        public void MeassagingNotificationSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                emailNotification.EmailNotificationFunctionality();
            });

        }

    }

}
