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
        public async Task<IActionResult> AddClubToUser(int userId, int clubId)
        {
            try
            {
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

        public async Task<IActionResult> RemoveMemberFromClub(int userId, int clubId){
            try 
            {
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

        public async Task<IActionResult> RemoveClubFromUser(int userId, int clubId){
            try
            {
                var userClubs = await _context.MemberInfo.Where(club => club.UserId == userId && club.ClubId == clubId).ToListAsync();

                if (userClubs == null || !userClubs.Any())
                {
                    return NotFound("User is not associated with the club.");
                }

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