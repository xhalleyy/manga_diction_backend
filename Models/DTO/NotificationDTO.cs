using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models.DTO
{
    public class NotificationDTO
    {
        public string Username { get; set; }
        public string ProfilePic { get; set; }
        public bool FromPost { get; set; }
        public string detail {get; set; }
    }
}