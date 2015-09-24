using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class DropdownListUT : BaseUnitTest
    {
        DropdownList dropdownList;

        [TestFixtureSetUp]
        public void init()
        {
            dropdownList = new DropdownList();
            AddActionClassesToList(dropdownList);
        }

        [SetUp]
        public void SetupBase()
        {
            dropdownList.Login();
        }

        [Test]
        public void DropdownListSmokeFunctionality()
        {
            ExecuteTest(() =>
                {
                    dropdownList.DropdownListFunctionality();
                });
        }
    }
}
