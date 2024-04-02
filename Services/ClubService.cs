using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;

namespace manga_diction_backend.Services
{
    public class ClubService : ControllerBase
    {
        private readonly DataContext _context;

        public ClubService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<ClubModel> GetAllClubs()
        {
            return _context.ClubInfo;
        }


        public IActionResult GetClubsByPrivacy()
        {
            var allItems = GetAllClubs().ToList();
            var filteredItems = allItems.Where(item => item.IsPublic).ToList();

            if (filteredItems == null || filteredItems.Count == 0)
            {
                return NotFound("No public clubs found.");
            }

            return Ok(filteredItems);
        }

        public bool CreateClub(ClubModel newClub)
        {
            _context.Add(newClub);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateClub(ClubModel clubToUpdate)
        {
            _context.Update<ClubModel>(clubToUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool DeleteClub(ClubModel clubToDelete)
        {
            clubToDelete.IsDeleted = true;
            _context.Update<ClubModel>(clubToDelete);
            return _context.SaveChanges() != 0;
        }
    }

}