using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;

namespace manga_diction_backend.Services
{
    public class FavoritedService : ControllerBase
    {
        private readonly DataContext _context;

        public FavoritedService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<FavoritedModel>> AddFavoriteManga(int userId, [FromBody] FavoritedModel favorited)
        {
            var newFavorite = new FavoritedModel
            {
                UserId = userId,
                MangaId = favorited.MangaId,
                Completed = favorited.Completed
            };

            _context.FavoritedInfo.Add(newFavorite);
            await _context.SaveChangesAsync();

            return Ok("Manga successfully added to favorites");
        }

        public ActionResult<IEnumerable<FavoritedModel>> GetInProgressFavorites(int userId)
        {
            var readingFavorites = _context.FavoritedInfo
                .Where(favorite => favorite.UserId == userId && !favorite.Completed)
                .ToList();

            return Ok(readingFavorites);
        }

        public ActionResult<IEnumerable<FavoritedModel>> GetCompletedFavorites(int userId)
        {
            var completedFavorites = _context.FavoritedInfo
               .Where(favorite => favorite.UserId == userId && favorite.Completed)
               .ToList();

            return Ok(completedFavorites);
        }

        public async Task<ActionResult<FavoritedModel>> DeleteFavoriteManga(int id)
        {
            var favoriteToDelete = _context.FavoritedInfo.Find(id);

            if (favoriteToDelete == null)
            {
                return NotFound("Favorite not found.");
            }

            _context.FavoritedInfo.Remove(favoriteToDelete);
            await _context.SaveChangesAsync();

            return Ok("Favorite deleted successfully.");
        }
    }
}