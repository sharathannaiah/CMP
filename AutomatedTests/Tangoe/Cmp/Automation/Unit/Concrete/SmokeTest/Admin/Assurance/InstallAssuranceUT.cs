using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Assurance;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;
namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Assurance
{
    class InstallAssuranceUT : BaseUnitTest
    {

        InstallAssurance installAssurance;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            installAssurance = new InstallAssurance();
            AddActionClassesToList(installAssurance);

        }

        [SetUp]
        public void SetupBase()
        {
            installAssurance.Login();
        }



        [Test]
        public void InstallAssuranceFunctionality()
        {
            ExecuteTest(() =>
            {
                installAssurance.AssuranceFunctionality();
            }
            );

        }
    }
}
