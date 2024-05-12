using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;

namespace manga_diction_backend.Models
{
    // enum type is a value type which the associated values of enum members are of type int; starting with zero and increases by one
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