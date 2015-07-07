using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Navigation;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Navigation

{
    class CompleteNavigationUT :  BaseUnitTest
    {
        CompleteNavigation completeNavigation;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            completeNavigation = new CompleteNavigation();
            AddActionClassesToList(completeNavigation);
        }

        [SetUp]
        public void SetupBase()
        {
            completeNavigation.Login();
        }



        [Test]
        public void navigation()
        {
            ExecuteTest(() =>
                {
                    completeNavigation.Navigation();

                }
            );

        }
    }
}
