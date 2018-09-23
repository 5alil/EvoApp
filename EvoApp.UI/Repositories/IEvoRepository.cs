using EvoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoApp.UI.Repositories
{
    public interface IEvoRepository
    {
        IEnumerable<Evo> ListAll();
        Evo GetEvoById(int id);
        void Add(Evo evo);
        bool Delete(int id);
    }
}
