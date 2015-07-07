using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement.Accounts;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Navigation;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement.Accounts
{
    class AccountMaintainanceUT :BaseUnitTest
    {
        AccountMaintainance accountMaintainance;
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            accountMaintainance = new AccountMaintainance();
            AddActionClassesToList(accountMaintainance);
        }

        [SetUp]
        public void SetupBase()
        {
           accountMaintainance.Login();
        }



        [Test]
        public void AccountMaintainance()
        {
            ExecuteTest(() =>
            {
                accountMaintainance.createAccount();

            }
            );

        }
    }
}
