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

        public async Task<ActionResult<LikesResponseDTO>> GetLikesForComment(int commentId)
        {
            try
            {
                int likesCount = await _context.LikesInfo.CountAsync(like => like.CommentId == commentId);
                var likes = await _context.LikesInfo
                    .Include(like => like.User)
                    .Where(like => like.CommentId == commentId)
                    .ToListAsync();

                var likesResponse = new LikesResponseDTO
                {
                    LikesCount = likesCount,
                    LikedByUsers = likes.Select(like => new LikesByUserDTO
                    {
                        UserId = like.UserId,
                        Username = like.User.Username // Assuming UserModel has a Username property
                    }).ToList()
                };

                return likesResponse;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting likes for post: {ex.Message}");
            }
        }

        public async Task<List<RecentLikesDTO>> GetRecentLikes(int userId)
        {

            var latestPosts = await _context.PostInfo
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.DateCreated)
                .Take(3)
                .Select(p => p.ID)
                .ToListAsync();

            if (!latestPosts.Any())
            {
                return new List<RecentLikesDTO>(); 
            }

            var recentLikes = await _context.LikesInfo
                .Where(l => latestPosts.Contains(l.PostId))
                .OrderByDescending(l => l.LikedAt)
                .Include(l => l.User) 
                .ToListAsync();


            var groupedLikes = recentLikes
                .GroupBy(l => l.PostId)
                .Select(group => new RecentLikesDTO
                {
                    PostId = group.Key,
                    Likes = new LikesResponseDTO
                    {
                        LikesCount = group.Count(),
                        LikedByUsers = group
                            .Select(l => new LikesByUserDTO
                            {
                                UserId = l.UserId,
                                Username = l.User.Username
                            })
                            .ToList()
                    }
                })
                .ToList();

            return groupedLikes;
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

        public async Task<ActionResult<LikesModel>> AddLikeToComment(int commentId, int userId)
        {
            try
            {
                // Check if the user already liked this comment
                var existingLike = await _context.LikesInfo
                    .FirstOrDefaultAsync(like => like.CommentId == commentId && like.UserId == userId);

                if (existingLike != null)
                {
                    return BadRequest("You have already liked this comment.");
                }

                // Create the new like
                var like = new LikesModel
                {
                    CommentId = commentId,
                    UserId = userId,
                    LikedAt = DateTime.UtcNow
                };

                // Add and save the like to the database
                _context.LikesInfo.Add(like);
                await _context.SaveChangesAsync();

                // Fetch the like with the related User entity
                var likedWithUser = await _context.LikesInfo
                    .Include(l => l.User)
                    .FirstOrDefaultAsync(l => l.Id == like.Id);

                return Ok(likedWithUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding like: {ex.Message}");
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
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing like: {ex.Message}");
            }
        }

        public async Task<ActionResult<bool>> RemoveCommentLike(int commentId, int userId)
        {
            try
            {
                var like = await _context.LikesInfo.FirstOrDefaultAsync(like => like.CommentId == commentId && like.UserId == userId);
                if (like == null)
                {
                    throw new Exception("Like not found.");
                }

                _context.LikesInfo.Remove(like);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing like: {ex.Message}");
            }
        }
    }
}