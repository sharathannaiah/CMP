using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Inventory;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Inventory
{
    class NetworkApplicationUT : BaseUnitTest
    {

        NetworkApplications networkApplications;

        [TestFixtureSetUp]
        public void init() 
        {
            networkApplications = new NetworkApplications();
            AddActionClassesToList(networkApplications);
        }
       
        [SetUp]
        public void SetUpBase() {

            networkApplications.Login();
        }

        [Test]
        public void NetworkApplicationsSmokeTest() 
        {
            networkApplications.NetworkApplicationsFunctionality();
        }
    }
}
