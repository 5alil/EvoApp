using EvoApp.Data;
using EvoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoApp.UI.Repositories
{
    public class EvoRepository : IEvoRepository
    {
        private readonly EvoContext _dbContext;

        public EvoRepository(EvoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Evo> ListAll()
        {
            return _dbContext.Evos.AsEnumerable();
        }

        public void Add(Evo evo)
        {
            _dbContext.Evos.Add(evo);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var evo = _dbContext.Evos.Where(x => x.Id == id).FirstOrDefault();
            if (evo == null)
                return false;
            evo.IsDeleted = true;
            _dbContext.SaveChanges();
            return true;
        }

        public Evo GetEvoById(int id)
        {
            return _dbContext.Evos.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
        }
    }
}
