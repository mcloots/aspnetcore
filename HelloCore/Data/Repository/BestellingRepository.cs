using HelloCore.Data.UnitOfWork;
using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Data.Repository
{
    public class BestellingRepository : IBestellingRepository
    {
        private readonly HelloCoreContext _context;

        public BestellingRepository(HelloCoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Bestelling Add(Bestelling bestelling)
        {
            return _context.Bestellingen.Add(bestelling).Entity;
        }

        public Bestelling Find(int bestellingID)
        {
            return _context.Bestellingen.Find(bestellingID);
        }

        public IEnumerable<Bestelling> All()
        {
            return _context.Bestellingen.ToList();
        }

        public IQueryable<Bestelling> Search()
        {
            return _context.Bestellingen.AsQueryable();
        }
    }
}
