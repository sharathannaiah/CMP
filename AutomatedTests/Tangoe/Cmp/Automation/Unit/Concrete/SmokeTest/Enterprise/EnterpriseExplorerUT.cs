using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Enterprise
{
    class EnterpriseExplorerUT :BaseUnitTest
    {
            
       EnterpriseExplorer enterpriseExplorer;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            enterpriseExplorer = new EnterpriseExplorer();
            AddActionClassesToList(enterpriseExplorer);

        }

        [SetUp]
        public void SetupBase()
        {
            enterpriseExplorer.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                enterpriseExplorer.EnterpriseExplorerFunctionality();

            }
            );

        }
    }
}
