using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinStoreApi.Data;
using SkinStoreApi.Models;

namespace SkinStoreApi.Services
{
    public class UserService
    {
        private readonly SkinStoreApiContext _context;

        public UserService(SkinStoreApiContext context)
        {
            _context = context;
        }

        //Buscando usuários pelo "Name" na tabela User
        public async Task<List<User>> FindAllAsync()
        {
            var lista = await _context.User.OrderBy(x => x.Name).ToListAsync();
            foreach (var usuario in lista)
            {
                //
                var usResultList = new List<UsResult>();
                var usList = await _context.UserSkin.Where(x => x.CodeUser == usuario.Id).ToListAsync();
                foreach (var dbUserSkin in usList)
                {
                    usResultList.Add(new UsResult
                    {
                        CodeSkin = dbUserSkin.CodeSkin,
                        CodeUser = dbUserSkin.CodeUser,
                        Id = dbUserSkin.Id
                    });
                }
                usuario.UsResult = usResultList;
            }
            return lista;
        }

        //Buscando usuários pelo "Login" na tabela User
        public async Task InsertAsync(User obj)
        {
            var userBanco = _context.User.Where(x => x.Login.ToLower() == obj.Login.ToLower()).FirstOrDefault();
            //Atualizando o usuário caso ele já exista
            if (userBanco != null)
            {
                userBanco.Name = obj.Name;
                userBanco.LastName = obj.LastName;
                userBanco.Email = obj.Email;
                userBanco.Password = obj.Password;
                userBanco.Balance = obj.Balance;
                userBanco.Active = obj.Active;
                _context.Update(userBanco);
                await _context.SaveChangesAsync();
            }
            //Inserindo um usuário caso ele não exista
            else
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
        }

        //Buscando usuários pelo "Login" na tabela User
        public async Task RemoveAsync(string Login)
        {
            var userBanco = _context.User.Where(x => x.Login.ToLower() == Login.ToLower()).FirstOrDefault();
            //Deletando o usuário caso ele exista
            if (userBanco != null)
            {
                _context.Remove(userBanco);
                await _context.SaveChangesAsync();
            }
        }
    }
}
