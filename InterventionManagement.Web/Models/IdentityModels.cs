using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ASDF.ENETCare.InterventionManagement.Business;
using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int Hours { get; set; }
        public decimal Cost { get; set; }
        public int DistrictId { get; set; }
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

            // Custom entities
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<District>().ToTable("Districts");
            modelBuilder.Entity<Intervention>().ToTable("Interventions");
            modelBuilder.Entity<InterventionState>().ToTable("InterventionStates");
            modelBuilder.Entity<InterventionTemplate>().ToTable("InterventionTemplates");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}