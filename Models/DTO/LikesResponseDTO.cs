using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manga_diction_backend.Models.DTO
{
    public class LikesResponseDTO
    {
        public int LikesCount { get; set; }
        public List<LikesByUserDTO> LikedByUsers { get; set; }
    }
}