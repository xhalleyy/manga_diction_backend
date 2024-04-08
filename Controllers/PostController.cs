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
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _data;

        public PostController(PostService data){
            _data = data;
        }

        // Get Posts by Clubs
        [HttpGet]
        [Route("GetAllPostsInClub/{clubId}")]
        public IEnumerable<PostModel>GetAllPostsInClub(int clubId){
            return _data.GetAllPostsInClub(clubId);
        }

        // Get Posts by Category
        [HttpGet]
        [Route("GetPostsByCategory/{clubId}/{category}")]
        public IEnumerable<PostModel> GetPostsByCategory(int clubId, string category){
            return _data.GetPostsByCategory(clubId, category);
        }

        // Create Post
        [HttpPost]
        [Route("CreateNewPostInClub/{clubId}")]
        public bool CreateNewPostInClub(int clubId, PostModel newPost){
            
            return _data.CreateNewPostInClub(clubId, newPost);
        }

        // Update Post
        [HttpPut]
        [Route("UpdatePost")]
        public bool UpdatePost(PostModel postToUpdate){
            return _data.UpdatePost(postToUpdate);
        }

        // Delete Post
        [HttpDelete]
        [Route("DeletePost")]
        public bool DeletePost(PostModel postToDelete){
            return _data.DeletePost(postToDelete);
        }
        

    }
}