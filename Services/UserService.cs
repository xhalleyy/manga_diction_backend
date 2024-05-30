using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;
using manga_diction_backend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace manga_diction_backend.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string Username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == Username) != null;
        }

        public bool CreateUser(CreateAccountDTO UserToAdd)
        {
            bool result = false;
            if (!DoesUserExist(UserToAdd.Username))
            {
                UserModel newUser = new UserModel();

                var hashPassword = HashPassword(UserToAdd.Password);
                newUser.ID = UserToAdd.ID;
                newUser.Username = UserToAdd.Username;
                newUser.FirstName = UserToAdd.FirstName;
                newUser.LastName = UserToAdd.LastName;
                newUser.Age = UserToAdd.Age;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;
                _context.Add(newUser);

                result = _context.SaveChanges() != 0;

            }

            return result;
        }

        public PasswordDTO HashPassword(string password)
        {
            PasswordDTO newHashPassword = new PasswordDTO();

            byte[] SaltByte = new byte[64];

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltByte);
            string salt = Convert.ToBase64String(SaltByte);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);
            string hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashPassword.Salt = salt;
            newHashPassword.Hash = hash;

            return newHashPassword;
        }

        public bool VerifyUsersPassword(string? password, string? storedHash, string? storedSalt)
        {

            byte[] SaltBytes = Convert.FromBase64String(storedSalt);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            string newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == storedHash;
        }

        public IActionResult Login(LoginDTO User)
        {
            IActionResult Result = Unauthorized();

            if (DoesUserExist(User.Username))
            {

                UserModel foundUser = GetUserByUsername(User.Username);

                if (VerifyUsersPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(), 
                        expires: DateTime.Now.AddMinutes(30), 
                        signingCredentials: signinCredentials 
                    );

                    // Generate JWT token as a string
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                    // Include user ID in the response
                    var userId = foundUser.ID;

                    Result = Ok(new { Token = tokenString, UserId = userId });
                }
            }

            return Result;
        }

        public UserModel GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public UserModel GetUser(int id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.ID == id);
        }

        public IActionResult GetUsersbyUsername(string username)
        {
            // NULL OR EMPTY: indicates whether the specified string is null or an empty string ("")
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("No Users with that Username.");
            }

            var users = _context.UserInfo
                                // Finding Users that contain the string username; then grabbing their properties and returning it
                                .Where(user => user.Username.Contains(username))
                                .Select(user => new UserModel
                                {
                                    ID = user.ID,
                                    Username = user.Username,
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    // Age = user.Age,
                                    ProfilePic = user.ProfilePic
                                })
                                .ToList();

            return Ok(users);
        }

        // public bool UpdateUser(UserModel userToUpdate){
        //     _context.Update<UserModel>(userToUpdate);
        //     return _context.SaveChanges() != 0;
        // }

        public IActionResult UpdateUser([FromBody] UpdateUserDTO model)
        {
            if (model == null || model.ID == 0)
            {
                return BadRequest("Invalid user update request");
            }

            var user = _context.UserInfo.Find(model.ID);
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (!string.IsNullOrEmpty(model.CurrentPassword) && !string.IsNullOrEmpty(model.NewPassword))
            {
                // Verify the current password
                if (!VerifyUsersPassword(model.CurrentPassword, user.Hash, user.Salt))
                {
                    return Unauthorized("Current password is incorrect");
                }

                // Hash the new password
                var newHashedPassword = HashPassword(model.NewPassword);
                user.Hash = newHashedPassword.Hash;
                user.Salt = newHashedPassword.Salt;
            }

            // Check if the new username already exists
            if (!string.IsNullOrEmpty(model.Username) && model.Username != user.Username)
            {
                var existingUserWithUsername = _context.UserInfo.FirstOrDefault(u => u.Username == model.Username);
                if (existingUserWithUsername != null)
                {
                    return Conflict("Username already exists");
                }

                user.Username = model.Username;
            }

            // Update other user properties
            if (!string.IsNullOrEmpty(model.FirstName)) user.FirstName = model.FirstName;
            if (!string.IsNullOrEmpty(model.LastName)) user.LastName = model.LastName;
            if (model.Age.HasValue) user.Age = model.Age.Value;
            if (!string.IsNullOrEmpty(model.ProfilePic)) user.ProfilePic = model.ProfilePic;

            _context.Update(user);
            bool result = _context.SaveChanges() != 0;

            if (result)
            {
                return Ok("User updated successfully");
            }

            return StatusCode(500, "An error occurred while updating the user");
        }

        // public bool UpdateUsername(int id, string username)
        // {
        //     UserModel foundUser = GetUserById(id);

        //     bool result = false;

        //     if (foundUser != null)
        //     {
        //         foundUser.Username = username;
        //         _context.Update<UserModel>(foundUser);
        //         result = _context.SaveChanges() != 0;
        //     }

        //     return result;
        // }

        public UserModel GetUserById(int id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.ID == id);
        }

        public bool DeleteUser(string userToDelete)
        {
            UserModel foundUser = GetUserByUsername(userToDelete);
            bool result = false;

            if (foundUser != null)
            {
                _context.Remove<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }

            return result;
        }
    }
}