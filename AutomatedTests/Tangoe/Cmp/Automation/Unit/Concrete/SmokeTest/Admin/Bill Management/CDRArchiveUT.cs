using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class CDRArchiveUT :BaseUnitTest
    {

        CDRArchive cdrArchive;

        //pre
        [TestFixtureSetUp]
        public void init()
        {
            cdrArchive = new CDRArchive();
            AddActionClassesToList(cdrArchive);
        }

        [SetUp]
        public void SetUpBase()
        {
            cdrArchive.Login();
        }
        [Test]
        public void CDRArchiveSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                cdrArchive.CDRArchiveFunctionality();
            });

        }

    }
}
