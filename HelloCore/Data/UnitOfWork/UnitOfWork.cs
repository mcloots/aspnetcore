using HelloCore.Data.Repository;
using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HelloCoreContext _context;

        public UnitOfWork(HelloCoreContext context)
        {
            _context = context;
        }
      

        private GenericRepository<Bestelling> iBestellingRepository;

        public GenericRepository<Bestelling> BestellingRepository
        {
            get
            {
                if (this.iBestellingRepository == null)
                {
                    this.iBestellingRepository = new GenericRepository<Bestelling>(_context);
                }
                return iBestellingRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
