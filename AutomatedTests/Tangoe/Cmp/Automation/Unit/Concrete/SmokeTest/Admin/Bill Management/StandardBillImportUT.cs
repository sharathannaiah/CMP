using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class StandardBillImportUT : BaseUnitTest
    {

        StandardBillImport standardBillImport;
      
        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            standardBillImport = new StandardBillImport();
            AddActionClassesToList(standardBillImport);

        }

        [SetUp]
        public void SetupBase()
        {
            standardBillImport.Login();
        }



        [Test]
        public void StandardBillImportFunctionality()
        {
            ExecuteTest(() =>
            {
                standardBillImport.StandardBillImportFunctionality();

            });

        }
    }
}


