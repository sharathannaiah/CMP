using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Provisioning;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Provisioning
{
    class CreateRequestUT :  BaseUnitTest
    {
 


        CreateRequest createRequest;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            createRequest = new CreateRequest();
            AddActionClassesToList(createRequest);

        }

        [SetUp]
        public void SetupBase()
        {
            createRequest.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                createRequest.CreateRequestt();

            }
            );

        }
    }
}