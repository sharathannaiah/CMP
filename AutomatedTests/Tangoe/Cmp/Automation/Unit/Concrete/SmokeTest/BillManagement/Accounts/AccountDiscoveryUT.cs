using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement.Accounts;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement.Accounts
{
    class AccountDiscoveryUT : BaseUnitTest
    {

        AccountDiscovery accountDiscovery;


        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            accountDiscovery = new AccountDiscovery();
            AddActionClassesToList(accountDiscovery);

        }

        [SetUp]
        public void SetupBase()
        {
            accountDiscovery.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                accountDiscovery.AccountDiscoveryy();

            }
            );

        }
    }
}
