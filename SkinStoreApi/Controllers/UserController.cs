using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkinStoreApi.Models;
using SkinStoreApi.Services;

namespace SkinStoreApi.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //Rota para buscar na lista de usuários
        [HttpGet]
        public Task<List<User>> Get()
        {
            var usuarios = _userService.FindAllAsync();
            return usuarios;
        }

        //Rota para receber um usuário como parametro
        [HttpPost]
        public async Task Post(User user)
        {
            await _userService.InsertAsync(user);
        }

        //Rota para deletar um usuário pelo "Login"
        [HttpDelete]
        public async Task Delete(string Login)
        {
            await _userService.RemoveAsync(Login);
        }
    }
}