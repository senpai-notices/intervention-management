using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    public class MainContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<InterventionTemplate> InterventionTemplate { get; set; }
        public DbSet<Intervention> Intervention { get; set; }

        public MainContext() : base("MainContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            /*            modelBuilder.Entity<Intervention>()
                            .HasRequired(m => m.Proposer)
                            .WithMany(m => m.ProposedInterventions)
                            .HasForeignKey(m => m.ProposerId);
                        modelBuilder.Entity<Intervention>()
                            .HasRequired(m => m.Approver)
                            .WithMany(m => m.ApprovedInterventions)
                            .HasForeignKey(m => m.ApproverId);*/
        }
    }
}
