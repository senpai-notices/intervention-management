using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using System.Collections.Generic;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class ClientTableWrapper
    {
        #region deprecated
        public void addClient(string name, string location, int districtId)
        {
            MainDataSet.ClientDataTable clients = new ClientTableAdapter().GetData();
            MainDataSet.ClientRow newClient = clients.NewClientRow();

            newClient.Name = name;
            newClient.Location = location;
            newClient.DistrictId = districtId;

            clients.Rows.Add(newClient);

            // update the database
            new ClientTableAdapter().Update(clients);
        }

        public List<string> getClientIdAndNameListForEngineer(string username)
        {
            List<string> clientNames = new List<string>();
            var clients = new ClientTableAdapter().GetDataBy_GetClientsByEngineerUsername(username);

            foreach (var client in clients)
            {
                clientNames.Add(client.ClientId.ToString() + " " + client.Name.ToString());
            }

            return clientNames;
        }

        /*        public string getClientNameByClientId(int clientId)
                {
                    var clientDataTable = new ClientTableAdapter().GetDataBy_ClientId(clientId);
                    var client = clientDataTable.Rows[0]["Name"].ToString();
                    return client;
                }*/
        #endregion

        public MainDataSet.ClientDataTable GetClients()
        {
            return new ClientTableAdapter().GetData();
        }

        public MainDataSet.ClientDataTable GetClientById(int id)
        {
            return new ClientTableAdapter().GetClientById(id);
        }

        public void InsertClient(string name, string location, int districtId)
        {
            new ClientTableAdapter().InsertClient(name, location, districtId);
        }

        public void DeleteClient(int id)
        {
            new ClientTableAdapter().DeleteClient(id);
        }

        public MainDataSet.ClientDataTable GetClientByDistrictId(int districtId)
        {
            return new ClientTableAdapter().GetDataBy_DistrictId(districtId);
        }
    }
}