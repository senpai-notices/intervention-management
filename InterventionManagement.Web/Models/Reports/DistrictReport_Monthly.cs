using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Web.Models.Reports
{
    public class DistrictReport_Monthly
    {
        public Dictionary<int,CostHour_District_Month_Report> MonthReports { get; set; }

        public DistrictReport_Monthly(IEnumerable<Intervention> Interventions, District District, int ReportYear)
        {
            //Initialise Months
            for (int i=1; i <=12; i++ )
            {
                var month = new CostHour_District_Month_Report();
                month.Name = District.Name;
                month.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                month.TotalCost = 0;
                month.TotalHours = 0;
                MonthReports.Add(i, new CostHour_District_Month_Report());
            }

            //Populate based on months
            foreach (var intervention in Interventions)
            {
                //TODO: Directly reference completed intervention state.
                if (intervention.DatePerformed.Year == ReportYear)
                {
                    CostHour_District_Month_Report report = null;

                    if (MonthReports.TryGetValue(intervention.DatePerformed.Month, out report))
                    {
                       // if(report.Name == null)  report.Name = intervention.Client.District.Name;
                       // if (report.Month == null) report.Month = intervention.DatePerformed.Month.ToString("MMMM");
                        report.TotalCost = report.TotalCost + intervention.Cost;
                        report.TotalHours = report.TotalHours + intervention.Hours;
                    }
                }
            }

        }

        public class CostHour_District_Month_Report
        {
            [Required]
            [DisplayName("District Name")]
            public string Name { get; set; }
            [Required]
            [DisplayName("Month")]
            public string Month { get; set; }
            [Required]
            [DisplayName("Total Labour Hours")]
            public int TotalHours { get; set; }
            [Required]
            [DisplayName("Total Cost")]
            public decimal TotalCost { get; set; }
        }
    }
}