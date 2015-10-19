using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Assurance;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Assurance
{
    class UninstallAssuranceUT : BaseUnitTest
    {
        UninstallAssurance uninstallAssurance;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            uninstallAssurance = new UninstallAssurance();
            AddActionClassesToList(uninstallAssurance);

        }

        [SetUp]
        public void SetupBase()
        {
            uninstallAssurance.Login();
        }



        [Test]
        public void UninstallAssuranceFunctionality()
        {
            ExecuteTest(() =>
            {
                uninstallAssurance.UninstallAssuranceFunctionality();
            }
            );

        }
    }
}

