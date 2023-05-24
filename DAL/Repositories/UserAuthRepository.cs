using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserAuthRepository : IUserAuthRepository
    {
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
                if(db.UsersAuth.Where(x => x.User.UserId == userId).FirstOrDefault() != null)
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
    }
}
