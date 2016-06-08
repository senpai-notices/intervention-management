using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public class DistrictRepository: Repository<District>
    {

        public DistrictRepository(ApplicationDbContext appContext) : base(appContext)
        {

        }


        public string GetDistrictName(int id)
        {
            return Context.District.First(x => x.DistrictId == id).Name;
        }
    }
}
