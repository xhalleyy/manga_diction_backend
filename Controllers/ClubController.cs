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
    public class ClubController : ControllerBase
    {
        private readonly ClubService _data;

        public ClubController(ClubService data)
        {
            _data = data;
        }

        // Get All CLubs
        [HttpGet]
        [Route("GetAllClubs")]
        public IEnumerable<ClubModel> GetAllClubs()
        {
            return _data.GetAllClubs();
        }

        // Get Clubs From LeaderId
        [HttpGet]
        [Route("GetClubsByLeader/{leaderId}")]
        public async Task<ActionResult<List<ClubModel>>> GetClubsByLeader(int leaderId){
            var clubs = await _data.GetClubsByLeaderAsync(leaderId);
            return clubs;
        }

        // Get Public Clubs
        [HttpGet]
        [Route("GetAllPublicClubs")]
        public IEnumerable<ClubModel>GetAllPublicClubs(){
            return _data.GetAllPublicClubs();
        }

        // Get Club by ID
        [HttpGet]
        [Route("GetClubById/{id}")]
        public ClubModel GetClubById(int id){
            return _data.GetClubById(id);
        }

        // Get Club by Name
        [HttpGet]
        [Route("GetClubsByName/{club}")]
        public List<ClubModel>GetClubsByName(string club){
            return _data.GetClubsByName(club);
        }

        // Get Club by Recently Created
        [HttpGet]
        [Route("GetRecentPublicClubs")]
        public List<ClubModel> GetRecentPublicClubs(){
            return _data.GetRecentPublicClubs().ToList();
        }
        
        [HttpGet]
        [Route("GetOldestPublicClubs")]
        public List<ClubModel> GetOldestPublicClubs(){
            return _data.GetOldestPublicClubs().ToList();
        }

        [HttpGet]
        [Route("GetPopularClubs")]
        public async Task<ActionResult<List<ClubMemberCountDTO>>> GetPopularClubs(){
           return await _data.GetPopularClubs(); 
        }

        // Create Club
        [HttpPost]
        [Route("CreateClub")]
        public bool CreateClub(ClubModel newClub){
            return _data.CreateClub(newClub);
        }

        // Update Club
        [HttpPut]
        [Route("UpdateClub")]
        public bool UpdateClub(ClubModel clubToUpdate){
            return _data.UpdateClub(clubToUpdate);
        }

        // Delete Club
        [HttpDelete]
        [Route("DeleteClub")]
        public bool DeleteClub(ClubModel clubToDelete){
            return _data.DeleteClub(clubToDelete);
        }

    }

}