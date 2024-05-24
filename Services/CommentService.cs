using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace manga_diction_backend.Services
{
    public class CommentService : ControllerBase
    {
        private readonly DataContext _context;

        public CommentService(DataContext context)
        {
            _context = context;
        }

        // GET COMMENT BY ID
        public IActionResult GetCommentById(int id)
        {
            try
            {
                var comment = _context.CommentInfo.FirstOrDefault(c => c.ID == id);
                if (comment == null)
                {
                    return Ok("User doesn't have any like notifications");
                }

                return Ok(comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<ActionResult<List<UserCommentDTO>>> GetUserComments(int userId)
        {
            var userComments = await _context.CommentInfo
                .Where(c => c.UserId == userId)
                .Include(c => c.User)
                .Select(c => new UserCommentDTO
                {
                    UserId = c.User.ID,
                    Username = c.User.Username,
                    Comments = new List<CommentDTO>
                    {
                new CommentDTO
                {
                    CommentId = c.ID,
                    Reply = c.Reply,
                    PostedAt = c.PostedAt
                }
                    }
                })
                .ToListAsync();

            return userComments;
        }

        // Get Replies from Posts
        public async Task<IActionResult> GetPostReplies(int postId)
        {
            try
            {
                // I only want the comments from the top level (posts)
                var comments = await _context.CommentInfo.Where(comment => comment.PostId == postId && comment.ParentCommentId == null)
                .Include(comment => comment.User) // includes user's info for each comment
                .ToListAsync();

                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching comments for post: {ex.Message}");
            }
        }

        // Get Replies from Comments
        public async Task<IActionResult> GetRepliesFromComment(int commentId)
        {
            try
            {
                var replies = await _context.CommentInfo.Where(reply => reply.ParentCommentId == commentId)
                .Include(reply => reply.User)
                .ToListAsync();

                return Ok(replies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching replies for comments: {ex.Message}");
            }
        }

        // Add Comment to Post
        // From Body: reply is included in the JSON body and will be bound by to string reply; expects that the reply data to be a string 
        public async Task<IActionResult> AddCommentForPost(int postId, [FromBody] string reply, int userId)
        {
            try
            {
                var post = await _context.PostInfo.FirstOrDefaultAsync(post => post.ID == postId);

                if (post == null)
                {
                    return NotFound("Post not found");
                }

                // creating a new instance of the model
                var comment = new CommentModel
                {
                    UserId = userId,
                    Reply = reply,
                    PostedAt = DateTime.UtcNow,
                    PostId = postId
                };

                _context.CommentInfo.Add(comment);
                await _context.SaveChangesAsync();

                return Ok("Comment added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding comment for post: {ex.Message}");
            }
        }

        // Add Reply To comment:
        public async Task<IActionResult> AddReplyForComment(int commentId, int userId, [FromBody] string reply)
        {
            try
            {
                var topComment = await _context.CommentInfo.FirstOrDefaultAsync(comment => comment.ID == commentId);

                if (topComment == null)
                {
                    return NotFound("Parent Comment not found");
                }

                var childComment = new CommentModel
                {
                    UserId = userId,
                    Reply = reply,
                    PostedAt = DateTime.UtcNow,
                    ParentCommentId = commentId
                };

                _context.CommentInfo.Add(childComment);
                await _context.SaveChangesAsync();

                return Ok("Reply added successfully.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding reply for comment: {ex.Message}");
            }
        }

        // Updating the reply of top-level comment
        public async Task<IActionResult> UpdateReplyFromPost(int commentId, [FromBody] string reply)
        {
            try
            {
                var replyToUpdate = await _context.CommentInfo.FirstOrDefaultAsync(c => c.ID == commentId);

                if (replyToUpdate == null)
                {
                    return NotFound("Reply not found.");
                }

                replyToUpdate.Reply = reply; // Update the reply content with the provided string

                _context.CommentInfo.Update(replyToUpdate);
                await _context.SaveChangesAsync();

                return Ok("Reply updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating reply: {ex.Message}");
            }
        }

        public async Task<IActionResult> DeleteComment(int commentId)
        {
            try
            {
                var comment = await _context.CommentInfo.FirstOrDefaultAsync(c => c.ID == commentId);

                if (comment == null)
                {
                    return NotFound("Comment not found.");
                }

                _context.CommentInfo.Remove(comment);
                await _context.SaveChangesAsync();

                return Ok("Comment deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting comment: {ex.Message}");
            }
        }
    }
}