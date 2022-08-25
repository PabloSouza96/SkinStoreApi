﻿using System.Collections.Generic;
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

        public async Task<List<User>> FindAllAsync()
        {
            return await _context.User.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(User obj)
        {
            var userBanco = _context.User.Where(x => x.Login.ToLower() == obj.Login.ToLower()).FirstOrDefault();
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
            else
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(string Login)
        {
            var userBanco = _context.User.Where(x => x.Login.ToLower() == Login.ToLower()).FirstOrDefault();
            if (userBanco != null)
            {
                _context.Remove(userBanco);
                await _context.SaveChangesAsync();
            }
        }
    }
}
