using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public int Age { get; set; }
        public string? ProfilePic { get; set; }
        // To not display Salt and Hash when I retrieve the likes
        [JsonIgnore]
        public string? Salt { get; set; }
        [JsonIgnore]
        public string? Hash { get; set; }
        public UserModel()
        {

        }
    }
}