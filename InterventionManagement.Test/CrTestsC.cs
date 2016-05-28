using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class CrTestsC
    {
        [TestMethod]
        public void InsertClient()
        {
            Mock<IClientR> clientRepo = new Mock<IClientR>();

            //clientRepo.Setup(x => x.)
        }
    }
}
