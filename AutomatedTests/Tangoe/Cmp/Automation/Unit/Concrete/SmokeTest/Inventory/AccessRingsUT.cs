using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Inventory;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Inventory
{
    class AccessRingsUT : BaseUnitTest
    {
        AccessRings accessRings;

         
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            accessRings = new AccessRings();
            AddActionClassesToList(accessRings);

        }

        [SetUp]
        public void SetupBase()
        {
            accessRings.Login();
        }



        [Test]
        public void AccessRingsFunctionality()
        {
            ExecuteTest(() =>
            {
                accessRings.AccessRingsFunctionality();

            }
            );

        }
    }
}
