using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace manga_diction_backend.Services
{
    public class FriendService : ControllerBase
    {
        private readonly DataContext _context;
        public FriendService(DataContext context)
        {
            _context = context;
        }

        // Adds Friend And is Now Pending 
        public IActionResult AddFriend(int userId, int friendId)
        {
            // Check if the user has already sent a request to add this friend
            var existingRequest = _context.FriendInfo.FirstOrDefault(f =>
                f.UserId == userId && f.FriendId == friendId && f.Status == RequestStatus.Pending);

            if (existingRequest != null)
            {
                // Return a message indicating that the request already exists
                return Conflict("Friend request already exists.");
            }

            var newFriends = new FriendModel
            {
                UserId = userId,
                FriendId = friendId,
                Status = RequestStatus.Pending
            };
            // newFriends.Status = RequestStatus.Pending;
            _context.Add(newFriends);
            _context.SaveChanges();

            return Ok("You successfully requested to add!");
        }

        // Get Pending Requests 
        public IActionResult GetPendingFriends(int userId)
        {
            var pendingRequests = _context.FriendInfo
                .Where(friend => friend.FriendId == userId && friend.Status == RequestStatus.Pending)
                .ToList();

            return Ok(pendingRequests);
        }

        // Update Friend Requests to Deny or Accept
        public IActionResult HandleFriendRequest(int id, [FromBody] string action)
        {
            var friend = _context.FriendInfo.FirstOrDefault(request => request.ID == id && request.Status == RequestStatus.Pending);

            if (friend != null)
            {
                if (action.ToLower() == "accept")
                {
                    friend.Status = RequestStatus.Accepted;
                    _context.SaveChanges();
                    return Ok("Friend request accepted successfully!");
                }
                else if (action.ToLower() == "deny")
                {
                    // Remove association if request is denied
                    _context.FriendInfo.Remove(friend);
                    _context.SaveChanges();
                    return Ok("Friend request denied and association removed successfully!");
                }
                else
                {
                    return BadRequest("Invalid action specified. Please specify 'accept' or 'deny'.");
                }
            }
            else
            {
                return NotFound("Friend request not found or already accepted/denied.");
            }
        }


        public IActionResult GetAcceptedFriends(int userId)
        {
            var acceptedFriends = _context.FriendInfo
                .Where(f => (f.UserId == userId || f.FriendId == userId) && f.Status == RequestStatus.Accepted)
                .ToList();

            // Want to return the list of user Models of the Accepted Friends, so creating a new instance of userModel.
            List<UserModel> acceptedFriendsWithUserModel = new List<UserModel>();

            // for each person on the friends list
            foreach (var friend in acceptedFriends)
            {
                // grabbing friend's id by ternary
                int friendUserId = friend.UserId == userId ? friend.FriendId : friend.UserId;
                // grab the first element/ object of the user model with the friend's id
                var friendUser = _context.UserInfo.FirstOrDefault(u => u.ID == friendUserId);

                if (friendUser != null)
                {
                    acceptedFriendsWithUserModel.Add(friendUser);
                }
            }

            return Ok(acceptedFriendsWithUserModel);
        }

        public IActionResult DeleteFriend(int userId, int friendId)
        {
            try
            {
                var friendRelationship = _context.FriendInfo.FirstOrDefault(f =>
                    (f.UserId == userId && f.FriendId == friendId) ||
                    (f.UserId == friendId && f.FriendId == userId));

                if (friendRelationship != null)
                {
                    _context.FriendInfo.Remove(friendRelationship);
                    _context.SaveChanges();
                    return Ok("Friend relationship deleted successfully.");
                }
                else
                {
                    return NotFound("Friend relationship not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}