using DAL.Repositories;
using DTO.Models;
using Eksamensprojekt_Final_1_Web_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net;

namespace Eksamensprojekt_Final_1_Web_App.Controllers
{
    public class UserController : Controller
    {
        IUserRepository UserRepository = new UserRepository();
        IUserAuthRepository UserAuthRepository = new UserAuthRepository();

        [HttpGet]

        public ActionResult GetUsers()
        {
            List<User> users = UserRepository.GetAllUsers();

            return View("Users", users);
        }

        [HttpGet]
        public ActionResult GetUser(int? id)
        {
            if (id == null)
            {
                ViewBag.Title = "Opret ny Bruger";
                return View("User", null);
            }
            else
            {
                UserViewModel userViewModel = new UserViewModel()
                {
                    UserAuth = UserAuthRepository.GetUserAuthFromUserId((int)id)
                };
                ViewBag.Title = "Rediger Bruger";
                return View("User", userViewModel);
            }
        }

        [HttpPost]
        public ActionResult CreateUser(UserViewModel userViewModel)
        {
            Tuple<string, string> passwordAndSalt = this.GetHashedPasswordAndSaltFrom(userViewModel.Password);

            int createdUserId = UserRepository.CreateNewUser(userViewModel.UserAuth.User.Username,
                userViewModel.UserAuth.User.Email, userViewModel.UserAuth.User.Birthday);

            UserAuthRepository.CreateNewUserAuthForUserId(createdUserId, passwordAndSalt.Item1,
                passwordAndSalt.Item2);

            return RedirectToAction("GetUsers");
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel userViewModel)
        {
            UserRepository.UpdateUser(
                userViewModel.UserAuth.User.Email,
                userViewModel.UserAuth.User.Username,
                userViewModel.UserAuth.User.UserId,
                userViewModel.UserAuth.User.Birthday);

            return RedirectToAction("GetUsers");
        }

        [HttpPost]
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("GetUsers");
            }
            else
            {
                UserRepository.DeleteUserWithId((int)id);
                return RedirectToAction("GetUsers");
            }
        }

        private Tuple<string, string> GetHashedPasswordAndSaltFrom(string password)
        {

            SecureString secureStringPassword = new NetworkCredential("", password).SecurePassword;
            // Generate a random salt value
            byte[] salt = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Convert the SecureString password to a byte array
            byte[] passwordBytes = ConvertSecureStringToByteArray(secureStringPassword);

            // Concatenate the password and salt
            byte[] passwordWithSalt = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, passwordWithSalt, passwordBytes.Length, salt.Length);

            // Compute the hash of the password + salt
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(passwordWithSalt);

            // Convert the hash and salt to strings for storage
            string hashString = Convert.ToBase64String(hash);
            string saltString = Convert.ToBase64String(salt);

            return Tuple.Create(hashString, saltString);
        }

        private byte[] ConvertSecureStringToByteArray(SecureString secureString)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                // Decrypt the SecureString into an unmanaged BSTR
                valuePtr = Marshal.SecureStringToBSTR(secureString);

                // Copy the unmanaged BSTR to a managed byte array
                int length = Marshal.ReadInt32(valuePtr, -4);
                byte[] byteArray = new byte[length];
                Marshal.Copy(valuePtr, byteArray, 0, length);

                return byteArray;
            }
            finally
            {
                // Free the unmanaged BSTR
                Marshal.ZeroFreeBSTR(valuePtr);
            }
        }

    }
}