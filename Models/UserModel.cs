using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;

namespace manga_diction_backend.Models
{
    public class UserModel
    {

        public int ID { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        // public List<FriendModel>? FriendList { get; set; }
        // public List<FavoritedModel>? FavoritedMangas { get; set; }
        // public List<ClubModel>? Clubs { get; set; }

        public UserModel()
        {

        }
    }
}