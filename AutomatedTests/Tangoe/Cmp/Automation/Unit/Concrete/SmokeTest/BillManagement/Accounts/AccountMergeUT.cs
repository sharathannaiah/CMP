using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.BillManagement.Accounts;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.BillManagement.Accounts
{
    class AccountMergeUT : BaseUnitTest
    {

       AccountMerge accountMerge;
       
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
           accountMerge = new AccountMerge();
            AddActionClassesToList(accountMerge);

        }

        [SetUp]
        public void SetupBase()
        {
            accountMerge.Login();
        }



        [Test]
        public void AccountMergeFunctionality()
        {
            ExecuteTest(() =>
            {
                accountMerge.AccountToMerge();

            }
            );

        }
    }
}

