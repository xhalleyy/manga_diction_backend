using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace manga_diction_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _data;

        public CommentController (CommentService data){
            _data = data;
        }

        // Get Replies from Post
        [HttpGet]
        [Route("GetPostReplies/{postId}")]
        public async Task<IActionResult> GetPostReplies(int postId){
            return await _data.GetPostReplies(postId);
        }

        // Get Replies from Comments
        [HttpGet]
        [Route("GetRepliesFromComment/{commentId}")]
        public async Task<IActionResult> GetRepliesFromComment(int commentId){
            return await _data.GetRepliesFromComment(commentId);
        }

        // Add Reply To Post
        [HttpPost]
        [Route("AddCommentForPost/{postId}/{userId}")]
        public async Task<IActionResult> AddCommentForPost(int postId, [FromBody] string reply, int userId){
            return await _data.AddCommentForPost(postId, reply, userId);
        }

        // Add Reply To Comment]
        [HttpPost]
        [Route("AddReplyForComment/{commentId}/{userId}")]
        public async Task<IActionResult> AddReplyForComment(int commentId, int userId, [FromBody] string reply){
            return await _data.AddReplyForComment(commentId, userId, reply);
        }

        // Updating Top Level Reply
        [HttpPut]
        [Route("UpdateReplyFromPost/{commentId}")]
        public async Task<IActionResult> UpdateReplyFromPost(int commentId, [FromBody] string reply){
            return await _data.UpdateReplyFromPost(commentId, reply);
        }

        // Updating Replies From Comment
        // [HttpPut]
        // [Route("UpdateReplyFromComment/{replyId}")]
        // public async Task<IActionResult> UpdateReplyFromComment(int replyId, [FromBody] string reply){
        //     return await _data.UpdateReplyFromComment(replyId, reply);
        // }

        [HttpDelete]
        [Route("DeleteComment/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId){
            return await _data.DeleteComment(commentId);
        }
        
    }
}