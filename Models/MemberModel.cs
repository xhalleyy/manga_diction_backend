using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClubId { get; set; }
        
        public MemberModel(){}
    }
}