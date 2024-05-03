using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;

namespace manga_diction_backend.Services
{
    public class PostService : ControllerBase
    {
        private readonly DataContext _context;

        public PostService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<PostModel> GetAllPostsInClub(int clubId)
        {
            return _context.PostInfo.Where(post => post.ClubId == clubId && !post.IsDeleted).ToList();
        }

        public PostModel GetPostById(int id)
        {
            return _context.PostInfo.SingleOrDefault(post => post.ID == id);
        }

        public IEnumerable<PostModel> GetPostsByCategory(int clubId, string category)
        {
            var allItems = GetAllPostsInClub(clubId).ToList();
            return allItems.Where(post => post.Category == category);
        }

        public List<PostModel> GetPostsByTags(int clubId, string tag)
        {
            // converts to lowercase and trim spaces
            tag = tag.ToLower().Trim();

            var allItems = GetAllPostsInClub(clubId).ToList();
            var filteredItems = allItems.Where(post => post.Tags != null && post.Tags
                // Then splits tags by commas and remove spaces
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                // Convert each tag to lowercase and trim spaces
                .Select(t => t.ToLower().Trim())
                .Contains(tag))
                .ToList();

            return filteredItems;
        }

        public List<PostModel> GetPostsByRecentlyUpdated(int clubId)
        {
            var allItems = GetAllPostsInClub(clubId).ToList();
            return allItems.OrderByDescending(post => post.DateUpdated).ToList();
        }

        public List<PostModel> GetPostsByLeastRecentUpdates(int clubId)
        {
            var allItems = GetAllPostsInClub(clubId).ToList();
            return allItems.OrderBy(post => post.DateUpdated).ToList();
        }

        public List<PostModel> GetRecentlyCreatedPosts(int clubId)
        {
            var allItems = GetAllPostsInClub(clubId).ToList();
            return allItems.OrderByDescending(post => post.DateCreated).ToList();
        }

        public List<PostModel> GetOldestCreatedPosts(int clubId)
        {
            var allItems = GetAllPostsInClub(clubId).ToList();
            return allItems.OrderBy(post => post.DateCreated).ToList();
        }

        // Create New Post 
        public bool CreateNewPostInClub(int clubId, PostModel newPost)
        {
            // Ensure the club exists (Might want to add error handling if club doesn't exist)
            var club = _context.ClubInfo.FirstOrDefault(c => c.ID == clubId);
            if (club == null)
            {
                // Club not found
                return false;
            }

            newPost.ClubId = clubId;
            DateTime currentUtcTime = DateTime.UtcNow;
            string formattedTime = currentUtcTime.ToString("yyyy-MM-dd HH:mm:ss");
            newPost.DateCreated = formattedTime; 

            // Format tags
            if (!string.IsNullOrEmpty(newPost.Tags))
            {
                var tagsArray = newPost.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(tag => tag.Trim().ToLower()) // Trim spaces and convert to lowercase
                    .Distinct() // Remove duplicates
                    .ToArray();

                newPost.Tags = string.Join(",", tagsArray); // Join tags back into a string
            }

            _context.PostInfo.Add(newPost);
            return _context.SaveChanges() != 0;
        }

        public bool UpdatePost(PostModel postToUpdate)
        {
            _context.Update<PostModel>(postToUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool DeletePost(PostModel postToDelete)
        {
            postToDelete.IsDeleted = true;
            _context.Update<PostModel>(postToDelete);
            return _context.SaveChanges() != 0;
        }
    }
}