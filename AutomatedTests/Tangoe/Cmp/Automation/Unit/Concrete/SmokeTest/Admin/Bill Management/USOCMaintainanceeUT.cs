using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class USOCMaintainanceeUT : BaseUnitTest
    {

        USOCMaintainancee uscoMainatainancee;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            uscoMainatainancee = new USOCMaintainancee();
            AddActionClassesToList(uscoMainatainancee);

        }

        [SetUp]
        public void SetupBase()
        {
            uscoMainatainancee.Login();
        }



        [Test]
        public void USOCMaintainanceFunctionality()
        {
            ExecuteTest(() =>
            {
                uscoMainatainancee.USOCMaintainanceFunctionality();

            });

        }
    }
}

