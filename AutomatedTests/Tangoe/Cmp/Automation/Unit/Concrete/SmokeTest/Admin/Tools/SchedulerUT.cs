using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Tools
{
    class SchedulerUT : BaseUnitTest
    {

        Scheduler scheduler;
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            scheduler = new Scheduler();
            AddActionClassesToList(scheduler);

        }

        [SetUp]
        public void SetupBase()
        {
            scheduler.Login();
        }



        [Test]
        public void SchedulerFunctionality()
        {
            ExecuteTest(() =>
            {
                scheduler.SchedulerFunctionality();
            }
            );

        }

    }
}
  
  