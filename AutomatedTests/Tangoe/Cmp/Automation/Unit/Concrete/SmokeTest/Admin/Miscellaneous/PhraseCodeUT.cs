using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class PhraseCodeUT : BaseUnitTest
    {
        PhraseCode phraseCode;

        [TestFixtureSetUp]
        public void init()
        {
            phraseCode = new PhraseCode();
            AddActionClassesToList(phraseCode);
        }

        [SetUp]
        public void SetupBase()
        {
            phraseCode.Login();
        }

        [Test]
        public void PhraseCodesSmokeTestFunctionality()
        {
            ExecuteTest(() =>
            {
                phraseCode.PhraseCodesFunctionality();
            });
        }
    }
}
