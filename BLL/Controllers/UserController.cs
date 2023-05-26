using BLL.Services;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public class UserController
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserAuthRepository _userAuthRepository;

        public UserController(IUserRepository userRepository, IUserAuthRepository userAuthRepository)
        {
            _userRepository = userRepository;

            _userAuthRepository = userAuthRepository;
        }

        public User GetUserFromEmail(string email)
        {
            return _userRepository.GetUserFromEmail(email);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void UpdateUserWithDetails(string email, string username, int userID)
        {
            _userRepository.UpdateUser(email, username, userID);
        }

        public void CreateNewUser(string username, string email, string hashedPassword, string salt)
        {
            int createdUserId = _userRepository.CreateNewUser(username,email);

            _userAuthRepository.CreateNewUserAuthForUserId(createdUserId,hashedPassword,salt);
        }
    }
}
