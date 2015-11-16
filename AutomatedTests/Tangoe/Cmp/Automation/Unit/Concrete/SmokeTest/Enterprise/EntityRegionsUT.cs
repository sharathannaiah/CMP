using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Enterprise
{
    class EntityRegionsUT : BaseUnitTest
    {

        EntityRegions entityRegions;



        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            entityRegions = new EntityRegions();
            AddActionClassesToList(entityRegions);

        }

        [SetUp]
        public void SetupBase()
        {
            entityRegions.Login();
        }



        [Test]
        public void RegionsFunctionality()
        {
            ExecuteTest(() =>
            {
                entityRegions.EntityRegionFunctionality();

            }
            );

        }
    }
}







