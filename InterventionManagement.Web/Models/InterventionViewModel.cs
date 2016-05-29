using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class InterventionViewModel
    {
    }

    public class InterventionsListViewModel
    {
        public IEnumerable<Intervention> Interventions { get; set; }

    }
    


}