using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    public class MainContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<InterventionTemplate> InterventionTemplate { get; set; }
        public DbSet<Intervention> Intervention { get; set; }
        public DbSet<InterventionState> InterventionState { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        

        public MainContext() : base("MainContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
