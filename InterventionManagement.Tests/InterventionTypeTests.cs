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

        [TestMethod]
        [ExpectedException(typeof(InterventionTypeNameException))]
        public void InterventionTypeMissingNameException()
        {
            var sut = new InterventionType(null, 3, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTypeNameException))]
        public void InterventionTypeEmptyNameException()
        {
            var sut = new InterventionType("", 3, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTypeNumberException))]
        public void InterventionTypeNegativeHoursException()
        {
            var sut = new InterventionType("Mosquito Nets", -1, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTypeNumberException))]
        public void InterventionTypeNoHoursException()
        {
            var sut = new InterventionType("Mosquito Nets", 0, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTypeNumberException))]
        public void InterventionTypeNegativeCostException()
        {
            var sut = new InterventionType("Mosquito Nets", 1, -40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTypeNumberException))]
        public void InterventionTypeNoCostException()
        {
            var sut = new InterventionType("Mosquito Nets", 1, 0);
        }
    }
}
