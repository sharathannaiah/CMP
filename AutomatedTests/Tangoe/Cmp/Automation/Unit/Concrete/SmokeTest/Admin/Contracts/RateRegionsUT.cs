using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Contracts;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Contracts
{
    class RateRegionsUT : BaseUnitTest
    {

        RateRegions rateRegions;


        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
           rateRegions = new RateRegions();
            AddActionClassesToList(rateRegions);

        }

        [SetUp]
        public void SetupBase()
        {
            rateRegions.Login();
        }



        [Test]
        public void RateRegionFunction()
        {
            ExecuteTest(() =>
            {
                rateRegions.RateRegionfunctionality();
            }
            );

        }

    }
}
