using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Reporting;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Reporting
{
    class ManageCustomReportsUT : BaseUnitTest
    {
        
        ManageCustomReports manageCustomReports;

        //
        [TestFixtureSetUp]
        public void init()
        {
            manageCustomReports = new ManageCustomReports();
            AddActionClassesToList(manageCustomReports);
        }

        [SetUp]
        public void SetupBase()
        {
            manageCustomReports.Login();
        }

        [Test]
        public void ManageReportsSmokeTestFunctionality()
        {
            ExecuteTest(() =>
            {
                manageCustomReports.ManageCustomReportsFunctionality();
            });
        }
    }
}
