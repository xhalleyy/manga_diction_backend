using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace manga_diction_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendController : ControllerBase
    {
        private readonly FriendService _data;
        public FriendController(FriendService data)
        {
            _data = data;
        }

        // Add User as Friend
        [HttpPost]
        [Route("AddFriend/{userId}/{friendId}")]
        public IActionResult AddFriend(int userId, int friendId)
        {
            return _data.AddFriend(userId, friendId);
        }

        // Get Pending Requests Based On FriendId 
        // NOT userId because userId is the one that requested to add friendId
        [HttpGet]
        [Route("GetPendingFriends/{userId}")]
        public IActionResult GetPendingFriends(int userId)
        {
            return _data.GetPendingFriends(userId);
        }

        // Accepts OR Deny Friend Requests
        [HttpPut]
        [Route("HandleFriendRequest/{id}")]
        public IActionResult HandleFriendRequest(int id, [FromBody] string action)
        {
            return _data.HandleFriendRequest(id, action);
        }

        [HttpGet]
        [Route("GetAcceptedFriends/{userId}")]
        public IActionResult GetAcceptedFriends(int userId)
        {
            return _data.GetAcceptedFriends(userId);
        }

        [HttpDelete]
        [Route("DeleteFriend/{userId}/{friendId}")]
        public IActionResult DeleteFriend(int userId, int friendId){
            return _data.DeleteFriend(userId, friendId);
        }

    }
}