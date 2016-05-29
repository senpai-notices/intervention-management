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
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;

        public ClientRepository(ApplicationDbContext appContext)
        {
            _context = appContext;
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
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public Client GetClientById(int clientId)
        {
            return _context.Client.Find(clientId);
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Client.ToList();
        }

        public void InsertClient(Client client)
        {
            _context.Client.Add(client);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
        }
    }
}
