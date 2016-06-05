using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string Name { get; set; }
        public int? Hours { get; set; }
        public decimal? Cost { get; set; }
        public int? DistrictId { get; set; }
        public virtual ICollection<Intervention> ProposedInterventions { get; set; }
        public virtual ICollection<Intervention> ApprovedInterventions { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomUserClaim : IdentityUserClaim<int> { }

    public class CustomUserRole : IdentityUserRole<int> { }

    public class ApplicationRoleManager : RoleManager<CustomRole, int>
    {
        public ApplicationRoleManager(IRoleStore<CustomRole, int> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<CustomRole, int, CustomUserRole>(context.Get<ApplicationDbContext>()));
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<InterventionTemplate> InterventionTemplate { get; set; }
        public DbSet<Intervention> Intervention { get; set; }
        public DbSet<InterventionState> InterventionState { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<CustomRole>().ToTable("Roles");
            modelBuilder.Entity<CustomUserRole>().HasKey(r => new {r.UserId, r.RoleId}).ToTable("UserRoles");
            modelBuilder.Entity<CustomUserLogin>().HasKey(l => new {l.LoginProvider, l.ProviderKey, l.UserId}).ToTable("UserLogins");
            modelBuilder.Entity<CustomUserClaim>().ToTable("UserClaims");

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