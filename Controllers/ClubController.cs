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

        // Get Public Clubs
        [HttpGet]
        [Route("GetClubsByPrivacy")]
        public IActionResult GetClubsByPrivacy(){
            return _data.GetClubsByPrivacy();
        }

        // Get Club for how many members

        // Get Clubs based on creation date

        // Get Club based on 

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

        [HttpDelete]
        [Route("DeleteClub")]
        public bool DeleteClub(ClubModel clubToDelete){
            return _data.DeleteClub(clubToDelete);
        }

    }

}