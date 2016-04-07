using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class EngineerTests
    {
        [TestMethod]
        public void CreateClient_Normal_Exists()
        {
            var engineer = new Engineer(1, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.RuralNewSouthWales);
            var client = new Client(1, "The Client", "24 Main St, <further description", engineer.District);

            engineer.CreateClient(client);

            Assert.IsNotNull(ClientManager.Clients);
            Assert.AreEqual(true, ClientManager.Clients.Contains(client));
            Assert.AreEqual(client, ClientManager.Clients.First());
        }
    }
}
// http://www.yegor256.com/2014/05/05/oop-alternative-to-utility-classes.html