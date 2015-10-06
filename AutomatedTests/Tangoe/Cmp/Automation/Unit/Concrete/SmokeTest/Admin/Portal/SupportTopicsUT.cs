using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Portal;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Portal
{
    class SupportTopicsUT : BaseUnitTest
    {
        SupportTopics supportTopics;

        [TestFixtureSetUp]
        public void init()
        {
            supportTopics = new SupportTopics();
            AddActionClassesToList(supportTopics);
        }

        [SetUp]
        public void SetupBase()
        {
            supportTopics.Login();
        }

        [Test]
        public void SuooprtTopicsSmokeTestFunctionality()
        {
            ExecuteTest(() =>
            {
                supportTopics.SupportTopicsFunctionality();
            });
        }
    }
}