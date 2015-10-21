using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin
{
    class AdminProvisioningUT : BaseUnitTest
    {

        AdminProvisioning adminProvisioning;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            adminProvisioning = new AdminProvisioning();
            AddActionClassesToList(adminProvisioning);

        }

        [SetUp]
        public void SetupBase()
        {
            adminProvisioning.Login();
        }

        [Test]
        public void AdminProvsioningFunctionality()
        {
            ExecuteTest(() =>
            {
                adminProvisioning.AdminProvisioningFunctionality();
            });
        }
    }
}