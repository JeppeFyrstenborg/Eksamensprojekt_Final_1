using BLL.Services;
using DAL;
using DTO.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Initializers
{
    public class UserAuthInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {

        protected override void Seed(DatabaseContext context)
        {
            //if (context.Users.FirstOrDefault() == null)
            //{
            //    var userInitializer = new UserInitializer();
            //    userInitializer.SeedUsers(context);
            //}

            Security _security = new Security();

            UserAuth UserAuth1 = new UserAuth
            {
                User = context.Users.FirstOrDefault()
            };
            Tuple<string, string> UserAuth1PassAndSalt = _security.GetHashedPasswordAndSaltFrom("123456");
            UserAuth1.HashedPassword = UserAuth1PassAndSalt.Item1;
            UserAuth1.Salt = UserAuth1PassAndSalt.Item2;


            UserAuth UserAuth2 = new UserAuth
            {
                User = context.Users.OrderBy(x => x.UserId).Skip(1).FirstOrDefault()
            };
            Tuple<string, string> UserAuth2PassAndSalt = _security.GetHashedPasswordAndSaltFrom("123456");
            UserAuth2.HashedPassword = UserAuth2PassAndSalt.Item1;
            UserAuth2.Salt = UserAuth2PassAndSalt.Item2;

            context.UsersAuth.Add(UserAuth1);
            context.UsersAuth.Add(UserAuth2);

            context.SaveChanges();
        }
        public void SeedUserAuths(DatabaseContext context)
        {
            Seed(context);
        }

    }
}
