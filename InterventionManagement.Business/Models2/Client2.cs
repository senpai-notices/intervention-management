using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Models2
{
    public class Client2
    {
        public int ClientId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public District2 District { get; private set; }

        public Client2(int clientId, string name, string location, District2 district)
        {
            ClientId = ClientValidator.ValidateClientId(clientId);
            Name = ClientValidator.ValidateName(name.Trim());
            Location = ClientValidator.ValidateLocation(location.Trim());
            District = district;
        }
    }
}
