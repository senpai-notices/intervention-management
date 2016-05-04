using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers;
using System;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services
{
    // Should this be static? Static classes cannot implement interfaces
    public static class ClientManager
    {
        private static ClientTableWrapper _clients = new ClientTableWrapper();

        public static void AddNewClient(string name, string location, int districtID, int engineerDistrict)
        {
            if (ClientValidator.ValidateName(name) && ClientValidator.ValidateLocation(location) && districtID == engineerDistrict)
                {
                    _clients.addClient(name, location, districtID);
                }
                //Invalid Client Data
                //Console.WriteLine(e.Message);
        }
    }
}
