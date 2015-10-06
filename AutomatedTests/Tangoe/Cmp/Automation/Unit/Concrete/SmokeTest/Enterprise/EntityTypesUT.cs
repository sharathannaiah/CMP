using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Enterprise
{
    class EntityTypesUT : BaseUnitTest
    {

        EntityTypes entityTypes;



        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            entityTypes = new EntityTypes();
            AddActionClassesToList(entityTypes);

        }

        [SetUp]
        public void SetupBase()
        {
            entityTypes.Login();
        }



        [Test]
        public void EnterpriseTypesFunctionality()
        {
            ExecuteTest(() =>
            {
                entityTypes.EntityTypesFunctionality();

            }
            );

        }
    }
}



 


   
