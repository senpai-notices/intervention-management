namespace ASDF.ENETCare.InterventionManagement.Business
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // foreign keys
        public int DistrictID { get; set; }
    }
}
