using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.EmployeePortal;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.EmployeePortal
{
    class EmployeeLoginUT : BaseUnitTest
    {
        EmployeeLogin employeeLogin;

         //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            employeeLogin = new EmployeeLogin();
            AddActionClassesToList(employeeLogin);

        }

        [SetUp]
        public void SetupBase()
        {
            employeeLogin.Login();
        }



        [Test]
        public void EmployeeLoginFunction()
        {
            ExecuteTest(() =>
            {
               employeeLogin.EmployeeLoginn();
               // employeeLogin.Login1();

            }
            );
        }
            


        }

    }

