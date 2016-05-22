using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class Demo
    {
        [TestMethod]
        public void CreateClient()
        {
            var mockContext = new Mock<MainContext>();
            var unitOfWork = new UnitOfWork(mockContext.Object);

            unitOfWork.Complete();
            mockContext.Verify(x => x.SaveChanges());
        }
    }
}
