using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System.Threading.Tasks;
using System.Data;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class InterventionTableWrapper
    {

        public Dictionary<int, KeyValuePair<string, string>> getInterventionsByManager(string username)
        {

            Dictionary<int, KeyValuePair<string, string>> details = new Dictionary<int, KeyValuePair<string, string>>();
            var interventionTemplate = new InterventionTemplateTableAdapter().GetData();
            var interventions = new InterventionTableAdapter().GetDataBy_GetInterventionsByManager(username);

            var Interventiondetails = from intervention in interventions
                                      join template in interventionTemplate on
                                      intervention.InterventionTemplateId equals template.InterventionTemplateId
                                      select template.Name;

            foreach(var interventionName in Interventiondetails)
            {
                foreach (var interventionInfo in interventions)
                {      
                    string interventionData = "Cost: " + interventionInfo.Cost.ToString()
                        + "<br>" + "Hours: " + interventionInfo.Hours.ToString() + "<br>" +
                        "Note: " + interventionInfo.Notes;
                    details.Add(interventionInfo.InterventionId, new KeyValuePair<string,string>(interventionName.ToString(),interventionData));
                }                           
            }

            return details;
        }

        
    }
}
