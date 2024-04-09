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

        // Get Posts by Category
        [HttpGet]
        [Route("GetPostsByTags/{clubId}/{tag}")]
        public List<PostModel> GetPostsByTags(int clubId, string tag){
            return _data.GetPostsByTags(clubId, tag);
        }

        // Get Posts By Updated Dates
        [HttpGet]
        [Route("GetPostsByRecentlyUpdated/{clubId}")]
        public List<PostModel> GetPostsByRecentlyUpdated(int clubId){
            return _data.GetPostsByRecentlyUpdated(clubId);
        }

        [HttpGet]
        [Route("GetPostsByLeastRecentUpdates/{clubId}")]
        public List<PostModel> GetPostsByLeastRecentUpdates(int clubId){
            return _data.GetPostsByLeastRecentUpdates(clubId);
        }

        // Get Posts by Created Dates
        [HttpGet]
        [Route("GetRecentlyCreatedPosts/{clubId}")]
        public List<PostModel> GetRecentlyCreatedPosts(int clubId){
            return _data.GetRecentlyCreatedPosts(clubId);
        }

        [HttpGet]
        [Route("GetOldestCreatedPosts/{clubId}")]
        public List<PostModel> GetOldestCreatedPosts(int clubId){
            return _data.GetOldestCreatedPosts(clubId);
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