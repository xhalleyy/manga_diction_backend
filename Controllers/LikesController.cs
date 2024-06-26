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
    public class LikesController : ControllerBase
    {
        private readonly LikesService _data;

        public LikesController(LikesService data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("GetLikesForPost/{postId}")]
        public async Task<ActionResult<LikesResponseDTO>> GetLikesForPost(int postId)
        {
            return await _data.GetLikesForPost(postId);
        }

        [HttpGet]
        [Route("GetPostRecentLikes/{userId}")]
        public async Task<ActionResult<List<RecentLikesDTO>>> GetPostRecentLikes(int userId)
        {
            return await _data.GetPostRecentLikes(userId);
        }

        [HttpGet]
        [Route("GetCommentRecentLikes/{userId}")]
        public async Task<ActionResult<List<RecentLikesDTO>>> GetCommentRecentLikes(int userId){
            return await _data.GetCommentRecentLikes(userId);
        }

        [HttpGet]
        [Route("GetLikesForComment/{commentId}")]
        public async Task<ActionResult<LikesResponseDTO>> GetLikesForComment(int commentId)
        {
            return await _data.GetLikesForComment(commentId);
        }

        [HttpPost]
        [Route("AddLikeToPost/{postId}/{userId}")]
        public async Task<ActionResult<LikesModel>> AddLikeToPost(int postId, int userId)
        {
            return await _data.AddLikeToPost(postId, userId);
        }

        [HttpPost]
        [Route("AddLikeToComment/{commentId}/{userId}")]
        public async Task<ActionResult<LikesModel>> AddLikeToComment(int commentId, int userId)
        {
            return await _data.AddLikeToComment(commentId, userId);
        }

        [HttpDelete]
        [Route("RemoveLike/{postId}/{userId}")]
        public async Task<ActionResult<bool>> RemoveLike(int postId, int userId)
        {
            return await _data.RemoveLike(postId, userId);
        }

        [HttpDelete]
        [Route("RemoveCommentLike/{commentId}/{userId}")]
        public async Task<ActionResult<bool>> RemoveCommentLike(int commentId, int userId)
        {
            return await _data.RemoveCommentLike(commentId, userId);
        }
    }
}