using System.Text.RegularExpressions;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [Ignore]
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void Test()
        {
            var rgx = new Regex("/([a-z'-]+) ([a-z'-]+)/i");
            var rgx2 = new Regex("/^[a - z,.'-]+$/i");

            var rgx10 = new Regex("[a-z'-]+");

            StringAssert.Matches("alex1??", rgx10);
        }
    }
}
