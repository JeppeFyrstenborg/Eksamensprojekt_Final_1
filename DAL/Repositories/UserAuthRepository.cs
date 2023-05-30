using DTO.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class UserAuthRepository : IUserAuthRepository
    {
        public void CreateNewUserAuthForUserId(int userId, string hashedPassword, string salt)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = db.Users.FirstOrDefault(u => u.UserId == userId);
                UserAuth userAuth = new UserAuth()
                {
                    HashedPassword = hashedPassword,
                    Salt = salt,
                    User = user
                };

                db.UsersAuth.Add(userAuth);
                db.SaveChanges();
            }
        }

        public string GetHashedPasswordFromUserId(int userId)
        {
            string hashedPassword = "";
            using (DatabaseContext db = new DatabaseContext())
            {
                if (db.UsersAuth.Where(x => x.User.UserId == userId).FirstOrDefault() != null)
                    hashedPassword = db.UsersAuth.Where(x => x.User.UserId == userId).FirstOrDefault().HashedPassword;
            }
            return hashedPassword;
        }

        public string GetSaltFromUserId(int userId)
        {
            string salt = "";
            using (DatabaseContext db = new DatabaseContext())
            {
                if (db.UsersAuth.Where(x => x.User.UserId == userId).FirstOrDefault() != null)
                    salt = db.UsersAuth.Where(x => x.User.UserId == userId).FirstOrDefault().Salt;
            }
            return salt;
        }

        public void SetHashedPasswordForUserId(int userId)
        {

            throw new NotImplementedException();
        }

        public void SetSaltForUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public UserAuth GetUserAuthFromUserId(int userId)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.UsersAuth.Where(u => u.User.UserId == userId).Include(u => u.User).Include(u => u.User.Chats).FirstOrDefault();
            }
        }
    }
}
