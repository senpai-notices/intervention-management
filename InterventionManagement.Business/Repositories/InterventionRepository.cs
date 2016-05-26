using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    class InterventionRepository : IInterventionRepository, IDisposable
    {
        private ApplicationDbContext _context;
        private bool _disposed = false;

        public InterventionRepository(ApplicationDbContext appContext)
        {
            _context = appContext;
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

        public IEnumerable<Intervention> GetInterventions()
        {
            return _context.Intervention.ToList();
        }

        public Intervention GetInterventionById(int interventionId)
        {
            return _context.Intervention.Find(interventionId);
        }

        public void InsertIntervention(Intervention intervention)
        {
            _context.Intervention.Add(intervention);
        }

        public void DeleteIntervention(int interventionId)
        {
            throw new NotImplementedException();
        }

        public void UpdateIntervention(Intervention intervention)
        {
            _context.Entry(intervention).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
