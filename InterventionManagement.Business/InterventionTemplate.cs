using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class InterventionTemplate
    {
        public int InterventionTemplateId { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
    }
}
