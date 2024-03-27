using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models
{
    public class FriendModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public FriendModel(){}
    }
}