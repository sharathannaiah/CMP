using AutomatedTests.Tangoe.Cmp.Automation.UI.Concrete;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete
{
    class TrainingUnitTest : BaseUnitTest
    {

        Training training;

        //pre 
        [TestFixtureSetUp]
        public void Init()
        {
            training = new Training();
            AddActionClassesToList(training);
        }

        [SetUp]
        public void SetupBase()
        {
            training.Login();
        }


    //    [Category("FAT")]
       // [Test]
       // public void instruction()
       // {
        //    ExecuteTest(() =>
          //  {
          //      training.TC6665();
          //  }
           //);
        //}


        //[Test]
        //public void Explorer()
        //{
        //    ExecuteTest(() =>
        //        {
        //         //   training.Navigation();

        //        }
        //    );

        //}

        //[Test]
        //public void Explorer()
        //{
        //    ExecuteTest(() =>
        //    {
        //        training.Enterprise();

        //    }
        //    );

        //}

        //[Test]
        //public void explorer()
        //{
        //    ExecuteTest(() =>
        //    {
        //        training.EmployeeCreation();

        //    }
        //    );

        //}


        //[Test]
        //public void Explorer()
        //{
        //    ExecuteTest(() =>
        //    {
        //        training.EntityRegion();

        //    }
        //    );

        //}

        //[Test]
        //public void Explorer()
        //{
        //    ExecuteTest(() =>
        //    {
        //        training.Contract();

        //    }
        //    );

        //}

        [Test]
        public void Explorer()
        {
            ExecuteTest(() =>
            {
                training.Inventory();

            }
            );

        }


        //[TearDown]
        //public void TearDownBase()
        //{
        //    training.Logout();
        //}

    

    }    
}