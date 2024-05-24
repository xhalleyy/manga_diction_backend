using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace manga_diction_backend.Services
{
    public class MemberService : ControllerBase
    {
        private readonly DataContext _context;
        public MemberService(DataContext context)
        {
            _context = context;
        }

        // GET CLUBS BY USER ID; BASED ON ACCEPTED STATUS
        public IActionResult GetUserClubs(int userId)
        {
            var clubIds = _context.MemberInfo
                .Where(uc => uc.UserId == userId && uc.Status == MemberStatus.Accepted)
                .Select(uc => uc.ClubId)
                .ToList();

            if (clubIds.Count > 0)
            {
                return Ok(clubIds);
            }
            else
            {
                // Return an empty array to indicate no club IDs found
                return Ok(new int[0]);
            }
        }
        // // GET PENDING REQUEST BY CLUB ID
        public List<ClubMembers> GETPENDINGREQUESTFORCLUB(int userId)
        {
            List<ClubMembers> ClubMembers = new List<ClubMembers>();

            var clubs = _context.ClubInfo
                .Where(club => club.LeaderId == userId && club.IsPublic == false && club.IsDeleted == false)
                .Select(club => new { ClubName = club.ClubName, ClubId = club.ID })
                .ToList();

            foreach (var club in clubs)
            {
                List<MemberModel> pendingMembers = _context.MemberInfo
                    .Where(member => member.ClubId == club.ClubId && member.Status == MemberStatus.Pending)
                    .ToList();

                List<MembersIdAndName> allPendingMembers = new List<MembersIdAndName>();
                foreach (var member in pendingMembers)
                {
                    UserModel userInfo = _context.UserInfo.SingleOrDefault(user => user.ID == member.UserId);
                    if (userInfo != null)
                    {
                        allPendingMembers.Add(new MembersIdAndName
                        {
                            Id = member.Id, // Use the MemberInfo Id instead of UserInfo ID
                            memberId = userInfo.ID,
                            name = userInfo.Username,
                            profilepic = userInfo.ProfilePic
                        });
                    }
                }

                ClubMembers.Add(new ClubMembers
                {
                    ClubName = club.ClubName,
                    ClubId = club.ClubId,
                    Members = allPendingMembers
                });
            }

            return ClubMembers;
        }

        // GET INVITED REQUESTS BY USER ID


        // GET CLUB MEMBERS BY CLUB ID; BASED ON ACCEPTED STATUS
        public IActionResult GetClubMembers(int clubId)
        {
            var memberIds = _context.MemberInfo
                .Where(club => club.ClubId == clubId && club.Status == MemberStatus.Accepted)
                .Select(clubM => clubM.UserId)
                .ToList();

            if (memberIds.Count > 0)
            {
                return Ok(memberIds);
            }
            else
            {
                // Return an empty array to indicate no club IDs found
                return Ok(new int[0]);
            }
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

                if (existingClub != null)
                {
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

        public async Task<IActionResult> AddMemberToClub(int userId, int clubId, bool isLeader)
        {
            try
            {
                var existingUser = await _context.MemberInfo.FirstOrDefaultAsync(club => club.UserId == userId && club.ClubId == clubId);

                if (existingUser != null)
                {
                    return Conflict("User already joined this club");
                }

                var club = await _context.ClubInfo.FindAsync(clubId);

                if (club == null)
                {
                    return NotFound("Club not found");
                }

                var userClub = new MemberModel
                {
                    UserId = userId,
                    ClubId = clubId,
                    Status = club.IsPublic ? MemberStatus.Accepted : (!club.IsPublic && isLeader ? MemberStatus.Accepted : MemberStatus.Pending)
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

        public async Task<IActionResult> UpdatePendingStatus(int id, [FromBody] string newStatus)
        {
            try
            {
                var existingMember = await _context.MemberInfo.FirstOrDefaultAsync(m => m.Id == id);

                if (existingMember == null)
                {
                    return NotFound("Member not found");
                }

                if (string.IsNullOrWhiteSpace(newStatus))
                {
                    return BadRequest("New status is required.");
                }

                string statusLowerCase = newStatus.ToLower();
                if (statusLowerCase == "accept")
                {
                    existingMember.Status = MemberStatus.Accepted;
                    await _context.SaveChangesAsync();
                    return Ok("User successfully joined!");
                }
                else if (statusLowerCase == "deny")
                {
                    existingMember.Status = MemberStatus.Denied;
                    await _context.SaveChangesAsync();
                    return Ok("User denied from Club!");
                }
                else
                {
                    return BadRequest("Invalid action specified. Please specify 'accept' or 'deny'.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating member status: {ex.Message}");
            }
        }


        // This function removes a specific user from a specific club 
        public async Task<IActionResult> RemoveMemberFromClub(int userId, int clubId)
        {
            try
            {
                var userClub = await _context.MemberInfo.FirstOrDefaultAsync(club => club.UserId == userId && club.ClubId == clubId);

                if (userClub == null)
                {
                    return NotFound("User is not a member of the club.");
                }

                if (userClub.Status != MemberStatus.Accepted)
                {
                    return BadRequest("Only accepted members can be removed from the club.");
                }

                _context.MemberInfo.Remove(userClub);
                await _context.SaveChangesAsync();

                return Ok("User removed from club successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error removing member from club: {ex.Message}");
            }
        }

    }
}