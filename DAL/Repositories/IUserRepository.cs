﻿using DTO.Models;
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

        List<User> GetAllUsers();

        void UpdateUser(string email, string username, int userID);

        int CreateNewUser(string username, string email);
    }
}
