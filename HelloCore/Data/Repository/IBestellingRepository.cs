using HelloCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Data.Repository
{
    public interface IBestellingRepository
    {
        Bestelling Add(Bestelling bestelling);
        Bestelling Find(int bestellingID);
        IEnumerable<Bestelling> All();
    }
}
