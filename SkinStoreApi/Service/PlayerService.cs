using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinStoreApi.Data;
using SkinStoreApi.Models;

namespace SkinStoreApi.Services
{
    public class PlayerService
    {
        private readonly SkinStoreApiContext _context;

        public PlayerService(SkinStoreApiContext context)
        {
            _context = context;
        }

        //Buscando player pelo "Nick" na tabela player
        public async Task<List<Player>> FindAllAsync()
        {
            return await _context.Player.OrderBy(x => x.Nick).ToListAsync();
        }
    }
}