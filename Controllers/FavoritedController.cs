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
    public class FavoritedController : ControllerBase
    {
        private readonly FavoritedService _data;
        public FavoritedController(FavoritedService data)
        {
            _data = data;
        }

        // ADD FAVORITES TO A USER
        [HttpPost]
        [Route("AddFavoriteManga/{userId}")]
        public async Task<ActionResult<FavoritedModel>> AddFavoriteManga(int userId, [FromBody] FavoritedModel favorited)
        {
            return await _data.AddFavoriteManga(userId, favorited);
        }

        // GET CURRENTLY READING FAVORITES
        [HttpGet]
        [Route("GetInProgressFavorites/{userId}")]
        public ActionResult<IEnumerable<FavoritedModel>> GetInProgressFavorites(int userId)
        {
            return _data.GetInProgressFavorites(userId);
        }

        // GET COMPLETED FAVORITES
        [HttpGet]
        [Route("GetCompletedFavorites/{userId}")]
        public ActionResult<IEnumerable<FavoritedModel>> GetCompletedFavorites(int userId)
        {
            return _data.GetCompletedFavorites(userId);
        }

        [HttpDelete]
        [Route("DeleteFavoriteManga/{userId}/{mangaId}")]
        public async Task<ActionResult> DeleteFavoriteManga(int userId, string mangaId)
        {
            return await _data.DeleteFavoriteManga(userId, mangaId);
        }
    }

}