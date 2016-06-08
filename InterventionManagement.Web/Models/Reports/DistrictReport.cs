using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ASDF.ENETCare.InterventionManagement.Business;
using System.Collections;

namespace ASDF.ENETCare.InterventionManagement.Web.Models.Reports
{
    public class DistrictReport : CostHour_DistrictReport, IEnumerable<CostHour_DistrictReport>
    {
        public List<CostHour_DistrictReport> DistrictReports { get; set; }
        private IEnumerable<Intervention> Interventions;

        public DistrictReport(IEnumerable<Intervention> interventions, IEnumerable<District> districts)
        {
            DistrictReports = new List<CostHour_DistrictReport>();
            Interventions = interventions;

            foreach (var district in districts)
            {
                int districtId = district.DistrictId;
                decimal totalCost = GetTotalCostForDistrict(districtId);
                int totalHours = GetTotalHoursForDistrict(districtId);

                var report = new CostHour_DistrictReport();
                report.Name = district.Name;
                report.TotalCost = totalCost;
                report.TotalHours = totalHours;

                DistrictReports.Add(report);
            }
        }

        private decimal GetTotalCostForDistrict(int districtId)
        {
            decimal totalCost = 0;

            foreach (var intervention in Interventions)
            {
                if (intervention.InterventionStateId == 3)
                {
                    totalCost = totalCost + intervention.Cost;
                }
            }
            return totalCost;
        }

        private int GetTotalHoursForDistrict(int districtId)
        {
            int totalHours = 0;

            foreach (var intervention in Interventions)
            {
                if (intervention.InterventionStateId == 3)
                {
                    totalHours = totalHours + intervention.Hours;
                }
            }
            return totalHours;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return DistrictReports.GetEnumerator();
        }

        public IEnumerator<CostHour_DistrictReport> GetEnumerator()
        {
            return DistrictReports.GetEnumerator();
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