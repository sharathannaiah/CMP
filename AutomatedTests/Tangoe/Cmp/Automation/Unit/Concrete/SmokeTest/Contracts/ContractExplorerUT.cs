using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Contracts;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Contracts
{
    class ContractExplorerUT :BaseUnitTest
    {
        ContractsExplorer contractsExplorer;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            contractsExplorer = new ContractsExplorer();
            AddActionClassesToList(contractsExplorer);

        }

        [SetUp]
        public void SetupBase()
        {
           contractsExplorer.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                contractsExplorer.ContractSmokeFunctionality();

            }
            );

        }
    }
}


 
