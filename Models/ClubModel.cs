using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models.DTO;

namespace manga_diction_backend.Models
{
    public class ClubModel
    {
        public int ID { get; set; }
        public int? LeaderId { get; set; }
        public string? ClubName { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        // separated by commas in endpoint
        // public List<MemberModel>? Members { get; set; }
        public bool IsDeleted { get; set; }
        // public List<PostModel>? Posts { get; set; }
        
        public ClubModel(){}
    }
}