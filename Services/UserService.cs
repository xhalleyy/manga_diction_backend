using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using manga_diction_backend.Models;
using manga_diction_backend.Models.DTO;
using manga_diction_backend.Services.Context;

namespace manga_diction_backend.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string Username){
            return _context.UserInfo.SingleOrDefault(user => user.Username == Username) != null;
        }

        public bool CreateUser(CreateAccountDTO UserToAdd)
        {
            bool result = false;
            if(!DoesUserExist(UserToAdd.Username)){
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

        public PasswordDTO HashPassword(string password){
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

        public bool VerifyUsersPassword(string? password, string? storedHash, string? storedSalt){

            byte[] SaltBytes = Convert.FromBase64String(storedSalt);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            string newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == storedHash;
        }
    }
}