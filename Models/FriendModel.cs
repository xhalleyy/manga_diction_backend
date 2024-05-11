using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;

namespace manga_diction_backend.Models
{
    public enum RequestStatus {
        Pending,
        Accepted,
        Denied
    }
    public class FriendModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public RequestStatus Status { get; set; }

        public FriendModel(){}
    }
}