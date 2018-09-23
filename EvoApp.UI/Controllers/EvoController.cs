using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvoApp.UI.Repositories;
using EvoApp.UI.Services;
using EvoApp.UI.Services.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvoController : ControllerBase
    {
        //private IEvoRepository _evoRepository;
        private EvoServices _evoService;

        public EvoController(IEvoRepository evoRepository)
        {
            //_evoRepository = evoRepository;
            _evoService = new EvoServices(evoRepository);
        }

        [HttpGet("[action]")]
        public IEnumerable<EvoDto> GetEvos()
        {
            return _evoService.GetAllEvos();
        }

        [HttpPost("[action]")]
        public void AddEvo(EvoDto evo)
        {
            evo.IsActive = true;
            evo.IsDeleted = true;
            _evoService.InsertEvo(evo);
        }

        [HttpDelete("[action]")]
        public bool DeleteEvo(int id)
        {
            if (!ModelState.IsValid)
                return false;

            return _evoService.DeleteEvo(id);
        }
    }
}