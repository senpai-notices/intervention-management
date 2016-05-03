using System.Collections.Generic;
using System.Data;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class DistrictWrapper
    {

        public List<string> getDistricts()
        {
            List<string> districtNames = new List<string>();
            var districts = new Data.DataSets.MainDataSetTableAdapters.DistrictTableAdapter().GetData();
            foreach (var district in districts)
            {
                districtNames.Add(district.Name.ToString());
            }
            return districtNames;

        }
    }
    
}
