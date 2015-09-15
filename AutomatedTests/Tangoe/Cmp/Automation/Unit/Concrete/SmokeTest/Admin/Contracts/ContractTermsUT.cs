using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Contracts;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Contracts
{
    class ContractTermsUT :BaseUnitTest
    {
        ContractTerms contractTerms;

        [TestFixtureSetUp]
        public void init()
        {
            contractTerms = new ContractTerms();
            AddActionClassesToList(contractTerms);
        }

        [SetUp]
        public void SetUpBase()
        {
            contractTerms.Login();
        }
        [Test]
        public void ContractTermsFunctionality()
        {
            ExecuteTest(() =>
                {
                    contractTerms.ContractTermsFunctions();
                });

        }

    }

}
