using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class ProjectCodesUT: BaseUnitTest
    {
        ProjectCodes projectCodes;

        [TestFixtureSetUp]
        public void init()
        {
            projectCodes = new ProjectCodes();
            AddActionClassesToList(projectCodes);
        }

        [SetUp]
        public void SetupBase()
        {
            projectCodes.Login();
        }

        [Test]
        public void ProjectCodesSmokeFunctionality()
        {
            ExecuteTest(() =>
                {
                    projectCodes.ProjectCodesSmokeFunctionality();
                });
        }
    }
}
