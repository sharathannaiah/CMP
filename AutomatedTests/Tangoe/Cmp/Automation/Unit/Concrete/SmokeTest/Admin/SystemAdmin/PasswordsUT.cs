using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.SystemAdmin;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.SystemAdmin
{
    class PasswordUT : BaseUnitTest
    {
        Passwords password;

         //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            password = new Passwords();
            AddActionClassesToList(password);

        }

        [SetUp]
        public void SetupBase()
        {
            password.Login();
        }



        [Test]
        public void PasswordFunction()
        {
            ExecuteTest(() =>
            {
                password.PasswordFunctionality();
            }
            );

        }

    }
}
    
