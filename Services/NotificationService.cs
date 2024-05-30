using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;
using manga_diction_backend.Services.Context;

namespace manga_diction_backend.Services
{
    public class NotificationService
    {
        private readonly DataContext _context;
        public NotificationService(DataContext context)
        {
            _context = context;
        }

        public List<NotificationDTO> GetNotificationByUserId(int userId)
        {
            List<PostModel> allUserPosts = _context.PostInfo.Where(post => post.UserId == userId && post.IsDeleted == false).ToList();

            List<int> allUserPostIds = allUserPosts.Select(post => post.ID).ToList();


            List<CommentModel> allUsersComments = _context.CommentInfo.Where(comment => comment.UserId == userId).ToList();
            List<int> allUserCommentsIds = allUsersComments.Select(c => c.ID).ToList();
            // get the most recent replies to both

            List<CommentModel> repliesFromOthers = _context.CommentInfo
           .Where(comment =>
           (comment.PostId.HasValue && allUserPostIds.Contains(comment.PostId.Value) && comment.UserId != userId) || // Replies to user's posts
           (comment.ParentCommentId.HasValue && allUserCommentsIds.Contains(comment.ParentCommentId.Value)) // Replies to user's comments
            ).OrderByDescending(comment => comment.PostedAt).Take(3).ToList();


            List<NotificationDTO> result = new List<NotificationDTO>();

            foreach (CommentModel reply in repliesFromOthers)
            {
                UserModel userInfo = _context.UserInfo.SingleOrDefault(user => user.ID == reply.UserId);
                string originalPost = "";
                if (reply.PostId.HasValue)
                {
                    originalPost = allUserPosts.SingleOrDefault(post => post.ID == reply.PostId).Title;
                }
                else
                {
                    originalPost = allUsersComments.SingleOrDefault(comment => comment.ID == reply.ParentCommentId).Reply;
                }
                NotificationDTO info = new NotificationDTO
                {
                    Username = userInfo?.Username,
                    ProfilePic = userInfo?.ProfilePic,
                    FromPost = reply.PostId.HasValue,
                    detail = originalPost
                };

                result.Add(info);

            }

            return result;
        }
    }
}