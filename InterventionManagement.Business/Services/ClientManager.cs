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

        public static bool AddNewClient(string name, string location, int districtID, int engineerDistrict)
        {
            try
            {
                if (ClientValidator.ValidateName(name) && ClientValidator.ValidateLocation(location) && districtID == engineerDistrict)
                {
                    //TODO: AddNewClient(Stub)
                    //Valid Client Entry
                    //_clients.AddNewClient(name, location, districtID
                }
            }
            catch (System.Exception e)
            {
                //Invalid Client Data
                Console.WriteLine(e.Message);
                return false;
            }

            //Valid Client has beed added
            return true;


        }

        //TODO: GetClientByID (Required Get Client In Wrapper)
        //public static Client GetClientById(int clientId)
        //{
        //    return _clients.FirstOrDefault(c => c.ClientId == clientId);
        //}
    }
}
