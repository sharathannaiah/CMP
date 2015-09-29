using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Localization;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Localization
{
    class CountryStatesUT : BaseUnitTest
    {
        CountryState countryStates;

        [TestFixtureSetUp]
        public void init()
        {
            countryStates = new CountryState();
            AddActionClassesToList(countryStates);
        }

        [SetUp]
        public void SetUpBase()
        {
            countryStates.Login();
        }
        [Test]
        public void CountryStateSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                countryStates.LocalizationSmokeTest();
            });

        }

    }

}
