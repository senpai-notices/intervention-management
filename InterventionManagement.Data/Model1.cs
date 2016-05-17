namespace ASDF.ENETCare.InterventionManagement.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }
        public virtual DbSet<InterventionState> InterventionStates { get; set; }
        public virtual DbSet<InterventionTemplate> InterventionTemplates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
