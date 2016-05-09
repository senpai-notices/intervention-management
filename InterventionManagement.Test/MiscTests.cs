using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASDF.ENETCare.InterventionManagement.Test
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
