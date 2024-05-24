using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models.DTO
{
    public class ClubMemberCountDTO
    {
        public int ClubId { get; set; }
        public string? ClubName { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsMature { get; set; }
        public bool IsPublic { get; set; }
        public int MemberCount { get; set; }
    }
}