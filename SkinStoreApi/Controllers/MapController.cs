using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkinStoreApi.Models;
using SkinStoreApi.Services;

namespace SkinStoreApi.Controllers
{
    [ApiController]
    [Route("Map")]
    public class MapController : ControllerBase
    {
        private readonly MapService _mapService;

        public MapController(MapService mapService)
        {
            _mapService = mapService;
        }

        //Rota para buscar a lista de mapas
        [HttpGet]
        public Task<List<Map>> Get(bool? comp = null)
        {
            if (comp == null)
            {
                return _mapService.FindAllAsync();
            }
            else
            {
                return _mapService.FindComp(comp.Value);
            }
        }

        ////Rota para buscar a lista de mapas competitivos
        //[HttpGet]
        //public Task<List<Map>> GetComp()
        //{
        //    var mapasComp = _mapService.FindComp();
        //    return mapasComp;
        //}
    }
}