using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Contracts;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Contracts
{
    class RateQualifiersUT : BaseUnitTest
    {

      //  RateRegions rateRegions;
        RateQualifiers rateQualify;


        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            rateQualify = new RateQualifiers();
            AddActionClassesToList(rateQualify);

        }

        [SetUp]
        public void SetupBase()
        {
            rateQualify.Login();
        }



        [Test]
        public void RateRegionFunction()
        {
            ExecuteTest(() =>
            {
                rateQualify.RateQualifierTest();
            }
            );

        }

    }
}
