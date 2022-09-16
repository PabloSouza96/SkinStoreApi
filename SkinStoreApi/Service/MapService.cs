using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinStoreApi.Data;
using SkinStoreApi.Models;

namespace SkinStoreApi.Services
{
    public class MapService
    {
        private readonly SkinStoreApiContext _context;

        public MapService(SkinStoreApiContext context)
        {
            _context = context;
        }

        //Buscando mapa pelo "Name" na tabela Map
        public async Task<List<Map>> FindAllAsync()
        {
            return await _context.Map.OrderBy(x => x.Name).ToListAsync();
        }

        //Buscando mapa competitivo pelo "Comp" na tabela Map
        public async Task<List<Map>> FindComp(bool comp)
        {
            return await _context.Map.Where(x => x.Comp == comp).ToListAsync();
        }


    }
}
