using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        int GetUserIdFromEmail(string email);

        User GetUserFromEmail(string email);

        User GetUserFromUserId(int userId);

        List<User> GetAllUsers();

        void UpdateUser(string email, string username, int userID, DateTime birthday);

        int CreateNewUser(string username, string email, DateTime birthday);

        void DeleteUserWithId(int userId);
    }
}
