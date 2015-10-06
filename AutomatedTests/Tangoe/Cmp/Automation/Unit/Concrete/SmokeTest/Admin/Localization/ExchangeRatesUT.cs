using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Localization;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Localization
{
    class ExchangeRatesUT : BaseUnitTest
    {
 

       ExchangeRates exchangeRates;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            exchangeRates = new ExchangeRates();
            AddActionClassesToList(exchangeRates);

        }

        [SetUp]
        public void SetupBase()
        {
            exchangeRates.Login();
        }



        [Test]
        public void ExchangeRatesFunction()
        {
            ExecuteTest(() =>
            {
                exchangeRates.ExchangeRatesFunctionality();
            }
            );

        }

    }
}