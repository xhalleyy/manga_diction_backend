using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// DTO doesn't need a constructor because our model handles that
namespace manga_diction_backend.Models.DTO
{
    public class CreateAccountDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }
}