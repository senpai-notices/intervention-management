using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;
using ASDF.ENETCare.InterventionManagement.Business;
using System.Diagnostics;//remove
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Linq;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class TotalCostsByEngineerViewModel : TotalCostByEngineerRow, IEnumerable<TotalCostByEngineerRow>
    {
        public List<TotalCostByEngineerRow> Rows { get; set; }

        public TotalCostsByEngineerViewModel()
        {
            var engineerReportsRepository = new EngineerReportsRepository();
            Rows = new List<TotalCostByEngineerRow>();

            // populate rows
            foreach (var engineer in engineerReportsRepository.GetEngineers())
            {
                var row = new TotalCostByEngineerRow();
                row.Name = engineer.Name;
                row.TotalHours = engineer.Hours ?? default(int);
                row.TotalCost = engineer.Cost ?? default(decimal);

                Rows.Add(row);
            }

            // sort alphabetically
            Rows = Rows.OrderBy(o => o.Name).ToList();
        }

        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Rows.GetEnumerator();
        }

        public IEnumerator<TotalCostByEngineerRow> GetEnumerator()
        {
            return Rows.GetEnumerator();
        }
    }

    public class TotalCostByEngineerRow
    {
        [Required]
        [DisplayName("Engineer Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Total Labour Hours")]
        public int TotalHours { get; set; }
        [Required]
        [DisplayName("Total Cost")]
        public decimal TotalCost { get; set; }
    }
}