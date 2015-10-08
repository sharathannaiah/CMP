using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class FiscalPeriodUT : BaseUnitTest
    {
        FiscalCalendar fiscalCalendar;

         //pre
        [TestFixtureSetUp]
        public void init()
        {
            fiscalCalendar = new FiscalCalendar();
            AddActionClassesToList(fiscalCalendar);
        }

        [SetUp]
        public void SetUpBase()
        {
            fiscalCalendar.Login();
        }
        [Test]
        public void FiscalCalendarSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                fiscalCalendar.FiscalCalendarFunctionality();
            });

        }

    }
}

