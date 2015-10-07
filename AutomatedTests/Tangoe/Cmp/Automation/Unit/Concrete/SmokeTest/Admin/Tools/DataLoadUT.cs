using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Tools
{
    class DataLoadUT : BaseUnitTest
    {
        DataLoad dataLoad;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            dataLoad = new DataLoad();
            AddActionClassesToList(dataLoad);

        }

        [SetUp]
        public void SetupBase()
        {
            dataLoad.Login();
        }



        [Test]
        public void DataLoadFunctionality()
        {
            ExecuteTest(() =>
            {
                dataLoad.DataLoadFunctionality();
            }
            );
            }

    }
        
}