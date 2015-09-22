using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Messaging;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Messaging
{
    class EmployeeNotificationUT : BaseUnitTest
    {
        EmployeeNotification employeeNotification;

        [TestFixtureSetUp]
        public void init()
        {
            employeeNotification = new EmployeeNotification();
            AddActionClassesToList(employeeNotification);
        }

        [SetUp]
        public void SetupBase()
        {
            employeeNotification.Login();
        }

        [Test]
        public void EmployeeNotificationSmokeTest()
        {
            ExecuteTest(() =>
                {
                    employeeNotification.EmployeeNotifiacationFunctionality();

                });
        }
    }
}

