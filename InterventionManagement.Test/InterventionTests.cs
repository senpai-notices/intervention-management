using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class InterventionTests
    {
        [TestMethod]
        public void Intervention_Invalid_When_Hours_NULL()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_Hours_Negative()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_Excessive_Value()
        {
            // 9,999,999,999 a good point?
            Assert.Fail();
        }
        
        [TestMethod]
        public void Intervention_Invalid_When_Cost_NULL()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_Cost_Negative()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_Cost_Excessive_Value()
        {
            // 9,999,999,999 a good point?
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_Notes_NULL()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_Notes_Whitespace()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_Notes_Exceed_Character_Limit()
        {
            // What is notes character limit?
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_Life_Outside_Range()
        {
            //0 - 100
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_NULL()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Intervention_Invalid_When_LastVisit_is_Before_DatePerformed()
        {
            Assert.Fail();
        }

    }
}
