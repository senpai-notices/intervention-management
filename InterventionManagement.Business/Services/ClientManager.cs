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

        public static string AddNewClient(string name, string location, int districtID)
        {
            try
            {
                if (ClientValidator.ValidateName(name) && ClientValidator.ValidateLocation(location))
                {
                    _clients.addClient(name, location, districtID);
                }

            }
            catch (ArgumentException e)
            {
                return e.Message;
            }

            return "Client was sucessfully added to the Databae";
            
            //Invalid Client Data
                //Console.WriteLine(e.Message);
        }
    }
}
