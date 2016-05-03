using System;
using System.Collections.Generic;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class InterventionTemplateTableWrapper
    {
        public List<string> getTemplateIdAndNameList()
        {
            List<string> templateNames = new List<string>();
            var templates = new InterventionTemplateTableAdapter().GetData();

            foreach (var template in templates)
            {
                templateNames.Add(template.InterventionTemplateId.ToString() + " " + template.Name.ToString());
            }

            return templateNames;
        }
    }
}
