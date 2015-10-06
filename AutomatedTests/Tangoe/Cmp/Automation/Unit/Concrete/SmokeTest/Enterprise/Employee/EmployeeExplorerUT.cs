using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Enterprise.Employee;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Enterprise.Employee
{
    class EmployeeExplorerUT :BaseUnitTest
    {
        EmployeeExplorer employeeExplorer;

        
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            employeeExplorer = new EmployeeExplorer();
            AddActionClassesToList(employeeExplorer);

        }

        [SetUp]
        public void SetupBase()
        {
           employeeExplorer.Login();
        }



        [Test]
        public void EnterpriseFunctionality()
        {
            ExecuteTest(() =>
            {
                employeeExplorer.EmployeeExplorerFunctions();

            }
            );

        }
    }
}


 
