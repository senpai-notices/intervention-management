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

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class TotalCostsByEngineerViewModel : TotalCostByEngineerRow
    {
        public IEnumerable<TotalCostByEngineerRow> Engineers { get; set; }

        public TotalCostsByEngineerViewModel()
        {
            //var context = new ApplicationDbContext();
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var users = new GenericRepository<ApplicationUser>(context);
            //foreach (var user in users.SelectAll())
            //{
            //    if (userManager.IsInRole(user.Id, "Engineer"))
            //    {
            //        Debug.WriteLine(user.Name);
            //    }
            //}
            var engineerReportsRepository = new EngineerReportsRepository();
            foreach (var id in engineerReportsRepository.GetEngineerIds())
            {

            }
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
        public double TotalCost { get; set; }
    }
}