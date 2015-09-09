using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class CompanyUT : BaseUnitTest
    {
        Company company;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            company = new Company();
            AddActionClassesToList(company);

        }

        [SetUp]
        public void SetupBase()
        {
            company.Login();
        }



        [Test]
        public void MicellaneousContact()
        {
            ExecuteTest(() =>
            {
                company.CreateComp();
            }
            );

        }

    }
}