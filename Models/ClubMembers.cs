using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models.DTO;

namespace manga_diction_backend.Models
{
    public class ClubMembers
    {
     public string ClubName { get; set; }
     public int ClubId { get; set;}
     public List<MembersIdAndName> Members { get; set; }
    }

    public class MembersIdAndName 
    {
        public int memberId { get; set; }
        public string name { get; set; }
        public string? profilepic { get; set;}
    }
}