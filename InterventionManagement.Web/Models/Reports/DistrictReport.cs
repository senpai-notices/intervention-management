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
        public Dictionary<ApplicationUser, DistrictReport> EngineersReport { get; set; }

        public void CostHourByEngineerReport(IEnumerable<Intervention> Interventions)
        {
            var engineers = new GenericRepository<District>();

            foreach (var district in engineers.GetEngineers())
            {
                EngineersReport.Add(district, new DistrictReport());
            }

            foreach (var intervention in Interventions)
            {
                //TODO: Directly reference completed intervention state.
                if (intervention.InterventionState.InterventionStateId == 3)
                {
                    CostHour_DistrictReport report = null;
                    var responsible = intervention.Approver;

                    if (EngineersReport.TryGetValue(responsible, out report))
                    {
                        report.Name = responsible.Name;
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