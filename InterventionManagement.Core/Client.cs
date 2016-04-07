namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class Client
    {
        public int ClientId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public DistrictName District { get; private set; }

        public Client(int clientId, string name, string location, DistrictName district)
        {
            ClientId = ClientValidator.ValidateClientId(clientId);
            Name = ClientValidator.ValidateName(name.Trim());
            Location = ClientValidator.ValidateLocation(location.Trim());
            District = district;
        }
    }
}
