using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class VoiceProductUT : BaseUnitTest
    {

        VoiceProduct voiceProduct;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            voiceProduct = new VoiceProduct();
            AddActionClassesToList(voiceProduct);

        }

        [SetUp]
        public void SetupBase()
        {
            voiceProduct.Login();
        }



        [Test]
        public void VoiceProductFunctionality()
        {
            ExecuteTest(() =>
            {
                voiceProduct.VoiceProductFunctionality();

            });
        }
    }
}
