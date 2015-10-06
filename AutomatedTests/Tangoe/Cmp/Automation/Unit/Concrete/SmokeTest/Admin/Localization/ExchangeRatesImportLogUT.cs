using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Localization;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Localization
{
    class ExchangeRatesImportLogUT : BaseUnitTest
    {
        ExchangeRatesImportLog exchangeRatesImport;

          //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            exchangeRatesImport = new ExchangeRatesImportLog();
            AddActionClassesToList(exchangeRatesImport);

        }

        [SetUp]
        public void SetupBase()
        {
            exchangeRatesImport.Login();
        }



        [Test]
        public void ExchangeRatesImportLogFunction()
        {
            ExecuteTest(() =>
            {
                exchangeRatesImport.ExchangeRatesImportLogFunctionality();
            }
            );

        }

    
    }
}
