using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public class ClientRepository : IClientRepository, IDisposable
    {
        private ApplicationDbContext context;
        private bool disposed = false;

        public ClientRepository(ApplicationDbContext appcontext)
        {
            context = appcontext;
        }

        public void DeleteClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public Client GetClientById(int clientId)
        {
            return context.Client.Find(clientId);
        }

        public IEnumerable<Client> GetClients()
        {
            return context.Client.ToList();
        }

        public void InsertClient(Client client)
        {
            context.Client.Add(client);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            context.Entry(client).State = EntityState.Modified;
        }
    }
}
