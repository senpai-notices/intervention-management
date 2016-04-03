using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class Client
    {
        public int ClientID { get; set; }

        public string ClientName {
            get
            { return ClientName; }

            set
            {
                if (value == null || !value.Any(c => char.IsLetter(c)) || value.Trim() == string.Empty)
                {
                    throw new ArgumentException("Please enter a valid name. Name must not contain numbers.");
                }
                ClientName = value;
            }
        }

        public string ClientLocation {
            get
            { return ClientLocation; }

            set
            {
                if (value == null || value.Trim() == string.Empty)
                {
                    throw new ArgumentException("Please enter a location description.");
                }
                ClientLocation = value;
            }

        }
        public DistrictName ClientDistrictName { get; set; }

        public Client(int clientID, string Name, string location, DistrictName DistrictName)
        {
            ClientID = clientID;
            ClientName = Name;
            ClientLocation = location;
            ClientDistrictName = DistrictName;

        }
    }
}
