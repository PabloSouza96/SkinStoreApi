using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkinStoreApi.Models;
using SkinStoreApi.Services;

namespace SkinStoreApi.Controllers
{
    [ApiController]
    [Route("Skin")]
    public class SkinController : ControllerBase
    {
        private readonly SkinService _skinService;

        public SkinController(SkinService skinService)
        {
            _skinService = skinService;
        }

        //Rota para buscar a lista de produtos
        [HttpGet]
        public Task<List<Skin>> Get()
        {
            var produtos = _skinService.FindAllAsync();
            return produtos;
        }

        //Rota para receber uma skin como parametro
        [HttpPost]
        public async Task Post(Skin skin)
        {
            await _skinService.InsertAsync(skin);
        }

        //Rota para deletar uma skin pela "Key"
        [HttpDelete]
        public async Task Delete(string Key)
        {
            await _skinService.RemoveAsync(Key);
        }
    }
}