using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASDF.ENETCare.InterventionManagement.Web.Models.Reports
{
    public class DistrictReport
    {
        public Dictionary<District, CostHour_DistrictReport> DistrictReports { get; set; }

        public void CostHourByDistrictReport(IEnumerable<Intervention> Interventions, IEnumerable<District> Districts )
        {

            foreach (var district in Districts)
            {
                DistrictReports.Add(district, new CostHour_DistrictReport());
            }

            foreach (var intervention in Interventions)
            {
                //TODO: Directly reference completed intervention state.
                if (intervention.InterventionState.InterventionStateId == 3)
                {
                    CostHour_DistrictReport report = null;
                    var district = intervention.Client.District;

                    if (DistrictReports.TryGetValue(district, out report))
                    {
                        report.Name = district.Name;
                        report.TotalCost = report.TotalCost + intervention.Cost;
                        report.TotalHours = report.TotalHours + intervention.Hours;
                    }
                }
            }

        }

        public class CostHour_DistrictReport
        {
            [Required]
            [DisplayName("District Name")]
            public string Name { get; set; }
            [Required]
            [DisplayName("Total Labour Hours")]
            public int TotalHours { get; set; }
            [Required]
            [DisplayName("Total Cost")]
            public decimal TotalCost { get; set; }
        }
    }
}