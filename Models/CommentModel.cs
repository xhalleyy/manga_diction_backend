using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string? Reply { get; set; }
        // public int Likes { get; set; }
        public DateTime PostedAt { get; set; }
        public int? PostId { get; set; }
        public int? ParentCommentId { get; set; } // Parent comment ID for nested comments
        public UserModel User { get; set; }

        public CommentModel() { }
    }

}