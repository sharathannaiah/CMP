using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Contracts;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Contracts
{
    class ContractTariffUT : BaseUnitTest
    {

        ContractTariff contractTariff;


        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            contractTariff = new ContractTariff();
            AddActionClassesToList(contractTariff);

        }

        [SetUp]
        public void SetupBase()
        {
            contractTariff.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                contractTariff.ContractTariffFunctionality();

            }
            );

        }
    }
}