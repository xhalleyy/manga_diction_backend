using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models.DTO
{
    public class UpdateUserDTO
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? ProfilePic { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}