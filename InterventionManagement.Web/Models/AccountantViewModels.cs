using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class TotalCostByEngineerViewModel
    {
        public IEnumerable<TotalCostByEngineerRow> Engineers { get; }
    }

    public class TotalCostByEngineerRow
    {
        [Required]
        [DisplayName("Engineer Name")]
        public string Name { get; }
        [Required]
        [DisplayName("Total Labour Hours")]
        public int TotalHours { get; }
        [Required]
        [DisplayName("Total Cost")]
        public double TotalCost { get; }
    }
}