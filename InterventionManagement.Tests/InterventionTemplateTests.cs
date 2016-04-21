using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Exceptions;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class InterventionTemplateTests
    {
        [TestMethod]
        public void CreateNewInterventionType()
        {
            var sut = new InterventionTemplate("Mosquito Nets", 3, 40);

            Assert.AreEqual(sut.Name, "Mosquito Nets");
            Assert.AreEqual(sut.Hours, 3);
            Assert.AreEqual(sut.Cost, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTemplateNameException))]
        public void InterventionTemplateMissingNameException()
        {
            var sut = new InterventionTemplate(null, 3, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTemplateNameException))]
        public void InterventionTemplateEmptyNameException()
        {
            var sut = new InterventionTemplate("", 3, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTemplateNumberException))]
        public void InterventionTemplateNegativeHoursException()
        {
            var sut = new InterventionTemplate("Mosquito Nets", -1, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTemplateNumberException))]
        public void InterventionTemplateNoHoursException()
        {
            var sut = new InterventionTemplate("Mosquito Nets", -10, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTemplateNumberException))]
        public void InterventionTemplateNegativeCostException()
        {
            var sut = new InterventionTemplate("Mosquito Nets", 1, -40);
        }

        [TestMethod]
        [ExpectedException(typeof(InterventionTemplateNumberException))]
        public void InterventionTemplateNoCostException()
        {
            var sut = new InterventionTemplate("Mosquito Nets", 1, -10);
        }
    }
}
