using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Reporting;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Reporting
{
    class DisplayReportsUT : BaseUnitTest
    {

        DisplayReports displayReports;

        //
        [TestFixtureSetUp]
        public void init()
        {
            displayReports = new DisplayReports();
            AddActionClassesToList(displayReports);
        }

        [SetUp]
        public void SetupBase()
        {
            displayReports.Login();
        }

        [Test]
        public void DisplayReportsSmokeTestFunctionality()
        {
            ExecuteTest(() =>
            {
                displayReports.DisplayReportsFunctionality();
            });
        }
    }
}
  