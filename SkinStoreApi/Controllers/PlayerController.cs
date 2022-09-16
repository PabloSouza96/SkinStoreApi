using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkinStoreApi.Models;
using SkinStoreApi.Services;

namespace SkinStoreApi.Controllers
{
    [ApiController]
    [Route("Player")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        //Rota para buscar a lista de jogadores
        [HttpGet]
        public Task<List<Player>> Get()
        {
            var jogadores = _playerService.FindAllAsync();
            return jogadores;
        }
    }
}