using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // Create User Endpoint
        [HttpPost]
        [Route("CreateUser")]
        public bool CreateUser(CreateAccountDTO UserToAdd){
            return _data.CreateUser(UserToAdd);
        }

        // Update User Endpoint

        // Delete User Endpoint
    }
}