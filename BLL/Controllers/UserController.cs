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

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserFromEmail(string email)
        {
            return _userRepository.GetUserFromEmail(email);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

    }
}
