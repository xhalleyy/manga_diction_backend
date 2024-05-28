using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models.DTO
{
    public class PostWithLikesDTO
    {
        public int ClubId { get; set; }
        public string? ClubName { get; set; }
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int LikeCount { get; set; }
        public UserModel User { get; set; }
    }

    public class PostWithCommentCountDTO
    {
        public int ClubId { get; set; }
        public string? ClubName { get; set; }
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public int CommentCount { get; set; }
        public UserModel User { get; set; }
    }
}