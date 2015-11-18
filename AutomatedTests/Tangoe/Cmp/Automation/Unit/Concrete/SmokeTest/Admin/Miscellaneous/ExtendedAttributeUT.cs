using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Miscellaneous;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;


namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Miscellaneous
{
    class ExtendedAttributeUT : BaseUnitTest
    {
        ExtendedAttributes extendedAttribute;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            extendedAttribute = new ExtendedAttributes();
            AddActionClassesToList(extendedAttribute);

        }

        [SetUp]
        public void SetupBase()
        {
            extendedAttribute.Login();
        }



        [Test]
        public void ExtendAttributeFunctionality()
        {
            ExecuteTest(() =>
            {
                extendedAttribute.ExtendedAttribyesFunctionality();
            }
            );

        }
    }
}
