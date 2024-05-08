using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace manga_diction_backend.Services
{
    public class MemberService : ControllerBase
    {
        private readonly DataContext _context;
        public MemberService(DataContext context)
        {
            _context = context;
        }

        // GET CLUBS BY USER ID
        public IActionResult GetUserClubs(int userId)
        {
            var clubIds = _context.MemberInfo
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.ClubId)
                .ToList();

            return Ok(clubIds);
        }

        // GET MEMBERS BY CLUB ID
        public IActionResult GetClubMembers(int clubId)
        {
            var memberIds = _context.MemberInfo
                .Where(club => club.ClubId == clubId)
                .Select(clubM => clubM.UserId)
                .ToList();

            return Ok(memberIds);
        }

        // ADD CLUB TO USER 
        // input/output operations (i.e. reading/writing data to a database, executing queries, retrieving records, updating database tables)
        // async because this function interacts with a database and is making changes; allow the calling thread to be released while waiting for the operation to complete
        public async Task<IActionResult> AddClubToUser(int userId, int clubId)
        {
            try
            {
                // first or default returns first element, but allows other operations to continue while the database query is being processed. 
                var existingClub = await _context.MemberInfo.FirstOrDefaultAsync(club => club.UserId == userId && club.ClubId == clubId);

                if(existingClub != null){
                    return Conflict("User already joined this club");
                }

                var userClub = new MemberModel
                {
                    UserId = userId,
                    ClubId = clubId
                };

                _context.MemberInfo.Add(userClub);
                await _context.SaveChangesAsync();

                return Ok("User successfully joined the club!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding club: {ex.Message}"); ;
            }
        }

        public async Task<IActionResult> AddMemberToClub(int userId, int clubId)
        {
            try
            {
                var existingUser = await _context.MemberInfo.FirstOrDefaultAsync(club => club.UserId == userId && club.ClubId == clubId);

                if(existingUser != null){
                    return Conflict("User already joined this club");
                }

                var userClub = new MemberModel
                {
                    UserId = userId,
                    ClubId = clubId
                };

                _context.MemberInfo.Add(userClub);
                await _context.SaveChangesAsync();

                return Ok("User successfully joined the club!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding member: {ex.Message}");
            }
        }

        // This function removes a specific user from a specific club 
        public async Task<IActionResult> RemoveMemberFromClub(int userId, int clubId){
            try 
            {
                // uses first or default async to find the first match of user id and club id in the table
                var userClub = await _context.MemberInfo.FirstOrDefaultAsync(club => club.UserId == userId && club.ClubId == clubId);

                if(userClub == null)
                {
                    return NotFound("User is not a member of the club.");
                }

                _context.MemberInfo.Remove(userClub);
                 await _context.SaveChangesAsync();

                return Ok("User removed from club successfully.");
            } catch (Exception ex)
            {
                return StatusCode(500, $"Error removing member from club: {ex.Message}");
            }
        }

        // This function remove the club with a specific user.
        public async Task<IActionResult> RemoveClubFromUser(int userId, int clubId){
            try
            {
                // Uses Where instead to fetch ALL matching records in the MemberInfo table; just in case there are somehow instances of duplicates
                var userClubs = await _context.MemberInfo.Where(club => club.UserId == userId && club.ClubId == clubId).ToListAsync();

                // if any clubs are found, it removes all of them with remove range
                if (userClubs == null || !userClubs.Any())
                {
                    return NotFound("User is not associated with the club.");
                }

                // RemoveRange is used to remove a range of entities from a db. 
                 _context.MemberInfo.RemoveRange(userClubs);
                await _context.SaveChangesAsync();

                return Ok("Club removed from user successfully.");
            }catch (Exception ex)
            {
                return StatusCode(500, $"Error removing club from user: {ex.Message}");
            }
        }
    }
}