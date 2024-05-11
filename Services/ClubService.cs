using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<ClubModel>> GetClubsByLeaderAsync(int leaderId)
        {
            return await _context.ClubInfo
                .Where(c => c.LeaderId == leaderId)
                .ToListAsync();
        }
        
        public IEnumerable<ClubModel> GetAllPublicClubs(bool recent = true)
        {
            var allItems = GetAllClubs().ToList();
            var filteredItems = allItems.Where(item => item.IsPublic).ToList();

            // return filteredItems;

            if (recent)
            {
                return filteredItems.OrderByDescending(item => item.DateCreated);
            }
            else
            {
                return filteredItems.OrderBy(item => item.DateCreated);
            }

        }

        public IEnumerable<ClubModel> GetRecentPublicClubs()
        {
            var allItems = GetAllPublicClubs().ToList();
            return allItems.OrderByDescending(item => item.DateCreated);
        }

        public IEnumerable<ClubModel> GetOldestPublicClubs()
        {
            var allItems = GetAllPublicClubs().ToList();
            return allItems.OrderBy(item => item.DateCreated);
        }

        public ClubModel GetClubById(int id)
        {
            return _context.ClubInfo.SingleOrDefault(club => club.ID == id);
        }

        public List<ClubModel> GetClubsByName(string clubName)
        {
            var allItems = GetAllClubs().ToList();
            var filteredItems = allItems.Where(club => club.ClubName.Contains(clubName)).ToList();

            return filteredItems;
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