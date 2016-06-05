using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ASDF.ENETCare.InterventionManagement.Business;
using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int? Hours { get; set; }
        public decimal? Cost { get; set; }
        public int? DistrictId { get; set; }
        public virtual ICollection<Intervention> ProposedInterventions { get; set; }
        public virtual ICollection<Intervention> ApprovedInterventions { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<InterventionTemplate> InterventionTemplate { get; set; }
        public DbSet<Intervention> Intervention { get; set; }
        public DbSet<InterventionState> InterventionState { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");

            modelBuilder.Entity<Intervention>()
                .HasRequired(i => i.Proposer)
                .WithMany(a => a.ProposedInterventions)
                .HasForeignKey(a => a.ProposerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Intervention>()
                .HasOptional(i => i.Approver)
                .WithMany(a => a.ApprovedInterventions)
                .HasForeignKey(a => a.ApproverId)
                .WillCascadeOnDelete(false);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}