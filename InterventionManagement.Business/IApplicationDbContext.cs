using System.Data.Entity;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Client { get; set; }
        DbSet<District> District { get; set; }
        DbSet<InterventionTemplate> InterventionTemplate { get; set; }
        DbSet<Intervention> Intervention { get; set; }
        DbSet<InterventionState> InterventionState { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        int SaveChanges();
    }
}