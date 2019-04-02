using HelloCore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        BestellingRepository BestellingRepository { get; }
        void Save();
    }
}
