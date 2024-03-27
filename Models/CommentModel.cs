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
        public int Likes { get; set; }
        // public List<CommentModel>? Comments { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public CommentModel(){}
    }
}