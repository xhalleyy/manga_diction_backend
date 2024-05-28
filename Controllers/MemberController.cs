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
    public class MemberController : ControllerBase
    {
        private readonly MemberService _data;
        public MemberController (MemberService data){
            _data = data;
        }

        // GET CLUB IDS BY USER IDS?
        [HttpGet]
        [Route("GetUserClubs/{userId}")]
        public IActionResult GetUserClubs(int userId){
            return _data.GetUserClubs(userId);
        }

        // GET MEMBERS BY CLUB ID?
        [HttpGet]
        [Route("GetClubMembers/{clubId}")]
        public IActionResult GetClubMembers(int clubId){
            return _data.GetClubMembers(clubId);
        }

        // ADD USER TO CLUB MEMBERS
        [HttpPost]
        [Route("AddClubToUser")]
        public async Task<IActionResult> AddClubToUser(int userId, int clubId){
            return await _data.AddClubToUser(userId, clubId);
        }
        // ADD CLUB TO USER ID
        [HttpPost]
        [Route("AddMemberToClub/{userId}/{clubId}/{isLeader}")]
        public async Task<IActionResult> AddMemberToClub(int userId, int clubId, bool isLeader){
            return await _data.AddMemberToClub(userId, clubId, isLeader);
        }

        // GET PENDING REQUESTS AS LEADER
        [HttpGet]
        [Route("GetPendingRequest/{userId}")]
        public List<ClubMembers> GETPENDINGREQUESTFORCLUB(int userId)
        {
            return _data.GETPENDINGREQUESTFORCLUB(userId);
        }

        [HttpGet]
        [Route("GetUserStatusInClub/{clubId}/{userId}")]
        public IActionResult GetUserStatusInClub(int clubId, int userId){
            return _data.GetUserStatusInClub(clubId, userId);
        }

        // UPDATE INVITE REQUEST AS LEADER
        [HttpPut]
        [Route("UpdatePendingStatus/{id}")]
        public async Task<IActionResult> UpdatePendingStatus(int id, [FromBody] string newStatus){
            return await _data.UpdatePendingStatus(id, newStatus);
        }


        // DELETE USER IN CLUB MEMBERS
        [HttpDelete]
        [Route("RemoveMemberFromClub")]
        public async Task<IActionResult> RemoveMemberFromClub(int userId, int clubId){
            return await _data.RemoveMemberFromClub(userId, clubId);
        }
    }
}