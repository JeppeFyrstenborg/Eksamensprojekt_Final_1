using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public class Security
    {

        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IUserRepository _userRepository;

        public Security() { }

        public Security(IUserAuthRepository userAuthRepository, IUserRepository userRepository)
        {
            _userAuthRepository = userAuthRepository;
            _userRepository = userRepository;
        }


        public Tuple<string, string> GetHashedPasswordAndSaltFrom(string password)
        {
            // Generate a random salt value
            byte[] salt = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Concatenate the password and salt
            string passwordWithSalt = String.Concat("123456", Convert.ToBase64String(salt));

            // Compute the hash of the password + salt
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));

            // Convert the hash and salt to strings for storage
            string hashString = Convert.ToBase64String(hash);
            string saltString = Convert.ToBase64String(salt);

            return Tuple.Create(hashString, saltString);
        }

        public bool VerifyPassword(SecureString password, string userEmail)
        {
            int userId = _userRepository.GetUserIdFromEmail(userEmail);

            string storedHashedPassword, storedSalt;

            storedHashedPassword = _userAuthRepository.GetHashedPasswordFromUserId(userId);
            storedSalt = _userAuthRepository.GetSaltFromUserId(userId);

            // Decode the stored salt from base64
            byte[] salt = Convert.FromBase64String(storedSalt);

            // Convert the secure string to a regular string
            string passwordString = new NetworkCredential("", password).Password;

            // Concatenate the password and salt
            string passwordWithSalt = String.Concat(passwordString, Convert.ToBase64String(salt));

            // Compute the hash of the password + salt
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));

            // Convert the hash to a string for comparison with the stored hashed password
            string hashString = Convert.ToBase64String(hash);

            // Compare the computed hash with the stored hashed password
            return hashString == storedHashedPassword;
        }
    }
}
