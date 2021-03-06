﻿using AutomatedTests.Tangoe.Cmp.Automation.UI.Actions.SmokeTest.Admin.Bill_Management;
using AutomatedTests.Tangoe.Cmp.Automation.Unit.Abstract;
using NUnit.Framework;

namespace AutomatedTests.Tangoe.Cmp.Automation.Unit.Concrete.SmokeTest.Admin.Bill_Management
{
    class AllocationApprovalRulesUT : BaseUnitTest
    {

        AllocationApprovalRules allocationApprovalRules;
        //pre
        [TestFixtureSetUp]
        public void init()
        {
            allocationApprovalRules = new AllocationApprovalRules();
            AddActionClassesToList(allocationApprovalRules);
        }

        [SetUp]
        public void SetUpBase()
        {
            allocationApprovalRules.Login();
        }
        [Test]
        public void AllocationBucketSmokeFunctionality()
        {
            ExecuteTest(() =>
            {
                allocationApprovalRules.AllocationApprovalRulesFunctionality();
            });

        }
    }
}

