using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class InterventionTypeTests
    {
        [TestMethod]
        public void CreateNewInterventionType()
        {
            var sut = new InterventionType("Mosquito Nets", 3, 40);

            Assert.AreEqual(sut.Name, "Mosquito Nets");
            Assert.AreEqual(sut.Hours, 3);
            Assert.AreEqual(sut.Cost, 40);
        }
    }
}
