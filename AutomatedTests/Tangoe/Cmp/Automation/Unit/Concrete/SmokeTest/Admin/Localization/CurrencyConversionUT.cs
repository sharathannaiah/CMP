using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Localization;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;
namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Localization
{
    class CurrencyConversionUT : BaseUnitTest
    {
        CurrencyConversion currencyConversion;

        [TestFixtureSetUp]
        public void init()
        {
            currencyConversion = new CurrencyConversion();
            AddActionClassesToList(currencyConversion);
        }

        [SetUp]
        public void SetUpBase()
        {
            currencyConversion.Login();
        }
        [Test]
        public void LocalizationSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                currencyConversion.SmokeTestCurrencyConversion();

            });

        }

    }
}

    