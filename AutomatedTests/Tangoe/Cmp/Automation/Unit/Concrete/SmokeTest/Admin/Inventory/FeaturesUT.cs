using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Inventory;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;
namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Inventory

{
    class FeaturesUT : BaseUnitTest 
    {
        Features features;

        [TestFixtureSetUp]
        public void Init()
        {
            features = new Features();
            AddActionClassesToList(features);
        }

        [SetUp]
        public void SetUpBase()
        {
            features.Login();
        }

        [Test]
        public void FeatureSmokeFunctionality()
        {
            ExecuteTest(() =>
                {
                    features.FeaturesFunctionality();
                }
            );
        }
    }
    }
