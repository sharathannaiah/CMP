using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.SystemAdmin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.SystemAdmin
{
    class UsersandGroupsUT : BaseUnitTest
    {
        UsersandGroups usersandGroups;

        [TestFixtureSetUp]
        public void init()
        {
            usersandGroups = new UsersandGroups();
            AddActionClassesToList(usersandGroups);
        }

        [SetUp]
        public void SetupBase()
        {
            usersandGroups.Login();
        }

        [Test]
        public void UsersandGroupsSmokeTestFunctionality()
        {
            ExecuteTest(() =>
            {
                usersandGroups.UsersandGropusFunctionality();
            });
        }
    }
}
