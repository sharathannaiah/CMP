using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Localization;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Localization
{
    class UserDefinedTranscationsUT : BaseUnitTest
    {

        UserDefinedTransctions userDefinedTranscations;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            userDefinedTranscations = new UserDefinedTransctions();
            AddActionClassesToList(userDefinedTranscations);

        }

        [SetUp]
        public void SetupBase()
        {
            userDefinedTranscations.Login();
        }



        [Test]
        public void UserDefinedTranscationFunction()
        {
            ExecuteTest(() =>
            {
                userDefinedTranscations.UserDefinedTranscationsFun();
            }
            );

        }

    }
}