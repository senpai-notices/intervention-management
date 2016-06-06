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
    public class EngineerReport
    {
        public Dictionary<ApplicationUser, CostByEngineer> EngineersReport { get; set; }


        public EngineerReport(IEnumerable<Intervention> Interventions, IEnumerable<ApplicationUser> Engineers )
        {
            
            foreach (var engineer in Engineers)
            {
                EngineersReport.Add(engineer, new CostByEngineer());
            }

            foreach (var intervention in Interventions)
            {
                //TODO: Directly reference completed intervention state.
                if (intervention.InterventionState.InterventionStateId == 3)
                {
                    CostByEngineer report = null;
                    var responsible = intervention.Approver;

                    if (EngineersReport.TryGetValue(responsible, out report))
                    {
                        report.Completed++;
                        report.Name = responsible.Name;
                        report.TotalCost = report.TotalCost + intervention.Cost;
                        report.TotalHours = report.TotalHours + intervention.Hours;
                    }
                }
            }

        }
        public void AverageCostHour()
        {
            //Averages the amounts per engineer
            foreach (var report in EngineersReport)
            {
                int completed = report.Value.Completed;
                int hours = report.Value.TotalHours;
                decimal cost = report.Value.TotalCost;

                report.Value.TotalHours = hours / completed;
                report.Value.TotalCost = cost / completed;
            }
        }

        public class CostByEngineer
        {
            [Required]
            [DisplayName("Engineer Name")]
            public string Name { get; set; }
            [Required]
            [DisplayName("Completed Interventions")]
            public int Completed { get; set; }
            [Required]
            [DisplayName("Total Labour Hours")]
            public int TotalHours { get; set; }
            [Required]
            [DisplayName("Total Cost")]
            public decimal TotalCost { get; set; }

            
        }
    }
}