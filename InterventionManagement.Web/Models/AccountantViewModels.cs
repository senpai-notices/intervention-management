using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class TotalCostByEngineerViewModel
    {
        public IEnumerable<TotalCostByEngineerRow> Engineers { get; }
    }

    public class TotalCostByEngineerRow
    {
        public string Name { get; }
        public int TotalHours { get; }
        public double TotalCost { get; }
    }
}