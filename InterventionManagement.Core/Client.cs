using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class Client
    {
        public int ClientId { get; set; }
        private string _clientName;
        private string _clientLocation;

        public string ClientName {
            get
            {
                return _clientName;
            }

            set
            {
                _clientName = value;
                if (string.IsNullOrWhiteSpace(_clientName) || !value.Any(char.IsLetter))
                {
                    throw new ArgumentException("Please enter a valid name. Name must not contain numbers.");
                }

            }
        }

        public string ClientLocation {
            get
            { return _clientLocation; }

            set
            {
                _clientLocation = value;
                if (string.IsNullOrWhiteSpace(_clientLocation))
                {
                    throw new ArgumentException("Please enter a location description.");
                }

            }

        }
        public DistrictName ClientDistrictName { get; set; }

        public Client(int clientId, string name, string location, DistrictName districtName)
        {
            ClientId = clientId;
            ClientName = name;
            ClientLocation = location;
            ClientDistrictName = districtName;

        }
    }
}
