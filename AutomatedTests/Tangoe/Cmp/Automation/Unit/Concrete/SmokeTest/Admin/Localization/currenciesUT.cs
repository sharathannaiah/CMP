using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Localization;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Localization
{
    class CurrenciesUT :BaseUnitTest
    {
        Currencies currencies;

        [TestFixtureSetUp]
        public void init()
        {
            currencies = new Currencies();
            AddActionClassesToList(currencies);
        }

        [SetUp]
        public void SetUpBase()
        {
            currencies.Login();
        }
        [Test]
        public void CurrenciesSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                currencies.CurrenciesSomkeTest();

            });

        }

    }
}

