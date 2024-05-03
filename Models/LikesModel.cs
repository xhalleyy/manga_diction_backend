using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models
{
    public class LikesModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime LikedAt { get; set; }

        // Navigation property for the User
        public UserModel User { get; set; }
        public LikesModel()
        {

        }
    }

}