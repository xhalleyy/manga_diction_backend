using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models
{
    public enum MemberStatus {
        Pending,
        Accepted,
        Denied,
        Default
    }
    public class MemberModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClubId { get; set; }
        public MemberStatus Status { get; set; }
        public MemberModel(){}
    }
}