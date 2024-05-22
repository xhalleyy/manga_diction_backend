using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models.DTO
{
    public class RecentLikesDTO
    {
        public int PostId { get; set; }
        public int? CommentId { get; set; }
        public int UserId { get; set; }
        public LikesResponseDTO Likes { get; set; }

    }
}