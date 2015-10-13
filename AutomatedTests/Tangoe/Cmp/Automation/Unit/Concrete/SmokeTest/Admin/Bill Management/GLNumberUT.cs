using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class GLNumberUT : BaseUnitTest
    {

        GLNumber glNumber;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            glNumber = new GLNumber();
            AddActionClassesToList(glNumber);

        }

        [SetUp]
        public void SetupBase()
        {
            glNumber.Login();
        }



        [Test]
        public void GLNumberFunctionality()
        {
            ExecuteTest(() =>
            {
                glNumber.GLNumberFunctionality();
            }
            );

        }

    }
}
  
  
