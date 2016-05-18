namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Username { get; set; }
        public int DistrictId { get; set; }

        public virtual District District { get; set; }
    }
}