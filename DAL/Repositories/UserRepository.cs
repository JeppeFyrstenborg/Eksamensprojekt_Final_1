using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public int GetUserIdFromEmail(string email)
        {
            int userId = 0;
            using (DatabaseContext db = new DatabaseContext())
            {
                if(db.Users.Where(x => x.Email == email).FirstOrDefault() != null)
                    userId = db.Users.Where(x => x.Email == email).FirstOrDefault().UserId;
            }
            return userId;
        }

        public User GetUserFromEmail(string email)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Users.Where(x => x.Email == email).FirstOrDefault();
            }
        }

        public List<User> GetAllUsers() 
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Users.ToList();
            }
        }

        public void UpdateUser(string email, string username, int userID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User userToUpdate = db.Users.FirstOrDefault(u => u.UserId == userID);
                userToUpdate.Email = email;
                userToUpdate.Username = username;
                db.SaveChanges();
            }
        }

        public int CreateNewUser(string username, string email)
        {
            User tempUser = new User()
            {
                Username = username,
                Email = email
            };

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Users.Add(tempUser);
                db.SaveChanges();

                return db.Users.FirstOrDefault(u => u.Username == username && u.Email == email).UserId;
            }
        }
    }
}
