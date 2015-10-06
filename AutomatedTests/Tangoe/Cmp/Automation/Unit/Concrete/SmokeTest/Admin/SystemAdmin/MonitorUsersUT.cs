using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.SystemAdmin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.SystemAdmin
{
    class MonitorUsersUT : BaseUnitTest
    {

        MonitorUsers monitorUsers;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            monitorUsers = new MonitorUsers();
            AddActionClassesToList(monitorUsers);

        }

        [SetUp]
        public void SetupBase()
        {
            monitorUsers.Login();
        }



        [Test]
        public void MonitorUserFunctionality()
        {
            ExecuteTest(() =>
            {
                monitorUsers.MonitorUsersFunctionality();
            }
            );

        }

    }
}