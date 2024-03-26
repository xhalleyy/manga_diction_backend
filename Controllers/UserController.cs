using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;
using manga_diction_backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace manga_diction_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;
        public UserController (UserService _dataFromService){
            _data = _dataFromService;
        }

        // Login Endpoint
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User){
            return _data.Login(User);
        }

        // Create User Endpoint
        [HttpPost]
        [Route("CreateUser")]
        public bool CreateUser(CreateAccountDTO UserToAdd){
            return _data.CreateUser(UserToAdd);
        }

        // Update User Endpoint
        [HttpPut]
        [Route("UpdateUser")]
        public bool UpdateUser(UserModel userToUpdate){
            return _data.UpdateUser(userToUpdate);
        }

        // Delete User Endpoint
        [HttpPut]
        [Route("UpdateUser/{id}/{username}")]
        public bool UpdateUser(int id, string username){
            return _data.UpdateUsername(id, username);
        }

        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete){
            return _data.DeleteUser(userToDelete);
        }
    }
}