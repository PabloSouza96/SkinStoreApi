using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinStoreApi.Data;
using SkinStoreApi.Models;

namespace SkinStoreApi.Services
{
    public class SkinService
    {
        private readonly SkinStoreApiContext _context;

        public SkinService(SkinStoreApiContext context)
        {
            _context = context;
        }

        public async Task<List<Skin>> FindAllAsync()
        {
            return await _context.Skin.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Skin obj)
        {
            var skinBanco = _context.Skin.Where(x => x.Key.ToLower() == obj.Key.ToLower()).FirstOrDefault();
            if (skinBanco != null)
            {
                skinBanco.Name = obj.Name;
                skinBanco.Float = obj.Float;
                skinBanco.Value = obj.Value;
                skinBanco.Amount = obj.Amount;
                _context.Update(skinBanco);
                await _context.SaveChangesAsync();
            }
            else
            {
                obj.Key = obj.Name.ToLower().Replace(" ","") + obj.Float.ToString();
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(string Key)
        {
            var skinBanco = _context.Skin.Where(x => x.Key.ToLower() == Key.ToLower()).FirstOrDefault();
            if (skinBanco != null)
            {
                _context.Remove(skinBanco);
                await _context.SaveChangesAsync();
            }
        }
    }
}