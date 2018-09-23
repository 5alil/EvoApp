using EvoApp.Domain;
using EvoApp.UI.Repositories;
using EvoApp.UI.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvoApp.UI.Services
{
    public class EvoServices
    {
        private readonly IEvoRepository _evoRepository;

        public EvoServices(IEvoRepository evoRepository)
        {
            _evoRepository = evoRepository;
        }


        public void InsertEvo(EvoDto evo)
        {
            _evoRepository.Add(new Domain.Evo() {
                Name = evo.Name,
                IsActive = evo.IsActive
            });
        }

        public IEnumerable<EvoDto> GetAllEvos()
        {
            List<EvoDto> evos = new List<EvoDto>();
            foreach (var evo in _evoRepository.ListAll().Where(x => !x.IsDeleted).ToList())
                evos.Add(new EvoDto() { Id = evo.Id, Name = evo.Name, IsActive = evo.IsActive, IsDeleted = evo.IsDeleted });
            return evos;
        }

        public bool DeleteEvo(int id)
        {
            return _evoRepository.Delete(id);
        }

        public bool IsActiveEvo(int evoId)
        {
            Evo evo = _evoRepository.GetEvoById(evoId);
            if (evo == null) 
                throw new NotImplementedException("Please enter valid evo id !!!!");
            
            return evo.IsActive;
        }

    }
}
