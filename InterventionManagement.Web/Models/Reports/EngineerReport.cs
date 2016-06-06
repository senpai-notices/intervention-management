using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Web.Models.Reports
{
    public class EngineerReport
    {
        public List<CostByEngineer> _report { get; set; }


        public EngineerReport(IEnumerable<Intervention> Interventions, IEnumerable<ApplicationUser> Engineers )
        {
            Dictionary<ApplicationUser, CostByEngineer> EngineersReport;
            EngineersReport = new Dictionary<ApplicationUser, CostByEngineer>() ;

            foreach (var engineer in Engineers)
            {
                var item = new CostByEngineer();
                item.Name = engineer.Name;
                item.TotalCost = 0;
                item.TotalHours = 0;
                item.Completed = 0;
                EngineersReport.Add(engineer, item);
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

            _report = new List<CostByEngineer>();
            foreach (var item in EngineersReport)
            {
                _report.Add(item.Value);
            }

        }
        public void AverageCostHour()
        {
            //Averages the amounts per engineer
            foreach (var report in _report)
            {
                int completed = report.Completed;
                int hours = report.TotalHours;
                decimal cost = report.TotalCost;

                report.TotalHours = hours / completed;
                report.TotalCost = cost / completed;
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