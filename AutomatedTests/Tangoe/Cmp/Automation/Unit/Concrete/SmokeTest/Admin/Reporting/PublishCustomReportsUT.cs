using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Reporting;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Reporting
{
    class PublishCustomReportsUT : BaseUnitTest
    {

        PublishCustomReports publishCustomReports;

        //
        [TestFixtureSetUp]
        public void init()
        {
            publishCustomReports = new PublishCustomReports();
            AddActionClassesToList(publishCustomReports);
        }

        [SetUp]
        public void SetupBase()
        {
            publishCustomReports.Login();
        }

        [Test]
        public void PublishReportSmokeTestFunctionality()
        {
            ExecuteTest(() =>
            {
                publishCustomReports.PublishCustomReportsFunctionality();
            });
        }
    }
}