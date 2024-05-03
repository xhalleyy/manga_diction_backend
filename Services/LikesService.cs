using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace manga_diction_backend.Services
{
    public class LikesService : ControllerBase
    {
        private readonly DataContext _context;

        public LikesService(DataContext context)
        {
            _context = context;
        }


        public async Task<ActionResult<LikesResponseDTO>> GetLikesForPost(int postId)
        {
            try
            {
                int likesCount = await _context.LikesInfo.CountAsync(like => like.PostId == postId);
                var likes = await _context.LikesInfo.Include(like => like.User).Where(like => like.PostId == postId).ToListAsync();

                var likesResponse = new LikesResponseDTO
                {
                    LikesCount = likesCount,
                    LikedByUsers = likes.Select(like => new LikesByUserDTO
                    {
                        UserId = like.UserId,
                        Username = like.User.Username
                    }).ToList()
                };

                return likesResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting likes for post: {ex.Message}");
            }
        }

        public async Task<LikesModel> AddLikeToPost(int postId, int userId)
        {
            try
            {
                var existingLike = await _context.LikesInfo
                    .Include(like => like.User) // Include the related User entity
                    .FirstOrDefaultAsync(like => like.PostId == postId && like.UserId == userId);

                if (existingLike != null)
                {
                    throw new Exception("You have already liked this post.");
                }

                var like = new LikesModel
                {
                    PostId = postId,
                    UserId = userId,
                    LikedAt = DateTime.UtcNow
                };

                _context.LikesInfo.Add(like);
                await _context.SaveChangesAsync();

                // Now that the like is added and saved to the database,
                // include the related User entity before returning
                var likedWithUser = await _context.LikesInfo
                    .Include(l => l.User)
                    .FirstOrDefaultAsync(l => l.Id == like.Id);

                return likedWithUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding like: {ex.Message}");
            }
        }

        public async Task<ActionResult<bool>> RemoveLike(int postId, int userId)
        {
            try
            {
                var like = await _context.LikesInfo.FirstOrDefaultAsync(like => like.PostId == postId && like.UserId == userId);
                if (like == null)
                {
                    throw new Exception("Like not found.");
                }

                _context.LikesInfo.Remove(like);
                await _context.SaveChangesAsync();
                return true; // Indicate successful removal
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing like: {ex.Message}");
            }
        }
    }
}