using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    public class Startup
    {
        public Startup()
        {
            Database.SetInitializer(new DatabaseInitializer());
            using (var db = new MainContext())
            {
                db.Database.Initialize(false);
            }
        }
    }
}
