using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    public class MainContext : DbContext
    {
        public MainContext() : base("MainContext")
        {
        }

        public DbSet<Intervention> Intervention { get; set; }
        public DbSet<InterventionState> InterventionState { get; set; }
        //public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
