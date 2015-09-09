using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class ContactsUT : BaseUnitTest
    {
        Contacts contacts;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            contacts = new Contacts();
            AddActionClassesToList(contacts);

        }

        [SetUp]
        public void SetupBase()
        {
            contacts.Login();
        }



        [Test]
        public void MicellaneousContact()
        {
            ExecuteTest(() =>
            {
                contacts.CreateReq();
            }
            );

        }

    }
}
