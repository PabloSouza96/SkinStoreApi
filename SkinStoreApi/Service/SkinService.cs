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
        
        //Buscando skins pelo "Name" na tabela Skin
        public async Task<List<Skin>> FindAllAsync()
        {
            return await _context.Skin.OrderBy(x => x.Name).ToListAsync();
        }

        //Buscando skins pela "Key" na tabela Skin
        public async Task InsertAsync(Skin obj)
        {
            var skinBanco = _context.Skin.Where(x => x.Key.ToLower() == obj.Key.ToLower()).FirstOrDefault();
            //Atualizando a skin caso ele já exista
            if (skinBanco != null)
            {
                skinBanco.Name = obj.Name;
                skinBanco.Float = obj.Float;
                skinBanco.Value = obj.Value;
                skinBanco.Amount = obj.Amount;
                _context.Update(skinBanco);
                await _context.SaveChangesAsync();
            }
            //Inserindo uma skin caso ela não exista
            //Key vai ser o Name + Float, com letras minúsculas e sem espaço
            else
            {
                obj.Key = obj.Name.ToLower().Replace(" ","") + obj.Float.ToString();
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
        }

        //Buscando skins pela "Key" na tabela Skin
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