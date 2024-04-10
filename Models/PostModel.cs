using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models
{
    public class PostModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int ClubId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Likes { get; set; }
        public string? DateCreated { get; set; }
        public string? DateUpdated { get; set; }
        public bool IsDeleted { get; set; } = false;

        // public ClubModel? Club { get; set; } // Navigation property to ClubModel
        
        public PostModel(){}
    }
}