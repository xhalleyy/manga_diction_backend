using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models
{
    public class NotificationModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int? PostId { get; set; } 
        public int? ClubId { get; set; }
        public NotificationType Type { get; set; } 
        public bool IsRead { get; set; } = false;

        public NotificationModel() { }

    }
    public enum NotificationType
    {
        Like,
        Comment,
        ClubInvitation,
        ClubJoinRequest,
        AddFriend
    }
}